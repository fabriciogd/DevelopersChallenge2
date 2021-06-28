using Microsoft.Extensions.DependencyInjection;
using Nibo.Application.Interfaces;
using Nibo.Application.Services;

namespace Nibo.Application
{
    public static class Injection
    {
        public static IServiceCollection RegisterApplicationServices(
            this IServiceCollection services)
        {
            services.AddScoped<ITransactionService, TransactionService>();

            return services;
        }
    }
}
