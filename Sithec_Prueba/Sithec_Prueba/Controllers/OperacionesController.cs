using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sithec_Prueba.Bussines;
using Sithec_Prueba.Bussines.Interfaces;
using Sithec_Prueba.Entities;
using Sithec_Prueba.Entities.enums;
using Sithec_Prueba.Utils;

namespace Sithec_Prueba.Controllers
{
    [Route("api/Operaciones")]
    [ApiController]
    public class OperacionesController : ControllerBase
    {
        private readonly IBusOperaciones busOperaciones;
        public OperacionesController(IBusOperaciones busOperaciones)
        {
            this.busOperaciones = busOperaciones;
        }
        [HttpPost]
        public async Task<ActionResult<SithecResponse<double>>> RealizarOperacion(EntOperacion entOperacion)
        {
            SithecResponse<double> response = await busOperaciones.BRealizarOperacion(entOperacion);
            return StatusCode((int)response.HttpCode, response);
        }
        [HttpGet("realizarOperacionConHeaders")]
        public async Task<ActionResult<SithecResponse<double>>> RealizarOperacionConHeaders([FromHeader] double Numero1, [FromHeader] double Numero2, [FromHeader] OperacionEnum operacionEnum)
        {
            EntOperacion entOperacion = new EntOperacion();
            entOperacion.Numero1 = Numero1;
            entOperacion.Numero2 = Numero2;
            entOperacion.Operacion = operacionEnum;
            SithecResponse<double> response = await busOperaciones.BRealizarOperacion(entOperacion);
            return StatusCode((int)response.HttpCode, response);
        }
    }
}
