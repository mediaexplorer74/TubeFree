// Decompiled with JetBrains decompiler
// Type: Microsoft.AdMediator.Core.Models.BaseConfiguration
// Assembly: Microsoft.AdMediator.Core, Version=2.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: DB70E93F-CF3F-46EC-9B00-17C400B010D8
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\Microsoft.AdMediator.Core.dll

using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Microsoft.AdMediator.Core.Models
{
  [DataContract(Namespace = "")]
  internal class BaseConfiguration
  {
    [DataMember(EmitDefaultValue = false)]
    public Uri ConfigurationUri { get; set; }

    [DataMember(EmitDefaultValue = false)]
    public IList<AdControlConfiguration> AdControlConfigurations { get; set; }

    [DataMember(EmitDefaultValue = false)]
    public IList<AdAdapterInfo> AdAdapters { get; set; }

    [DataMember(EmitDefaultValue = false)]
    public IList<AdAdapterInfo> UnusedAdAdapters { get; set; }

    [DataMember(EmitDefaultValue = false)]
    public string Version { get; set; }

    [DataMember(EmitDefaultValue = false)]
    public string RotationAlgorithm { get; set; }
  }
}
