using OnSales.Share.Model.Model;

namespace OnSales.Share.Testes.TesteUnit;

public class VendaItensUnitTests
{
    private readonly Guid _id = Guid.NewGuid();
    private readonly Guid _userId = Guid.NewGuid();
    private readonly Guid _vendaId = Guid.NewGuid();
    private readonly Guid _produtoId = Guid.NewGuid();

    [Fact]
    public void DeveCriarVendaItemComDadosInformados()
    {
        var item = new VendaItens(
            _id,
            _userId,
            _vendaId,
            _produtoId,
            2,
            500m
        );

        Assert.Equal(_vendaId, item.VendaId);
        Assert.Equal(_produtoId, item.ProdutoId);
        Assert.Equal(2, item.Quantidade);
        Assert.Equal(500m, item.Total);
    }

    [Fact]
    public void DeveAtualizarVendaItem()
    {
        var item = new VendaItens(
            _id,
            _userId,
            _vendaId,
            _produtoId,
            2,
            500m
        );

        var novaVendaId = Guid.NewGuid();
        var novoProdutoId = Guid.NewGuid();

        item.AtualizarVendaItem(
            _userId,
            novaVendaId,
            novoProdutoId,
            5,
            1500m
        );

        Assert.Equal(novaVendaId, item.VendaId);
        Assert.Equal(novoProdutoId, item.ProdutoId);
        Assert.Equal(5, item.Quantidade);
        Assert.Equal(1500m, item.Total);
    }
}