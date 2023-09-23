// Decompiled with JetBrains decompiler
// Type: AngleSharp.ConfigurationExtensions
// Assembly: AngleSharp, Version=0.9.9.0, Culture=neutral, PublicKeyToken=e83494dcdc6d31ea
// MVID: 6D8FC1AC-F585-421F-BEC1-9105A73220DF
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\AngleSharp.dll

using AngleSharp.Dom.Css;
using AngleSharp.Extensions;
using AngleSharp.Network;
using AngleSharp.Network.Default;
using AngleSharp.Services;
using AngleSharp.Services.Default;
using AngleSharp.Services.Styling;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace AngleSharp
{
  public static class ConfigurationExtensions
  {
    public static Configuration With(this IConfiguration configuration, object service)
    {
      if (configuration == null)
        throw new ArgumentNullException(nameof (configuration));
      if (service == null)
        throw new ArgumentNullException(nameof (service));
      return new Configuration(configuration.Services.Concat<object>(service));
    }

    public static Configuration With(
      this IConfiguration configuration,
      IEnumerable<object> services)
    {
      if (configuration == null)
        throw new ArgumentNullException(nameof (configuration));
      if (services == null)
        throw new ArgumentNullException(nameof (services));
      return new Configuration(configuration.Services.Concat<object>(services));
    }

    public static IConfiguration With<TService>(
      this IConfiguration configuration,
      Func<IBrowsingContext, TService> creator)
    {
      IEnumerable<object> objects = configuration.Services;
      IEnumerable<Func<IBrowsingContext, TService>> funcs = configuration.Services.OfType<Func<IBrowsingContext, TService>>();
      if (funcs.Any<Func<IBrowsingContext, TService>>())
        objects = objects.Except<object>((IEnumerable<object>) funcs);
      return (IConfiguration) new Configuration(objects.Concat<object>((object) creator));
    }

    public static Configuration SetCulture(this IConfiguration configuration, string name)
    {
      CultureInfo culture = new CultureInfo(name);
      return configuration.SetCulture(culture);
    }

    public static Configuration SetCulture(this IConfiguration configuration, CultureInfo culture) => configuration.With((object) culture);

    public static IConfiguration WithCss(
      this IConfiguration configuration,
      Action<CssStyleEngine> setup = null)
    {
      if (configuration == null)
        throw new ArgumentNullException(nameof (configuration));
      if (configuration.GetServices<IStylingProvider>().Any<IStylingProvider>())
        return configuration;
      StylingService service = new StylingService();
      CssStyleEngine engine = new CssStyleEngine();
      if (setup != null)
        setup(engine);
      service.Register((IStyleEngine) engine);
      return (IConfiguration) configuration.With((object) service);
    }

    public static IConfiguration WithDefaultLoader(
      this IConfiguration configuration,
      Action<ConfigurationExtensions.LoaderSetup> setup = null,
      IEnumerable<IRequester> requesters = null)
    {
      IConfiguration configuration1 = configuration != null ? configuration : throw new ArgumentNullException(nameof (configuration));
      object services = (object) requesters;
      if (services == null)
        services = (object) new IRequester[2]
        {
          (IRequester) new HttpRequester(),
          (IRequester) new DataRequester()
        };
      configuration = (IConfiguration) ConfigurationExtensions.With(configuration1, (IEnumerable<object>) services);
      ConfigurationExtensions.LoaderSetup config = new ConfigurationExtensions.LoaderSetup()
      {
        Filter = (Predicate<IRequest>) null,
        IsNavigationEnabled = true,
        IsResourceLoadingEnabled = false
      };
      configuration.GetFactory<IServiceFactory>();
      if (setup != null)
        setup(config);
      if (config.IsNavigationEnabled)
        configuration = configuration.With<IDocumentLoader>((Func<IBrowsingContext, IDocumentLoader>) (ctx => (IDocumentLoader) new DocumentLoader(ctx, config.Filter)));
      if (config.IsResourceLoadingEnabled)
        configuration = configuration.With<IResourceLoader>((Func<IBrowsingContext, IResourceLoader>) (ctx => (IResourceLoader) new ResourceLoader(ctx, config.Filter)));
      return configuration;
    }

    public static IConfiguration WithLocaleBasedEncoding(this IConfiguration configuration)
    {
      if (configuration == null)
        throw new ArgumentException(nameof (configuration));
      if (configuration.GetServices<IEncodingProvider>().Any<IEncodingProvider>())
        return configuration;
      LocaleEncodingProvider service = new LocaleEncodingProvider();
      return (IConfiguration) configuration.With((object) service);
    }

    public static IConfiguration WithCookies(this IConfiguration configuration)
    {
      if (configuration == null)
        throw new ArgumentNullException(nameof (configuration));
      if (configuration.GetServices<ICookieProvider>().Any<ICookieProvider>())
        return configuration;
      MemoryCookieProvider service = new MemoryCookieProvider();
      return (IConfiguration) configuration.With((object) service);
    }

    public sealed class LoaderSetup
    {
      public bool IsNavigationEnabled { get; set; }

      public bool IsResourceLoadingEnabled { get; set; }

      public Predicate<IRequest> Filter { get; set; }
    }
  }
}
