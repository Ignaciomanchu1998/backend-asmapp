using BackEnd.Dao;
using BackEnd.Models;
using BackEnd.Settings.Globals;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EquipoController : ControllerBase
    {
        private EquipoDao _ed = new();
        private StructureResponse _struct = new();

        [HttpGet]
        public async Task<IActionResult> EquipoGetAll()
        {
            _struct = await _ed.ProductoGetAll();
            return Ok(_struct);
        }

        [HttpPost]
        public async Task<IActionResult> EquipoPost([FromBody] EquipoModel data)
        {
            _struct = await _ed.EquipoPost(data);
            return Ok(_struct);
        }

        [HttpPut]
        public async Task<IActionResult> EquipoUpdate([FromBody] EquipoModel data)
        {
            _struct = await _ed.EquipoUpdate(data);
            return Ok(_struct);
        }

        [HttpDelete]
        public async Task<IActionResult> EquipoDelete(int idEquipo)
        {
            _struct = await _ed.EquipoDelete(idEquipo);
            return Ok(_struct);
        }
    }
}
