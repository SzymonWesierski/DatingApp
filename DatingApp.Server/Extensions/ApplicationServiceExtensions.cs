using DatingApp.Server.Data;
using DatingApp.Server.Helpers;
using DatingApp.Server.Interfaces;
using DatingApp.Server.Services;
using DatingApp.Server.SignalR;
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

            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            services.Configure<CloudinarySettings>(config.GetSection("CloudinarySettings"));
            services.AddScoped<IPhotoService, PhotoService>();

            services.AddScoped<LogUsersActivity>();

            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddSignalR();

            services.AddSingleton<PresenceTracker>();


			return services;
        }
    }
}