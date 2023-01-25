using Microsoft.Extensions.DependencyInjection;
using Oc6.Library.Data;
using System;

namespace Oc6.Library.DependencyInjection
{
    public static class IServiceCollectionExtensions
    {
        public static IServiceCollection AddITsidFactory(this IServiceCollection services)
            => services.AddITsidFactory(ServiceLifetime.Singleton);

        public static IServiceCollection AddITsidFactory(this IServiceCollection services, ServiceLifetime serviceLifetime)
            => serviceLifetime switch
            {
                ServiceLifetime.Scoped => services.AddScoped<ITsidFactory, TsidFactory>(),
                ServiceLifetime.Singleton => services.AddSingleton<ITsidFactory, TsidFactory>(),
                ServiceLifetime.Transient => services.AddTransient<ITsidFactory, TsidFactory>(),
                _ => throw new NotImplementedException(),
            };
    }
}
