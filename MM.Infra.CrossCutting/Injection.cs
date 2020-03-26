using Microsoft.Extensions.DependencyInjection;
using MM.Domain;
using MM.Domain.Interface;
using MM.Service;
using MM.Service.Interface;

namespace MM.Infra.CrossCutting
{
    public class Injection
    {
        public static void Configure(IServiceCollection services)
        {
            // Domain
            services.AddScoped<IUsuario, Usuario>();

            // Service
            services.AddScoped<IUsuarioService, UsuarioService>();
        }
    }
}
