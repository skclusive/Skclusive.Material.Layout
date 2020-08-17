using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Skclusive.Core.Component;
using Skclusive.Material.Component;

namespace Skclusive.Material.Layout
{
    public static class LayoutExtension
    {
        public static void TryAddLayoutServices(this IServiceCollection services, ILayoutConfig config)
        {
            services.TryAddMaterialServices(config);

            services.TryAddScoped<ILayoutConfig>((p) => config);

            services.AddSingleton<IStyleTypeProvider, LayoutStyleProvider>();
        }
    }
}
