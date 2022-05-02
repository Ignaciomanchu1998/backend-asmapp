using BackEnd.Dao;
using BackEnd.Models;
using BackEnd.Settings.Globals;
using Microsoft.AspNetCore.Mvc;

namespace BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private StructureResponse _struct = new();
        private UsuarioDao _cant = new();

        [HttpGet]
        [Route("UsuarioGetAll")]
        public async Task<IActionResult> UsuarioGetAll()
        {
            _struct = await _cant.UsuarioGetAll();
            return Ok(_struct);
        }

        [HttpGet]
        [Route("UsuarioGetById")]
        public async Task<IActionResult> UsuarioGetById(int idUsuario)
        {
            _struct = await _cant.UsuarioGetById(idUsuario);
            return Ok(_struct);
        }
       

        [HttpPost]
        public async Task<IActionResult> UsuarioPost([FromBody] UsuarioModel data)
        {
            _struct = await _cant.UsuarioPost(data);
            return Ok(_struct);
        }

        [HttpPut]
        public async Task<IActionResult> UsuarioPut([FromBody] UsuarioModel data)
        {
            _struct = await _cant.UsuarioPut(data);
            return Ok(_struct);
        }

        [HttpDelete]
        public async Task<IActionResult> UsuarioDelete(int idUsuario)
        {
            _struct = await _cant.UsuarioDelete(idUsuario);
            return Ok(_struct);
        }
    }
}
