using BackEnd.Dao;
using BackEnd.Models;
using BackEnd.Settings.Globals;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaisController : ControllerBase
    {
        private StructureResponse _struct = new();
        private PaisDao _cant = new();

        [HttpGet]
        public async Task<IActionResult> PaisGetAll()
        {
            _struct = await _cant.PaisGetAll();
            return Ok(_struct);
        }

        [HttpPost]
        public async Task<IActionResult> PaisPost([FromBody] PaisModel data)
        {
            _struct = await _cant.PaisPost(data);
            return Ok(_struct);
        }

        [HttpPut]
        public async Task<IActionResult> PaisPut([FromBody] PaisModel data)
        {
            _struct = await _cant.PaisPut(data);
            return Ok(_struct);
        }

        [HttpDelete]
        public async Task<IActionResult> PaisDelete(int idPais)
        {
            _struct = await _cant.PaisDelete(idPais);
            return Ok(_struct);
        }
    }
}
