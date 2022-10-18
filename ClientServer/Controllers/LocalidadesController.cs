using ClientServer.DTOs;
using ClientServer.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ClientServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocalidadesController : ControllerBase
    {
        public readonly ILocalicadesService _localicadesService;

        public LocalidadesController(ILocalicadesService localicadesService)
        {
            _localicadesService = localicadesService;
        }

        [HttpGet("estados")]
        public async Task<ActionResult<IEnumerable<EstadoDTO>>> EstadosByName()
        {
            var result = await _localicadesService.GetEstados();
            return Ok(result);
        }
        [HttpGet("{uf}",Name ="Municipios")]
        public async Task<ActionResult<MunicipiosDTO>> MunicipiosByUf(string uf) 
        {

            return Ok();
        }
    }
}
