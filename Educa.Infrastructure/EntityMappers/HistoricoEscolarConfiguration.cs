using Educa.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Educa.Infrastructure.EntityMappers
{
    public class HistoricoEscolarConfiguration : IEntityTypeConfiguration<HistoricoEscolar>
    {
        public void Configure(EntityTypeBuilder<HistoricoEscolar> builder)
        {
            builder.ToTable("tb_historico_escolar");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnName("id_historico_escolar");
            builder.HasOne(x => x.Usuario).WithOne(x => x.HistoricoEscolar);
            builder.Property(x => x.Formato).HasColumnName("formato").HasColumnType("varchar(50)");
            builder.Property(x => x.Nome).HasColumnName("nome").HasColumnType("varchar(50)");

            builder.Property(x => x.CriadoEm).HasColumnName("criado_em");
            builder.Property(x => x.AtualizadoEm).HasColumnName("atualizado_em");
            builder.Property(x => x.Status).HasColumnName("status");
        }
    }
}
