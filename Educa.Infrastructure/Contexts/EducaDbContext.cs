using Educa.Domain.Entities;
using Educa.Infrastructure.EntityMappers;
using Educa.Infrastructure.EntityMappers.Seeds;
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
            builder.ApplyConfiguration(new EscolaridadeConfiguration());
            builder.ApplyConfiguration(new UsuarioConfiguration());
            builder.ApplyConfiguration(new HistoricoEscolarConfiguration());
            builder.PopularEscolaridade();
            base.OnModelCreating(builder);
        }
    }
}
