using Microsoft.Extensions.DependencyInjection;
using TicketPurchase.Application.Interfaces;
using TicketPurchase.Application.Services;
using TicketPurchase.Core.Interfaces;
using TicketPurchase.Infra.Data.Repositories;

namespace TicketPurchase.Infra.Data.IoC.Configuration
{
    public static class DependencyInjectionConfiguration
    {
        public static void AddDependencyInjectionConfiguration(this IServiceCollection services) {

            services.AddScoped<IEventRepository, EventRepository>();

            services.AddScoped<IEventService, EventService>();
        }
    }
}
