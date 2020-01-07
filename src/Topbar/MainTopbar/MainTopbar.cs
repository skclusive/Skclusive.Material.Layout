using System;
using Microsoft.AspNetCore.Components;
using Skclusive.Material.Core;

namespace Skclusive.Material.Layout
{
    public class MainTopbarComponent : MaterialComponent
    {
        public MainTopbarComponent() : base("MainTopbar")
        {
        }

        [Parameter]
        public string GrowStyle { set; get; }

        [Parameter]
        public string GrowClass { set; get; }

        [Parameter]
        public string Notifications  { set; get; }

        [Parameter]
        public Action OnSidebarOpen { set; get; }
    }
}
