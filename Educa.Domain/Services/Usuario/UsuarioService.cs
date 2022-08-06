using Educa.Domain.Interfaces.Repositories;
using Educa.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Educa.Domain.Services.Usuario
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository _context;

        public UsuarioService(
            IUsuarioRepository context)
        {
            _context = context;
        }

        public Entities.Usuario Create(Entities.Usuario model, string ipAddress)
        {
            return _context.Add(model);
        }
        public Entities.Usuario Update(Entities.Usuario usuario)
        {
            return _context.Update(usuario);
        }
        public Entities.Usuario Delete(Entities.Usuario model)
        {
            try
            {
                _context.Delete(model);
                return model;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public IEnumerable<Entities.Usuario> List()
        {
            var Usuario = _context.List().ToList();
            return Usuario;
        }
        public IEnumerable<Entities.Usuario> ListarAtivos() => _context.List().Where(x => x.Status == true).ToList();
        public Entities.Usuario GetByUsuarioNome(string Usuarioname)
        {
            var Usuario = _context.GetBy(x => x.Nome == Usuarioname);
            return Usuario;
        }
        public Entities.Usuario GetById(int id)
        {
            if (id == 0)
            {
                throw new ArgumentException("Usuario id was not informed");
            }

            var Usuario = _context.GetById(id);
            if (Usuario == null) throw new KeyNotFoundException("Usuario not found");

            return Usuario;
        }
        public Entities.Usuario GetByEmail(string email)
        {
            var user = _context.GetBy(x => x.Email == email);
            return user;
        }
    }
}
