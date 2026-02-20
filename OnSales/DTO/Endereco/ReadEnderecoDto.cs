namespace OnSales.DTO.Endereco;

public class ReadEnderecoDto
{
    public Guid Id { get; private set; }
    public Guid ClientId { get; private set; }
    public string Rua { get; private set; }
    public string Numero { get; private set; }
    public string Complemento { get; private set; }
    public string Bairro { get; private set; }
    public string Cidade { get; private set; }
    public string Estado { get; private set; }
    public string Cep { get; private set; }
    public bool Ativo { get; set; }
    public Guid UltimoUsuarioId { get; set; }
    public DateTime DataCriacao { get; set; }
    public DateTime DataAtualizacao { get; set; }
}
