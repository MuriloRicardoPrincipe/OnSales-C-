namespace OnSales.Share.Testes.TesteUnit;

using System;
using Xunit;
using OnSales.Share.Model.Model;

public class ClientesUnitTests
{
    private readonly Guid _id = Guid.NewGuid();
    private readonly Guid _userId = Guid.NewGuid();

    #region Construtor

    [Fact]
    public void DeveCriarClienteComDadosInformados()
    {
        var cliente = new Clientes(
            _id,
            _userId,
            "Murilo",
            TipoDocumento.CPF,
            "12345678900"
        );

        Assert.Equal("Murilo", cliente.Nome);
        Assert.Equal(TipoDocumento.CPF, cliente.TipoDeDocumento);
        Assert.Equal("12345678900", cliente.Documento);
    }

    [Fact]
    public void DeveInicializarListasDeContatosEEnderecos()
    {
        var cliente = new Clientes(
            _id,
            _userId,
            "Murilo",
            TipoDocumento.CPF,
            "12345678900"
        );

        Assert.NotNull(cliente.ContatosDeCliente);
        Assert.NotNull(cliente.EnderecosDeCliente);
        Assert.Empty(cliente.ContatosDeCliente);
        Assert.Empty(cliente.EnderecosDeCliente);
    }

    #endregion

    #region Atualizacao

    [Fact]
    public void DeveAtualizarDadosDoCliente()
    {
        var cliente = new Clientes(
            _id,
            _userId,
            "Murilo",
            TipoDocumento.CPF,
            "12345678900"
        );

        cliente.AtualizacaoCliente(
            _userId,
            "Novo Nome",
            TipoDocumento.CNPJ,
            "11222333000199"
        );

        Assert.Equal("Novo Nome", cliente.Nome);
        Assert.Equal(TipoDocumento.CNPJ, cliente.TipoDeDocumento);
        Assert.Equal("11222333000199", cliente.Documento);
    }

    #endregion
}