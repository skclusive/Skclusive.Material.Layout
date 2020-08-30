using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Components;
using Skclusive.Core.Component;
using Skclusive.Material.Core;

namespace Skclusive.Material.Layout
{
    public partial class NotFound : MaterialComponent
    {
        public NotFound() : base("NotFound")
        {
        }

        [Parameter]
        public string Component { set; get; } = "div";

        [Parameter]
        public string Title { set; get; }

        [Parameter]
        public string SubTitle { set; get; }

        [Parameter]
        public string Message { set; get; }

        [Parameter]
        public string ImageStyle { set; get; }

        [Parameter]
        public string ImageClass { set; get; }

        [Parameter]
        public string ContentStyle { set; get; }

        [Parameter]
        public string ContentClass { set; get; }

        protected virtual string _ImageStyle
        {
            get => CssUtil.ToStyle(ImageStyles, ImageStyle);
        }

        protected virtual IEnumerable<Tuple<string, object>> ImageStyles
        {
            get => Enumerable.Empty<Tuple<string, object>>();
        }

        protected virtual string _ImageClass
        {
            get => CssUtil.ToClass(Selector, ImageClasses, ImageClass);
        }

        protected virtual IEnumerable<string> ImageClasses
        {
            get
            {
                yield return "Image";
            }
        }

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
