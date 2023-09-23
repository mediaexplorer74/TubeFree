﻿// Decompiled with JetBrains decompiler
// Type: AngleSharp.Dom.IApplicationCache
// Assembly: AngleSharp, Version=0.9.9.0, Culture=neutral, PublicKeyToken=e83494dcdc6d31ea
// MVID: 6D8FC1AC-F585-421F-BEC1-9105A73220DF
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\AngleSharp.dll

using AngleSharp.Attributes;

namespace AngleSharp.Dom
{
  [DomName("ApplicationCache")]
  public interface IApplicationCache : IEventTarget
  {
    [DomName("status")]
    CacheStatus Status { get; }

    [DomName("update")]
    void Update();

    [DomName("abort")]
    void Abort();

    [DomName("swapCache")]
    void Swap();

    [DomName("onchecking")]
    event DomEventHandler Checking;

    [DomName("onerror")]
    event DomEventHandler Error;

    [DomName("onnoupdate")]
    event DomEventHandler NoUpdate;

    [DomName("ondownloading")]
    event DomEventHandler Downloading;

    [DomName("onprogress")]
    event DomEventHandler Progress;

    [DomName("onupdateready")]
    event DomEventHandler UpdateReady;

    [DomName("oncached")]
    event DomEventHandler Cached;

    [DomName("onobsolete")]
    event DomEventHandler Obsolete;
  }
}
