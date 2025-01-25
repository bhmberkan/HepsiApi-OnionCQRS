using Hepsiapi.Application.Interfaces.Repositories;
using Hepsiapi.Application.UnitOfWorks;
using Hepsiapi.Domain.Entities;
using HepsiApi.PresisTence.Context;
using HepsiApi.PresisTence.Repositories;
using HepsiApi.PresisTence.UnitOfWorks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HepsiApi.PresisTence
{
    public static class Registration
    {
        public static void AddPersistence(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AppDbContext>(opt => 
            opt.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            services.AddScoped(typeof(IReadRepository<>), typeof(ReadRepository<>));
            services.AddScoped(typeof(IWriteRepository<>), typeof(WriteRepository<>));


            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddIdentityCore<User>(opt =>
            {
                opt.Password.RequireNonAlphanumeric = false; // genel şifre kontrolleri
                opt.Password.RequiredLength = 2;
                opt.Password.RequireUppercase = false;
                opt.Password.RequireLowercase= false;
                opt.Password.RequireDigit = false;
                opt.SignIn.RequireConfirmedEmail = false; // mail kontrolu

            })
                .AddRoles<Role>()
                .AddEntityFrameworkStores<AppDbContext>();

        }


    }

}
