using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Oc6.Library.Config
{
    public static class AutoIOptionsIServiceCollectionExtensions
    {
        private static readonly MethodInfo addOptionsMethod = typeof(OptionsServiceCollectionExtensions)
            .GetMethods(BindingFlags.Public | BindingFlags.Static)
            .Where(x => x.Name == nameof(OptionsServiceCollectionExtensions.AddOptions)
                 && x.IsGenericMethod
                 && x.GetParameters().Length == 1)
            .First();

        private static readonly MethodInfo bindMethod = typeof(OptionsBuilderConfigurationExtensions)
            .GetMethods(BindingFlags.Public | BindingFlags.Static)
            .Where(x => x.Name == nameof(OptionsBuilderConfigurationExtensions.Bind)
                && x.IsGenericMethod
                && x.GetParameters().Length == 2)
            .First();

        private static  void Test<T>()
            where T:class
        {

        }

        public static IServiceCollection AddAutoIOptionsFromAssembly(this IServiceCollection services, IConfiguration configuration, Assembly assembly)
        {
            foreach (var type in assembly.GetTypes().Where(x => x.GetCustomAttribute<AutoIOptionsAttribute>() != null))
            {
                if (type.GetCustomAttribute<AutoIOptionsAttribute>() is AutoIOptionsAttribute attribute)
                {
                    var optionsBuilder = addOptionsMethod.MakeGenericMethod(type).Invoke(null, new[] { services });

                    var section = configuration.GetSection(attribute.ConfigurationSectionName);

                    bindMethod.MakeGenericMethod(type).Invoke(null, new[] { optionsBuilder, section });
                }
                else
                {
                    throw new CustomAttributeFormatException($"Invalid or missing attribute: {nameof(AutoIOptionsAttribute)}");
                }
            }

            return services;
        }

        public static IServiceCollection AddAutoIOptionsFromCallingAssembly(this IServiceCollection services, IConfiguration configuration)
            => AddAutoIOptionsFromAssembly(services, configuration, Assembly.GetCallingAssembly());

        public static IServiceCollection AddAutoIOptions<T>(this IServiceCollection services, IConfiguration configuration)
            where T : class
        {
            if (typeof(T).GetCustomAttribute<AutoIOptionsAttribute>() is not AutoIOptionsAttribute attribute)
            {
                throw new CustomAttributeFormatException($"Invalid or missing attribute: {nameof(AutoIOptionsAttribute)}");
            }

            services.AddOptions<T>()
                .Bind(configuration.GetSection(attribute.ConfigurationSectionName));

            return services;
        }
    }
}
