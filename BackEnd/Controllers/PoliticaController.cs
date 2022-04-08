﻿using BackEnd.Dao;
using BackEnd.Settings.Globals;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PoliticaController : ControllerBase
    {
        private StructureResponse _struct = new();
        private PoliticaDao _po = new();

        [HttpGet]       
        [ResponseCache(Duration = 60)]
        public async Task<IActionResult> PoliticaGetAll()
        {
            _struct = await _po.PoliticaGetAll();
            return Ok(_struct);
        }

        [HttpPost]      
        public async Task<IActionResult> PoliticaPost(string json)
        {
            _struct = await _po.PoliticaPost(json);
            return Ok(_struct);
        }

        [HttpPut]
        public async Task<IActionResult> PoliticaUpdate(string json)
        {
            _struct = await _po.PoliticaUpdate(json);
            return Ok(_struct);
        }

        [HttpDelete]
        public async Task<IActionResult> PoliticaDelete(string json)
        {
            _struct = await _po.PoliticaDelete(json);
            return Ok(_struct);
        }
    }
}
