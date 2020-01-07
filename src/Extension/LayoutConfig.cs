namespace Skclusive.Material.Layout
{
    public interface ILayoutConfig
    {
        bool Responsive { get; }
    }

    public class LayoutConfigBuilder
    {
        private class LayoutConfig : ILayoutConfig
        {
            public bool Responsive { get; internal set; }
        }

        private readonly LayoutConfig config = new LayoutConfig();

        public ILayoutConfig Build()
        {
            return config;
        }

        public LayoutConfigBuilder WithResponsive(bool responsive)
        {
            config.Responsive = responsive;

            return this;
        }

        public LayoutConfigBuilder With(ILayoutConfig config)
        {
            WithResponsive(config.Responsive);

            return this;
        }
    }
}
