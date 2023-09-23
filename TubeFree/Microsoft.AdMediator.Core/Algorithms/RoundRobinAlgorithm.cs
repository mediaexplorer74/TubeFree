// Decompiled with JetBrains decompiler
// Type: Microsoft.AdMediator.Core.Algorithms.RoundRobinAlgorithm
// Assembly: Microsoft.AdMediator.Core, Version=2.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: DB70E93F-CF3F-46EC-9B00-17C400B010D8
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\Microsoft.AdMediator.Core.dll

using Microsoft.AdMediator.Core.Models.Runtime;
using System;
using System.Collections.Generic;

namespace Microsoft.AdMediator.Core.Algorithms
{
  internal class RoundRobinAlgorithm : IRotationAlgorithm
  {
    private readonly IList<AdAdapterRuntimeInfo> adAdapterRuntimeConfigurations;
    private int currentIndex;
    private int numberOfAdAdaptersRemaining;

    public RoundRobinAlgorithm(
      IList<AdAdapterRuntimeInfo> adAdapterRuntimeConfigurations)
    {
      this.adAdapterRuntimeConfigurations = adAdapterRuntimeConfigurations;
      this.currentIndex = 0;
      this.numberOfAdAdaptersRemaining = -1;
    }

    public AdAdapterRuntimeInfo GetNextAdAdapterRuntimeConfiguration()
    {
      if (this.numberOfAdAdaptersRemaining == -1)
        throw new InvalidOperationException("Cannot get next ad adapter until an iteration is started");
      if (this.numberOfAdAdaptersRemaining == 0)
        return (AdAdapterRuntimeInfo) null;
      AdAdapterRuntimeInfo runtimeConfiguration = this.adAdapterRuntimeConfigurations[this.currentIndex];
      this.currentIndex = (this.currentIndex + 1) % this.adAdapterRuntimeConfigurations.Count;
      --this.numberOfAdAdaptersRemaining;
      return runtimeConfiguration;
    }

    public void StartNewIteration() => this.numberOfAdAdaptersRemaining = this.adAdapterRuntimeConfigurations.Count;
  }
}
