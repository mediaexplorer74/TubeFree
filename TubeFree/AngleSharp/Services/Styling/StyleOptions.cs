// Decompiled with JetBrains decompiler
// Type: AngleSharp.Services.Styling.StyleOptions
// Assembly: AngleSharp, Version=0.9.9.0, Culture=neutral, PublicKeyToken=e83494dcdc6d31ea
// MVID: 6D8FC1AC-F585-421F-BEC1-9105A73220DF
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\AngleSharp.dll

using AngleSharp.Dom;

namespace AngleSharp.Services.Styling
{
  public sealed class StyleOptions
  {
    public StyleOptions(IBrowsingContext context) => this.Context = context;

    public IElement Element { get; set; }

    public bool IsDisabled { get; set; }

    public bool IsAlternate { get; set; }

    public IBrowsingContext Context { get; private set; }
  }
}
