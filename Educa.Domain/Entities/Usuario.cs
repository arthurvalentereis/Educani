using Educa.Domain.Entities.Base;
using Educa.Domain.Util;
using System.ComponentModel.DataAnnotations;

namespace Educa.Domain.Entities
{
    public class Usuario : EntidadeBase
    {
        [StringLength(50)]
        public string Nome { get; set; }
        [StringLength(50)]
        public string Sobrenome { get; set; }
        [StringLength(150)]
        [DataType(DataType.EmailAddress)]
        [EmailAddress]
        public string Email { get; set; }
        [ValidateMaximumDate]
        public DateTime DataNascimento { get; set; }
        public int EscolaridadeId { get; set; }
        public int HistoricoEscolarId { get; set; }
        public Escolaridade Escolaridade { get; set; }  
        public HistoricoEscolar HistoricoEscolar { get; set; }  

        public Usuario() { }
    }
}
