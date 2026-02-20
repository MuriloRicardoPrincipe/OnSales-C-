using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using OnSales.DTO.Produto;
using OnSales.Interface;
using OnSales.Repository;
using OnSales.Share.Data.Data;

namespace OnSales.Controllers;

[Authorize]
[ApiController]
[Route("[controller]")]
public class ProdutoController : Controller
{
    private IProdutoRepository _repository;
    private readonly IUserContext _userContext;

    public ProdutoController(IProdutoRepository repository, IUserContext userContext)
    {
        _repository = repository;
        _userContext = userContext;
    }

    [HttpPost]
    public async Task<IActionResult> AddProduto([FromBody] CriaAtualizaProdutoDto Dto)
    {
        await _repository.Criar(_userContext.UserId, Dto);

        return Ok();
    }

    [HttpGet]
    public IEnumerable<ReadProdutoDto> GetClients()
    {
        var prod = _repository.GetAll();

        return prod;

    }


    [HttpGet("{id}")]
    public IActionResult GetProdutoById(Guid id)
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
    public async Task<IActionResult> UpdateProduto(Guid id, [FromBody] CriaAtualizaProdutoDto dto)
    {
        try
        {
            await _repository.Update(id, _userContext.UserId, dto);
            return Ok(new { message = "Atualizado com sucesso." });
        }catch (KeyNotFoundException ex)
        {
            return NotFound(new { message = ex.Message });
        }
    }
}
