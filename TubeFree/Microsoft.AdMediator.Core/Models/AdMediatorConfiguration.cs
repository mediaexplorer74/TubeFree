// Decompiled with JetBrains decompiler
// Type: Microsoft.AdMediator.Core.Models.AdMediatorConfiguration
// Assembly: Microsoft.AdMediator.Core, Version=2.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: DB70E93F-CF3F-46EC-9B00-17C400B010D8
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\Microsoft.AdMediator.Core.dll

using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Microsoft.AdMediator.Core.Models
{
  [DataContract(Namespace = "")]
  internal class AdMediatorConfiguration
  {
    [DataMember(EmitDefaultValue = false)]
    public string SchemaVersion { get; set; }

    [DataMember(EmitDefaultValue = false)]
    public string AppVersion { get; set; }

    [DataMember(EmitDefaultValue = false)]
    public string FileVersion { get; set; }

    [DataMember(EmitDefaultValue = false)]
    public string Version { get; set; }

    [DataMember(EmitDefaultValue = false)]
    public DateTime UpdatedDateTime { get; set; }

    [DataMember(EmitDefaultValue = false)]
    public int? RefreshRate { get; set; }

    [DataMember(EmitDefaultValue = false)]
    public bool? UseRoundRobin { get; set; }

    [DataMember(EmitDefaultValue = false)]
    public string CdnUriFormat { get; set; }

    [DataMember(EmitDefaultValue = false)]
    public BaseConfiguration BaseConfiguration { get; set; }

    [DataMember(EmitDefaultValue = false)]
    public IList<MarketConfiguration> MarketOverrides { get; set; }

    [DataMember(EmitDefaultValue = false)]
    public BaseConfiguration TestConfiguration { get; set; }

    [DataMember(EmitDefaultValue = false)]
    public string ConfigId { get; set; }

    [DataMember(EmitDefaultValue = false)]
    public string LegacyConfigId { get; set; }
  }
}
