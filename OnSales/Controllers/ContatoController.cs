using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnSales.DTO.Contato;
using OnSales.Interface;
using OnSales.Repository;

namespace OnSales.Controllers;

[Authorize]
[ApiController]
[Route("[controller]")]
public class ContatoController : Controller
{
    private IContatoRepository _repository;
    private readonly IUserContext _userContext;

    public ContatoController(IContatoRepository repository, IUserContext userContext)
    {
        _repository = repository;
        _userContext = userContext;
    }

    [HttpPost]
    public async Task<IActionResult> AddContato([FromBody] CriaAtualizaContatoDto Dto)
    {

        await _repository.Criar(_userContext.UserId, Dto);

        return Ok();
    }

    [HttpGet]
    public IEnumerable<ReadContatoDto> GetClients()
    {
        var contatos = _repository.GetAll();

        return contatos;

    }


    [HttpGet("{id}")]
    public IActionResult GetContatoById(Guid id)
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
    public async Task<IActionResult> UpdateContato(Guid id, [FromBody] CriaAtualizaContatoDto dto)
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
