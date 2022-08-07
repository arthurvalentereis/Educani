using Educa.Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Educa.Domain.Entities
{
    public class HistoricoEscolar : EntidadeBase
    {
        public string Formato { get; set; }
        public string Nome { get; set; }
        public string CaminhoArquivo { get; set; }
        public List<Usuario>? Usuario { get; set; }

        public HistoricoEscolar(string Formato, string Nome, string CaminhoArquivo) 
        {
            this.Formato = Formato;
            this.Nome = Nome;
            this.CaminhoArquivo = CaminhoArquivo;
        }
    }
}
