// Decompiled with JetBrains decompiler
// Type: AngleSharp.Dom.Io.FileList
// Assembly: AngleSharp, Version=0.9.9.0, Culture=neutral, PublicKeyToken=e83494dcdc6d31ea
// MVID: 6D8FC1AC-F585-421F-BEC1-9105A73220DF
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\AngleSharp.dll

using System.Collections;
using System.Collections.Generic;

namespace AngleSharp.Dom.Io
{
  internal sealed class FileList : IFileList, IEnumerable<IFile>, IEnumerable
  {
    private readonly List<IFile> _entries;

    internal FileList() => this._entries = new List<IFile>();

    public IFile this[int index] => this._entries[index];

    public int Length => this._entries.Count;

    public void Add(IFile item) => this._entries.Add(item);

    public void Clear() => this._entries.Clear();

    public bool Remove(IFile item) => this._entries.Remove(item);

    public IEnumerator<IFile> GetEnumerator() => (IEnumerator<IFile>) this._entries.GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator() => (IEnumerator) this.GetEnumerator();
  }
}
