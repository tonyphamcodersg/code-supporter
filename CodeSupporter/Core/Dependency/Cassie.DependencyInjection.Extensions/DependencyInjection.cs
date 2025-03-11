using Cassie.DependencyInjection.Extensions.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using System.Reflection;

namespace Cassie.DependencyInjection.Extensions
{
    public static class ServiceRegistration
    {
        public static void RegisterDependencies(this IServiceCollection services, Assembly assembly)
        {
            var types = assembly.GetTypes()
                .Where(x => x.GetInterfaces().Any() && !x.IsAbstract && !x.IsInterface);
            var dependencyNames = new[]
            {
                nameof(ITransientService),
                nameof(IScopedService),
                nameof(ISingletonService)
            };

            foreach (var type in types)
            {
                var interfaces = type.GetInterfaces();
                if (interfaces.Count(x => dependencyNames.Contains(x.Name)) > 1)
                {
                    throw new InvalidOperationException($"The class '{type.Name}' implements multiple DI lifetimes (ITransientService, IScopedService, ISingletonService), which is not allowed. A class can only be registered with a single lifetime.");
                }

                if (typeof(ITransientService).IsAssignableFrom(type))
                {
                    foreach (var @interface in interfaces)
                    {
                        services.AddTransient(@interface, type);
                    }
                }
                else if (typeof(IScopedService).IsAssignableFrom(type))
                {
                    foreach (var @interface in interfaces)
                    {
                        services.AddScoped(@interface, type);
                    }
                }
                else if (typeof(ISingletonService).IsAssignableFrom(type))
                {
                    foreach (var @interface in interfaces)
                    {
                        services.AddSingleton(@interface, type);
                    }
                }
                else
                {
                    throw new InvalidOperationException($"The class '{type.Name}' does not implement a valid DI interface (ITransientService, IScopedService, or ISingletonService).");
                }
            }
        }
    }
}
