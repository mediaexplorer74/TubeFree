// Decompiled with JetBrains decompiler
// Type: AngleSharp.Dom.Collections.StringList
// Assembly: AngleSharp, Version=0.9.9.0, Culture=neutral, PublicKeyToken=e83494dcdc6d31ea
// MVID: 6D8FC1AC-F585-421F-BEC1-9105A73220DF
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\AngleSharp.dll

using AngleSharp.Extensions;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace AngleSharp.Dom.Collections
{
  internal sealed class StringList : IStringList, IEnumerable<string>, IEnumerable
  {
    private readonly IEnumerable<string> _list;

    internal StringList(IEnumerable<string> list) => this._list = list;

    public string this[int index] => this._list.GetItemByIndex<string>(index);

    public int Length => this._list.Count<string>();

    public bool Contains(string entry) => this._list.Contains<string>(entry);

    public IEnumerator<string> GetEnumerator() => this._list.GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator() => (IEnumerator) this._list.GetEnumerator();
  }
}
