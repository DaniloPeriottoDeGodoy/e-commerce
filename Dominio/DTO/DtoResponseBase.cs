using System.Collections.Generic;
using System.Linq;

namespace Dominio.DTO
{
    public class DtoResponseBase
    {
        public List<DtoErro> ListaErros { get; set; }
        public bool PossuiErros { get { return this.ListaErros.Any(); } }

        public DtoResponseBase() => this.ListaErros = new List<DtoErro>();

        public void AdicionarErro(string mensagemErro, string codigoErro)
        {
            ListaErros.Add(new DtoErro
            {
                CodigoErro = codigoErro,
                MensagemErro = mensagemErro
            });
        }

        public void AdicionarErro(string mensagemErro)
        {
            ListaErros.Add(new DtoErro { MensagemErro = mensagemErro });
        }

        public List<DtoErro> ObterErros() => this.ListaErros;
    }
}
