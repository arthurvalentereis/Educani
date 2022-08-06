using Educa.Domain.Entities.Base;

namespace Educa.Domain.Entities
{
    public class Usuario : EntidadeBase
    {
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string Email { get; set; }
        public DateTime DataNascimento { get; set; }
        public int EscolaridadeId { get; set; }
        public int HistoricoEscolarId { get; set; }
        public Escolaridade Escolaridade { get; set; }  
        public HistoricoEscolar HistoricoEscolar { get; set; }  
    }
}
