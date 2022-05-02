using BackEnd.Dao;
using BackEnd.Models;
using BackEnd.Settings.Globals;
using Microsoft.AspNetCore.Mvc;

namespace BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriaController : ControllerBase
    {
        private CategoriaDao _ed = new();
        private StructureResponse _struct = new();

        [HttpGet]
        public async Task<IActionResult> CategoriaGetAll()
        {
            _struct = await _ed.CategoriaGetAll();
            return Ok(_struct);
        }

        [HttpPost]
        public async Task<IActionResult> CategoriaPost([FromBody] CategoriaModel data)
        {
            _struct = await _ed.CategoriaPost(data);
            return Ok(_struct);
        }

        [HttpPut]
        public async Task<IActionResult> CategoriaPut([FromBody] CategoriaModel data)
        {
            _struct = await _ed.CategoriaPut(data);
            return Ok(_struct);
        }

        [HttpDelete]
        public async Task<IActionResult> CategoriaDelete(int idCategoria)
        {
            _struct = await _ed.CategoriaDelete(idCategoria);
            return Ok(_struct);
        }
    }
}
