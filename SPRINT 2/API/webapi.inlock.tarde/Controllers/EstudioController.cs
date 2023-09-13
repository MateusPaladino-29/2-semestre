﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using webapi.inlock.tarde.Interfaces;
using webapi.inlock.tarde.Repositories;

namespace webapi.inlock.tarde.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class EstudioController : ControllerBase
    {
        private IEstudioRepository _estudioRepository;

        public EstudioController()
        {
            _estudioRepository = new EstudioRepository();
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
               
                return Ok(_estudioRepository.Listar());
            }
            catch (Exception erro)
            {

                return BadRequest(erro.Message);
            }    
        }
    }
}
