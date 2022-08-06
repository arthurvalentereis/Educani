using Educa.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Educa.Domain.Interfaces.Services
{
    public interface IUsuarioService
    {
        Usuario Create(Usuario model, string ipAddress);
        IEnumerable<Usuario> List();
        Usuario Update(Usuario model);
        Usuario Delete(Usuario model);
        Usuario GetByUsuarioNome(string UsuarioName);
        Usuario GetByEmail(string email);
        Usuario GetById(int id);
    }

}
