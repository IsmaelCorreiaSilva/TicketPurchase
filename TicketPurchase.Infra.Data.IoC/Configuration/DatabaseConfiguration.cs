
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using TicketPurchase.Infra.Data.Context;

namespace TicketPurchase.Infra.Data.IoC.Configuration
{
    public static class DatabaseConfiguration
    {
        public static void AddDatabaseConfiguration(this IServiceCollection services, IConfiguration configuration) {
            var connectionString = configuration.GetConnectionString("ConnectionString");
            var serverVersion = new MySqlServerVersion(new Version(8, 0, 30));
            services.AddDbContext<ApplicationDbContext>(
                dbContextOptions => dbContextOptions
               .UseMySql(connectionString, serverVersion)
               // The following three options help with debugging, but should
               // be changed or removed for production.
               .LogTo(Console.WriteLine, LogLevel.Information)
               .EnableSensitiveDataLogging()
               .EnableDetailedErrors()
               );
        }
    }
}
