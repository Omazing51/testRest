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
    public class PolizasController : ControllerBase
    {
        public PolizaService _polizaService;

        public PolizasController(PolizaService polizaService)
        {
            _polizaService = polizaService;
        }

        [HttpGet]
        public ActionResult<List<Poliza>> Get()
        {
            return _polizaService.Get();
        }

        [HttpPost]
        public ActionResult<Poliza> Create(Poliza poliza) 
        {
            _polizaService.Create(poliza);
            return Ok(poliza);
        }
    }
}
