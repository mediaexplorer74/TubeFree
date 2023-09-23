// Decompiled with JetBrains decompiler
// Type: Newtonsoft.Json.Utilities.DynamicUtils
// Assembly: Newtonsoft.Json, Version=12.0.0.0, Culture=neutral, PublicKeyToken=30ad4fe6b2a6aeed
// MVID: A4A4D6C6-3EFA-4DC8-AAEA-DA1EC7F2D4DE
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\Newtonsoft.Json.dll

using Microsoft.CSharp.RuntimeBinder;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;

namespace Newtonsoft.Json.Utilities
{
  internal static class DynamicUtils
  {
    public static IEnumerable<string> GetDynamicMemberNames(
      this IDynamicMetaObjectProvider dynamicProvider)
    {
      return dynamicProvider.GetMetaObject((Expression) Expression.Constant((object) dynamicProvider)).GetDynamicMemberNames();
    }

    internal static class BinderWrapper
    {
      public static CallSiteBinder GetMember(string name, Type context) => Binder.GetMember(CSharpBinderFlags.None, name, context, (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[1]
      {
        CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null)
      });

      public static CallSiteBinder SetMember(string name, Type context) => Binder.SetMember(CSharpBinderFlags.None, name, context, (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
      {
        CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null),
        CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.Constant, (string) null)
      });
    }
  }
}
