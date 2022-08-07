using Microsoft.AspNetCore.Http;

namespace Educa.Domain.Dto.Usuario.Request
{
    public class NovoUsuarioRequest
    {
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string Email { get; set; }
        public DateTime DataNascimento { get; set; }
        public int EscolaridadeId { get; set; }
        public IFormFile HistoricoEscolar { get; set; }
    }
}
