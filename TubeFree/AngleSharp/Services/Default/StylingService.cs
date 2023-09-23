// Decompiled with JetBrains decompiler
// Type: AngleSharp.Services.Default.StylingService
// Assembly: AngleSharp, Version=0.9.9.0, Culture=neutral, PublicKeyToken=e83494dcdc6d31ea
// MVID: 6D8FC1AC-F585-421F-BEC1-9105A73220DF
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\AngleSharp.dll

using AngleSharp.Extensions;
using AngleSharp.Services.Styling;
using System.Collections.Generic;

namespace AngleSharp.Services.Default
{
  public class StylingService : IStylingProvider
  {
    private readonly List<IStyleEngine> _engines;

    public StylingService() => this._engines = new List<IStyleEngine>();

    public virtual void Register(IStyleEngine engine) => this._engines.Add(engine);

    public virtual void Unregister(IStyleEngine engine) => this._engines.Remove(engine);

    public virtual IStyleEngine GetEngine(string mimeType)
    {
      foreach (IStyleEngine engine in this._engines)
      {
        if (engine.Type.Isi(mimeType))
          return engine;
      }
      return (IStyleEngine) null;
    }
  }
}
