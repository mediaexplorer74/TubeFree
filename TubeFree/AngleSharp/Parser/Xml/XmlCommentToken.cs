﻿// Decompiled with JetBrains decompiler
// Type: AngleSharp.Parser.Xml.XmlCommentToken
// Assembly: AngleSharp, Version=0.9.9.0, Culture=neutral, PublicKeyToken=e83494dcdc6d31ea
// MVID: 6D8FC1AC-F585-421F-BEC1-9105A73220DF
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\AngleSharp.dll

namespace AngleSharp.Parser.Xml
{
  internal sealed class XmlCommentToken : XmlToken
  {
    private readonly string _data;

    public XmlCommentToken(TextPosition position)
      : this(position, string.Empty)
    {
    }

    public XmlCommentToken(TextPosition position, string data)
      : base(XmlTokenType.Comment, position)
    {
      this._data = data;
    }

    public string Data => this._data;
  }
}
