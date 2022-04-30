using BackEnd.Dao;
using BackEnd.Models;
using BackEnd.Settings.Globals;
using Microsoft.AspNetCore.Mvc;

namespace BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EquipoIngresoComponenteController : ControllerBase
    {
        private StructureResponse _struct = new();
        private EquipoIngresoComponenteDao _ei = new();

        [HttpGet]
        public async Task<IActionResult> EquipoIngresoComponenteGetAll()
        {
            _struct = await _ei.EquipoIngresoConponenteGetAll();
            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> EquipoIngresoComponentePost([FromBody] EquipoIngresoComponenteModel data)
        {
            _struct = await _ei.EquipoIngresoConponentePost(data);
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> EquipoIngresoComponenteUpdate([FromBody] EquipoIngresoComponenteModel data)
        {
            _struct = await _ei.EquipoIngresoConponenteUpdate(data);
            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> EquipoIngresoComponenteDelete(int idEquipoIngresoComponente)
        {
            _struct = await _ei.EquipoIngresoConponenteDelete(idEquipoIngresoComponente);
            return Ok();
        }
    }
}
