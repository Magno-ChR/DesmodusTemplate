using DesmodusTemplate.LogicServices;
using System;

namespace DesmodusTemplate.Config
{
    public static class ConfLS
    {
        public static IServiceCollection AddConfLS(this IServiceCollection services)
        {

            RegisterLogicServices(services);
            return services;
        }
        private static IServiceCollection RegisterLogicServices(this IServiceCollection services)
        {
            services.AddTransient<PersonaLS>();
            services.AddTransient<AuthLS>();
            services.AddTransient<UsuarioLS>();
            return services;

        }
    }
}
