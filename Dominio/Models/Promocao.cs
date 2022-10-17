using Dominio.Resources;

namespace Dominio.Models
{
    public class Promocao : Base
    {
        public string Descricao { get; set; }
        public int QuantidadeMinima { get; set; }
        public TipoPromocao TipoPromocao { get; set; }        
    }
}
