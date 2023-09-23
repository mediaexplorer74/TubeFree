// Decompiled with JetBrains decompiler
// Type: Microsoft.AdMediator.Core.Utilities.StringHelper
// Assembly: Microsoft.AdMediator.Core, Version=2.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: DB70E93F-CF3F-46EC-9B00-17C400B010D8
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\Microsoft.AdMediator.Core.dll

using System;
using System.Globalization;

namespace Microsoft.AdMediator.Core.Utilities
{
  internal static class StringHelper
  {
    public static string FormatWithInvariantCulture(string format, params object[] args) => string.Format((IFormatProvider) CultureInfo.InvariantCulture, format, args);
  }
}
