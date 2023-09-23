// Decompiled with JetBrains decompiler
// Type: AngleSharp.Dom.Media.IVideoTrack
// Assembly: AngleSharp, Version=0.9.9.0, Culture=neutral, PublicKeyToken=e83494dcdc6d31ea
// MVID: 6D8FC1AC-F585-421F-BEC1-9105A73220DF
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\AngleSharp.dll

using AngleSharp.Attributes;

namespace AngleSharp.Dom.Media
{
  [DomName("VideoTrack")]
  public interface IVideoTrack
  {
    [DomName("id")]
    string Id { get; }

    [DomName("kind")]
    string Kind { get; }

    [DomName("label")]
    string Label { get; }

    [DomName("language")]
    string Language { get; }

    [DomName("selected")]
    bool IsSelected { get; set; }
  }
}
