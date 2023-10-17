// Decompiled with JetBrains decompiler
// Type: AngleSharp.Css.IValueConverter
// Assembly: AngleSharp, Version=0.9.9.0, Culture=neutral, PublicKeyToken=e83494dcdc6d31ea
// MVID: 6D8FC1AC-F585-421F-BEC1-9105A73220DF
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\AngleSharp.dll

using AngleSharp.Dom.Css;
using AngleSharp.Parser.Css;
using System.Collections.Generic;

namespace AngleSharp.Css
{
  internal interface IValueConverter
  {
    IPropertyValue Convert(IEnumerable<CssToken> value);

    IPropertyValue Construct(CssProperty[] properties);
  }
}
