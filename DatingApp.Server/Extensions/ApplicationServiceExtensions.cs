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
			services.AddDbContext<DataContext>(options =>
            {
                options.UseSqlServer(config.GetConnectionString("DefaultConnection"));
            });

			services.AddScoped<ITokenService, TokenService>();
			services.AddScoped<IUserRepository, UserRepository>();

            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

			return services;
        }
    }
}