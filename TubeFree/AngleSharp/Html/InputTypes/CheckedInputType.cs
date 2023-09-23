// Decompiled with JetBrains decompiler
// Type: AngleSharp.Html.InputTypes.CheckedInputType
// Assembly: AngleSharp, Version=0.9.9.0, Culture=neutral, PublicKeyToken=e83494dcdc6d31ea
// MVID: 6D8FC1AC-F585-421F-BEC1-9105A73220DF
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\AngleSharp.dll

using AngleSharp.Dom.Html;

namespace AngleSharp.Html.InputTypes
{
  internal class CheckedInputType : BaseInputType
  {
    public CheckedInputType(IHtmlInputElement input, string name)
      : base(input, name, true)
    {
    }

    public override void Check(ValidityState state) => state.IsValueMissing = this.Input.IsRequired && !this.Input.IsChecked;

    public override void ConstructDataSet(FormDataSet dataSet)
    {
      if (!this.Input.IsChecked)
        return;
      string str = this.Input.HasValue ? this.Input.Value : Keywords.On;
      dataSet.Append(this.Input.Name, str, this.Input.Type);
    }
  }
}
