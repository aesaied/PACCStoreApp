using FluentValidation;
using FluentValidation.AspNetCore;
using StoreApp.AppServices;
using StoreApp.AppServices.Country.Dtos;
using System.Reflection;

namespace StoreApp
{
    public static class StartupHelper
    {

        public static IServiceCollection RegisterFluentValidators(this IServiceCollection services)
        {
            services.AddFluentValidationAutoValidation();

            services.AddFluentValidationClientsideAdapters();

            services.AddValidatorsFromAssemblyContaining<CountryCreateValidator>();



            return services;

        }

        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            Type serviceInterfaceType = typeof(IApplicationService);


            Assembly assembly = serviceInterfaceType.Assembly;//Assembly.GetExecutingAssembly(); // Get the current assembly or provide the desired assembly

            IEnumerable<Type> interfaceImplementations = assembly.GetTypes()
                .Where(t => t.IsInterface && serviceInterfaceType.IsAssignableFrom(t));

            foreach (Type implementation in interfaceImplementations)
            {
                if (implementation == serviceInterfaceType)
                    continue;
                IEnumerable<Type> classes = assembly.GetTypes()
              .Where(t => t.IsClass && implementation.IsAssignableFrom(t));

                if (classes.Any())
                {
                    Type typeint = implementation;
                    Type typeImp = classes.First();

                    services.AddScoped(typeint, typeImp);
                }
            }

            return services;
        }

    }
}
