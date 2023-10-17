// Decompiled with JetBrains decompiler
// Type: AngleSharp.Dom.Collections.StringMap
// Assembly: AngleSharp, Version=0.9.9.0, Culture=neutral, PublicKeyToken=e83494dcdc6d31ea
// MVID: 6D8FC1AC-F585-421F-BEC1-9105A73220DF
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\AngleSharp.dll

using AngleSharp.Extensions;
using AngleSharp.Html;
using System;
using System.Collections;
using System.Collections.Generic;

namespace AngleSharp.Dom.Collections
{
  internal sealed class StringMap : 
    IStringMap,
    IEnumerable<KeyValuePair<string, string>>,
    IEnumerable
  {
    private readonly string _prefix;
    private readonly Element _parent;

    internal StringMap(string prefix, Element parent)
    {
      this._prefix = prefix;
      this._parent = parent;
    }

    public string this[string name]
    {
      get => this._parent.GetOwnAttribute(this._prefix + StringMap.Check(name));
      set => this._parent.SetOwnAttribute(this._prefix + StringMap.Check(name), value);
    }

    public void Remove(string name)
    {
      if (!this.Contains(name))
        return;
      this[name] = (string) null;
    }

    public bool Contains(string name) => this._parent.HasOwnAttribute(this._prefix + StringMap.Check(name));

    private static string Check(string name)
    {
      if (name.StartsWith(TagNames.Xml, StringComparison.OrdinalIgnoreCase))
        throw new DomException(DomError.Syntax);
      if (name.IndexOf(';') >= 0)
        throw new DomException(DomError.Syntax);
      for (int index = 0; index < name.Length; ++index)
      {
        if (name[index].IsUppercaseAscii())
          throw new DomException(DomError.Syntax);
      }
      return name;
    }

    public IEnumerator<KeyValuePair<string, string>> GetEnumerator()
    {
      foreach (IAttr attribute in this._parent.Attributes)
      {
        if (attribute.NamespaceUri == null && attribute.Name.StartsWith(this._prefix, StringComparison.OrdinalIgnoreCase))
          yield return new KeyValuePair<string, string>(attribute.Name.Remove(0, this._prefix.Length), attribute.Value);
      }
    }

    IEnumerator IEnumerable.GetEnumerator() => (IEnumerator) this.GetEnumerator();
  }
}
