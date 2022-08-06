using Educa.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Educa.Infrastructure.Contexts
{
    public class EducaDbContext : DbContext
    {

        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<HistoricoEscolar> HistoricoEscolar { get; set; }
        public DbSet<Escolaridade> Escolaridade { get; set; }
        public EducaDbContext(DbContextOptions<EducaDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}
