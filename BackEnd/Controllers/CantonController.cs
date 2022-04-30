using BackEnd.Dao;
using BackEnd.Models;
using BackEnd.Settings.Globals;
using Microsoft.AspNetCore.Mvc;

namespace BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CantonController : ControllerBase
    {
        private StructureResponse _struct = new();
        private CantonDao _cant = new();

        [HttpGet]
        public async Task<IActionResult> CantonGetById(int idProvincia)
        {
            _struct = await _cant.CantonGetById(idProvincia);
            return Ok(_struct);
        }

        [HttpPost]
        public async Task<IActionResult> CantonPost([FromBody] CantonModel data)
        {
            _struct = await _cant.CantonPost(data);
            return Ok(_struct);
        }

        [HttpPut]
        public async Task<IActionResult> CantonPut([FromBody] CantonModel data)
        {
            _struct = await _cant.CantonPut(data);
            return Ok(_struct);
        }

        [HttpDelete]
        public async Task<IActionResult> CantonDelete(int idCanton)
        {
            _struct = await _cant.CantonDelete(idCanton);
            return Ok(_struct);
        }
    }
}
