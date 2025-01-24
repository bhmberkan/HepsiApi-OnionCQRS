using FluentValidation;
using Hepsiapi.Application.Bases;
using Hepsiapi.Application.Beheviors;
using Hepsiapi.Application.Exeptions;
using Hepsiapi.Application.Features.Products.Rules;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Hepsiapi.Application
{
    public static class Registration
    {
        public static void AddApplication(this IServiceCollection services)
        {
         var assembly =  Assembly.GetExecutingAssembly();


            services.AddTransient<ExceptionMiddleware>();
            //   services.AddTransient<ProductRules>(); // tek tek tüm kurallar için yazmak yeine
            // aşşağıdaki private yapıyı oluşturduk

            services.AddRulesFromAssemblyContaining(assembly, typeof(BaseRules));

            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(assembly));

            services.AddValidatorsFromAssembly(assembly);
            ValidatorOptions.Global.LanguageManager.Culture = new CultureInfo("tr");

            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(FluentValidationBehevior<,>));
        }

        private static IServiceCollection AddRulesFromAssemblyContaining(
            this IServiceCollection services, 
            Assembly assembly, 
            Type type)
        {
            var types = assembly.GetTypes().Where(t => t.IsSubclassOf(type) && type !=t ).ToList();
            foreach (var item in types)
                services.AddTransient(item);

            return services;
        }
    }
}
