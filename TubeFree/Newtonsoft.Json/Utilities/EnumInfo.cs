// Decompiled with JetBrains decompiler
// Type: Newtonsoft.Json.Utilities.EnumInfo
// Assembly: Newtonsoft.Json, Version=12.0.0.0, Culture=neutral, PublicKeyToken=30ad4fe6b2a6aeed
// MVID: A4A4D6C6-3EFA-4DC8-AAEA-DA1EC7F2D4DE
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\Newtonsoft.Json.dll

namespace Newtonsoft.Json.Utilities
{
  internal class EnumInfo
  {
    public readonly bool IsFlags;
    public readonly ulong[] Values;
    public readonly string[] Names;
    public readonly string[] ResolvedNames;

    public EnumInfo(bool isFlags, ulong[] values, string[] names, string[] resolvedNames)
    {
      this.IsFlags = isFlags;
      this.Values = values;
      this.Names = names;
      this.ResolvedNames = resolvedNames;
    }
  }
}
