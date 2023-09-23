// Decompiled with JetBrains decompiler
// Type: AngleSharp.Parser.Html.HtmlToken
// Assembly: AngleSharp, Version=0.9.9.0, Culture=neutral, PublicKeyToken=e83494dcdc6d31ea
// MVID: 6D8FC1AC-F585-421F-BEC1-9105A73220DF
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\AngleSharp.dll

using AngleSharp.Extensions;
using AngleSharp.Html;

namespace AngleSharp.Parser.Html
{
  public class HtmlToken
  {
    private readonly HtmlTokenType _type;
    private readonly TextPosition _position;
    private string _name;

    public HtmlToken(HtmlTokenType type, TextPosition position, string name = null)
    {
      this._type = type;
      this._position = position;
      this._name = name;
    }

    public bool IsEmpty => string.IsNullOrEmpty(this._name);

    public bool HasContent
    {
      get
      {
        for (int index = 0; index < this._name.Length; ++index)
        {
          if (!this._name[index].IsSpaceCharacter())
            return true;
        }
        return false;
      }
    }

    public string Name
    {
      get => this._name;
      set => this._name = value;
    }

    public string Data => this._name;

    public TextPosition Position => this._position;

    public bool IsHtmlCompatible => this._type == HtmlTokenType.StartTag || this._type == HtmlTokenType.Character;

    public bool IsSvg => this.IsStartTag(TagNames.Svg);

    public bool IsMathCompatible => !this.IsStartTag("mglyph") && !this.IsStartTag("malignmark") || this._type == HtmlTokenType.Character;

    public HtmlTokenType Type => this._type;

    public string TrimStart()
    {
      int num = 0;
      while (num < this._name.Length && this._name[num].IsSpaceCharacter())
        ++num;
      string str = this._name.Substring(0, num);
      this._name = this._name.Substring(num);
      return str;
    }

    public void RemoveNewLine()
    {
      if (!this._name.Has('\n'))
        return;
      this._name = this._name.Substring(1);
    }

    public HtmlTagToken AsTag() => (HtmlTagToken) this;

    public bool IsStartTag(string name) => this._type == HtmlTokenType.StartTag && this._name.Is(name);
  }
}
