using Cassie.Application.Common.Interfaces;
using Cassie.DependencyInjection.Extensions;
using Cassie.Infrastructure.Persistence;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Cassie.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.RegisterDependencies(Assembly.GetExecutingAssembly());

            services.AddScoped<ICassieDbContext, CassieDbContext>();
            return services;
        }
    }
}
