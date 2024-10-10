using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MaterIOTAPI.Collections;
using MaterIOTAPI.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace MaterIOTAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ClientsController : ControllerBase
{
    private readonly IClientRepository _repo;

    public ClientsController(IClientRepository repository)
    {
        _repo = repository;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var clientes = await _repo.GetAllAsync();
        return Ok(clientes);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(string id)
    {
        var cliente = await _repo.GetByIdAsync(id);
        if (cliente == null)
            return NotFound("Cliente não encontrado");
        return Ok(cliente);
    }

    [HttpPost]
    public async Task<IActionResult> Create(Client cliente)
    {
        await _repo.CreateAsync(cliente);
        return CreatedAtAction(nameof(Get), new { id = cliente.Id }, cliente);
    }

    [HttpPut]
    public async Task<IActionResult> Edit(Client cliente)
    {
        var cli = await _repo.GetByIdAsync(cliente.Id);
        if (cli == null)
            return NotFound("Cliente não encontrado");

        await _repo.UpdateAsync(cliente);
        return NoContent();
    }

    [HttpDelete]
    public async Task<IActionResult> Delete(string id)
    {
        var cli = await _repo.GetByIdAsync(id);
        if (cli == null)
            return NotFound("Cliente não encontrado");
        await _repo.DeleteAsync(id);
        return NoContent();
    }
}
