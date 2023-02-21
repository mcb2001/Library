using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oc6.Library.Data
{
    public static class TsidIServiceCollectionExtensions
    {
        public static IServiceCollection AddITsidFactory(this IServiceCollection services)
            => AddITsidFactory(services, ServiceLifetime.Singleton);

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
