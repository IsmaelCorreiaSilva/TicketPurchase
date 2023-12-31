using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using TicketPurchase.Application.Validators.Event;

namespace TicketPurchase.Infra.Data.IoC.Configuration
{
    public static class FluentValidationConfiguration
    {
        public static void AddFluentValidationConfiguration(this IServiceCollection services)
        {
            services.AddValidatorsFromAssemblyContaining<EventCreateValidator>();
        }
    }
}
