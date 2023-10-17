// Decompiled with JetBrains decompiler
// Type: YoutubeExplode.Models.ClosedCaptions.ClosedCaption
// Assembly: Explode, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D9BD94EC-1F8A-4D23-A0FC-F2CF6230133A
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\Explode.dll

using JetBrains.Annotations;
using System;
using YoutubeExplode.Internal;

namespace YoutubeExplode.Models.ClosedCaptions
{
  public class ClosedCaption
  {
    [NotNull]
    public string Text { get; }

    public TimeSpan Offset { get; }

    public TimeSpan Duration { get; }

    public ClosedCaption(string text, TimeSpan offset, TimeSpan duration)
    {
      this.Text = text.GuardNotNull<string>(nameof (text));
      this.Offset = offset.GuardNotNegative(nameof (offset));
      this.Duration = duration.GuardNotNegative(nameof (duration));
    }

    public override string ToString() => this.Text;
  }
}
