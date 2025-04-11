using Umbraco.Engage.Infrastructure.Analytics.Processing.Extractors;
using Umbraco.Engage.Common.Composing;
using Umbraco.Cms.Core.Composing;
using Umbraco.Cms.Core.DependencyInjection;
using Umbraco.Extensions;

namespace Our.Umbraco.Engage.LocationHeaders
{
    [ComposeAfter(typeof(UmbracoEngageApplicationComposer))]
    public class EngageLocationComposer : IComposer
    {
        public void Compose(IUmbracoBuilder builder)
        {
            builder.Services.AddUnique<IRawPageviewLocationExtractor, HttpHeaderLocationExtractor>();
        }
    }
}
