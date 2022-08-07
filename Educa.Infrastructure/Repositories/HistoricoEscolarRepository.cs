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
    public class HistoricoEscolarRepository : BaseRepository<HistoricoEscolar, int>, IHistoricoEscolarRepository
    {
        private EducaDbContext Contexto { get; }

        public HistoricoEscolarRepository(
           EducaDbContext context) : base(context)
        {
            Contexto = context;
        }
    }
}
