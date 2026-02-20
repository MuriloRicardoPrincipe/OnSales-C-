using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnSales.DTO.Cliente;
using OnSales.Interface;
using OnSales.Repository;

namespace OnSales.Controllers;
[Authorize]
[ApiController]
[Route("[controller]")]
public class ClienteController : Controller
{
    private IClienteRepository _repository;
    private readonly IUserContext _userContext;

    public ClienteController (IClienteRepository repository, IUserContext userContext)
    {
        _repository = repository;
        _userContext = userContext;
    }

    [HttpPost]
    public async Task<IActionResult> AddCliente([FromBody] CriaAtualizaClienteDto Dto)
    {

        await _repository.Criar(_userContext.UserId, Dto);

        return Ok();
    }

    [HttpGet]
    public IEnumerable<ReadClienteDto> GetClients()
    {
        var clientes = _repository.GetAll();

        return clientes;

    }


    [HttpGet("{id}")]
    public IActionResult GetClienteById(Guid id)
    {
        var prod = _repository.GetById(id);

        if (prod != null)
        {
            return Ok(prod);
        }
        return NotFound();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var deleted = await _repository.Delete(id);

        if (!deleted)
            return NotFound();

        return NoContent();
    }


    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateCliente(Guid id, [FromBody] CriaAtualizaClienteDto dto)
    {
        try
        {
            await _repository.Update(id, _userContext.UserId, dto);
            return Ok(new { message = "Atualizado com sucesso." });
        }
        catch (KeyNotFoundException ex)
        {
            return NotFound(new { message = ex.Message });
        }
    }
}
