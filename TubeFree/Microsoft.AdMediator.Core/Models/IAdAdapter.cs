// Decompiled with JetBrains decompiler
// Type: Microsoft.AdMediator.Core.Models.IAdAdapter
// Assembly: Microsoft.AdMediator.Core, Version=2.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: DB70E93F-CF3F-46EC-9B00-17C400B010D8
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\Microsoft.AdMediator.Core.dll

using Microsoft.AdMediator.Core.Events;
using Microsoft.AdMediator.Core.Utilities;
using System;

namespace Microsoft.AdMediator.Core.Models
{
  internal interface IAdAdapter
  {
    void Start(TimeSpan refreshInterval);

    void StopExecution();

    event EventHandler<AdSdkEventArgs> AdFilled;

    event EventHandler<AdFailedEventArgs> AdError;

    event EventHandler<AdSdkEventArgs> AdSdkEvent;

    event EventHandler<AdSdkEventArgs> PauseForInterstitialEvent;

    event EventHandler<AdSdkEventArgs> ResumeForInterstitialEvent;

    string Name { get; }

    IParameterDictionary<string, object> UserParameters { get; }

    IParameterDictionary<string, string> AdControlParameters { get; }

    Location Location { get; set; }

    bool CanBeGarbageCollected();

    void Release();

    void Pause();

    void Resume();
  }
}
