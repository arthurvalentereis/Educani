﻿using Educa.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Educa.Infrastructure.EntityMappers
{
    internal class UsuarioConfiguration : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.ToTable("tb_usuarios");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnName("id_usuario");
            builder.HasOne(x => x.HistoricoEscolar).WithOne(x => x.Usuario);
            builder.HasOne(x => x.Escolaridade).WithOne(x => x.Usuario);
            builder.Property(x => x.Nome).HasColumnName("nome").HasColumnType("varchar(50)");
            builder.Property(x => x.Sobrenome).HasColumnName("username").HasColumnType("varchar(50)");
            builder.Property(x => x.DataNascimento).HasColumnName("password_hash").HasColumnType("varchar(200)");
            builder.Property(x => x.EscolaridadeId).HasColumnName("id_escolaridade");
            builder.Property(x => x.HistoricoEscolarId).HasColumnName("id_historico_escolar");

            builder.Property(x => x.CriadoEm).HasColumnName("criado_em");
            builder.Property(x => x.AtualizadoEm).HasColumnName("atualizado_em");
            builder.Property(x => x.Status).HasColumnName("status");
        }
    }
}
