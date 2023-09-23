// Decompiled with JetBrains decompiler
// Type: Microsoft.AdMediator.Core.IAdMediatorControl
// Assembly: Microsoft.AdMediator.Core, Version=2.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: DB70E93F-CF3F-46EC-9B00-17C400B010D8
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\Microsoft.AdMediator.Core.dll

using Microsoft.AdMediator.Core.Events;
using Microsoft.AdMediator.Core.Models;
using System;
using System.Collections.Generic;

namespace Microsoft.AdMediator.Core
{
  public interface IAdMediatorControl
  {
    string Id { get; set; }

    void Pause();

    void Resume();

    void Disable();

    AdSdkParameters AdSdkOptionalParameters { get; }

    event EventHandler<AdSdkEventArgs> AdMediatorFilled;

    event EventHandler<AdSdkEventArgs> AdSdkEvent;

    event EventHandler<AdFailedEventArgs> AdSdkError;

    event EventHandler<AdMediatorFailedEventArgs> AdMediatorError;

    event EventHandler<AdSdkEventArgs> PauseForInterstitialEvent;

    event EventHandler<AdSdkEventArgs> ResumeForInterstitialEvent;

    IDictionary<string, TimeSpan> AdSdkTimeouts { get; }
  }
}
