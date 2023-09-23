// Decompiled with JetBrains decompiler
// Type: Newtonsoft.Json.Bson.BsonEmpty
// Assembly: Newtonsoft.Json, Version=12.0.0.0, Culture=neutral, PublicKeyToken=30ad4fe6b2a6aeed
// MVID: A4A4D6C6-3EFA-4DC8-AAEA-DA1EC7F2D4DE
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\Newtonsoft.Json.dll

namespace Newtonsoft.Json.Bson
{
  internal class BsonEmpty : BsonToken
  {
    public static readonly BsonToken Null = (BsonToken) new BsonEmpty(BsonType.Null);
    public static readonly BsonToken Undefined = (BsonToken) new BsonEmpty(BsonType.Undefined);

    private BsonEmpty(BsonType type) => this.Type = type;

    public override BsonType Type { get; }
  }
}
