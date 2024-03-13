using DatingApp.Server.Data;
using DatingApp.Server.Helpers;
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

            services.Configure<CloudinarySettings>(config.GetSection("CloudinarySettings"));
            services.AddScoped<IPhotoService, PhotoService>();

            services.AddScoped<LogUsersActivity>();

			services.AddScoped<ILikesRepository,LikesRepository>();
			services.AddScoped<IMessageRepository, MessageRepository>();

			return services;
        }
    }
}