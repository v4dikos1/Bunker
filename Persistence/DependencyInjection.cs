using Application.Common.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Persistence
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("DbConnection");
            services.AddDbContext<BunkerDbContext>(options =>
            {
                options.UseNpgsql(connectionString);
            });
            services.AddScoped<IBunkerDbContext>(provider => provider.GetService<BunkerDbContext>());

            services.AddSingleton<IFileService, FIleService>();

            return services;
        }
    }
}
