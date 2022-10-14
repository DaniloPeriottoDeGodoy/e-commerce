namespace Dominio.Models
{
    public class Produto : Base
	{		
		public string Nome { get; set; }
		public decimal Preco { get; set; }

        public Promocao Promocao { get; set; }
    }
}
