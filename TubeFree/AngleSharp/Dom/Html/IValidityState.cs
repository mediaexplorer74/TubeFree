// Decompiled with JetBrains decompiler
// Type: AngleSharp.Dom.Html.IValidityState
// Assembly: AngleSharp, Version=0.9.9.0, Culture=neutral, PublicKeyToken=e83494dcdc6d31ea
// MVID: 6D8FC1AC-F585-421F-BEC1-9105A73220DF
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\AngleSharp.dll

using AngleSharp.Attributes;

namespace AngleSharp.Dom.Html
{
  [DomName("ValidityState")]
  public interface IValidityState
  {
    [DomName("valueMissing")]
    bool IsValueMissing { get; }

    [DomName("typeMismatch")]
    bool IsTypeMismatch { get; }

    [DomName("patternMismatch")]
    bool IsPatternMismatch { get; }

    [DomName("tooLong")]
    bool IsTooLong { get; }

    [DomName("tooShort")]
    bool IsTooShort { get; }

    [DomName("badInput")]
    bool IsBadInput { get; }

    [DomName("rangeUnderflow")]
    bool IsRangeUnderflow { get; }

    [DomName("rangeOverflow")]
    bool IsRangeOverflow { get; }

    [DomName("stepMismatch")]
    bool IsStepMismatch { get; }

    [DomName("customError")]
    bool IsCustomError { get; }

    [DomName("valid")]
    bool IsValid { get; }
  }
}
