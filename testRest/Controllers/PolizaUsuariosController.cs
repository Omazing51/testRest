using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using testRest.Models;
using testRest.Services;

namespace testRest.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class PolizaUsuariosController : ControllerBase
    {
        public PolizaUsuarioService _polizaUsuarioService;

        public PolizaUsuariosController(PolizaUsuarioService polizaUsuarioService)
        {
            _polizaUsuarioService = polizaUsuarioService;
        }

        [HttpGet]
        public ActionResult<List<PolizaUsuario>> Get()
        {
            return _polizaUsuarioService.Get();
        }

        [HttpGet("GetByPolizaOPlaca")]
        public IActionResult ConsultarPorNumeroPolizaOPlaca([FromQuery] string? polizas , [FromQuery] string? placa_automotor)
        {
            List<PolizaUsuario> resultados;

            if (!string.IsNullOrEmpty(polizas) && !string.IsNullOrEmpty(placa_automotor))
            {
                resultados = _polizaUsuarioService.GetByPolizaOrPlaca(polizas, placa_automotor);
            }
            else if (!string.IsNullOrEmpty(polizas))
            {
                resultados = _polizaUsuarioService.GetByPolizaOrPlaca(polizas, "");
            }
            else if (!string.IsNullOrEmpty(placa_automotor))
            {
                resultados = _polizaUsuarioService.GetByPolizaOrPlaca("", placa_automotor);
            }
            else
            {
                return BadRequest("Debes proporcionar al menos uno de los campos para la consulta.");
            }

            return Ok(resultados);
        }

        [HttpPost]
        public ActionResult<PolizaUsuario> Create(PolizaUsuario polizaU)
        {
            
            _polizaUsuarioService.Create(polizaU);
            return Ok(polizaU);
        }
    }
}
