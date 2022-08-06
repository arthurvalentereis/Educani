using Educa.Domain.Entities;
using Educa.Domain.Interfaces.Repositories;
using Educa.Infrastructure.Contexts;
using Educa.Infrastructure.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Educa.Infrastructure.Repositories
{
    public class UsuarioRepository : BaseRepository<Usuario, int>, IUsuarioRepository
    {
        private EducaDbContext Contexto { get; }

        public UsuarioRepository(
           EducaDbContext context) : base(context)
        {
            Contexto = context;
        }

        public Usuario CustomAction(Usuario user)
        {
            throw new NotImplementedException();
        }
    }
}
