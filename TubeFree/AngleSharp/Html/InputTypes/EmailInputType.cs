// Decompiled with JetBrains decompiler
// Type: AngleSharp.Html.InputTypes.EmailInputType
// Assembly: AngleSharp, Version=0.9.9.0, Culture=neutral, PublicKeyToken=e83494dcdc6d31ea
// MVID: 6D8FC1AC-F585-421F-BEC1-9105A73220DF
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\AngleSharp.dll

using AngleSharp.Dom.Html;
using System.Text.RegularExpressions;

namespace AngleSharp.Html.InputTypes
{
  internal class EmailInputType : BaseInputType
  {
    private static readonly Regex email = new Regex("^[a-zA-Z0-9.!#$%&'*+/=?^_`{|}~-]+@[a-zA-Z0-9](?:[a-zA-Z0-9-]{0,61}[a-zA-Z0-9])?(?:\\.[a-zA-Z0-9](?:[a-zA-Z0-9-]{0,61}[a-zA-Z0-9])?)*$");

    public EmailInputType(IHtmlInputElement input, string name)
      : base(input, name, true)
    {
    }

    public override void Check(ValidityState state)
    {
      string str = this.Input.Value ?? string.Empty;
      state.IsPatternMismatch = BaseInputType.IsInvalidPattern(this.Input.Pattern, str);
      if (!EmailInputType.IsInvalidEmail(this.Input.IsMultiple, str))
        return;
      state.IsTypeMismatch = !string.IsNullOrEmpty(str);
      state.IsBadInput = state.IsTypeMismatch;
    }

    private static bool IsInvalidEmail(bool multiple, string value)
    {
      if (!multiple)
        return !EmailInputType.email.IsMatch(value.Trim());
      string str1 = value;
      char[] chArray = new char[1]{ ',' };
      foreach (string str2 in str1.Split(chArray))
      {
        if (!EmailInputType.email.IsMatch(str2.Trim()))
          return true;
      }
      return false;
    }
  }
}
