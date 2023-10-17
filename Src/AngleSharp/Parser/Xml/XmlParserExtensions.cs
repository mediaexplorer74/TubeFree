// Decompiled with JetBrains decompiler
// Type: AngleSharp.Parser.Xml.XmlParserExtensions
// Assembly: AngleSharp, Version=0.9.9.0, Culture=neutral, PublicKeyToken=e83494dcdc6d31ea
// MVID: 6D8FC1AC-F585-421F-BEC1-9105A73220DF
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\AngleSharp.dll

namespace AngleSharp.Parser.Xml
{
  internal static class XmlParserExtensions
  {
    public static XmlParseException At(this XmlParseError code, TextPosition position)
    {
      string message = "Error while parsing the provided XML document.";
      return new XmlParseException(code.GetCode(), message, position);
    }

    public static int GetCode(this XmlParseError code) => (int) code;
  }
}
