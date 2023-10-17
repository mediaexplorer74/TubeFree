// Decompiled with JetBrains decompiler
// Type: AngleSharp.Dom.Media.MediaReadyState
// Assembly: AngleSharp, Version=0.9.9.0, Culture=neutral, PublicKeyToken=e83494dcdc6d31ea
// MVID: 6D8FC1AC-F585-421F-BEC1-9105A73220DF
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\AngleSharp.dll

using AngleSharp.Attributes;

namespace AngleSharp.Dom.Media
{
  [DomName("HTMLMediaElement")]
  public enum MediaReadyState : byte
  {
    [DomName("HAVE_NOTHING")] Nothing,
    [DomName("HAVE_METADATA")] Metadata,
    [DomName("HAVE_CURRENT_DATA")] CurrentData,
    [DomName("HAVE_FUTURE_DATA")] FutureData,
    [DomName("HAVE_ENOUGH_DATA")] EnoughData,
  }
}
