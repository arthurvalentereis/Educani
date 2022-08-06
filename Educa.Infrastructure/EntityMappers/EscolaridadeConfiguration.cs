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
    public class EscolaridadeConfiguration : IEntityTypeConfiguration<Escolaridade>
    {
        public void Configure(EntityTypeBuilder<Escolaridade> builder)
        {
            builder.ToTable("tb_escolaridade");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnName("id_escolaridade");
            builder.HasOne(x => x.Usuario).WithOne(x => x.Escolaridade);
            builder.Property(x => x.Descricao).HasColumnName("descricao").HasColumnType("varchar(50)");

            builder.Property(x => x.CriadoEm).HasColumnName("criado_em");
            builder.Property(x => x.AtualizadoEm).HasColumnName("atualizado_em");
            builder.Property(x => x.Status).HasColumnName("status");
        }
    }
}
