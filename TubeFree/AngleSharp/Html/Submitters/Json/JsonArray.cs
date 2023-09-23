// Decompiled with JetBrains decompiler
// Type: AngleSharp.Html.Submitters.Json.JsonArray
// Assembly: AngleSharp, Version=0.9.9.0, Culture=neutral, PublicKeyToken=e83494dcdc6d31ea
// MVID: 6D8FC1AC-F585-421F-BEC1-9105A73220DF
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\AngleSharp.dll

using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AngleSharp.Html.Submitters.Json
{
  internal sealed class JsonArray : JsonElement, IEnumerable<JsonElement>, IEnumerable
  {
    private readonly List<JsonElement> _elements;

    public JsonArray() => this._elements = new List<JsonElement>();

    public int Length => this._elements.Count;

    public void Push(JsonElement element) => this._elements.Add(element);

    public JsonElement this[int key]
    {
      get => this._elements.ElementAtOrDefault<JsonElement>(key);
      set
      {
        for (int count = this._elements.Count; count <= key; ++count)
          this._elements.Add((JsonElement) null);
        this._elements[key] = value;
      }
    }

    public override string ToString()
    {
      StringBuilder stringBuilder = Pool.NewStringBuilder().Append('[');
      bool flag = false;
      foreach (JsonElement element in this._elements)
      {
        if (flag)
          stringBuilder.Append(',');
        stringBuilder.Append(element?.ToString() ?? "null");
        flag = true;
      }
      return stringBuilder.Append(']').ToPool();
    }

    public IEnumerator<JsonElement> GetEnumerator() => (IEnumerator<JsonElement>) this._elements.GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator() => (IEnumerator) this.GetEnumerator();
  }
}
