using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using MediatR;
using Application.Common.Interfaces;
using Application.Common.Services;

namespace Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddMediatR(cfg =>
                cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly())
            );

            services.AddSingleton<IPasswordService, PasswordService>();
            services.AddSingleton<ITokenService, TokenService>();

            return services;
        }
    }
}
