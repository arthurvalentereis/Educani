using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Educa.Domain.Entities.Base
{
    public class EntidadeBase
    {
        public EntidadeBase()
        {
            Status = true;
        }
        public int Id { get; set; }
        public DateTime CriadoEm { get; set; } = DateTime.Now;
        public DateTime AtualizadoEm { get; set; } = DateTime.Now;
        public bool? Status { get; set; }
    }
}
