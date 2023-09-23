// Decompiled with JetBrains decompiler
// Type: AngleSharp.Services.Default.ContextFactory
// Assembly: AngleSharp, Version=0.9.9.0, Culture=neutral, PublicKeyToken=e83494dcdc6d31ea
// MVID: 6D8FC1AC-F585-421F-BEC1-9105A73220DF
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\AngleSharp.dll

using AngleSharp.Dom;
using System;
using System.Collections.Generic;

namespace AngleSharp.Services.Default
{
  public class ContextFactory : IContextFactory
  {
    private readonly Dictionary<string, WeakReference<IBrowsingContext>> _cache = new Dictionary<string, WeakReference<IBrowsingContext>>();

    public IBrowsingContext Create(IConfiguration configuration, Sandboxes security) => (IBrowsingContext) new BrowsingContext(configuration, security);

    public IBrowsingContext Create(IBrowsingContext parent, string name, Sandboxes security)
    {
      BrowsingContext target = new BrowsingContext(parent, security);
      this._cache[name] = new WeakReference<IBrowsingContext>((IBrowsingContext) target);
      return (IBrowsingContext) target;
    }

    public IBrowsingContext Find(string name)
    {
      WeakReference<IBrowsingContext> weakReference = (WeakReference<IBrowsingContext>) null;
      IBrowsingContext target = (IBrowsingContext) null;
      if (this._cache.TryGetValue(name, out weakReference))
        weakReference.TryGetTarget(out target);
      return target;
    }
  }
}
