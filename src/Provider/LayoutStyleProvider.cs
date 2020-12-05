using Skclusive.Core.Component;

namespace Skclusive.Material.Layout
{
    public class LayoutStyleProvider : StyleTypeProvider
    {
        public LayoutStyleProvider() : base
        (
            priority: 1100,
            typeof(FooterStyle),
            typeof(MainLayoutStyle),
            typeof(MiniLayoutStyle),
            typeof(NavigationStyle),
            typeof(NotFoundStyle),
            typeof(ProfileStyle),
            typeof(SidebarStyle),
            typeof(TopbarStyle)
        )
        {
        }
    }
}