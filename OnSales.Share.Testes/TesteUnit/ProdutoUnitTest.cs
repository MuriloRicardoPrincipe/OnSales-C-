using OnSales.Share.Model.Model;

namespace OnSales.Share.Testes.TesteUnit;

public class ProdutoUnitTest
{
    private readonly Guid _id = Guid.NewGuid();
    private readonly Guid _userId = Guid.NewGuid();

    [Fact]
    public void DeveCriarProdutoComPrecoValido()
    {
        var produto = new Produtos(
            _id,
            _userId,
            "Produto",
            "Descricao",
            150m,
            100m
        );

        Assert.Equal(150m, produto.PrecoVenda);
        Assert.Equal(100m, produto.PrecoCusto);
    }

    [Fact]
    public void DeveLancarExcecaoQuandoPrecoVendaMenorQueCusto()
    {
        Assert.Throws<ArgumentException>(() =>
            new Produtos(_id, _userId, "Produto", "Desc", 90m, 100m));
    }

    [Fact]
    public void DeveLancarExcecaoQuandoPrecoVendaMenorIgualZero()
    {
        Assert.Throws<ArgumentException>(() =>
            new Produtos(_id, _userId, "Produto", "Desc", 0m, 100m));
    }

    [Fact]
    public void DeveLancarExcecaoQuandoPrecoCustoMenorIgualZero()
    {
        Assert.Throws<ArgumentException>(() =>
            new Produtos(_id, _userId, "Produto", "Desc", 100m, 0m));
    }

    [Fact]
    public void DeveAtualizarProdutoComPrecoValido()
    {
        var produto = new Produtos(_id, _userId, "Prod", "Desc", 100m, 80m);

        produto.AtualizacaoProduto(_userId, "Novo", "Nova Desc", 200m, 150m);

        Assert.Equal("Novo", produto.Nome);
        Assert.Equal(200m, produto.PrecoVenda);
        Assert.Equal(150m, produto.PrecoCusto);
    }
}
