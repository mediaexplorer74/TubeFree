// Decompiled with JetBrains decompiler
// Type: AngleSharp.Css.ValueConverters.BorderRadiusConverter
// Assembly: AngleSharp, Version=0.9.9.0, Culture=neutral, PublicKeyToken=e83494dcdc6d31ea
// MVID: 6D8FC1AC-F585-421F-BEC1-9105A73220DF
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\AngleSharp.dll

using AngleSharp.Dom.Css;
using AngleSharp.Extensions;
using AngleSharp.Parser.Css;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AngleSharp.Css.ValueConverters
{
  internal sealed class BorderRadiusConverter : IValueConverter
  {
    private readonly IValueConverter _converter = Converters.LengthOrPercentConverter.Periodic(PropertyNames.BorderTopLeftRadius, PropertyNames.BorderTopRightRadius, PropertyNames.BorderBottomRightRadius, PropertyNames.BorderBottomLeftRadius);

    public IPropertyValue Convert(IEnumerable<CssToken> value)
    {
      List<CssToken> cssTokenList1 = new List<CssToken>();
      List<CssToken> cssTokenList2 = new List<CssToken>();
      List<CssToken> cssTokenList3 = cssTokenList1;
      foreach (CssToken cssToken in value)
      {
        if (cssToken.Type == CssTokenType.Delim && cssToken.Data.Is("/"))
        {
          if (cssTokenList3 == cssTokenList2)
            return (IPropertyValue) null;
          cssTokenList3 = cssTokenList2;
        }
        else
          cssTokenList3.Add(cssToken);
      }
      IPropertyValue horizontal = this._converter.Convert((IEnumerable<CssToken>) cssTokenList1);
      if (horizontal == null)
        return (IPropertyValue) null;
      IPropertyValue vertical = cssTokenList3 == cssTokenList2 ? this._converter.Convert((IEnumerable<CssToken>) cssTokenList2) : horizontal;
      return vertical == null ? (IPropertyValue) null : (IPropertyValue) new BorderRadiusConverter.BorderRadiusValue(horizontal, vertical, new CssValue(value));
    }

    public IPropertyValue Construct(CssProperty[] properties)
    {
      if (properties.Length != 4)
        return (IPropertyValue) null;
      List<CssToken> items = new List<CssToken>();
      List<CssToken> second = new List<CssToken>();
      List<CssProperty> cssPropertyList = new List<CssProperty>()
      {
        ((IEnumerable<CssProperty>) properties).First<CssProperty>((Func<CssProperty, bool>) (m => m.Name.Is(PropertyNames.BorderTopLeftRadius))),
        ((IEnumerable<CssProperty>) properties).First<CssProperty>((Func<CssProperty, bool>) (m => m.Name.Is(PropertyNames.BorderTopRightRadius))),
        ((IEnumerable<CssProperty>) properties).First<CssProperty>((Func<CssProperty, bool>) (m => m.Name.Is(PropertyNames.BorderBottomRightRadius))),
        ((IEnumerable<CssProperty>) properties).First<CssProperty>((Func<CssProperty, bool>) (m => m.Name.Is(PropertyNames.BorderBottomLeftRadius)))
      };
      for (int index = 0; index < cssPropertyList.Count; ++index)
      {
        if (!(cssPropertyList[index].DeclaredValue is IEnumerable<IPropertyValue> declaredValue))
          return (IPropertyValue) null;
        CssValue original1 = declaredValue.First<IPropertyValue>().Original;
        CssValue original2 = declaredValue.Last<IPropertyValue>().Original;
        if (index != 0)
        {
          items.Add(CssToken.Whitespace);
          second.Add(CssToken.Whitespace);
        }
        items.AddRange((IEnumerable<CssToken>) original1);
        second.AddRange((IEnumerable<CssToken>) original2);
      }
      IPropertyValue horizontal = this._converter.Convert((IEnumerable<CssToken>) items);
      IPropertyValue propertyValue = this._converter.Convert((IEnumerable<CssToken>) second);
      IEnumerable<CssToken> tokens = items.Concat<CssToken>(new CssToken(CssTokenType.Delim, "/", TextPosition.Empty)).Concat<CssToken>((IEnumerable<CssToken>) second);
      IPropertyValue vertical = propertyValue;
      CssValue original = new CssValue(tokens);
      return (IPropertyValue) new BorderRadiusConverter.BorderRadiusValue(horizontal, vertical, original);
    }

    private sealed class BorderRadiusValue : IPropertyValue
    {
      private readonly IPropertyValue _horizontal;
      private readonly IPropertyValue _vertical;
      private readonly CssValue _original;

      public BorderRadiusValue(
        IPropertyValue horizontal,
        IPropertyValue vertical,
        CssValue original)
      {
        this._horizontal = horizontal;
        this._vertical = vertical;
        this._original = original;
      }

      public string CssText
      {
        get
        {
          string cssText1 = this._horizontal.CssText;
          if (this._vertical != null)
          {
            string cssText2 = this._vertical.CssText;
            if (cssText1 != cssText2)
              return cssText1 + " / " + cssText2;
          }
          return cssText1;
        }
      }

      public CssValue Original => this._original;

      public CssValue ExtractFor(string name)
      {
        CssValue items = this._horizontal.ExtractFor(name);
        CssValue second = this._vertical.ExtractFor(name);
        CssToken whitespace = CssToken.Whitespace;
        return new CssValue(items.Concat<CssToken>(whitespace).Concat<CssToken>((IEnumerable<CssToken>) second));
      }
    }
  }
}
