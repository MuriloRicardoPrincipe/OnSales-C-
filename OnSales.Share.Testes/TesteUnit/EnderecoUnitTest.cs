using FluentAssertions;
using OnSales.Share.Model.Model;

namespace OnSales.Share.Testes.TesteUnit;

public class EnderecoUnitTest
{

    private readonly Guid _id = Guid.NewGuid();
    private readonly Guid _userId = Guid.NewGuid();
    private readonly Guid _clienteId = Guid.NewGuid();

    [Fact]
    public void DeveCriarEndereco()
    {
        var enderecos = new Enderecos(_id, _userId, "Rua Teste", "10-20", "Complemento", "Bairro", "Cidade", "Estado", "CEP", _clienteId);

        enderecos.ClienteId.Should().Be(_clienteId);
    }

    [Fact]
    public void DeveAtualizarEndereco()
    {
        var enderecos = new Enderecos(_id, _userId, "Rua Teste", "10-20", "Complemento", "Bairro", "Cidade", "Estado", "CEP", _clienteId);
        var novoClienteId = Guid.NewGuid();

        enderecos.AtualizacaoEndereco(_userId, "Rua Teste atualizado", "10-20", "Complemento atualizado", "Bairro atualizado", "Cidade atualizado", "Estado atualizado", "CEP atualizado", novoClienteId);

        enderecos.ClienteId.Should().Be(novoClienteId);
    }
}
