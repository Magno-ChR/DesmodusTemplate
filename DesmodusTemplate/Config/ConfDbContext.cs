using DesmodusTemplate.Data;
using Microsoft.EntityFrameworkCore;

namespace DesmodusTemplate.Config
{
    public static class ConfDbContext
    {
        public static IServiceCollection AddConfContext(this IServiceCollection services,ConfigurationManager configuration)
        {
            services.AddDb<ArtecContext>(configuration, "ARTEC");
            return services;
        }
        private static IServiceCollection AddDb<T>(this IServiceCollection services, ConfigurationManager configuration, string connectionString = "Default")
            where T : DbContext
        {
            services.AddDbContext<T>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString(connectionString)!);
            });
            return services;
        }
    }
}
