// Decompiled with JetBrains decompiler
// Type: AngleSharp.Extensions.ConfigurationExtensions
// Assembly: AngleSharp, Version=0.9.9.0, Culture=neutral, PublicKeyToken=e83494dcdc6d31ea
// MVID: 6D8FC1AC-F585-421F-BEC1-9105A73220DF
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\AngleSharp.dll

using AngleSharp.Commands;
using AngleSharp.Dom;
using AngleSharp.Network;
using AngleSharp.Services;
using AngleSharp.Services.Media;
using AngleSharp.Services.Scripting;
using AngleSharp.Services.Styling;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace AngleSharp.Extensions
{
  internal static class ConfigurationExtensions
  {
    public static Encoding DefaultEncoding(this IConfiguration configuration) => configuration.GetProvider<IEncodingProvider>()?.Suggest(configuration.GetLanguage()) ?? Encoding.UTF8;

    public static CultureInfo GetCulture(this IConfiguration configuration) => configuration.GetService<CultureInfo>() ?? CultureInfo.CurrentUICulture;

    public static CultureInfo GetCultureFromLanguage(
      this IConfiguration configuration,
      string language)
    {
      try
      {
        return new CultureInfo(language);
      }
      catch (CultureNotFoundException ex)
      {
        return configuration.GetCulture();
      }
    }

    public static string GetLanguage(this IConfiguration configuration) => configuration.GetCulture().Name;

    public static TFactory GetFactory<TFactory>(this IConfiguration configuration) => configuration.GetServices<TFactory>().Single<TFactory>();

    public static TProvider GetProvider<TProvider>(this IConfiguration configuration) => configuration.GetServices<TProvider>().SingleOrDefault<TProvider>();

    public static TService GetService<TService>(this IConfiguration configuration) => configuration.GetServices<TService>().FirstOrDefault<TService>();

    public static IEnumerable<TService> GetServices<TService>(this IConfiguration configuration) => configuration.Services.OfType<TService>();

    public static IResourceService<TResource> GetResourceService<TResource>(
      this IConfiguration configuration,
      string type)
      where TResource : IResourceInfo
    {
      foreach (IResourceService<TResource> service in configuration.GetServices<IResourceService<TResource>>())
      {
        if (service.SupportsType(type))
          return service;
      }
      return (IResourceService<TResource>) null;
    }

    public static string GetCookie(this IConfiguration configuration, string origin) => configuration.GetProvider<ICookieProvider>()?.GetCookie(origin) ?? string.Empty;

    public static void SetCookie(this IConfiguration configuration, string origin, string value) => configuration.GetProvider<ICookieProvider>()?.SetCookie(origin, value);

    public static ISpellCheckService GetSpellCheck(
      this IConfiguration configuration,
      string language)
    {
      ISpellCheckService spellCheck = (ISpellCheckService) null;
      CultureInfo cultureFromLanguage = configuration.GetCultureFromLanguage(language);
      foreach (ISpellCheckService service in configuration.GetServices<ISpellCheckService>())
      {
        if (service.Culture.Equals((object) cultureFromLanguage))
          return service;
        if (service.Culture.TwoLetterISOLanguageName.Is(cultureFromLanguage.TwoLetterISOLanguageName))
          spellCheck = service;
      }
      return spellCheck;
    }

    public static ICssStyleEngine GetCssStyleEngine(this IConfiguration configuration) => configuration.GetStyleEngine(MimeTypeNames.Css) as ICssStyleEngine;

    public static IStyleEngine GetStyleEngine(this IConfiguration configuration, string type) => configuration.GetProvider<IStylingProvider>()?.GetEngine(type);

    public static bool IsScripting(this IConfiguration configuration) => (configuration != null ? configuration.GetProvider<IScriptingProvider>() : (IScriptingProvider) null) != null;

    public static IScriptEngine GetScriptEngine(this IConfiguration configuration, string type) => configuration.GetProvider<IScriptingProvider>()?.GetEngine(type);

    public static IBrowsingContext NewContext(this IConfiguration configuration, Sandboxes security = Sandboxes.None) => configuration.GetFactory<IContextFactory>().Create(configuration, security);

    public static IBrowsingContext FindContext(this IConfiguration configuration, string name) => configuration.GetFactory<IContextFactory>().Find(name);

    public static ICommand GetCommand(this IConfiguration configuration, string commandId) => configuration.GetProvider<ICommandProvider>()?.GetCommand(commandId);
  }
}
