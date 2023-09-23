// Decompiled with JetBrains decompiler
// Type: GoogleAnalytics.Core.TokenBucket
// Assembly: GoogleAnalytics.Core, Version=1.3.0.31481, Culture=neutral, PublicKeyToken=null, ContentType=WindowsRuntime
// MVID: 50A1198B-9AF1-4445-80B6-72A45A0328D9
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\GoogleAnalytics.Core.winmd

using System;

namespace GoogleAnalytics.Core
{
  internal class TokenBucket
  {
    private double capacity;
    private double tokens;
    private double fillRate;
    private DateTime timeStamp;
    private object locker = new object();

    public TokenBucket(double tokens, double fillRate)
    {
      this.capacity = tokens;
      this.tokens = tokens;
      this.fillRate = fillRate;
      this.timeStamp = DateTime.Now;
    }

    public bool Consume(double tokens = 1.0)
    {
      lock (this.locker)
      {
        if (this.GetTokens() - tokens <= 0.0)
          return false;
        this.tokens -= tokens;
        return true;
      }
    }

    private double GetTokens()
    {
      DateTime now = DateTime.Now;
      if (this.tokens < this.capacity)
      {
        this.tokens = Math.Min(this.capacity, this.tokens + this.fillRate * (now - this.timeStamp).TotalSeconds);
        this.timeStamp = now;
      }
      return this.tokens;
    }
  }
}
