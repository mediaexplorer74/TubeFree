﻿// Decompiled with JetBrains decompiler
// Type: Newtonsoft.Json.Linq.JsonPath.ArrayIndexFilter
// Assembly: Newtonsoft.Json, Version=12.0.0.0, Culture=neutral, PublicKeyToken=30ad4fe6b2a6aeed
// MVID: A4A4D6C6-3EFA-4DC8-AAEA-DA1EC7F2D4DE
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\Newtonsoft.Json.dll

using Newtonsoft.Json.Utilities;
using System;
using System.Collections.Generic;
using System.Globalization;

namespace Newtonsoft.Json.Linq.JsonPath
{
  internal class ArrayIndexFilter : PathFilter
  {
    public int? Index { get; set; }

    public override IEnumerable<JToken> ExecuteFilter(
      JToken root,
      IEnumerable<JToken> current,
      bool errorWhenNoMatch)
    {
      foreach (JToken jtoken1 in current)
      {
        int? index = this.Index;
        if (index.HasValue)
        {
          JToken t = jtoken1;
          int num = errorWhenNoMatch ? 1 : 0;
          index = this.Index;
          int valueOrDefault = index.GetValueOrDefault();
          JToken tokenIndex = PathFilter.GetTokenIndex(t, num != 0, valueOrDefault);
          if (tokenIndex != null)
            yield return tokenIndex;
        }
        else if (jtoken1 is JArray || jtoken1 is JConstructor)
        {
          foreach (JToken jtoken2 in (IEnumerable<JToken>) jtoken1)
            yield return jtoken2;
        }
        else if (errorWhenNoMatch)
          throw new JsonException("Index * not valid on {0}.".FormatWith((IFormatProvider) CultureInfo.InvariantCulture, (object) jtoken1.GetType().Name));
      }
    }
  }
}
