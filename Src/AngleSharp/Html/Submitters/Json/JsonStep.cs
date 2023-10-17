// Decompiled with JetBrains decompiler
// Type: AngleSharp.Html.Submitters.Json.JsonStep
// Assembly: AngleSharp, Version=0.9.9.0, Culture=neutral, PublicKeyToken=e83494dcdc6d31ea
// MVID: 6D8FC1AC-F585-421F-BEC1-9105A73220DF
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\AngleSharp.dll

using AngleSharp.Extensions;
using System.Collections.Generic;

namespace AngleSharp.Html.Submitters.Json
{
  internal abstract class JsonStep
  {
    public bool Append { get; set; }

    public JsonStep Next { get; set; }

    public static IEnumerable<JsonStep> Parse(string path)
    {
      List<JsonStep> jsonStepList = new List<JsonStep>();
      int num = 0;
      while (num < path.Length && path[num] != '[')
        ++num;
      if (num == 0)
        return JsonStep.FailedJsonSteps(path);
      jsonStepList.Add((JsonStep) new JsonStep.ObjectStep(path.Substring(0, num)));
      while (num < path.Length)
      {
        if (num + 1 >= path.Length || path[num] != '[')
          return JsonStep.FailedJsonSteps(path);
        if (path[num + 1] == ']')
        {
          jsonStepList[jsonStepList.Count - 1].Append = true;
          num += 2;
          if (num < path.Length)
            return JsonStep.FailedJsonSteps(path);
        }
        else if (path[num + 1].IsDigit())
        {
          int index;
          int startIndex;
          for (startIndex = index = num + 1; index < path.Length && path[index] != ']'; ++index)
          {
            if (!path[index].IsDigit())
              return JsonStep.FailedJsonSteps(path);
          }
          if (index == path.Length)
            return JsonStep.FailedJsonSteps(path);
          jsonStepList.Add((JsonStep) new JsonStep.ArrayStep(path.Substring(startIndex, index - startIndex).ToInteger(0)));
          num = index + 1;
        }
        else
        {
          int index;
          int startIndex = index = num + 1;
          while (index < path.Length && path[index] != ']')
            ++index;
          if (index == path.Length)
            return JsonStep.FailedJsonSteps(path);
          jsonStepList.Add((JsonStep) new JsonStep.ObjectStep(path.Substring(startIndex, index - startIndex)));
          num = index + 1;
        }
      }
      int index1 = 0;
      for (int index2 = jsonStepList.Count - 1; index1 < index2; ++index1)
        jsonStepList[index1].Next = jsonStepList[index1 + 1];
      return (IEnumerable<JsonStep>) jsonStepList;
    }

    private static IEnumerable<JsonStep> FailedJsonSteps(string original) => (IEnumerable<JsonStep>) new JsonStep.ObjectStep[1]
    {
      new JsonStep.ObjectStep(original)
    };

    protected abstract JsonElement CreateElement();

    protected abstract JsonElement SetValue(JsonElement context, JsonElement value);

    protected abstract JsonElement GetValue(JsonElement context);

    protected abstract JsonElement ConvertArray(JsonArray value);

    public JsonElement Run(JsonElement context, JsonElement value, bool file = false) => this.Next == null ? this.JsonEncodeLastValue(context, value, file) : this.JsonEncodeValue(context, value, file);

    private JsonElement JsonEncodeValue(JsonElement context, JsonElement value, bool file)
    {
      JsonElement jsonElement = this.GetValue(context);
      switch (jsonElement)
      {
        case null:
          JsonElement element = this.Next.CreateElement();
          return this.SetValue(context, element);
        case JsonObject _:
          return jsonElement;
        case JsonArray _:
          return this.SetValue(context, this.Next.ConvertArray((JsonArray) jsonElement));
        default:
          JsonObject jsonObject1 = new JsonObject();
          jsonObject1[string.Empty] = jsonElement;
          JsonObject jsonObject2 = jsonObject1;
          return this.SetValue(context, (JsonElement) jsonObject2);
      }
    }

    private JsonElement JsonEncodeLastValue(JsonElement context, JsonElement value, bool file)
    {
      JsonElement jsonElement = this.GetValue(context);
      switch (jsonElement)
      {
        case null:
          if (this.Append)
          {
            JsonArray jsonArray = new JsonArray();
            jsonArray.Push(value);
            value = (JsonElement) jsonArray;
          }
          this.SetValue(context, value);
          break;
        case JsonArray _:
          ((JsonArray) jsonElement).Push(value);
          break;
        case JsonObject _:
          if (!file)
            return new JsonStep.ObjectStep(string.Empty).JsonEncodeLastValue(jsonElement, value, true);
          goto default;
        default:
          JsonArray jsonArray1 = new JsonArray();
          jsonArray1.Push(jsonElement);
          jsonArray1.Push(value);
          this.SetValue(context, (JsonElement) jsonArray1);
          break;
      }
      return context;
    }

    private sealed class ObjectStep : JsonStep
    {
      public ObjectStep(string key) => this.Key = key;

      public string Key { get; private set; }

      protected override JsonElement GetValue(JsonElement context) => context[this.Key];

      protected override JsonElement SetValue(JsonElement context, JsonElement value)
      {
        context[this.Key] = value;
        return value;
      }

      protected override JsonElement CreateElement() => (JsonElement) new JsonObject();

      protected override JsonElement ConvertArray(JsonArray values)
      {
        JsonObject jsonObject = new JsonObject();
        for (int key = 0; key < values.Length; ++key)
        {
          JsonElement jsonElement = values[key];
          if (jsonElement != null)
            jsonObject[key.ToString()] = jsonElement;
        }
        return (JsonElement) jsonObject;
      }
    }

    private sealed class ArrayStep : JsonStep
    {
      public ArrayStep(int key) => this.Key = key;

      public int Key { get; private set; }

      protected override JsonElement GetValue(JsonElement context) => !(context is JsonArray jsonArray) ? context[this.Key.ToString()] : jsonArray[this.Key];

      protected override JsonElement SetValue(JsonElement context, JsonElement value)
      {
        if (context is JsonArray jsonArray)
          jsonArray[this.Key] = value;
        else
          context[this.Key.ToString()] = value;
        return value;
      }

      protected override JsonElement CreateElement() => (JsonElement) new JsonArray();

      protected override JsonElement ConvertArray(JsonArray value) => (JsonElement) value;
    }
  }
}
