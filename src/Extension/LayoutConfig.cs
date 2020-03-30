using Skclusive.Material.Component;

namespace Skclusive.Material.Layout
{
    public interface ILayoutConfig : IMaterialConfig
    {
        bool Responsive { get; }
    }

    public abstract class LayoutConfigBuilder<B, C> : MaterialConfigBuilder<B, C>
    where B : LayoutConfigBuilder<B, C>
    where C : ILayoutConfig
    {
        protected class LayoutConfig : MaterialConfig, ILayoutConfig
        {
            public bool Responsive { get; internal set; }
        }

        private LayoutConfig config;

        protected LayoutConfigBuilder(LayoutConfig config) : base(config)
        {
            this.config = config;
        }

        public B WithResponsive(bool responsive)
        {
            config.Responsive = responsive;

            return Builder();
        }

        public B With(ILayoutConfig config)
        {
            base.With(config);

            WithResponsive(config.Responsive);

            return Builder();
        }
    }

    public class LayoutConfigBuilder : LayoutConfigBuilder<LayoutConfigBuilder, ILayoutConfig>
    {
        public LayoutConfigBuilder() : base(new LayoutConfig())
        {
        }

        protected override ILayoutConfig Config()
        {
            return (ILayoutConfig)_config;
        }

        protected override LayoutConfigBuilder Builder()
        {
            return this;
        }
    }
}
