// Decompiled with JetBrains decompiler
// Type: AngleSharp.Dom.Collections.SettableTokenList
// Assembly: AngleSharp, Version=0.9.9.0, Culture=neutral, PublicKeyToken=e83494dcdc6d31ea
// MVID: 6D8FC1AC-F585-421F-BEC1-9105A73220DF
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\AngleSharp.dll

using System.Collections;
using System.Collections.Generic;

namespace AngleSharp.Dom.Collections
{
  internal sealed class SettableTokenList : 
    TokenList,
    ISettableTokenList,
    ITokenList,
    IEnumerable<string>,
    IEnumerable
  {
    internal SettableTokenList(string value)
      : base(value)
    {
    }

    public string Value
    {
      get => this.ToString();
      set => this.Update(value);
    }
  }
}
