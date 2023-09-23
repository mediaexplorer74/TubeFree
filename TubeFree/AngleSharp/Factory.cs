// Decompiled with JetBrains decompiler
// Type: AngleSharp.Factory
// Assembly: AngleSharp, Version=0.9.9.0, Culture=neutral, PublicKeyToken=e83494dcdc6d31ea
// MVID: 6D8FC1AC-F585-421F-BEC1-9105A73220DF
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\AngleSharp.dll

using AngleSharp.Dom;
using AngleSharp.Services.Default;

namespace AngleSharp
{
  internal static class Factory
  {
    public static readonly HtmlElementFactory HtmlElements = new HtmlElementFactory();
    public static readonly MathElementFactory MathElements = new MathElementFactory();
    public static readonly SvgElementFactory SvgElements = new SvgElementFactory();
    public static readonly EventFactory Events = new EventFactory();
    public static readonly CssPropertyFactory Properties = new CssPropertyFactory();
    public static readonly InputTypeFactory InputTypes = new InputTypeFactory();
    public static readonly MediaFeatureFactory MediaFeatures = new MediaFeatureFactory();
    public static readonly AttributeSelectorFactory AttributeSelector = new AttributeSelectorFactory();
    public static readonly PseudoElementSelectorFactory PseudoElementSelector = new PseudoElementSelectorFactory();
    public static readonly PseudoClassSelectorFactory PseudoClassSelector = new PseudoClassSelectorFactory();
    public static readonly LinkRelationFactory LinkRelations = new LinkRelationFactory();
    public static readonly DocumentFactory Document = new DocumentFactory();
    public static readonly ContextFactory BrowsingContext = new ContextFactory();
    public static readonly ServiceFactory Service = new ServiceFactory();
    public static readonly DefaultAttributeObserver Observer = new DefaultAttributeObserver();
  }
}
