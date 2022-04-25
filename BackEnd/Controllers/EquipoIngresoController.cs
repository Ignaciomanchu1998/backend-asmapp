using BackEnd.Dao;
using BackEnd.Models;
using BackEnd.Settings.Globals;
using Microsoft.AspNetCore.Mvc;

namespace BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EquipoIngresoController : ControllerBase
    {
        private StructureResponse _struct = new();
        private EquipoIngresoDao _equi = new();

        [HttpGet(Name = "EquipoIngresoGetAll")]
        public async Task<IActionResult> EquipoIngresoGetAll()
        {
            _struct = await _equi.EquipoIngresoGetAll();
            return Ok(_struct);
        }

        [HttpPost(Name = "EquipoIngresoPost")]
        public async Task<IActionResult> EquipoIngresoPost([FromBody] EquipoIngresoModel data)
        {
            _struct = await _equi.EquipoIngresoPost(data);
            return Ok(_struct);
        }

        [HttpPut(Name = "EquipoIngresoUpdate")]
        public async Task<IActionResult> EquipoIngresoUpdate([FromBody] EquipoIngresoModel data)
        {
            _struct = await _equi.EquipoIngresoUpdate(data);
            return Ok(_struct);
        }

        [HttpDelete(Name = "EquipoIngresoDelete")]
        public async Task<IActionResult> EquipoIngresoDelete(int idEquipoIngreso)
        {
            _struct = await _equi.EquipoIngresoDelete(idEquipoIngreso);
            return Ok(_struct);
        }
    }
}