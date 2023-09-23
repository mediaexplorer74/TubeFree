// Decompiled with JetBrains decompiler
// Type: AngleSharp.Services.ISpellCheckService
// Assembly: AngleSharp, Version=0.9.9.0, Culture=neutral, PublicKeyToken=e83494dcdc6d31ea
// MVID: 6D8FC1AC-F585-421F-BEC1-9105A73220DF
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\AngleSharp.dll

using System.Collections.Generic;
using System.Globalization;

namespace AngleSharp.Services
{
  public interface ISpellCheckService
  {
    CultureInfo Culture { get; }

    void Ignore(string word, bool persistent);

    bool IsCorrect(string word);

    IEnumerable<string> SuggestFor(string word);
  }
}
