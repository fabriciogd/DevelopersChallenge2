using Microsoft.Extensions.DependencyInjection;
using Nibo.Application.Interfaces;

namespace Nibo.Application
{
    public static class Injection
    {
        public static IServiceCollection RegisterApplicationServices(
            this IServiceCollection services)
        {
            services.AddScoped<ITransactionService, ITransactionService>();

            return services;
        }
    }
}
