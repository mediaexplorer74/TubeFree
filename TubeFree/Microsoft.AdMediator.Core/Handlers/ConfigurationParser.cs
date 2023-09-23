// Decompiled with JetBrains decompiler
// Type: Microsoft.AdMediator.Core.Handlers.ConfigurationParser
// Assembly: Microsoft.AdMediator.Core, Version=2.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: DB70E93F-CF3F-46EC-9B00-17C400B010D8
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\Microsoft.AdMediator.Core.dll

using Microsoft.AdMediator.Core.Algorithms;
using Microsoft.AdMediator.Core.Models;
using Microsoft.AdMediator.Core.Models.Runtime;
using Microsoft.AdMediator.Core.Utilities;
using Microsoft.AdMediator.Core.Utilities.Log;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Microsoft.AdMediator.Core.Handlers
{
  internal class ConfigurationParser : IConfigurationParser
  {
    private static readonly ILogger Log = (ILogger) new Logger(typeof (ConfigurationParser));
    private static readonly IDictionary<string, IDictionary<string, string>> StandardizedAdAdapterMetadataKeyMapping = (IDictionary<string, IDictionary<string, string>>) new Dictionary<string, IDictionary<string, string>>()
    {
      {
        "Inneractive",
        (IDictionary<string, string>) new Dictionary<string, string>()
        {
          {
            "APPID",
            "AppID"
          }
        }
      },
      {
        "GoogleAdMob",
        (IDictionary<string, string>) new Dictionary<string, string>()
        {
          {
            "ADUNITID",
            "AdUnitID"
          }
        }
      },
      {
        "Smaato",
        (IDictionary<string, string>) new Dictionary<string, string>()
        {
          {
            "ADSPACE",
            "Adspace"
          }
        }
      },
      {
        "MobFox",
        (IDictionary<string, string>) new Dictionary<string, string>()
        {
          {
            "PUBLISHERID",
            "PublisherID"
          }
        }
      }
    };
    private const int MinRefreshRate = 30;
    private readonly bool isTestMode;
    private readonly string market;

    public ConfigurationParser(string market)
    {
      this.isTestMode = false;
      this.market = market;
    }

    public void ValidateAdMediatorConfiguration(AdMediatorConfiguration configuration)
    {
      if (configuration == null)
        throw new ArgumentNullException(nameof (configuration));
      if (this.isTestMode)
      {
        this.ValidateBaseConfiguration(configuration.TestConfiguration);
      }
      else
      {
        this.ValidateBaseConfiguration(configuration.BaseConfiguration);
        if (configuration.MarketOverrides == null)
          return;
        foreach (BaseConfiguration marketOverride in (IEnumerable<MarketConfiguration>) configuration.MarketOverrides)
          this.ValidateBaseConfiguration(marketOverride);
      }
    }

    public AdMediatorRuntimeConfiguration ConvertConfiguration(
      AdMediatorConfiguration adMediatorConfiguration,
      string adControlId)
    {
      if (adMediatorConfiguration == null)
        throw new ArgumentNullException(nameof (adMediatorConfiguration));
      AdMediatorRuntimeConfiguration runtimeConfiguration1 = this.ConvertBaseConfiguration(ConfigurationParser.GetConfigurationSectionWithFallback(adMediatorConfiguration, this.market, this.isTestMode), adControlId);
      if (adMediatorConfiguration.UseRoundRobin.GetValueOrDefault(false))
        runtimeConfiguration1.RotationAlgorithm = AlgorithmType.RoundRobin;
      runtimeConfiguration1.Id = adControlId;
      int? refreshRate = adMediatorConfiguration.RefreshRate;
      if (!refreshRate.HasValue)
        ConfigurationParser.Log.Warning("Refresh rate not provided, using {0} seconds", (object) 60);
      AdMediatorRuntimeConfiguration runtimeConfiguration2 = runtimeConfiguration1;
      refreshRate = adMediatorConfiguration.RefreshRate;
      int valueOrDefault = refreshRate.GetValueOrDefault(60);
      runtimeConfiguration2.RefreshRate = valueOrDefault;
      if (runtimeConfiguration1.RefreshRate < 30)
      {
        ConfigurationParser.Log.Warning("Refresh rate less than minimum {0} seconds, using {0} seconds", (object) 30, (object) 60);
        runtimeConfiguration1.RefreshRate = 60;
      }
      return runtimeConfiguration1;
    }

    public AdMediatorRuntimeConfiguration ConvertBaseConfiguration(BaseConfiguration configuration) => this.ConvertBaseConfiguration(configuration, (string) null);

    public AdMediatorRuntimeConfiguration ConvertBaseConfiguration(
      BaseConfiguration configuration,
      string adControlId)
    {
      if (configuration == null)
        throw new ArgumentNullException(nameof (configuration));
      Dictionary<string, AdAdapterRuntimeInfo> dictionary = new Dictionary<string, AdAdapterRuntimeInfo>();
      int num1 = 0;
      if (configuration.AdAdapters != null)
      {
        for (int index = 0; index < configuration.AdAdapters.Count; ++index)
        {
          AdAdapterRuntimeInfo adapterRuntimeInfo = ConfigurationParser.ConvertAdAdapterInfo(configuration.AdAdapters[index]);
          adapterRuntimeInfo.Order = index;
          dictionary[adapterRuntimeInfo.Name] = adapterRuntimeInfo;
        }
        num1 = configuration.AdAdapters.Count;
      }
      AdMediatorRuntimeConfiguration runtimeConfiguration = new AdMediatorRuntimeConfiguration()
      {
        AdAdapters = (IList<AdAdapterRuntimeInfo>) new List<AdAdapterRuntimeInfo>()
      };
      if (configuration.RotationAlgorithm == null)
      {
        runtimeConfiguration.RotationAlgorithm = AlgorithmType.Ratio;
      }
      else
      {
        try
        {
          runtimeConfiguration.RotationAlgorithm = (AlgorithmType) Enum.Parse(typeof (AlgorithmType), configuration.RotationAlgorithm, true);
        }
        catch (ArgumentException ex)
        {
          runtimeConfiguration.RotationAlgorithm = AlgorithmType.Ratio;
        }
      }
      if (configuration.AdControlConfigurations != null && adControlId != null)
      {
        AdControlConfiguration controlConfiguration = configuration.AdControlConfigurations.FirstOrDefault<AdControlConfiguration>((Func<AdControlConfiguration, bool>) (c => c.Id == adControlId));
        runtimeConfiguration.Id = adControlId;
        if (controlConfiguration != null && controlConfiguration.AdAdapters != null)
        {
          foreach (AdAdapterInfo adAdapter in (IEnumerable<AdAdapterInfo>) controlConfiguration.AdAdapters)
          {
            if (dictionary.ContainsKey(adAdapter.Name))
            {
              AdAdapterRuntimeInfo adapterRuntimeInfo1 = dictionary[adAdapter.Name];
              int? weight = adAdapter.Weight;
              if (weight.HasValue)
              {
                AdAdapterRuntimeInfo adapterRuntimeInfo2 = adapterRuntimeInfo1;
                weight = adAdapter.Weight;
                int num2 = weight.Value;
                adapterRuntimeInfo2.Weight = num2;
              }
              if (adAdapter.Metadata != null)
              {
                foreach (AdAdapterProperty adAdapterProperty in (IEnumerable<AdAdapterProperty>) adAdapter.Metadata)
                  adapterRuntimeInfo1.Metadata[ConfigurationParser.StandardizeAdAdapterMetadataKey(adapterRuntimeInfo1.Name, adAdapterProperty.Key.Trim())] = adAdapterProperty.Value.Trim();
              }
            }
            else
            {
              AdAdapterRuntimeInfo adapterRuntimeInfo = ConfigurationParser.ConvertAdAdapterInfo(adAdapter);
              adapterRuntimeInfo.Order = num1;
              ++num1;
              dictionary[adapterRuntimeInfo.Name] = adapterRuntimeInfo;
            }
          }
        }
      }
      foreach (KeyValuePair<string, AdAdapterRuntimeInfo> keyValuePair in dictionary)
      {
        AdAdapterRuntimeInfo adapterRuntimeInfo = keyValuePair.Value;
        runtimeConfiguration.AdAdapters.Insert(adapterRuntimeInfo.Order, adapterRuntimeInfo);
      }
      return runtimeConfiguration;
    }

    internal static string GetConfigVersion(
      AdMediatorConfiguration adMediatorConfiguration,
      string market,
      bool isTestMode)
    {
      if (adMediatorConfiguration == null)
        throw new ArgumentNullException(nameof (adMediatorConfiguration));
      if (market == null)
        throw new ArgumentNullException(nameof (market));
      if (string.IsNullOrWhiteSpace(market))
        throw new ArgumentException("parameter cannot be empty or whitespace", nameof (market));
      BaseConfiguration sectionWithFallback = ConfigurationParser.GetConfigurationSectionWithFallback(adMediatorConfiguration, market, isTestMode);
      return !string.IsNullOrWhiteSpace(sectionWithFallback.Version) ? sectionWithFallback.Version : adMediatorConfiguration.FileVersion;
    }

    private static BaseConfiguration GetConfigurationSectionWithFallback(
      AdMediatorConfiguration adMediatorConfiguration,
      string market,
      bool isTestMode)
    {
      BaseConfiguration baseConfiguration = (BaseConfiguration) null;
      BaseConfiguration sectionWithFallback;
      if (isTestMode && adMediatorConfiguration.TestConfiguration != null)
      {
        sectionWithFallback = adMediatorConfiguration.TestConfiguration;
      }
      else
      {
        if (adMediatorConfiguration.MarketOverrides != null)
          baseConfiguration = (BaseConfiguration) adMediatorConfiguration.MarketOverrides.FirstOrDefault<MarketConfiguration>((Func<MarketConfiguration, bool>) (m => market.Equals(m.Region, StringComparison.OrdinalIgnoreCase)));
        sectionWithFallback = baseConfiguration ?? adMediatorConfiguration.BaseConfiguration;
      }
      return sectionWithFallback;
    }

    private void ValidateBaseConfiguration(BaseConfiguration configuration)
    {
      if (configuration == null)
        throw new ArgumentNullException(nameof (configuration));
      if (configuration.AdControlConfigurations != null)
      {
        foreach (string adControlId in configuration.AdControlConfigurations.Select<AdControlConfiguration, string>((Func<AdControlConfiguration, string>) (c => c.Id)))
          ConfigurationParser.ValidateRuntimeConfiguration(this.ConvertBaseConfiguration(configuration, adControlId));
      }
      else
        ConfigurationParser.ValidateRuntimeConfiguration(this.ConvertBaseConfiguration(configuration));
    }

    private static void ValidateRuntimeConfiguration(AdMediatorRuntimeConfiguration configuration)
    {
      if (configuration.AdAdapters == null || configuration.AdAdapters.Count <= 0)
      {
        ConfigurationParser.Log.Warning("No adapter configured");
      }
      else
      {
        foreach (AdAdapterRuntimeInfo adAdapter in (IEnumerable<AdAdapterRuntimeInfo>) configuration.AdAdapters)
        {
          if (adAdapter.Weight < 0)
            throw new ArgumentException(StringHelper.FormatWithInvariantCulture("Invalid weight {0} for adapter {1}", (object) adAdapter.Weight, (object) adAdapter.Name));
          if (adAdapter.Rank < 0)
            throw new ArgumentException(StringHelper.FormatWithInvariantCulture("Invalid rank {0} for adapter {1}", (object) adAdapter.Rank, (object) adAdapter.Name));
          if (adAdapter.Metadata == null || adAdapter.Metadata.Count <= 0)
            throw new ArgumentException(StringHelper.FormatWithInvariantCulture("Metadata properties need to be set for adapter {0}", (object) adAdapter.Name));
        }
      }
    }

    private static AdAdapterRuntimeInfo ConvertAdAdapterInfo(AdAdapterInfo info)
    {
      AdAdapterRuntimeInfo adAdapterInfo = new AdAdapterRuntimeInfo()
      {
        Name = info.Name,
        Weight = 0,
        Rank = 0,
        Timeout = -1
      };
      if (info.Weight.HasValue)
        adAdapterInfo.Weight = info.Weight.Value;
      int? nullable = info.Rank;
      if (nullable.HasValue)
      {
        AdAdapterRuntimeInfo adapterRuntimeInfo = adAdapterInfo;
        nullable = info.Rank;
        int num = nullable.Value;
        adapterRuntimeInfo.Rank = num;
      }
      nullable = info.Timeout;
      if (nullable.HasValue)
      {
        AdAdapterRuntimeInfo adapterRuntimeInfo = adAdapterInfo;
        nullable = info.Timeout;
        int num = nullable.Value;
        adapterRuntimeInfo.Timeout = num;
      }
      if (info.Metadata != null)
        adAdapterInfo.Metadata = (IDictionary<string, string>) info.Metadata.ToDictionary<AdAdapterProperty, string, string>((Func<AdAdapterProperty, string>) (key => ConfigurationParser.StandardizeAdAdapterMetadataKey(adAdapterInfo.Name, key.Key.Trim())), (Func<AdAdapterProperty, string>) (key => key.Value.Trim()));
      return adAdapterInfo;
    }

    private static string StandardizeAdAdapterMetadataKey(string adAdapterName, string rawKey) => ConfigurationParser.StandardizedAdAdapterMetadataKeyMapping.ContainsKey(adAdapterName) && ConfigurationParser.StandardizedAdAdapterMetadataKeyMapping[adAdapterName].ContainsKey(rawKey.ToUpperInvariant()) ? ConfigurationParser.StandardizedAdAdapterMetadataKeyMapping[adAdapterName][rawKey.ToUpperInvariant()] : rawKey;
  }
}
