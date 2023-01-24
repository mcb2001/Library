using Microsoft.Extensions.DependencyInjection;

namespace Oc6.Library.Data
{
    public static class IServiceCollectionExtensions
    {
        public static IServiceCollection AddTsidFactory(this IServiceCollection services)
            => services.AddSingleton<IServiceCollection>();
    }
}
