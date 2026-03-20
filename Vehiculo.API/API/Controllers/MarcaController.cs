using Abstracciones.Interfaces.API;
using Abstracciones.Interfaces.Flujo;
using Abstracciones.Modelos;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MarcaController : ControllerBase
    {
        private IVehiculoFlujo _vehiculoFlujo;
        private ILogger<MarcaController> _logger;

        public MarcaController(IVehiculoFlujo vehiculoFlujo, ILogger<MarcaController> logger)
        {
            _vehiculoFlujo = vehiculoFlujo;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> ObtenerMarcas()
        {
            var resultado = await _vehiculoFlujo.ObtenerMarcas();
            if (!resultado.Any())
            {
                return NoContent();
            }

            return Ok(resultado);
        }
    }
}
