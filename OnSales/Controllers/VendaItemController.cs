using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnSales.DTO.VendaItem;
using OnSales.Interface;
using OnSales.Repository;

namespace OnSales.Controllers;

[Authorize]
[ApiController]
[Route("[controller]")]
public class VendaItemController : Controller
{
    private readonly IVendaItemRepository _repository;
    private readonly IUserContext _userContext;

    public VendaItemController(IVendaItemRepository repository, IUserContext userContext)
    {
        _repository = repository;
        _userContext = userContext;
    }

    [HttpPost]
    public async Task<IActionResult> AddVendaItem([FromBody] CriaAtualizaVendaItemDto Dto)
    {

        await _repository.Criar(_userContext.UserId, Dto);

        return Ok();
    }

    [HttpGet]
    public IEnumerable<ReadVendaItemDto> GetClients()
    {
        var prod = _repository.GetAll();

        return prod;

    }


    [HttpGet("{id}")]
    public IActionResult GetVendaItemById(Guid id)
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
    public async Task<IActionResult> UpdateVendaItem(Guid id, [FromBody] CriaAtualizaVendaItemDto dto)
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
