// Decompiled with JetBrains decompiler
// Type: AngleSharp.Html.InputTypes.TextInputType
// Assembly: AngleSharp, Version=0.9.9.0, Culture=neutral, PublicKeyToken=e83494dcdc6d31ea
// MVID: 6D8FC1AC-F585-421F-BEC1-9105A73220DF
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\AngleSharp.dll

using AngleSharp.Dom.Html;

namespace AngleSharp.Html.InputTypes
{
  internal class TextInputType : BaseInputType
  {
    public TextInputType(IHtmlInputElement input, string name)
      : base(input, name, true)
    {
    }

    public override void Check(ValidityState state)
    {
      string str = this.Input.Value ?? string.Empty;
      state.IsPatternMismatch = BaseInputType.IsInvalidPattern(this.Input.Pattern, str);
    }

    public override void ConstructDataSet(FormDataSet dataSet)
    {
      base.ConstructDataSet(dataSet);
      string attribute = this.Input.GetAttribute((string) null, AttributeNames.DirName);
      if (string.IsNullOrEmpty(attribute))
        return;
      dataSet.Append(attribute, this.Input.Direction.ToLowerInvariant(), "Direction");
    }
  }
}
