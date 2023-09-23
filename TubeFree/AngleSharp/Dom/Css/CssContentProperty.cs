// Decompiled with JetBrains decompiler
// Type: AngleSharp.Dom.Css.CssContentProperty
// Assembly: AngleSharp, Version=0.9.9.0, Culture=neutral, PublicKeyToken=e83494dcdc6d31ea
// MVID: 6D8FC1AC-F585-421F-BEC1-9105A73220DF
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\AngleSharp.dll

using AngleSharp.Css;
using AngleSharp.Css.Values;
using AngleSharp.Extensions;
using System;
using System.Collections.Generic;

namespace AngleSharp.Dom.Css
{
  internal sealed class CssContentProperty : CssProperty
  {
    private static readonly Dictionary<string, CssContentProperty.ContentMode> ContentModes = new Dictionary<string, CssContentProperty.ContentMode>((IEqualityComparer<string>) StringComparer.OrdinalIgnoreCase)
    {
      {
        Keywords.OpenQuote,
        (CssContentProperty.ContentMode) new CssContentProperty.OpenQuoteContentMode()
      },
      {
        Keywords.NoOpenQuote,
        (CssContentProperty.ContentMode) new CssContentProperty.NoOpenQuoteContentMode()
      },
      {
        Keywords.CloseQuote,
        (CssContentProperty.ContentMode) new CssContentProperty.CloseQuoteContentMode()
      },
      {
        Keywords.NoCloseQuote,
        (CssContentProperty.ContentMode) new CssContentProperty.NoCloseQuoteContentMode()
      }
    };
    private static readonly CssContentProperty.ContentMode[] Default = (CssContentProperty.ContentMode[]) new CssContentProperty.NormalContentMode[1]
    {
      new CssContentProperty.NormalContentMode()
    };
    private static readonly IValueConverter StyleConverter = Converters.Assign<CssContentProperty.ContentMode[]>(Keywords.Normal, CssContentProperty.Default).OrNone().Or(CssContentProperty.ContentModes.ToConverter<CssContentProperty.ContentMode>().Or(Converters.UrlConverter).Or(Converters.StringConverter).Or(Converters.AttrConverter).Or(Converters.CounterConverter).Many()).OrDefault();

    internal CssContentProperty()
      : base(PropertyNames.Content)
    {
    }

    internal override IValueConverter Converter => CssContentProperty.StyleConverter;

    private static CssContentProperty.ContentMode TransformUrl(string url) => (CssContentProperty.ContentMode) new CssContentProperty.UrlContentMode(url);

    private static CssContentProperty.ContentMode TransformString(string str) => (CssContentProperty.ContentMode) new CssContentProperty.TextContentMode(str);

    private static CssContentProperty.ContentMode TransformAttr(string attr) => (CssContentProperty.ContentMode) new CssContentProperty.AttributeContentMode(attr);

    private static CssContentProperty.ContentMode TransformCounter(Counter counter) => (CssContentProperty.ContentMode) new CssContentProperty.CounterContentMode(counter);

    private abstract class ContentMode
    {
      public abstract string Stringify(IElement element);
    }

    private sealed class NormalContentMode : CssContentProperty.ContentMode
    {
      public override string Stringify(IElement element) => string.Empty;
    }

    private sealed class OpenQuoteContentMode : CssContentProperty.ContentMode
    {
      public override string Stringify(IElement element) => string.Empty;
    }

    private sealed class CloseQuoteContentMode : CssContentProperty.ContentMode
    {
      public override string Stringify(IElement element) => string.Empty;
    }

    private sealed class NoOpenQuoteContentMode : CssContentProperty.ContentMode
    {
      public override string Stringify(IElement element) => string.Empty;
    }

    private sealed class NoCloseQuoteContentMode : CssContentProperty.ContentMode
    {
      public override string Stringify(IElement element) => string.Empty;
    }

    private sealed class TextContentMode : CssContentProperty.ContentMode
    {
      private readonly string _text;

      public TextContentMode(string text) => this._text = text;

      public override string Stringify(IElement element) => this._text;
    }

    private sealed class CounterContentMode : CssContentProperty.ContentMode
    {
      private readonly Counter _counter;

      public CounterContentMode(Counter counter) => this._counter = counter;

      public override string Stringify(IElement element) => string.Empty;
    }

    private sealed class AttributeContentMode : CssContentProperty.ContentMode
    {
      private readonly string _attribute;

      public AttributeContentMode(string attribute) => this._attribute = attribute;

      public override string Stringify(IElement element) => element.GetAttribute(this._attribute) ?? string.Empty;
    }

    private sealed class UrlContentMode : CssContentProperty.ContentMode
    {
      private readonly string _url;

      public UrlContentMode(string url) => this._url = url;

      public override string Stringify(IElement element) => string.Empty;
    }
  }
}
