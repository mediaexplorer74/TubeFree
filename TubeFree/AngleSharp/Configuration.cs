// Decompiled with JetBrains decompiler
// Type: AngleSharp.Configuration
// Assembly: AngleSharp, Version=0.9.9.0, Culture=neutral, PublicKeyToken=e83494dcdc6d31ea
// MVID: 6D8FC1AC-F585-421F-BEC1-9105A73220DF
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\AngleSharp.dll

using System;
using System.Collections.Generic;

namespace AngleSharp
{
  public class Configuration : IConfiguration
  {
    private readonly IEnumerable<object> _services;
    private static readonly object[] standardServices = new object[16]
    {
      (object) Factory.HtmlElements,
      (object) Factory.MathElements,
      (object) Factory.SvgElements,
      (object) Factory.Events,
      (object) Factory.InputTypes,
      (object) Factory.LinkRelations,
      (object) Factory.MediaFeatures,
      (object) Factory.Properties,
      (object) Factory.AttributeSelector,
      (object) Factory.PseudoClassSelector,
      (object) Factory.PseudoElementSelector,
      (object) Factory.Document,
      (object) Factory.Observer,
      (object) Factory.BrowsingContext,
      (object) Factory.Service,
      (object) (Func<IBrowsingContext, IEventLoop>) (ctx => (IEventLoop) new TaskEventLoop())
    };
    private static readonly Configuration defaultConfiguration = new Configuration();
    private static IConfiguration customConfiguration;

    public Configuration(IEnumerable<object> services = null) => this._services = (IEnumerable<object>) ((object) services ?? (object) Configuration.standardServices);

    public static IConfiguration Default => Configuration.customConfiguration ?? (IConfiguration) Configuration.defaultConfiguration;

    public static void SetDefault(IConfiguration configuration) => Configuration.customConfiguration = configuration;

    public IEnumerable<object> Services => this._services;
  }
}
