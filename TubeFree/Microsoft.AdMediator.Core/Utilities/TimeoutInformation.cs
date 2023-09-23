// Decompiled with JetBrains decompiler
// Type: Microsoft.AdMediator.Core.Utilities.TimeoutInformation
// Assembly: Microsoft.AdMediator.Core, Version=2.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: DB70E93F-CF3F-46EC-9B00-17C400B010D8
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\Microsoft.AdMediator.Core.dll

using System;
using System.Collections.Generic;

namespace Microsoft.AdMediator.Core.Utilities
{
  internal class TimeoutInformation
  {
    public TimeoutInformation(Dictionary<string, TimeSpan> timeouts, List<string> errors)
    {
      this.Timeouts = timeouts;
      this.Errors = errors;
    }

    public Dictionary<string, TimeSpan> Timeouts { get; private set; }

    public List<string> Errors { get; private set; }
  }
}
