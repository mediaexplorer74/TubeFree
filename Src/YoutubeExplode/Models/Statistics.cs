// Decompiled with JetBrains decompiler
// Type: YoutubeExplode.Models.Statistics
// Assembly: Explode, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D9BD94EC-1F8A-4D23-A0FC-F2CF6230133A
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\Explode.dll

using YoutubeExplode.Internal;

namespace YoutubeExplode.Models
{
  public class Statistics
  {
    public long ViewCount { get; }

    public long LikeCount { get; }

    public long DislikeCount { get; }

    public double AverageRating => this.LikeCount + this.DislikeCount == 0L ? 0.0 : 1.0 + 4.0 * (double) this.LikeCount / (double) (this.LikeCount + this.DislikeCount);

    public Statistics(long viewCount, long likeCount, long dislikeCount)
    {
      this.ViewCount = viewCount.GuardNotNegative(nameof (viewCount));
      this.LikeCount = likeCount.GuardNotNegative(nameof (likeCount));
      this.DislikeCount = dislikeCount.GuardNotNegative(nameof (dislikeCount));
    }
  }
}
