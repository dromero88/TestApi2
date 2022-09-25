using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microservice.EF.Repositories;
using Microservice.EF.Data;
using Domain.Contracts.Repositories;
using Domain.Contracts.UnitOfWork;

namespace Microservice.EF.Registers
{
    public static class RepositoryRegister
    {
        public static  IServiceCollection AddRepository(IServiceCollection services, string connectionString)
        {
            services.AddTransient<IItemVentaRepository, ItemVentaRepository>();

            services.AddTransient<IUnitOfWork, UnitOfWork.UnitOfWork>();

            services.AddDbContext<EntitiesContext>(options =>
                options.UseLazyLoadingProxies().UseSqlServer(connectionString));

            return services;
        }
    }
}
