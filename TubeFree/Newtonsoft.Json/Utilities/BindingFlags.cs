// Decompiled with JetBrains decompiler
// Type: Newtonsoft.Json.Utilities.BindingFlags
// Assembly: Newtonsoft.Json, Version=12.0.0.0, Culture=neutral, PublicKeyToken=30ad4fe6b2a6aeed
// MVID: A4A4D6C6-3EFA-4DC8-AAEA-DA1EC7F2D4DE
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\Newtonsoft.Json.dll

using System;

namespace Newtonsoft.Json.Utilities
{
  [Flags]
  internal enum BindingFlags
  {
    Default = 0,
    IgnoreCase = 1,
    DeclaredOnly = 2,
    Instance = 4,
    Static = 8,
    Public = 16, // 0x00000010
    NonPublic = 32, // 0x00000020
    FlattenHierarchy = 64, // 0x00000040
    InvokeMethod = 256, // 0x00000100
    CreateInstance = 512, // 0x00000200
    GetField = 1024, // 0x00000400
    SetField = 2048, // 0x00000800
    GetProperty = 4096, // 0x00001000
    SetProperty = 8192, // 0x00002000
    PutDispProperty = 16384, // 0x00004000
    ExactBinding = 65536, // 0x00010000
    PutRefDispProperty = 32768, // 0x00008000
    SuppressChangeType = 131072, // 0x00020000
    OptionalParamBinding = 262144, // 0x00040000
    IgnoreReturn = 16777216, // 0x01000000
  }
}
