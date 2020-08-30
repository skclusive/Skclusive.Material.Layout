using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Components;
using Skclusive.Core.Component;
using Skclusive.Material.Core;

namespace Skclusive.Material.Layout
{
    public partial class MiniLayout : MaterialComponentBase
    {
        public MiniLayout() : base("MiniLayout")
        {
        }

        [Parameter]
        public RenderFragment LogoContent { set; get; }

        [Parameter]
        public RenderFragment BodyContent { get; set; }

        [Parameter]
        public RenderFragment FooterContent { set; get; }

        [Parameter]
        public string Component { set; get; } = "div";

        [Parameter]
        public string TopbarStyle { set; get; }

        [Parameter]
        public string TopbarClass { set; get; }

        [Parameter]
        public string ContentStyle { set; get; }

        [Parameter]
        public string ContentClass { set; get; }

        protected virtual string _ContentStyle
        {
            get => CssUtil.ToStyle(ContentStyles, ContentStyle);
        }

        protected virtual IEnumerable<Tuple<string, object>> ContentStyles
        {
            get => Enumerable.Empty<Tuple<string, object>>();
        }

        protected virtual string _ContentClass
        {
            get => CssUtil.ToClass(Selector, ContentClasses, ContentClass);
        }

        protected virtual IEnumerable<string> ContentClasses
        {
            get
            {
                yield return "Content";
            }
        }
    }
}
