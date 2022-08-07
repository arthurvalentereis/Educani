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
    public class UsuarioConfiguration : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.ToTable("tb_usuarios");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnName("id_usuario");
            builder.HasOne(x => x.HistoricoEscolar).WithMany(x => x.Usuario).HasForeignKey(x=> x.HistoricoEscolarId);
            builder.HasOne(x => x.Escolaridade).WithMany(x => x.Usuario).HasForeignKey(x => x.EscolaridadeId);

            builder.Property(x => x.Nome).HasColumnName("nome").HasColumnType("varchar(50)");
            builder.Property(x => x.Sobrenome).HasColumnName("sobrenome").HasColumnType("varchar(50)");
            builder.Property(x => x.DataNascimento).HasColumnName("data_nascimento");
            builder.Property(x => x.Email).HasColumnName("email").HasColumnType("varchar(150)");
            builder.Property(x => x.EscolaridadeId).HasColumnName("id_escolaridade");
            builder.Property(x => x.HistoricoEscolarId).HasColumnName("id_historico_escolar");

            builder.Property(x => x.CriadoEm).HasColumnName("criado_em");
            builder.Property(x => x.AtualizadoEm).HasColumnName("atualizado_em");
            builder.Property(x => x.Status).HasColumnName("status");
        }
    }
}
