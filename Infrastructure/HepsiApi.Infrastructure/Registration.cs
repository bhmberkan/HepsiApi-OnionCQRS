using Hepsiapi.Application.Interfaces.Tokens;
using HepsiApi.Infrastructure.Tokens;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HepsiApi.Infrastructure
{
    public  static class Registration
    {
        public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<TokenSettings>(configuration.GetSection("JWT"));
            services.AddTransient<ITokenService, TokenService>();

            services.AddAuthentication(opt => // kimlik doğrulama
            {
                opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme; 

            }).AddJwtBearer(JwtBearerDefaults.AuthenticationScheme,opt=> // jwt doğrulaması için yapılandırma
            {
                opt.SaveToken = true; // doğrulama sonrası bellekte tut
                opt.TokenValidationParameters = new TokenValidationParameters()
                { // diğer yapılandırmalar

                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWT:Secret"])),
                    ValidateLifetime = false,
                    ValidIssuer = configuration["JWT:Issuer"],
                    ValidAudience = configuration["JWT:Audience"],
                    ClockSkew = TimeSpan.Zero,
                };
            });
        }

    }
}
