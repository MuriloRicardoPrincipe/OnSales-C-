using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnSales.DTO.Estoque;
using OnSales.Interface;
using OnSales.Repository;

namespace OnSales.Controllers;
[Authorize]
[ApiController]
[Route("[controller]")]
public class EstoqueController : Controller
{
    private IEstoqueRepository _repository;
    private readonly IUserContext _userContext;

    public EstoqueController(IEstoqueRepository repository, IUserContext userContext)
    {
        _repository = repository;
        _userContext = userContext;
    }

    [HttpPost]
    public async Task<IActionResult> AddEstoque([FromBody] CriaAtualizaEstoqueDto Dto)
    {

        await _repository.Criar(_userContext.UserId, Dto);

        return Ok();
    }

    [HttpGet]
    public IEnumerable<ReadEstoqueDto> GetClients()
    {
        var prod = _repository.GetAll();

        return prod;

    }


    [HttpGet("{id}")]
    public IActionResult GetEstoqueById(Guid id)
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
    public async Task<IActionResult> UpdateEstoque(Guid id, [FromBody] CriaAtualizaEstoqueDto dto)
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
