
using Microsoft.Extensions.DependencyInjection;
using TicketPurchase.Application.Mappings;

namespace TicketPurchase.Infra.Data.IoC.Configuration
{
    public static class AutoMapperConfiguration
    {
        public static void AddAutoMapperConfiguration(this IServiceCollection services) {
            services.AddAutoMapper(
                    typeof(EventProfile)
                );
        }
    }
}
