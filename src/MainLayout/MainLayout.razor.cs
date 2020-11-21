using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Skclusive.Core.Component;
using Skclusive.Material.Core;
using Skclusive.Material.Drawer;
using Skclusive.Script.DomHelpers;

namespace Skclusive.Material.Layout
{
    public partial class MainLayout : MaterialComponentBase
    {
        public MainLayout() : base("MainLayout")
        {
        }

        [Parameter]
        public RenderFragment LogoContent { set; get; }

        [Parameter]
        public RenderFragment TitleContent { set; get; }

        [Parameter]
        public RenderFragment ActionsContent { set; get; }

        [Parameter]
        public RenderFragment BodyContent { get; set; }

        [Parameter]
        public RenderFragment SidebarContent { set; get; }

        [Parameter]
        public RenderFragment FooterContent { set; get; }

        [Parameter]
        public Action OnSidebarClick { set; get; }

        [Inject]
        public MediaQueryMatcher MediaQueryMatcher  { get; set; }

        [Inject]
        public ILayoutConfig LayoutConfig { get; set; }

        [Parameter]
        public string Component { set; get; } = "div";

        [Parameter]
        public string TopbarStyle { set; get; }

        [Parameter]
        public string TopbarClass { set; get; }

        [Parameter]
        public string SidebarStyle { set; get; }

        [Parameter]
        public string SidebarClass { set; get; }

        [Parameter]
        public string ContentStyle { set; get; }

        [Parameter]
        public string ContentClass { set; get; }

        protected bool IsDesktop { set; get; } = false;

        protected bool SidebarOpenPersistent { set; get; } = false;

        protected bool SidebarOpenTemporary { set; get; } = false;

        protected override IEnumerable<string> Classes
        {
            get
            {
                foreach (var item in base.Classes)
                    yield return item;

                if (IsDesktop)
                    yield return "ShiftContent";
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

        protected DrawerVariant SidebarVariant => IsDesktop ? DrawerVariant.Persistent : DrawerVariant.Temporary;

        private IDisposable TimeoutDisposal { set; get; }

        protected void HandleSidebarClose()
        {
            System.Console.WriteLine($"HandleSidebarClose");

            SidebarOpenTemporary = false;

            StateHasChanged();
        }

        protected void HandleSidebarClick()
        {
            System.Console.WriteLine($"HandleSidebarClick");

            if (!IsDesktop)
            {
                HandleSidebarClose();
            }
        }

        protected void HandleSidebarToggle()
        {
            System.Console.WriteLine($"HandleSidebarToggle");

            SidebarOpenTemporary = true;

            OnSidebarClick?.Invoke();

            StateHasChanged();
        }

        protected override Task OnInitializedAsync()
        {
            MediaQueryMatcher.OnChange += OnMediaQueryChanged;

            if (LayoutConfig.Responsive)
            {
                TimeoutDisposal = SetTimeout(() => {
                    _ = MediaQueryMatcher.InitAsync("(min-width:1280px)");
                }, 500);
            }

            return Task.CompletedTask;
        }

        private IDisposable MediaChangeDisposable;

        protected void OnMediaQueryChanged(object sender, bool match)
        {
            IsDesktop = match;

            System.Console.WriteLine($"OnMediaQueryChanged IsDesktop: {IsDesktop}");

            MediaChangeDisposable?.Dispose();
            MediaChangeDisposable = null;

            if (IsDesktop)
            {
                System.Console.WriteLine($"Desktop. disabling temporary");

                SidebarOpenTemporary = false;

                MediaChangeDisposable = SetTimeout(() =>
                {
                    SidebarOpenPersistent = true;

                    System.Console.WriteLine($"Desktop. enabling persistent");

                    _ = InvokeAsync(StateHasChanged);
                }, 225);
            }
            else
            {
                SidebarOpenPersistent = false;

                System.Console.WriteLine($"Mobile. disabling persistent");
            }

            _ = InvokeAsync(StateHasChanged);
        }

        protected override async ValueTask DisposeAsync()
        {
            TimeoutDisposal?.Dispose();

            MediaChangeDisposable?.Dispose();

            if (LayoutConfig.Responsive)
            {
                MediaQueryMatcher.OnChange -= OnMediaQueryChanged;

                await MediaQueryMatcher.DisposeAsync();
            }
        }
    }
}
