using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using MM.Domain;
using MM.Domain.Validators;
using MM.Infra.Data;
using MM.Infra.Data.Interface;
using MM.Service;
using MM.Service.Interface;

namespace MM.Infra.CrossCutting
{
    public class Injection
    {
        public static void Configure(IServiceCollection services)
        {
            // Service
            services.AddScoped<IUsuarioService, UsuarioService>();

            // Data
            services.AddScoped<IUsuarioDB, UsuarioDB>();

            // Validator
            services.AddScoped<IValidator<Usuario>, UsuarioInsertValidator>();
        }
    }
}
