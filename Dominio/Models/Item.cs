using Dominio.Resources;

namespace Dominio.Models
{
    public class Item
    {
        #region Construtores

        public Item(Produto produto, int quantidade)
        {
            this.Produto = produto;

            if (this.Produto != null)
                this.IdDoProduto = this.Produto.Id;

            this.Quantidade = quantidade;
            this.ValidarItem();
        }

        public Item()
        {

        }

        #endregion

        #region Propriedades

        public int IdDoProduto { get; set; }
        public int Quantidade { get; set; }
        public Produto Produto { get; set; }
        public bool PossuiPromocao
        {
            get
            {
                return this.Produto != null &&
                       this.Produto.Promocao != null &&
                       this.Produto.Promocao.Id > 0;
            }
        }

        #endregion

        #region Funções

        public TipoPromocao ObterTipoPromocao() => this.Produto?.Promocao?.TipoPromocao ?? TipoPromocao.SemPromocao;
        public int ObterQuantidadeMinimaParaAplicarPromocao() => this.Produto?.Promocao?.QuantidadeMinima ?? 0;

        // TODO. Adicionar Notification Patterns quando possúvel
        private void ValidarItem()
        {
            if (this.Quantidade == 0)
                throw new System.Exception("Quantidade não pode ser igual a zero.");

            if (this.IdDoProduto == 0)
                throw new System.Exception("Código do produto não pode ser igual a zero.");
        }

        #endregion
    }
}
