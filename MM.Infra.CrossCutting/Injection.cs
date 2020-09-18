using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using MM.Domain;
using MM.Domain.Interface.Repository;
using MM.Domain.Notifications;
using MM.Domain.Validators;
using MM.Infra.Data.Repository;
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
            services.AddScoped<ILoginService, LoginService>();

            // Validator
            services.AddScoped<IValidator<Usuario>, UsuarioInsertValidator>();

            // Repository
            services.AddScoped(typeof(IRepositoryBase<>), typeof(RepositoryBase<>));
            services.AddScoped<IUsuarioRepository, UsuarioRepository>();

            // Notification
            services.AddScoped<NotificationContext>();
        }
    }
}
