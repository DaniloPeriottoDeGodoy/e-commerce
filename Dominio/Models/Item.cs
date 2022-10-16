using Dominio.Resources;

namespace Dominio.Models
{
    public class Item
    {
        #region Construtores

        public Item(Produto produto, int quantidade)
        {
            this.Produto = produto;

            if(this.Produto != null)
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

        #endregion

        #region Funções

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
