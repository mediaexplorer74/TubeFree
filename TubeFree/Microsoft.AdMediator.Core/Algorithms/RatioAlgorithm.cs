// Decompiled with JetBrains decompiler
// Type: Microsoft.AdMediator.Core.Algorithms.RatioAlgorithm
// Assembly: Microsoft.AdMediator.Core, Version=2.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: DB70E93F-CF3F-46EC-9B00-17C400B010D8
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\Microsoft.AdMediator.Core.dll

using Microsoft.AdMediator.Core.Models.Runtime;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Microsoft.AdMediator.Core.Algorithms
{
  internal class RatioAlgorithm : IRotationAlgorithm
  {
    private readonly IEnumerable<AdAdapterRuntimeInfo> adAdapterRuntimeConfigurations;
    private readonly Random randomGenerator;
    private IList<AdAdapterRuntimeInfo> activeAdAdapterRuntimeConfigurations;

    public RatioAlgorithm(
      Random randomGenerator,
      IEnumerable<AdAdapterRuntimeInfo> adAdapterRuntimeConfigurations)
    {
      this.randomGenerator = randomGenerator;
      this.adAdapterRuntimeConfigurations = adAdapterRuntimeConfigurations;
    }

    public AdAdapterRuntimeInfo GetNextAdAdapterRuntimeConfiguration()
    {
      if (this.activeAdAdapterRuntimeConfigurations == null)
        throw new InvalidOperationException("Cannot get next ad adapter until an iteration is started");
      if (this.activeAdAdapterRuntimeConfigurations.Count == 0)
        return (AdAdapterRuntimeInfo) null;
      int returnIndex = this.GetReturnIndex(this.activeAdAdapterRuntimeConfigurations.Sum<AdAdapterRuntimeInfo>((Func<AdAdapterRuntimeInfo, int>) (activeAdAdapterRuntimeConfiguration => activeAdAdapterRuntimeConfiguration.Weight)));
      AdAdapterRuntimeInfo runtimeConfiguration = this.activeAdAdapterRuntimeConfigurations[returnIndex];
      this.activeAdAdapterRuntimeConfigurations.RemoveAt(returnIndex);
      return runtimeConfiguration;
    }

    public void StartNewIteration()
    {
      this.activeAdAdapterRuntimeConfigurations = (IList<AdAdapterRuntimeInfo>) new List<AdAdapterRuntimeInfo>();
      foreach (AdAdapterRuntimeInfo runtimeConfiguration in this.adAdapterRuntimeConfigurations)
        this.activeAdAdapterRuntimeConfigurations.Add(runtimeConfiguration);
    }

    private int GetReturnIndex(int totalWeight)
    {
      if (totalWeight == 0)
        return this.randomGenerator.Next(this.activeAdAdapterRuntimeConfigurations.Count);
      int num1 = this.randomGenerator.Next(totalWeight);
      int num2 = 0;
      for (int index = 0; index < this.activeAdAdapterRuntimeConfigurations.Count; ++index)
      {
        AdAdapterRuntimeInfo runtimeConfiguration = this.activeAdAdapterRuntimeConfigurations[index];
        num2 += runtimeConfiguration.Weight;
        if (num1 < num2)
          return index;
      }
      throw new InvalidDataException("The method to get return index should never reach this point");
    }
  }
}
