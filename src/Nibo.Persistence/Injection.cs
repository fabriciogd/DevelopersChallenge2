using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Nibo.Application.Context;
using Nibo.Domain.Interfaces;
using Nibo.Persistence.Context;
using Nibo.Persistence.Repositories;

namespace Nibo.Persistence
{
    public static class Injection
    {
        public static IServiceCollection RegisterInfrastructerServices(
            this IServiceCollection services)
        {
            services.AddDbContext<NiboDBContext>(options =>
            {
                options.UseInMemoryDatabase("Nibo");
            })
            .AddScoped<INiboDBContext>(optiont => optiont.GetService<NiboDBContext>());

            services.AddScoped<ITransactionRepository, TransactionRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork<NiboDBContext>>();

            return services;
        }
    }
}
