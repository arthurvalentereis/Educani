using Educa.Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Educa.Domain.Entities
{
    public class Escolaridade : EntidadeBase
    {
        public string Descricao { get; set; }
        public Usuario Usuario { get; set; }

        public Escolaridade() { }
    }
}
