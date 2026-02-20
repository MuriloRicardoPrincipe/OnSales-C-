namespace OnSales.DTO.VendaItem;

public class CriaAtualizaVendaItemDto
{
    public required Guid VendaId { get; set; }
    public required virtual Guid ProdutoId { get; set; }
    public required int Quantidade { get; set; }
}
