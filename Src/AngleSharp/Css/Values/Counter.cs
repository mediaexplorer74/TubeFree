// Decompiled with JetBrains decompiler
// Type: AngleSharp.Css.Values.Counter
// Assembly: AngleSharp, Version=0.9.9.0, Culture=neutral, PublicKeyToken=e83494dcdc6d31ea
// MVID: 6D8FC1AC-F585-421F-BEC1-9105A73220DF
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\AngleSharp.dll

namespace AngleSharp.Css.Values
{
  public sealed class Counter
  {
    private readonly string _identifier;
    private readonly string _listStyle;
    private readonly string _separator;

    public Counter(string identifier, string listStyle, string separator)
    {
      this._identifier = identifier;
      this._listStyle = listStyle;
      this._separator = separator;
    }

    public string CounterIdentifier => this._identifier;

    public string ListStyle => this._listStyle;

    public string DefinedSeparator => this._separator;
  }
}
