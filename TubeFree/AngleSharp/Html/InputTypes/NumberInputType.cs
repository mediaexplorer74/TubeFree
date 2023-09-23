// Decompiled with JetBrains decompiler
// Type: AngleSharp.Html.InputTypes.NumberInputType
// Assembly: AngleSharp, Version=0.9.9.0, Culture=neutral, PublicKeyToken=e83494dcdc6d31ea
// MVID: 6D8FC1AC-F585-421F-BEC1-9105A73220DF
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\AngleSharp.dll

using AngleSharp.Dom.Html;
using System;
using System.Globalization;

namespace AngleSharp.Html.InputTypes
{
  internal class NumberInputType : BaseInputType
  {
    public NumberInputType(IHtmlInputElement input, string name)
      : base(input, name, true)
    {
    }

    public override double? ConvertToNumber(string value) => BaseInputType.ToNumber(value);

    public override string ConvertFromNumber(double value) => value.ToString((IFormatProvider) CultureInfo.InvariantCulture);

    public override void Check(ValidityState state)
    {
      double? number1 = this.ConvertToNumber(this.Input.Value);
      state.Reset();
      if (number1.HasValue)
      {
        double? number2 = this.ConvertToNumber(this.Input.Minimum);
        double? number3 = this.ConvertToNumber(this.Input.Maximum);
        ValidityState validityState1 = state;
        double? nullable;
        int num1;
        if (number2.HasValue)
        {
          nullable = number1;
          double num2 = number2.Value;
          num1 = nullable.GetValueOrDefault() < num2 ? (nullable.HasValue ? 1 : 0) : 0;
        }
        else
          num1 = 0;
        validityState1.IsRangeUnderflow = num1 != 0;
        ValidityState validityState2 = state;
        int num3;
        if (number3.HasValue)
        {
          nullable = number1;
          double num4 = number3.Value;
          num3 = nullable.GetValueOrDefault() > num4 ? (nullable.HasValue ? 1 : 0) : 0;
        }
        else
          num3 = 0;
        validityState2.IsRangeOverflow = num3 != 0;
        state.IsValueMissing = false;
        state.IsStepMismatch = this.IsStepMismatch();
      }
      else
      {
        state.IsRangeUnderflow = false;
        state.IsRangeOverflow = false;
        state.IsValueMissing = this.Input.IsRequired;
        state.IsStepMismatch = false;
      }
    }

    public override void DoStep(int n)
    {
      double? number1 = BaseInputType.ToNumber(this.Input.Value);
      if (!number1.HasValue)
        return;
      double num = number1.Value + this.GetStep() * (double) n;
      double? number2 = BaseInputType.ToNumber(this.Input.Minimum);
      double? number3 = BaseInputType.ToNumber(this.Input.Maximum);
      if (number2.HasValue && number2.Value > num || number3.HasValue && number3.Value < num)
        return;
      this.Input.ValueAsNumber = num;
    }

    protected override double GetDefaultStepBase() => 0.0;

    protected override double GetDefaultStep() => 1.0;

    protected override double GetStepScaleFactor() => 1.0;
  }
}
