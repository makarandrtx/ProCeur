using Microsoft.EntityFrameworkCore;
using ProCeur.API.Repositories;
using ProCeur.API.Shared.Interface;
using System.Reflection;

namespace ProCeur.API.Shared.Service
{
    public static class ServiceExtensions
    {
        /// <summary>
        /// add more services in future, for now these are sufficient.
        /// </summary>
        /// <param name="services"></param>
        public static void AddApplicationLayer(this IServiceCollection services)
        {
            services.AddHttpContextAccessor();
            services.AddHttpClient();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddMediatR(mediator => mediator.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
        }

        public static void ConfigureCors(this IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy", builder =>
                {
                    builder.AllowAnyOrigin()
                    .AllowAnyHeader()
                    .AllowAnyMethod();
                });
            });
        }

        public static void ConfigurePostgreSqlServer(this IServiceCollection services, IConfiguration configuration)
        {
            //hardcoded for now.
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseNpgsql("Host=localhost;Port=5431;Database=ProCeur-DB;Username=postgres;Password=password"));
        }
    }
}
