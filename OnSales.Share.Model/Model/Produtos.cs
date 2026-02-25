namespace OnSales.Share.Model.Model
{
    public class Produtos : BaseEntity
    {
        public string Nome { get; private set; }
        public string Descricao { get; private set; }
        public decimal PrecoVenda { get; private set; }
        public decimal PrecoCusto { get; private set; }
        public virtual Estoques Estoques { get; private set; }
        public virtual ICollection <VendaItens> VendaItens { get; private set; } = new List<VendaItens>();
        public Produtos(Guid id,Guid userUpdateId, string nome, string descricao, decimal precoVenda, decimal precoCusto) : base(id)
        {
            Nome = nome;
            Descricao = descricao;
            ValidarPrecos(precoVenda, precoCusto);
            UserChageFile(userUpdateId);
            CriaData();
        }
        protected Produtos() { }

        public void AtualizacaoProduto(Guid userUpdateId, string nome, string descricao, decimal precoVenda, decimal precoCusto)
        {
            Nome = nome;
            Descricao = descricao;
            ValidarPrecos(precoVenda, precoCusto);
            UserChageFile(userUpdateId);
            AtualizarData();
        }

        private void ValidarPrecos(decimal precoVenda, decimal precoCusto)
        {
            if (precoVenda <= 0)
                throw new ArgumentException("Preço de venda deve ser maior que zero.");

            if (precoCusto <= 0)
                throw new ArgumentException("Preço de custo deve ser maior que zero.");

            if (precoVenda < precoCusto)
                throw new ArgumentException("Preço de venda não pode ser menor que o custo.");

            PrecoVenda = precoVenda;
            PrecoCusto = precoCusto;
        }
    }
}
