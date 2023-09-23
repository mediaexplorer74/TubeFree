// Decompiled with JetBrains decompiler
// Type: AngleSharp.Html.InputTypes.ButtonInputType
// Assembly: AngleSharp, Version=0.9.9.0, Culture=neutral, PublicKeyToken=e83494dcdc6d31ea
// MVID: 6D8FC1AC-F585-421F-BEC1-9105A73220DF
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\AngleSharp.dll

using AngleSharp.Dom.Html;
using AngleSharp.Extensions;

namespace AngleSharp.Html.InputTypes
{
  internal class ButtonInputType : BaseInputType
  {
    public ButtonInputType(IHtmlInputElement input, string name)
      : base(input, name, false)
    {
    }

    public override bool IsAppendingData(IHtmlElement submitter) => !this.Name.Is(InputTypeNames.Reset) || submitter == this.Input;
  }
}
