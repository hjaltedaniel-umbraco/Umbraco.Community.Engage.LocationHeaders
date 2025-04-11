# Engage LocationHeaders 

[![Downloads](https://img.shields.io/nuget/dt/Umbraco.Community.Engage.LocationHeaders?color=cc9900)](https://www.nuget.org/packages/Umbraco.Community.Engage.LocationHeaders/)
[![NuGet](https://img.shields.io/nuget/vpre/Umbraco.Community.Engage.LocationHeaders?color=0273B3)](https://www.nuget.org/packages/Umbraco.Community.Engage.LocationHeaders)
[![GitHub license](https://img.shields.io/github/license/hjaltedaniel-umbraco/Umbraco.Community.Engage.LocationHeaders?color=8AB803)](https://github.com/hjaltedaniel-umbraco/Umbraco.Community.Engage.LocationHeaders/blob/main/LICENSE)

**Engage - LocationHeaders** is a lightweight package for [Umbraco Engage](https://umbraco.com/products/umbraco-engage/) that enriches analytics and segmentation data with location information extracted from HTTP headers.

The package is designed to work out-of-the-box on **Umbraco Cloud**, using location headers automatically injected by services like **Cloudflare** or **Azure Front Door**. This allows Engage to tap into geographic information such as **country**, **region**, and **city**, without the need for client-side geolocation or third-party services.

## ✨ Features

- 🔌 **Plug-and-play for Umbraco Cloud** – no setup required
- 🌍 **Supports Cloudflare, Azure Front Door, and other CDNs** that inject location headers
- ⚙️ **Optional configuration** for custom header names or alternative setups
- 📊 Enables location-based **segmentation** and **analytics** in Umbraco Engage

## Installation

Add the package to an existing Umbraco website (v13+) from nuget:

`dotnet add package Umbraco.Community.Engage.LocationHeaders`

## 🛠️ Configuration (Optional)

By default, the package expects certain common header names. If your setup uses different headers, you can override the defaults using appsettings configuration:

```json
"Engage": {
  "LocationHeaders": {
    "Country": "uc-ipcountry",
    "County": "CF-Region",
    "Province": "CF-Region",
    "City": "cf-ipcity"
  }
}
```

If your infrastructure uses custom headers, you can override the defaults in your `appsettings.json` file. Simply add an `Engage:LocationHeaders` section with keys like `Country`, `County`, `Province`, or `City` and map them to your custom header names.

## 🚀 Getting Started

Install the package via NuGet and deploy it to your Umbraco project. If you’re using a compatible CDN (like Cloudflare), the package will begin collecting location data immediately.

## 🧠 Use Cases

- Segment content based on visitor location  
- Build region-specific personalizations  
- Enhance analytics with geographic insights  

## 📦 Package Compatibility

- Compatible with **Umbraco 13.x**  
- Optimized for **Umbraco Cloud**  
- Requires **Umbraco Engage**

Bring location awareness to your digital experiences with **Engage - LocationHeaders** – simple, configurable, and Umbraco Cloud-ready.

## Contributing

Contributions to this package are most welcome! Please read the [Contributing Guidelines](CONTRIBUTING.md).

## 🙌 Acknowledgements

Big thanks to the community members who inspired and supported this package:

- 💡 [@TvGessel](https://github.com/TvGessel) – for the original idea of using location headers to enrich Umbraco Engage with geolocation data.  
- 🧰 [@LottePitcher](https://github.com/LottePitcher) – for providing the excellent [Umbraco Package Starter Kit](https://github.com/LottePitcher/opinionated-package-starter), which this package is built upon.

This package wouldn’t exist without your contributions — thank you!