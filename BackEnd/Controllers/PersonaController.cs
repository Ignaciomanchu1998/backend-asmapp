using BackEnd.Dao;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonaController : ControllerBase
    {
        private readonly PersonaDao _p = new();
        [HttpGet(Name = "GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var res = await _p.GetAll();
            return Ok(res);
        }

        [HttpGet(Name = "Post")]
        public async Task<IActionResult> Post(string json)
        {
            var res = await _p.Post(json);
            return Ok(res);
        }

        [HttpGet(Name ="Put")]
        public async Task<IActionResult> Put(string json)
        {
            var res = await _p.Put(json);
            return Ok(res);
        }

        [HttpGet(Name ="Delete")]
        public async Task<IActionResult> Delete(int idPersona)
        {
            var res = await _p.Delete(idPersona);
            return Ok(res);
        }
    }
}
