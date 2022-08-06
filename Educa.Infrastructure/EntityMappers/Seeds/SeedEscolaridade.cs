using Educa.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Educa.Infrastructure.EntityMappers.Seeds
{
    public static class SeedEscolaridade
    {
        public static DataBuilder<Escolaridade> PopularEscolaridade(this ModelBuilder builder) =>
           builder.Entity<Escolaridade>().HasData(
               new Escolaridade
               {
                   Id = 1,
                   Descricao = "Infantil"
               },
               new Escolaridade
               {
                   Id = 2,
                   Descricao = "Fundamental"
               },
               new Escolaridade
               {
                   Id = 3,
                   Descricao = "Médio"
               },
               new Escolaridade
               {
                   Id = 4,
                   Descricao = "Superior"
               });
    }
}
