using Umbraco.Engage.Infrastructure.Analytics.Processed;

namespace Umbraco.Community.Engage.LocationHeaders
{
    public class GeoIpLocation : ILocation
    {
        public string Country { get; set; }
        public string County { get; set; }
        public string Province { get; set; }
        public string City { get; set; }
    }
}
