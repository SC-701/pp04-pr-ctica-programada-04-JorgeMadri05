using Abstracciones.Interfaces.API;
using Abstracciones.Interfaces.Flujo;
using Abstracciones.Modelos;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ModeloController : ControllerBase
    {
        private IVehiculoFlujo _vehiculoFlujo;
        private ILogger<ModeloController> _logger;

        public ModeloController(IVehiculoFlujo vehiculoFlujo, ILogger<ModeloController> logger)
        {
            _vehiculoFlujo = vehiculoFlujo;
            _logger = logger;
        }

        [HttpGet("{IdMarca}")]
        public async Task<IActionResult> ObtenerModelos([FromRoute] Guid IdMarca)
        {
            var resultado = await _vehiculoFlujo.ObtenerModelos(IdMarca);
            return Ok(resultado);
        }
        
    }
}
