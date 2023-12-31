﻿using Microsoft.AspNetCore.Mvc;
using webapi.event_.Domains;
using webapi.event_.Interfaces;
using webapi.event_.Repositories;

private IPresencasEventoRepository _presencasEventoRepository { get; set; }

public PresencasEventoController()
{
    _presencasEventoRepository = new PresencaRepository();
}

[HttpGet]
public IActionResult Get()
{
    try
    {
        return Ok(_presencasEventoRepository.Listar());
    }
    catch (Exception e)
    {

        return BadRequest(e.Message);
    }
}

[HttpPost]
public IActionResult Post(PresencasEvento presencasEvento)
{
    try
    {
        _presencasEventoRepository.Inscrever(presencasEvento);

        return StatusCode(201);

    }
    catch (Exception e)
    {

        return BadRequest(e.Message);
    }
}


[HttpGet("ListarMinhas/{id}")]
public IActionResult GetMyList(Guid id)
{
    try
    {
        return Ok(_presencasEventoRepository.ListarMinhas(id));
    }
    catch (Exception e)
    {
        return BadRequest(e.Message);
    }
}
