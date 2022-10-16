using Dominio.Resources;
using System.Collections.Generic;

namespace Dominio.Models
{
    public class Promocao : Base
    {
        public string Descricao { get; set; }
        public TipoPromocao TipoPromocao { get; set; }
        //public List<ItemPromocao> ItensPromocao { get; set; }
    }
}
