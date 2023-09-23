// Decompiled with JetBrains decompiler
// Type: AngleSharp.Html.Submitters.Json.JsonObject
// Assembly: AngleSharp, Version=0.9.9.0, Culture=neutral, PublicKeyToken=e83494dcdc6d31ea
// MVID: 6D8FC1AC-F585-421F-BEC1-9105A73220DF
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\AngleSharp.dll

using System.Collections.Generic;
using System.Text;

namespace AngleSharp.Html.Submitters.Json
{
  internal sealed class JsonObject : JsonElement
  {
    private readonly Dictionary<string, JsonElement> _properties;

    public JsonObject() => this._properties = new Dictionary<string, JsonElement>();

    public override JsonElement this[string key]
    {
      get
      {
        JsonElement jsonElement = (JsonElement) null;
        this._properties.TryGetValue(key.ToString(), out jsonElement);
        return jsonElement;
      }
      set => this._properties[key] = value;
    }

    public override string ToString()
    {
      StringBuilder stringBuilder = Pool.NewStringBuilder().Append('{');
      bool flag = false;
      foreach (KeyValuePair<string, JsonElement> property in this._properties)
      {
        if (flag)
          stringBuilder.Append(',');
        stringBuilder.Append('"').Append(property.Key).Append('"');
        stringBuilder.Append(':').Append(property.Value.ToString());
        flag = true;
      }
      return stringBuilder.Append('}').ToPool();
    }
  }
}
