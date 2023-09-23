// Decompiled with JetBrains decompiler
// Type: AngleSharp.Html.InputTypes.ColorInputType
// Assembly: AngleSharp, Version=0.9.9.0, Culture=neutral, PublicKeyToken=e83494dcdc6d31ea
// MVID: 6D8FC1AC-F585-421F-BEC1-9105A73220DF
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\AngleSharp.dll

using AngleSharp.Dom.Html;
using System.Text.RegularExpressions;

namespace AngleSharp.Html.InputTypes
{
  internal class ColorInputType : BaseInputType
  {
    private static readonly Regex color = new Regex("^\\#[0-9A-Fa-f]{6}$");

    public ColorInputType(IHtmlInputElement input, string name)
      : base(input, name, true)
    {
    }

    public override void Check(ValidityState state)
    {
      string input = this.Input.Value ?? string.Empty;
      state.IsBadInput = !ColorInputType.color.IsMatch(input);
      state.IsValueMissing = this.Input.IsRequired && state.IsBadInput;
    }
  }
}
