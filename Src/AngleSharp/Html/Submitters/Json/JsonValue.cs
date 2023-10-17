// Decompiled with JetBrains decompiler
// Type: AngleSharp.Html.Submitters.Json.JsonValue
// Assembly: AngleSharp, Version=0.9.9.0, Culture=neutral, PublicKeyToken=e83494dcdc6d31ea
// MVID: 6D8FC1AC-F585-421F-BEC1-9105A73220DF
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\AngleSharp.dll

using AngleSharp.Extensions;
using System;
using System.Globalization;

namespace AngleSharp.Html.Submitters.Json
{
  internal sealed class JsonValue : JsonElement
  {
    private readonly string _value;

    public JsonValue(string value) => this._value = value.CssString();

    public JsonValue(double value) => this._value = value.ToString((IFormatProvider) CultureInfo.InvariantCulture);

    public JsonValue(bool value) => this._value = value ? "true" : "false";

    public override string ToString() => this._value;
  }
}
