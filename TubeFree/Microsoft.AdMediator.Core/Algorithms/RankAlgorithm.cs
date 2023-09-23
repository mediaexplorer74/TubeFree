// Decompiled with JetBrains decompiler
// Type: Microsoft.AdMediator.Core.Algorithms.RankAlgorithm
// Assembly: Microsoft.AdMediator.Core, Version=2.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: DB70E93F-CF3F-46EC-9B00-17C400B010D8
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\Microsoft.AdMediator.Core.dll

using Microsoft.AdMediator.Core.Models.Runtime;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Microsoft.AdMediator.Core.Algorithms
{
  internal class RankAlgorithm : IRotationAlgorithm
  {
    private readonly IEnumerable<AdAdapterRuntimeInfo> adAdapterRuntimeConfigurations;
    private Queue<AdAdapterRuntimeInfo> activeAdAdapterRuntimeConfigurations;

    public RankAlgorithm(
      IEnumerable<AdAdapterRuntimeInfo> adAdapterRuntimeConfigurations)
    {
      this.adAdapterRuntimeConfigurations = adAdapterRuntimeConfigurations;
    }

    public void StartNewIteration() => this.activeAdAdapterRuntimeConfigurations = new Queue<AdAdapterRuntimeInfo>((IEnumerable<AdAdapterRuntimeInfo>) this.adAdapterRuntimeConfigurations.OrderBy<AdAdapterRuntimeInfo, int>((Func<AdAdapterRuntimeInfo, int>) (o => o.Rank)));

    public AdAdapterRuntimeInfo GetNextAdAdapterRuntimeConfiguration()
    {
      if (this.activeAdAdapterRuntimeConfigurations == null)
        throw new InvalidOperationException("Cannot get next ad adapter until an iteration is started");
      return this.activeAdAdapterRuntimeConfigurations.Count == 0 ? (AdAdapterRuntimeInfo) null : this.activeAdAdapterRuntimeConfigurations.Dequeue();
    }
  }
}
