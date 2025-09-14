using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace ProCeur.API.Shared.Service.JwtToken
{
    public static class JwtAuthentication
    {
        public static void AddJwtAuthentication(this IServiceCollection services, IConfiguration configuration)
        {
            // Configure Authentication services
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            // Adding Jwt Bearer
            .AddJwtBearer(options =>
            {
                options.SaveToken = true;
                options.RequireHttpsMetadata = false;
                options.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ValidateLifetime = true,
                    ValidAudience = configuration["Jwt:Audience"],
                    ValidIssuer = configuration["Jwt:Issuer"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Key"])),
                    ClockSkew = TimeSpan.Zero
                };
                // Handle Authentication failed event (token expired)
                options.Events = new JwtBearerEvents
                {
                    OnAuthenticationFailed = context =>
                    {
                        if (context.Exception.GetType() == typeof(SecurityTokenExpiredException))
                        {
                            context.Response.Headers.Append("IS-TOKEN-EXPIRED", "true");
                        }
                        return Task.CompletedTask;
                    }
                };
            });
        }
    }
}
