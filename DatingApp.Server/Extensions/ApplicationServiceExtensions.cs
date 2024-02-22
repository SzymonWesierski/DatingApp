using DatingApp.Server.Data;
using DatingApp.Server.Interfaces;
using DatingApp.Server.Services;
using Microsoft.EntityFrameworkCore;

namespace DatingApp.Server.Extensions
{
    public static class ApplicationServiceExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration config)
        {
            services.AddScoped<ITokenService, TokenService>();
            services.AddDbContext<DataContext>(options =>
            {
                options.UseSqlServer(config.GetConnectionString("DefaultConnection"));
            });

            return services;
        }
    }
}