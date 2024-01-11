using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sithec_Prueba.Bussines.Interfaces;
using Sithec_Prueba.Entities;
using Sithec_Prueba.Utils;

namespace Sithec_Prueba.Controllers
{
    [Route("api/humanos")]
    [ApiController]
    public class HumanosController : ControllerBase
    {
        private readonly IBusHumano busHumano;
        public HumanosController(IBusHumano busHumano)
        {
            this.busHumano = busHumano;
        }

        [HttpPost]
        public async Task<ActionResult<SithecResponse<bool>>> SaveHumano(EntHumano entHumano)
        {
            SithecResponse<bool> response = await busHumano.BSaveHumano(entHumano);
            return StatusCode((int)response.HttpCode, response);
        }

        [HttpPut]
        public async Task<ActionResult<SithecResponse<bool>>> UpdateHumano(EntHumano entHumano)
        {
            SithecResponse<bool> response = await busHumano.BUpdateHumano(entHumano);
            return StatusCode((int)response.HttpCode, response);
        }

        [HttpDelete("puIdHumano")]
        public async Task<ActionResult<SithecResponse<bool>>> DeleteHumano(Guid puIdHumano)
        {
            SithecResponse<bool> response = await busHumano.BDeleteHumano(puIdHumano);
            return StatusCode((int)response.HttpCode, response);
        }

        [HttpGet]
        public async Task<ActionResult<SithecResponse<List<EntHumano>>>> GetAll()
        {
            SithecResponse<List<EntHumano>> response = await busHumano.bGetAll();
            return StatusCode((int)response.HttpCode, response);
        }
        [HttpGet("getHumanosListMock")]
        public async Task<ActionResult<SithecResponse<List<EntHumano>>>> GetHumanosMock()
        {
            SithecResponse<List<EntHumano>> response = await busHumano.bGetHumanosMock();
            return StatusCode((int)response.HttpCode, response);
        }
        [HttpGet("getHumanoById/{id}")]
        public async Task<ActionResult<SithecResponse<List<EntHumano>>>> GetHumanoById(Guid id)
        {
            SithecResponse<EntHumano> response = await busHumano.bGetHumanoById(id);
            return StatusCode((int)response.HttpCode, response);
        }
    }
}

