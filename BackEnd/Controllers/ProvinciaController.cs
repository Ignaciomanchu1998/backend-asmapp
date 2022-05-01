using BackEnd.Dao;
using BackEnd.Models;
using BackEnd.Settings.Globals;
using Microsoft.AspNetCore.Mvc;

namespace BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProvinciaController : ControllerBase
    {
        private StructureResponse _struct = new();
        private ProvinciaDao _cant = new();

        [HttpGet]
        public async Task<IActionResult> ProvinciaGetById(int idPais)
        {
            _struct = await _cant.ProvinciaGetById(idPais);
            return Ok(_struct);
        }

        [HttpPost]
        public async Task<IActionResult> ProvinciaPost([FromBody] ProvinciaModel data)
        {
            _struct = await _cant.ProvinciaPost(data);
            return Ok(_struct);
        }

        [HttpPut]
        public async Task<IActionResult> ProvinciaPut([FromBody] ProvinciaModel data)
        {
            _struct = await _cant.ProvinciaPut(data);
            return Ok(_struct);
        }

        [HttpDelete]
        public async Task<IActionResult> ProvinciaDelete(int idProvincia)
        {
            _struct = await _cant.ProvinciaDelete(idProvincia);
            return Ok(_struct);
        }
    }
}
