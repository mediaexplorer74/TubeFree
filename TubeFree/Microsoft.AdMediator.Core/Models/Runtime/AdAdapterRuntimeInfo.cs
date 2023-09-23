// Decompiled with JetBrains decompiler
// Type: Microsoft.AdMediator.Core.Models.Runtime.AdAdapterRuntimeInfo
// Assembly: Microsoft.AdMediator.Core, Version=2.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: DB70E93F-CF3F-46EC-9B00-17C400B010D8
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\Microsoft.AdMediator.Core.dll

using System.Collections.Generic;

namespace Microsoft.AdMediator.Core.Models.Runtime
{
  internal class AdAdapterRuntimeInfo
  {
    public int Order { get; set; }

    public int Rank { get; set; }

    public string Name { get; set; }

    public int Weight { get; set; }

    public int Timeout { get; set; }

    public IDictionary<string, string> Metadata { get; set; }
  }
}
