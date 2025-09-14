using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
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

        public static void AddSwaggerGen(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSwaggerGen(swaggerConfig => {
                swaggerConfig.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "ProCeur.API",
                    Version = "v1"
                });
                swaggerConfig.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
                {
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer",
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Description = "JWT Authorization header using the Bearer scheme. \r\n\r\n Enter 'Bearer' [space] and then your token in the text input below.\r\n\r\nExample: \"Bearer 1safsfsdfdfd\"",
                });
                swaggerConfig.AddSecurityRequirement(new OpenApiSecurityRequirement {
                    {
                        new OpenApiSecurityScheme {
                            Reference = new OpenApiReference {
                                Type = ReferenceType.SecurityScheme,
                                    Id = "Bearer"
                            }
                        },
                        new string[] {}
                    }
                }
                );
            });
        }
    }
}
