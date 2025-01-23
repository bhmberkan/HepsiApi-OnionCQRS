using FluentValidation;
using Hepsiapi.Application.Beheviors;
using Hepsiapi.Application.Exeptions;
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
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(assembly));

            services.AddValidatorsFromAssembly(assembly);
            ValidatorOptions.Global.LanguageManager.Culture = new CultureInfo("tr");

            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(FluentValidationBehevior<,>));
        }
    }
}
