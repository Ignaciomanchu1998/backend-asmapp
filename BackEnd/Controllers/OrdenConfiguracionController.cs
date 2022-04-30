using BackEnd.Dao;
using BackEnd.Models;
using BackEnd.Settings.Globals;
using Microsoft.AspNetCore.Mvc;

namespace BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdenConfiguracionController : ControllerBase
    {
        private StructureResponse _struct = new();
        private OrdenConfiguracionDao _orden = new();

        [HttpGet]
        public async Task<IActionResult> OrdenConfiguracionGetAll()
        {
            _struct = await _orden.OrdenConfiguracionGetAll();
            return Ok(_struct);
        }

        [HttpPost]
        public async Task<IActionResult> OrdenConfiguracionPost([FromBody] OrdenConfiguracionModel data)
        {
            _struct = await _orden.OrdenConfiguracionPost(data);
            return Ok(_struct);
        }

        [HttpPut]
        public async Task<IActionResult> OrdenConfiguracionPut([FromBody] OrdenConfiguracionModel data)
        {
            _struct = await _orden.OrdenConfiguracionPut(data);
            return Ok(_struct);
        }

        [HttpDelete]
        public async Task<IActionResult> OrdenConfiguracionDelete(int idOrdenConfiguracion)
        {
            _struct = await _orden.OrdenConfiguracionDelete(idOrdenConfiguracion);
            return Ok(_struct);
        }
    }
}
