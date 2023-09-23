// Decompiled with JetBrains decompiler
// Type: AngleSharp.Css.ValueConverters.OrValueConverter
// Assembly: AngleSharp, Version=0.9.9.0, Culture=neutral, PublicKeyToken=e83494dcdc6d31ea
// MVID: 6D8FC1AC-F585-421F-BEC1-9105A73220DF
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\AngleSharp.dll

using AngleSharp.Dom.Css;
using AngleSharp.Parser.Css;
using System.Collections.Generic;

namespace AngleSharp.Css.ValueConverters
{
  internal sealed class OrValueConverter : IValueConverter
  {
    private readonly IValueConverter _previous;
    private readonly IValueConverter _next;

    public OrValueConverter(IValueConverter previous, IValueConverter next)
    {
      this._previous = previous;
      this._next = next;
    }

    public IPropertyValue Convert(IEnumerable<CssToken> value) => this._previous.Convert(value) ?? this._next.Convert(value);

    public IPropertyValue Construct(CssProperty[] properties) => this._previous.Construct(properties) ?? this._next.Construct(properties);
  }
}
