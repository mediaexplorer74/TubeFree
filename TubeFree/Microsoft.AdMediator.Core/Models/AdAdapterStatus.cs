﻿// Decompiled with JetBrains decompiler
// Type: Microsoft.AdMediator.Core.Models.AdAdapterStatus
// Assembly: Microsoft.AdMediator.Core, Version=2.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: DB70E93F-CF3F-46EC-9B00-17C400B010D8
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\Microsoft.AdMediator.Core.dll

namespace Microsoft.AdMediator.Core.Models
{
  internal class AdAdapterStatus
  {
    public bool IsActive { get; set; }

    public bool? IsSuccessful { get; set; }

    public AdAdapterStatus() => this.IsActive = true;
  }
}
