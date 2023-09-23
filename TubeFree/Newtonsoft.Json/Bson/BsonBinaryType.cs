// Decompiled with JetBrains decompiler
// Type: Newtonsoft.Json.Bson.BsonBinaryType
// Assembly: Newtonsoft.Json, Version=12.0.0.0, Culture=neutral, PublicKeyToken=30ad4fe6b2a6aeed
// MVID: A4A4D6C6-3EFA-4DC8-AAEA-DA1EC7F2D4DE
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\Newtonsoft.Json.dll

using System;

namespace Newtonsoft.Json.Bson
{
  internal enum BsonBinaryType : byte
  {
    Binary = 0,
    Function = 1,
    [Obsolete("This type has been deprecated in the BSON specification. Use Binary instead.")] BinaryOld = 2,
    [Obsolete("This type has been deprecated in the BSON specification. Use Uuid instead.")] UuidOld = 3,
    Uuid = 4,
    Md5 = 5,
    UserDefined = 128, // 0x80
  }
}
