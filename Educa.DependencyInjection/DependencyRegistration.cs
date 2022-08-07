using Educa.Domain.Entities;
using Educa.Domain.Interfaces.Repositories;
using Educa.Domain.Interfaces.Repositories.Base;
using Educa.Domain.Interfaces.Services;
using Educa.Domain.Services.Usuario;
using Educa.Infrastructure.Contexts;
using Educa.Infrastructure.Repositories;
using Educa.Infrastructure.Repositories.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Educa.DependencyInjection
{
    public static class DependencyRegistration
    {
        public static void RegistrarDependencias(this IServiceCollection services, IConfiguration configuration)
        {

            services.AddSingleton(configuration);
            RegistrarDados(services, configuration);
            RegistrarRepositorios(services);
            RegistrarServicos(services);
        }

        private static void RegistrarDados(IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<EducaDbContext>(x => x
                .UseSqlServer(configuration["ConnectionStrings:Educani"], x => { x.CommandTimeout(60); }));
        }
        private static void RegistrarRepositorios(IServiceCollection services)
        {
            //services.AddScoped(typeof(IBaseRepository<,>), typeof(BaseRepository<,>));
            //services.AddScoped(typeof(UsuarioRepository), typeof(BaseRepository<Usuario, int>));
            services.AddTransient<IUsuarioRepository, UsuarioRepository>();
            services.AddTransient<IHistoricoEscolarRepository, HistoricoEscolarRepository>();
        }

        private static void RegistrarServicos(IServiceCollection services)
        {
            services.AddTransient<IUsuarioService, UsuarioService>();
            services.AddTransient<IHistoricoEscolarService, HistoricoEscolarService>();
        }


    }
}
