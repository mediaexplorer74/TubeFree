﻿// Decompiled with JetBrains decompiler
// Type: Newtonsoft.Json.JsonConverter`1
// Assembly: Newtonsoft.Json, Version=12.0.0.0, Culture=neutral, PublicKeyToken=30ad4fe6b2a6aeed
// MVID: A4A4D6C6-3EFA-4DC8-AAEA-DA1EC7F2D4DE
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\Newtonsoft.Json.dll

using Newtonsoft.Json.Utilities;
using System;
using System.Globalization;

namespace Newtonsoft.Json
{
  public abstract class JsonConverter<T> : JsonConverter
  {
    public override sealed void WriteJson(
      JsonWriter writer,
      object value,
      JsonSerializer serializer)
    {
      if ((value != null ? (value is T ? 1 : 0) : (ReflectionUtils.IsNullable(typeof (T)) ? 1 : 0)) == 0)
        throw new JsonSerializationException("Converter cannot write specified value to JSON. {0} is required.".FormatWith((IFormatProvider) CultureInfo.InvariantCulture, (object) typeof (T)));
      this.WriteJson(writer, (T) value, serializer);
    }

    public abstract void WriteJson(JsonWriter writer, T value, JsonSerializer serializer);

    public override sealed object ReadJson(
      JsonReader reader,
      Type objectType,
      object existingValue,
      JsonSerializer serializer)
    {
      bool flag = existingValue == null;
      if (!flag && !(existingValue is T))
        throw new JsonSerializationException("Converter cannot read JSON with the specified existing value. {0} is required.".FormatWith((IFormatProvider) CultureInfo.InvariantCulture, (object) typeof (T)));
      return (object) this.ReadJson(reader, objectType, flag ? default (T) : (T) existingValue, !flag, serializer);
    }

    public abstract T ReadJson(
      JsonReader reader,
      Type objectType,
      T existingValue,
      bool hasExistingValue,
      JsonSerializer serializer);

    public override sealed bool CanConvert(Type objectType) => typeof (T).IsAssignableFrom(objectType);
  }
}
