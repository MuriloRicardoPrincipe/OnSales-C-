using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnSales.DTO.Endereco;
using OnSales.Interface;
using OnSales.Repository;

namespace OnSales.Controllers;
[Authorize]
[ApiController]
[Route("[controller]")]
public class EnderecoController : Controller
{
    private IEnderecoRepository _repository;
    private readonly IUserContext _userContext;

    public EnderecoController(IEnderecoRepository repository)
    {
        _repository = repository;
    }

    [HttpPost]
    public async Task<IActionResult> AddEndereco([FromBody] CriaAtualizaEnderecoDto Dto)
    {

        await _repository.Criar(_userContext.UserId, Dto);

        return Ok();
    }

    [HttpGet]
    public IEnumerable<ReadEnderecoDto> GetClients()
    {
        var enderecos = _repository.GetAll();

        return enderecos;

    }


    [HttpGet("{id}")]
    public IActionResult GetEnderecoById(Guid id)
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
    public async Task<IActionResult> UpdateEndereco(Guid id, [FromBody] CriaAtualizaEnderecoDto dto)
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
