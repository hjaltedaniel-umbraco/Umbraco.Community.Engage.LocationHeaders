using Microsoft.Extensions.Configuration;
using System.Globalization;
using System.Net;
using System.Text;
using Umbraco.Engage.Data.Analytics.Collection.Pageview;
using Umbraco.Engage.Infrastructure.Analytics.Processed;
using Umbraco.Engage.Infrastructure.Analytics.Processing.Extractors;
using Umbraco.Extensions;

namespace Our.Umbraco.Engage.LocationHeaders
{
    public class HttpHeaderLocationExtractor : IRawPageviewLocationExtractor
    {
        private readonly string _countryHeader;
        private readonly string _countyHeader;
        private readonly string _provinceHeader;
        private readonly string _cityHeader;
        public HttpHeaderLocationExtractor(IConfiguration configuration)
        {
            _countryHeader = configuration["Engage:LocationHeaders:Country"] ?? "uc-ipcountry";
            _countyHeader = configuration["Engage:LocationHeaders:County"] ?? "CF-Region";
            _provinceHeader = configuration["Engage:LocationHeaders:Province"] ?? "CF-Region";
            _cityHeader = configuration["Engage:LocationHeaders:City"] ?? "cf-ipcity";
        }
        public ILocation Extract(IRawPageview rawPageview)
        {
            if (!IPAddress.TryParse(rawPageview?.IpAddress, out var ipAddress) || IPAddress.IsLoopback(ipAddress)) return null;

            var headers = rawPageview.Headers;

            RegionInfo country = null;
            try
            {
                var countryCode = headers?.GetValue(_countryHeader);
                if (!string.IsNullOrEmpty(countryCode))
                {
                    country = new RegionInfo(countryCode);
                }
            }
            catch (ArgumentException)
            {
                // Fallback or logging could be added here
            }

            return new GeoIpLocation
            {
                Country = country?.EnglishName,
                County = Encode(headers?.GetValue(_countyHeader)),
                Province = Encode(headers?.GetValue(_provinceHeader)),
                City = Encode(headers?.GetValue(_cityHeader))
            };
        }
        private static string Encode(string input)
        {
            if (input == null) return null;

            var urlDecoded = WebUtility.UrlDecode(input);
            var latin1Bytes = Encoding.GetEncoding("ISO-8859-1").GetBytes(urlDecoded);
            return Encoding.UTF8.GetString(latin1Bytes);
        }
    }
}
