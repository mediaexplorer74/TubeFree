// Decompiled with JetBrains decompiler
// Type: AngleSharp.Html.InputTypes.UrlInputType
// Assembly: AngleSharp, Version=0.9.9.0, Culture=neutral, PublicKeyToken=e83494dcdc6d31ea
// MVID: 6D8FC1AC-F585-421F-BEC1-9105A73220DF
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\AngleSharp.dll

using AngleSharp.Dom.Html;

namespace AngleSharp.Html.InputTypes
{
  internal class UrlInputType : BaseInputType
  {
    public UrlInputType(IHtmlInputElement input, string name)
      : base(input, name, true)
    {
    }

    public override void Check(ValidityState state)
    {
      string str = this.Input.Value ?? string.Empty;
      state.IsPatternMismatch = BaseInputType.IsInvalidPattern(this.Input.Pattern, str);
      if (!UrlInputType.IsInvalidUrl(str))
        return;
      state.IsTypeMismatch = !string.IsNullOrEmpty(str);
      state.IsBadInput = state.IsTypeMismatch;
    }

    private static bool IsInvalidUrl(string value)
    {
      if (string.IsNullOrEmpty(value))
        return false;
      Url url = new Url(value);
      return url.IsInvalid || url.IsRelative;
    }
  }
}
