using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Hepsiapi.Application.Interfaces.AutoMapper;

namespace HepsiApi.Mapper
{
    public static class Registiration
    {
        public static void AddCustomMapper(this IServiceCollection services)
        {
            services.AddSingleton< Hepsiapi.Application.Interfaces.AutoMapper.IMapper, AutoMapper.Mapper>();
        }


    }
}
