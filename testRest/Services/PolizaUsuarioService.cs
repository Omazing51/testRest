using MongoDB.Driver;
using testRest.Helpers;
using testRest.Models;

namespace testRest.Services
{
    public class PolizaUsuarioService
    {
        private IMongoCollection<PolizaUsuario> _polizaU;
        private IMongoCollection<Poliza> _poliza;
        private IMongoCollection<PolizaUsuarioModel> _polizaU2;
        public PolizaUsuarioService(IPolizaSettings settings)
        {
            var cliente = new MongoClient(settings.Server);
            var database = cliente.GetDatabase(settings.Database);
            _polizaU = database.GetCollection<PolizaUsuario>("poliza_usuarios");
            _poliza = database.GetCollection<Poliza>("poliza");
            _polizaU2 = database.GetCollection<PolizaUsuarioModel>("poliza_usuarios");
        }

        public List<PolizaUsuario> Get()
        {
            return _polizaU.Find(x => true).ToList();
        }

        public List<PolizaUsuario> GetByPolizaOrPlaca(string numeroPoliza, string placa)
        {
            var filterBuilder = Builders<PolizaUsuario>.Filter;
            FilterDefinition<PolizaUsuario> filter = filterBuilder.Empty; // Inicializa con un filtro vacío

            if (!string.IsNullOrEmpty(numeroPoliza))
            {
                filter = filterBuilder.Eq("NumeroPoliza", numeroPoliza);
            }

            if (!string.IsNullOrEmpty(placa))
            {
                // Combina el filtro anterior con la condición de placa
                filter = filter & filterBuilder.Eq("PlacaAutomotor", placa);
            }

            return _polizaU.Find(filter).ToList();
        }

        public PolizaUsuario Create(PolizaUsuario polizaU)
        {
            if (!ExisteNumeroPoliza(polizaU.poliza))
            {
                throw new Exception("El número de póliza no existe.");
            }
            if (!ClienteEdadSuficiente(polizaU.FechaNacimientoCliente))
            {
                throw new Exception("El usuario debe ser mayor de 15 años.");
            }
            if (PolizaVencida(polizaU.poliza))
            {
                throw new Exception("La poliza solicitada ya no se encuentra vigente.");
            }
            _polizaU.InsertOne(polizaU);

            return polizaU;
        }

        private bool ClienteEdadSuficiente(DateTime fechaNacimientoCliente)
        {
            DateTime fechaActual = DateTime.Now;
            int edadCliente = fechaActual.Year - fechaNacimientoCliente.Year;
            return edadCliente >= 16;
        }

        public bool ExisteNumeroPoliza(string numeroPoliza)
        {
            var poliza = _poliza.Find(p => p.numeroPoliza == numeroPoliza).FirstOrDefault();
            return poliza != null;
        }

        public bool PolizaVencida(string numeroPoliza)
        {
            var poliza = _poliza.Find(p => p.numeroPoliza == numeroPoliza).FirstOrDefault();

            if (poliza == null)
            {
                throw new Exception("El número de póliza no existe.");
            }

            return poliza.fechaFinPoliza <= DateTime.Now;
        }
    }
}
