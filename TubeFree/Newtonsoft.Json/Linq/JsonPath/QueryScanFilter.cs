// Decompiled with JetBrains decompiler
// Type: Newtonsoft.Json.Linq.JsonPath.QueryScanFilter
// Assembly: Newtonsoft.Json, Version=12.0.0.0, Culture=neutral, PublicKeyToken=30ad4fe6b2a6aeed
// MVID: A4A4D6C6-3EFA-4DC8-AAEA-DA1EC7F2D4DE
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\Newtonsoft.Json.dll

using System.Collections.Generic;

namespace Newtonsoft.Json.Linq.JsonPath
{
  internal class QueryScanFilter : PathFilter
  {
    public QueryExpression Expression { get; set; }

    public override IEnumerable<JToken> ExecuteFilter(
      JToken root,
      IEnumerable<JToken> current,
      bool errorWhenNoMatch)
    {
      foreach (JToken t1 in current)
      {
        if (t1 is JContainer jcontainer)
        {
          foreach (JToken t2 in jcontainer.DescendantsAndSelf())
          {
            if (this.Expression.IsMatch(root, t2))
              yield return t2;
          }
        }
        else if (this.Expression.IsMatch(root, t1))
          yield return t1;
      }
    }
  }
}
