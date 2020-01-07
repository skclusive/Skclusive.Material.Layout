using Microsoft.Extensions.DependencyInjection;
using Skclusive.Material.Component;

namespace Skclusive.Material.Layout
{
    public static class LayoutExtension
    {
        public static void AddLayout(this IServiceCollection services, ILayoutConfig config)
        {
            services.AddMaterialUI();

            services.AddSingleton<ILayoutConfig>(config);
        }
    }
}
