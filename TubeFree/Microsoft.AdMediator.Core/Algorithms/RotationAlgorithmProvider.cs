// Decompiled with JetBrains decompiler
// Type: Microsoft.AdMediator.Core.Algorithms.RotationAlgorithmProvider
// Assembly: Microsoft.AdMediator.Core, Version=2.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: DB70E93F-CF3F-46EC-9B00-17C400B010D8
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\Microsoft.AdMediator.Core.dll

using Microsoft.AdMediator.Core.Models.Runtime;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;

namespace Microsoft.AdMediator.Core.Algorithms
{
  internal static class RotationAlgorithmProvider
  {
    private static readonly Random RandomGenerator = new Random();

    internal static IRotationAlgorithm GetRotationAlgorithm(
      AlgorithmType algorithmType,
      IList<AdAdapterRuntimeInfo> adAdapterRuntimeConfigurations)
    {
      switch (algorithmType)
      {
        case AlgorithmType.RoundRobin:
          return (IRotationAlgorithm) new RoundRobinAlgorithm(adAdapterRuntimeConfigurations);
        case AlgorithmType.Ratio:
          return (IRotationAlgorithm) new RatioAlgorithm(RotationAlgorithmProvider.RandomGenerator, (IEnumerable<AdAdapterRuntimeInfo>) adAdapterRuntimeConfigurations);
        case AlgorithmType.Rank:
          return (IRotationAlgorithm) new RankAlgorithm((IEnumerable<AdAdapterRuntimeInfo>) adAdapterRuntimeConfigurations);
        default:
          throw new InvalidDataException(string.Format((IFormatProvider) CultureInfo.InvariantCulture, "Unsupported algorithm type {0}", (object) algorithmType));
      }
    }
  }
}
