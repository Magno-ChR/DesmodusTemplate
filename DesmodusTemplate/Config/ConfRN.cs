using DesmodusTemplate.Entities.Autores;
using DesmodusTemplate.LogicServices;
using System;

namespace DesmodusTemplate.Config
{
    public static class ConfRN
    {
        public static IServiceCollection AddConfLS(this IServiceCollection services)
        {

            RegisterLogicServices(services);
            return services;
        }
        private static IServiceCollection RegisterLogicServices(this IServiceCollection services)
        {
            // here come our Dependency Inyection
            services.AddTransient<PersonaLS>();
            return services;

        }
    }
}
