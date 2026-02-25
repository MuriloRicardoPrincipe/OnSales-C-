using OnSales.Share.Model.Model;
using FluentAssertions;

namespace OnSales.Share.Testes.TesteUnit;

public class EstoqueUnitTest
{
    private readonly Guid _id = Guid.NewGuid();
    private readonly Guid _userId = Guid.NewGuid();
    private readonly Guid _produtoId = Guid.NewGuid();

    #region Construtor

    [Fact]
    public void DeveCriarEstoqueComQuantidadeInformada()
    {
        var estoque = new Estoques(_id, _userId, _produtoId, 10);

        estoque.ProdutoId.Should().Be(_produtoId);
        estoque.Quantidade.Should().Be(10);
    }

    #endregion

    #region AtualizacaoEstoque

    [Fact]
    public void DeveAtualizarProdutoIdEQuantidade()
    {
        var estoque = new Estoques(_id, _userId, _produtoId, 10);
        var novoProdutoId = Guid.NewGuid();

        estoque.AtualizacaoEstoque(_userId, novoProdutoId, 20);

        estoque.ProdutoId.Should().Be(novoProdutoId);
        estoque.Quantidade.Should().Be(20);
    }

    #endregion

    #region Retirar

    [Fact]
    public void DeveRetirarQuantidadeQuandoSuficiente()
    {
        var estoque = new Estoques(_id, _userId, _produtoId, 10);

        estoque.Retirar(4);

        estoque.Quantidade.Should().Be(6);
    }

    [Fact]
    public void DeveLancarExcecaoQuandoRetirarQuantidadeMenorIgualZero()
    {
        var estoque = new Estoques(_id, _userId, _produtoId, 10);

        Action act = () => estoque.Retirar(0);

        act.Should().Throw<ArgumentException>()
            .WithMessage("Quantidade inválida.");
    }

    [Fact]
    public void DeveLancarExcecaoQuandoEstoqueInsuficiente()
    {
        var estoque = new Estoques(_id, _userId, _produtoId, 5);

        Action act = () => estoque.Retirar(10);

        act.Should().Throw<InvalidOperationException>()
            .WithMessage("Estoque insuficiente.");
    }

    #endregion

    #region Devolver

    [Fact]
    public void DeveAumentarQuantidadeQuandoDevolverValido()
    {
        var estoque = new Estoques(_id, _userId, _produtoId, 5);

        estoque.Devolver(3);

        estoque.Quantidade.Should().Be(8);
    }

    [Fact]
    public void DeveLancarExcecaoQuandoDevolverQuantidadeMenorIgualZero()
    {
        var estoque = new Estoques(_id, _userId, _produtoId, 5);

        Action act = () => estoque.Devolver(0);

        act.Should().Throw<ArgumentException>()
            .WithMessage("Quantidade inválida.");
    }

    #endregion
}