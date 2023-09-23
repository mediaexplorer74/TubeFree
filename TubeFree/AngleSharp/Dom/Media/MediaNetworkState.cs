// Decompiled with JetBrains decompiler
// Type: AngleSharp.Dom.Media.MediaNetworkState
// Assembly: AngleSharp, Version=0.9.9.0, Culture=neutral, PublicKeyToken=e83494dcdc6d31ea
// MVID: 6D8FC1AC-F585-421F-BEC1-9105A73220DF
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\AngleSharp.dll

using AngleSharp.Attributes;

namespace AngleSharp.Dom.Media
{
  [DomName("HTMLMediaElement")]
  public enum MediaNetworkState : byte
  {
    [DomName("NETWORK_EMPTY")] Empty,
    [DomName("NETWORK_IDLE")] Idle,
    [DomName("NETWORK_LOADING")] Loading,
    [DomName("NETWORK_NO_SOURCE")] NoSource,
  }
}
