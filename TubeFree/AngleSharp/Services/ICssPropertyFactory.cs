// Decompiled with JetBrains decompiler
// Type: AngleSharp.Services.ICssPropertyFactory
// Assembly: AngleSharp, Version=0.9.9.0, Culture=neutral, PublicKeyToken=e83494dcdc6d31ea
// MVID: 6D8FC1AC-F585-421F-BEC1-9105A73220DF
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\AngleSharp.dll

using AngleSharp.Dom.Css;
using System.Collections.Generic;

namespace AngleSharp.Services
{
  internal interface ICssPropertyFactory
  {
    CssProperty Create(string name);

    CssProperty CreateFont(string name);

    CssProperty CreateLonghand(string name);

    CssProperty[] CreateLonghandsFor(string name);

    CssShorthandProperty CreateShorthand(string name);

    CssProperty CreateViewport(string name);

    string[] GetLonghands(string name);

    IEnumerable<string> GetShorthands(string name);

    bool IsAnimatable(string name);

    bool IsLonghand(string name);

    bool IsShorthand(string name);
  }
}
