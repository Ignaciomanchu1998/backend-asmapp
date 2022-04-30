using BackEnd.Dao;
using BackEnd.Models;
using BackEnd.Settings.Globals;
using Microsoft.AspNetCore.Mvc;

namespace BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ParroquiaController : ControllerBase
    {
        private StructureResponse _struct = new();
        private ParroquiaDao _parr = new();

        [HttpGet]
        public async Task<IActionResult> ParroquiaGetById(int idCanton)
        {
            _struct = await _parr.ParroquiaGetById(idCanton);
            return Ok(_struct);
        }

        [HttpPost]
        public async Task<IActionResult> ParroquiaPost([FromBody] ParroquiaModel data)
        {
            _struct = await _parr.ParroquiaPost(data);
            return Ok(_struct);
        }

        [HttpPut]
        public async Task<IActionResult> ParroquiaPut([FromBody] ParroquiaModel data)
        {
            _struct = await _parr.ParroquiaPut(data);
            return Ok(_struct);
        }

        [HttpDelete]
        public async Task<IActionResult> ParroquiaDelete(int idParroquia)
        {
            _struct = await _parr.ParroquiaDelete(idParroquia);
            return Ok(_struct);
        }
    }
}
