namespace OnSales.DTO.Produto
{
    public class ReadProdutoDto
    {
        public Guid id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public decimal PrecoVenda { get; set; }
        public decimal PrecoCusto { get; set; }
        public bool Ativo { get; set; }
        public Guid UltimoUsuarioId { get; set; }
        public DateTime DataCriacao { get; set; }
        public DateTime DataAtualizacao { get; set; }
    }
}
