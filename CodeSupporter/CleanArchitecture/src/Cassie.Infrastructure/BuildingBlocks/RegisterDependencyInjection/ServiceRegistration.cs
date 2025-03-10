using Cassie.Application.Common.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;
using System.Reflection;

namespace Cassie.Infrastructure.BuildingBlocks.RegisterDependencyInjection
{
    public static class ServiceRegistration
    {
        public static void RegisterDependencies(this IServiceCollection services, Assembly assembly)
        {
            var types = assembly.GetTypes()
                .Where(x => x.GetInterfaces().Any() && !x.IsAbstract && !x.IsInterface);

            foreach (var type in types)
            {
                var interfaces = type.GetInterfaces();
                foreach (var @interface in interfaces)
                {
                    if (@interface is ITransientService)
                    {
                        services.AddTransient(@interface, type);
                    }
                }
            }
        }
    }
}
