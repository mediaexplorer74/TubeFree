// Decompiled with JetBrains decompiler
// Type: AngleSharp.Html.Submitters.JsonFormDataSetVisitor
// Assembly: AngleSharp, Version=0.9.9.0, Culture=neutral, PublicKeyToken=e83494dcdc6d31ea
// MVID: 6D8FC1AC-F585-421F-BEC1-9105A73220DF
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\AngleSharp.dll

using AngleSharp.Dom.Io;
using AngleSharp.Extensions;
using AngleSharp.Html.Submitters.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace AngleSharp.Html.Submitters
{
  internal sealed class JsonFormDataSetVisitor : IFormSubmitter, IFormDataSetVisitor
  {
    private readonly JsonObject _context;

    public JsonFormDataSetVisitor() => this._context = new JsonObject();

    public void Text(FormDataSetEntry entry, string value)
    {
      JsonValue jsonValue = JsonFormDataSetVisitor.CreateValue(entry.Type, value);
      IEnumerable<JsonStep> jsonSteps = JsonStep.Parse(entry.Name);
      JsonElement context = (JsonElement) this._context;
      foreach (JsonStep jsonStep in jsonSteps)
        context = jsonStep.Run(context, (JsonElement) jsonValue);
    }

    public void File(FormDataSetEntry entry, string fileName, string contentType, IFile file)
    {
      JsonElement context = (JsonElement) this._context;
      Stream stream = file == null || file.Body == null || file.Type == null ? Stream.Null : file.Body;
      MemoryStream memoryStream = new MemoryStream();
      MemoryStream destination = memoryStream;
      stream.CopyTo((Stream) destination);
      byte[] array = memoryStream.ToArray();
      IEnumerable<JsonStep> jsonSteps = JsonStep.Parse(entry.Name);
      JsonObject jsonObject1 = new JsonObject();
      jsonObject1[AttributeNames.Type] = (JsonElement) new JsonValue(contentType);
      jsonObject1[AttributeNames.Name] = (JsonElement) new JsonValue(fileName);
      jsonObject1[AttributeNames.Body] = (JsonElement) new JsonValue(Convert.ToBase64String(array));
      JsonObject jsonObject2 = jsonObject1;
      foreach (JsonStep jsonStep in jsonSteps)
        context = jsonStep.Run(context, (JsonElement) jsonObject2, true);
    }

    public void Serialize(StreamWriter stream)
    {
      string str = this._context.ToString();
      stream.Write(str);
    }

    private static JsonValue CreateValue(string type, string value)
    {
      if (type.Is(InputTypeNames.Checkbox))
        return new JsonValue(value.Is(Keywords.On));
      return type.Is(InputTypeNames.Number) ? new JsonValue(value.ToDouble()) : new JsonValue(value);
    }
  }
}
