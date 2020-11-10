using Skclusive.Core.Component;

namespace Skclusive.Material.Layout
{
    public class LayoutStyleProvider : StyleTypeProvider
    {
        public LayoutStyleProvider() : base
        (
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