// Decompiled with JetBrains decompiler
// Type: AngleSharp.Dom.Collections.TokenList
// Assembly: AngleSharp, Version=0.9.9.0, Culture=neutral, PublicKeyToken=e83494dcdc6d31ea
// MVID: 6D8FC1AC-F585-421F-BEC1-9105A73220DF
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\AngleSharp.dll

using AngleSharp.Extensions;
using System;
using System.Collections;
using System.Collections.Generic;

namespace AngleSharp.Dom.Collections
{
  internal class TokenList : ITokenList, IEnumerable<string>, IEnumerable, IBindable
  {
    private readonly List<string> _tokens;

    public event Action<string> Changed;

    internal TokenList(string value)
    {
      this._tokens = new List<string>();
      this.Update(value);
    }

    public string this[int index] => this._tokens[index];

    public int Length => this._tokens.Count;

    public void Update(string value)
    {
      this._tokens.Clear();
      if (string.IsNullOrEmpty(value))
        return;
      string[] strArray = value.SplitSpaces();
      for (int index = 0; index < strArray.Length; ++index)
      {
        if (!this._tokens.Contains(strArray[index]))
          this._tokens.Add(strArray[index]);
      }
    }

    public bool Contains(string token) => this._tokens.Contains(token);

    public void Remove(params string[] tokens)
    {
      bool flag = false;
      foreach (string token in tokens)
      {
        if (this._tokens.Contains(token))
        {
          this._tokens.Remove(token);
          flag = true;
        }
      }
      if (!flag)
        return;
      this.RaiseChanged();
    }

    public void Add(params string[] tokens)
    {
      bool flag = false;
      foreach (string token in tokens)
      {
        if (!this._tokens.Contains(token))
        {
          this._tokens.Add(token);
          flag = true;
        }
      }
      if (!flag)
        return;
      this.RaiseChanged();
    }

    public bool Toggle(string token, bool force = false)
    {
      bool flag = this._tokens.Contains(token);
      if (flag & force)
        return true;
      if (flag)
        this._tokens.Remove(token);
      else
        this._tokens.Add(token);
      this.RaiseChanged();
      return !flag;
    }

    private void RaiseChanged()
    {
      Action<string> changed = this.Changed;
      if (changed == null)
        return;
      changed(this.ToString());
    }

    public IEnumerator<string> GetEnumerator() => (IEnumerator<string>) this._tokens.GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator() => (IEnumerator) this.GetEnumerator();

    public override string ToString() => string.Join(" ", (IEnumerable<string>) this._tokens);
  }
}
