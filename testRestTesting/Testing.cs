using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Moq;
using testRest.Controllers;
using testRest.Helpers;
using testRest.Models;
using testRest.Services;

namespace testRestTesting
{
    public class Testing
    {

        private readonly PolizaUsuariosController _polizaU;
        private readonly PolizaUsuarioService _polizaUsuarioService;
        public Testing()
        {
            var polizaSettings = new PolizaSettings
            {
                Server = "mongodb+srv://omarlozano1215:12345@cluster0.dkirgyy.mongodb.net/?retryWrites=true&w=majority", // Configura el servidor de MongoDB
                Database = "testmongodb"   
            };

            var options = Options.Create(polizaSettings);

            var mockPolizaSettings = new Mock<IPolizaSettings>();
            mockPolizaSettings.Setup(x => x.Server).Returns(polizaSettings.Server);
            mockPolizaSettings.Setup(x => x.Database).Returns(polizaSettings.Database);

            _polizaUsuarioService = new PolizaUsuarioService(mockPolizaSettings.Object);
            _polizaU = new PolizaUsuariosController(_polizaUsuarioService);

        }

        [Fact]
        public void Get_Ok()
        {
            var result = _polizaU.Get();

            Assert.NotNull(result); 
            Assert.IsType<ActionResult<List<PolizaUsuario>>>(result);

            if (result.Result is OkObjectResult okResult)
            {
                Assert.IsType<List<PolizaUsuario>>(okResult.Value); 
                Assert.Equal(200, okResult.StatusCode); 
            }
        }

        [Fact]
        public void Get_Quantity()
        {
            var result = _polizaU.Get();

            Assert.NotNull(result);
            var polizaU = Assert.IsType<List<PolizaUsuario>>(result.Value);
            Assert.True(polizaU.Count > 0);
        }

        [Fact]
        public void Post_PolizaUsuario_Success()
        {
            var polizaUsuario = new PolizaUsuario
            {
                Id="",
                NombreCliente = "Cliente2",
                IdentificacionCliente = "67890",
                FechaNacimientoCliente = new DateTime(1985, 3, 15),
                CiudadResidenciaCliente = "Ciudad2",
                DireccionResidenciaCliente = "Dirección2",
                PlacaAutomotor = "ABC456",
                ModeloAutomotor = "Modelo2",
                VehiculoTieneInspeccion = false,
                poliza = "001"
            };

            var result = _polizaU.Create(polizaUsuario);

            Assert.NotNull(result);
            Assert.IsType<ActionResult<PolizaUsuario>>(result);
        }
    }

    }
