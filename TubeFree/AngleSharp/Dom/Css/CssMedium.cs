// Decompiled with JetBrains decompiler
// Type: AngleSharp.Dom.Css.CssMedium
// Assembly: AngleSharp, Version=0.9.9.0, Culture=neutral, PublicKeyToken=e83494dcdc6d31ea
// MVID: 6D8FC1AC-F585-421F-BEC1-9105A73220DF
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\AngleSharp.dll

using AngleSharp.Css;
using AngleSharp.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AngleSharp.Dom.Css
{
  internal sealed class CssMedium : CssNode, ICssMedium, ICssNode, IStyleFormattable
  {
    private static readonly string[] KnownTypes = new string[4]
    {
      Keywords.Screen,
      Keywords.Speech,
      Keywords.Print,
      Keywords.All
    };

    public IEnumerable<MediaFeature> Features => this.Children.OfType<MediaFeature>();

    IEnumerable<IMediaFeature> ICssMedium.Features => (IEnumerable<IMediaFeature>) this.Features;

    public string Type { get; internal set; }

    public bool IsExclusive { get; internal set; }

    public bool IsInverse { get; internal set; }

    public string Constraints => string.Join(" and ", this.Features.Select<MediaFeature, string>((Func<MediaFeature, string>) (m => m.ToCss())));

    public bool Validate(RenderDevice device) => (string.IsNullOrEmpty(this.Type) || StringExtensions.Contains(CssMedium.KnownTypes, this.Type) != this.IsInverse) && !this.IsInvalid(device) && !this.Features.Any<MediaFeature>((Func<MediaFeature, bool>) (m => m.Validate(device) == this.IsInverse));

    public override bool Equals(object obj)
    {
      if (!(obj is CssMedium cssMedium) || cssMedium.IsExclusive != this.IsExclusive || cssMedium.IsInverse != this.IsInverse || !cssMedium.Type.Is(this.Type) || cssMedium.Features.Count<MediaFeature>() != this.Features.Count<MediaFeature>())
        return false;
      foreach (MediaFeature feature1 in cssMedium.Features)
      {
        MediaFeature feature = feature1;
        if (!this.Features.Any<MediaFeature>((Func<MediaFeature, bool>) (m => m.Name.Is(feature.Name) && m.Value.Is(feature.Value))))
          return false;
      }
      return true;
    }

    public override int GetHashCode() => base.GetHashCode();

    public override void ToCss(TextWriter writer, IStyleFormatter formatter) => writer.Write(formatter.Medium(this.IsExclusive, this.IsInverse, this.Type, (IEnumerable<IStyleFormattable>) this.Features));

    private bool IsInvalid(RenderDevice device) => this.IsInvalid(device, Keywords.Screen, RenderDevice.Kind.Screen) || this.IsInvalid(device, Keywords.Speech, RenderDevice.Kind.Speech) || this.IsInvalid(device, Keywords.Print, RenderDevice.Kind.Printer);

    private bool IsInvalid(RenderDevice device, string keyword, RenderDevice.Kind kind) => keyword.Is(this.Type) && device.DeviceType == kind == this.IsInverse;
  }
}
