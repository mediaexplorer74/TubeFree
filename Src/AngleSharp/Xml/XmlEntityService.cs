// Decompiled with JetBrains decompiler
// Type: AngleSharp.Xml.XmlEntityService
// Assembly: AngleSharp, Version=0.9.9.0, Culture=neutral, PublicKeyToken=e83494dcdc6d31ea
// MVID: 6D8FC1AC-F585-421F-BEC1-9105A73220DF
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\AngleSharp.dll

using AngleSharp.Services;
using System.Collections.Generic;

namespace AngleSharp.Xml
{
  public sealed class XmlEntityService : IEntityProvider
  {
    private readonly Dictionary<string, string> _entities = new Dictionary<string, string>()
    {
      {
        "amp",
        "&"
      },
      {
        "lt",
        "<"
      },
      {
        "gt",
        ">"
      },
      {
        "apos",
        "'"
      },
      {
        "quot",
        "\""
      }
    };
    public static readonly IEntityProvider Resolver = (IEntityProvider) new XmlEntityService();

    private XmlEntityService()
    {
    }

    public string GetSymbol(string name)
    {
      string empty = string.Empty;
      if (!string.IsNullOrEmpty(name))
        this._entities.TryGetValue(name, out empty);
      return empty;
    }
  }
}
