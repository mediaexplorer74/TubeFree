// Decompiled with JetBrains decompiler
// Type: Newtonsoft.Json.JsonConverter
// Assembly: Newtonsoft.Json, Version=12.0.0.0, Culture=neutral, PublicKeyToken=30ad4fe6b2a6aeed
// MVID: A4A4D6C6-3EFA-4DC8-AAEA-DA1EC7F2D4DE
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\Newtonsoft.Json.dll

using System;

namespace Newtonsoft.Json
{
  public abstract class JsonConverter
  {
    public abstract void WriteJson(JsonWriter writer, object value, JsonSerializer serializer);

    public abstract object ReadJson(
      JsonReader reader,
      Type objectType,
      object existingValue,
      JsonSerializer serializer);

    public abstract bool CanConvert(Type objectType);

    public virtual bool CanRead => true;

    public virtual bool CanWrite => true;
  }
}
