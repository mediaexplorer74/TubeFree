// Decompiled with JetBrains decompiler
// Type: Microsoft.AdMediator.Core.Models.AdAdapterInfo
// Assembly: Microsoft.AdMediator.Core, Version=2.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: DB70E93F-CF3F-46EC-9B00-17C400B010D8
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\Microsoft.AdMediator.Core.dll

using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Microsoft.AdMediator.Core.Models
{
  [DataContract(Namespace = "")]
  internal class AdAdapterInfo
  {
    [DataMember(EmitDefaultValue = false)]
    public string Name { get; set; }

    [DataMember(EmitDefaultValue = false)]
    public int? Weight { get; set; }

    [DataMember(EmitDefaultValue = false)]
    public IList<AdAdapterProperty> Metadata { get; set; }

    [DataMember(EmitDefaultValue = false)]
    public int? Rank { get; set; }

    [DataMember(EmitDefaultValue = false)]
    public int? Timeout { get; set; }
  }
}
