using Microsoft.Extensions.DependencyInjection;
using System;

namespace Oc6.Library.DependencyInjection
{
    public static class IServiceCollectionExtensions
    {
        public static IServiceCollection AddTsidFactory(this IServiceCollection services)
            => services.AddTsidFactory(ServiceLifetime.Singleton);

        public static IServiceCollection AddTsidFactory(this IServiceCollection services, ServiceLifetime serviceLifetime)
            => serviceLifetime switch
            {
                ServiceLifetime.Scoped => services.AddScoped<IServiceCollection>(),
                ServiceLifetime.Singleton => services.AddSingleton<IServiceCollection>(),
                ServiceLifetime.Transient => services.AddTransient<IServiceCollection>(),
                _ => throw new NotImplementedException(),
            };
    }
}
