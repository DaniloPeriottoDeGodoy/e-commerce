namespace Dominio.Models
{
    public class Produto : Base
    {
        #region Propriedades

        public string Nome { get; set; }
        public decimal Preco { get; set; }
        public Promocao Promocao { get; set; }

        #endregion

        #region Funções

        public void VincularPromocao(Promocao promocao)
        {
            if (promocao != null)
                this.Promocao = promocao;
        }

        #endregion
    }
}
