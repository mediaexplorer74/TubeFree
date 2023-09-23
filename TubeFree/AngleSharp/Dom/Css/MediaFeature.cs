// Decompiled with JetBrains decompiler
// Type: AngleSharp.Dom.Css.MediaFeature
// Assembly: AngleSharp, Version=0.9.9.0, Culture=neutral, PublicKeyToken=e83494dcdc6d31ea
// MVID: 6D8FC1AC-F585-421F-BEC1-9105A73220DF
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\AngleSharp.dll

using AngleSharp.Css;
using AngleSharp.Extensions;
using AngleSharp.Parser.Css;
using System.Collections.Generic;
using System.IO;

namespace AngleSharp.Dom.Css
{
  internal abstract class MediaFeature : CssNode, IMediaFeature, ICssNode, IStyleFormattable
  {
    private readonly bool _min;
    private readonly bool _max;
    private readonly string _name;
    private CssValue _value;

    internal MediaFeature(string name)
    {
      this._name = name;
      this._min = name.StartsWith("min-");
      this._max = name.StartsWith("max-");
    }

    public string Name => this._name;

    public bool IsMinimum => this._min;

    public bool IsMaximum => this._max;

    public string Value => !this.HasValue ? string.Empty : this._value.CssText;

    public bool HasValue => this._value != null && this._value.Count > 0;

    internal abstract IValueConverter Converter { get; }

    internal bool TrySetValue(CssValue value)
    {
      bool flag = value != null ? this.Converter.Convert((IEnumerable<CssToken>) value) != null : !this.IsMinimum && !this.IsMaximum && this.Converter.HasDefault();
      if (flag)
        this._value = value;
      return flag;
    }

    public abstract bool Validate(RenderDevice device);

    public override void ToCss(TextWriter writer, IStyleFormatter formatter)
    {
      string str = this.HasValue ? this.Value : (string) null;
      writer.Write(formatter.Constraint(this._name, str));
    }
  }
}
