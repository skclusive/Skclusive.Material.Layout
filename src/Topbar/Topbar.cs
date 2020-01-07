using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Components;
using Skclusive.Core.Component;
using Skclusive.Material.Core;

namespace Skclusive.Material.Layout
{
    public class TopbarComponent : MaterialComponent
    {
        public TopbarComponent() : base("Topbar")
        {
        }

        [Parameter]
        public string GrowStyle { set; get; }

        [Parameter]
        public string GrowClass { set; get; }

        protected virtual string _GrowStyle
        {
            get => CssUtil.ToStyle(GrowStyles, GrowStyle);
        }

        protected virtual IEnumerable<Tuple<string, object>> GrowStyles
        {
            get => Enumerable.Empty<Tuple<string, object>>();
        }

        protected virtual string _GrowClass
        {
            get => CssUtil.ToClass(Selector, GrowClasses, GrowClass);
        }

        protected virtual IEnumerable<string> GrowClasses
        {
            get
            {
                yield return "Grow";
            }
        }
    }
}
