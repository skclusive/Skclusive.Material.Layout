using Skclusive.Material.Core;
using Microsoft.AspNetCore.Components;

namespace Skclusive.Material.Layout
{
    public partial class Footer : MaterialComponent
    {
        public Footer() : base("Footer")
        {
        }

        [Parameter]
        public string Component { set; get; } = "div";

        [Parameter]
        public string DomainName { set; get; }

        [Parameter]
        public string DomainUrl { set; get; }

        [Parameter]
        public string Copyright { set; get; }
    }
}
