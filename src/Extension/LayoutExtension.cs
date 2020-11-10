using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Skclusive.Core.Component;
using Skclusive.Material.Core;
using Skclusive.Material.Baseline;
using Skclusive.Material.Icon;
using Skclusive.Material.Avatar;
using Skclusive.Material.Typography;
using Skclusive.Material.Toolbar;
using Skclusive.Material.Hidden;
using Skclusive.Material.Grid;
using Skclusive.Material.AppBar;
using Skclusive.Material.Button;
using Skclusive.Material.List;
using Skclusive.Material.Drawer;

namespace Skclusive.Material.Layout
{
    public static class LayoutExtension
    {
        public static void TryAddLayoutServices(this IServiceCollection services, ILayoutConfig config)
        {
            services.TryAddBaselineServices(config);
            services.TryAddIconServices(config);
            services.TryAddAvatarServices(config);
            services.TryAddTypographyServices(config);
            services.TryAddToolbarServices(config);
            services.TryAddGridServices(config);
            services.TryAddAppBarServices(config);
            services.TryAddButtonServices(config);
            services.TryAddListServices(config);
            services.TryAddDrawerServices(config);
            services.TryAddHiddenServices(config);

            services.TryAddScoped<ILayoutConfig>((p) => config);

            services.TryAddStyleTypeProvider<LayoutStyleProvider>();
        }
    }
}
