using OnSales.Share.Model.Model;

namespace OnSales.Share.Testes.TesteUnit;

public class VendaUnitTest
{
    private readonly Guid _id = Guid.NewGuid();
    private readonly Guid _userId = Guid.NewGuid();
    private readonly Guid _clienteId = Guid.NewGuid();

    [Fact]
    public void DeveCriarVendaComTotalInicialZero()
    {
        var venda = new Vendas(_id, _userId, _clienteId);

        Assert.Equal(_clienteId, venda.ClienteId);
        Assert.Equal(0m, venda.Total);
    }

    [Fact]
    public void DeveInicializarListaDeItens()
    {
        var venda = new Vendas(_id, _userId, _clienteId);

        Assert.NotNull(venda.VendaEmItens);
        Assert.Empty(venda.VendaEmItens);
    }

    [Fact]
    public void DeveAtualizarClienteDaVenda()
    {
        var venda = new Vendas(_id, _userId, _clienteId);
        var novoClienteId = Guid.NewGuid();

        venda.AtualizacaoVenda(_userId, novoClienteId);

        Assert.Equal(novoClienteId, venda.ClienteId);
    }

    [Fact]
    public void DeveAtualizarTotalDaVenda()
    {
        var venda = new Vendas(_id, _userId, _clienteId);

        venda.AtualizaVendaTotal(_userId, 2500m);

        Assert.Equal(2500m, venda.Total);
    }
}