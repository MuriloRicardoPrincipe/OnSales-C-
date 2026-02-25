using OnSales.Share.Model.Model;

namespace OnSales.Share.Testes.TesteUnit;
public class ContatosUnitTests
{
    private readonly Guid _id = Guid.NewGuid();
    private readonly Guid _userId = Guid.NewGuid();
    private readonly Guid _clienteId = Guid.NewGuid();

    [Fact]
    public void DeveCriarContatoComDadosInformados()
    {
        var contato = new Contatos(
            _id,
            _userId,
            _clienteId,
            "1433221100",
            "teste@email.com",
            "14999998888"
        );

        Assert.Equal(_clienteId, contato.ClienteId);
        Assert.Equal("1433221100", contato.Telefone);
        Assert.Equal("teste@email.com", contato.Email);
        Assert.Equal("14999998888", contato.Celular);
    }

    [Fact]
    public void DeveAtualizarDadosDoContato()
    {
        var contato = new Contatos(
            _id,
            _userId,
            _clienteId,
            "11111111",
            "old@email.com",
            "99999999"
        );

        var novoClienteId = Guid.NewGuid();

        contato.atualizarContato(
            _userId,
            novoClienteId,
            "22222222",
            "novo@email.com",
            "88888888"
        );

        Assert.Equal(novoClienteId, contato.ClienteId);
        Assert.Equal("22222222", contato.Telefone);
        Assert.Equal("novo@email.com", contato.Email);
        Assert.Equal("88888888", contato.Celular);
    }

}