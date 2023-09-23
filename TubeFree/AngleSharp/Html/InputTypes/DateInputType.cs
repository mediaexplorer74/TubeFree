// Decompiled with JetBrains decompiler
// Type: AngleSharp.Html.InputTypes.DateInputType
// Assembly: AngleSharp, Version=0.9.9.0, Culture=neutral, PublicKeyToken=e83494dcdc6d31ea
// MVID: 6D8FC1AC-F585-421F-BEC1-9105A73220DF
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\AngleSharp.dll

using AngleSharp.Dom.Html;
using AngleSharp.Extensions;
using System;
using System.Globalization;

namespace AngleSharp.Html.InputTypes
{
  internal class DateInputType : BaseInputType
  {
    public DateInputType(IHtmlInputElement input, string name)
      : base(input, name, true)
    {
    }

    public override void Check(ValidityState state)
    {
      string str = this.Input.Value;
      DateTime? nullable1 = DateInputType.ConvertFromDate(str);
      if (nullable1.HasValue)
      {
        DateTime? nullable2 = DateInputType.ConvertFromDate(this.Input.Minimum);
        DateTime? nullable3 = DateInputType.ConvertFromDate(this.Input.Maximum);
        ValidityState validityState1 = state;
        int num1;
        if (nullable2.HasValue)
        {
          DateTime? nullable4 = nullable1;
          DateTime dateTime = nullable2.Value;
          num1 = nullable4.HasValue ? (nullable4.GetValueOrDefault() < dateTime ? 1 : 0) : 0;
        }
        else
          num1 = 0;
        validityState1.IsRangeUnderflow = num1 != 0;
        ValidityState validityState2 = state;
        int num2;
        if (nullable3.HasValue)
        {
          DateTime? nullable5 = nullable1;
          DateTime dateTime = nullable3.Value;
          num2 = nullable5.HasValue ? (nullable5.GetValueOrDefault() > dateTime ? 1 : 0) : 0;
        }
        else
          num2 = 0;
        validityState2.IsRangeOverflow = num2 != 0;
        state.IsValueMissing = false;
        state.IsBadInput = false;
        state.IsStepMismatch = this.IsStepMismatch();
      }
      else
      {
        state.IsRangeUnderflow = false;
        state.IsRangeOverflow = false;
        state.IsStepMismatch = false;
        state.IsValueMissing = this.Input.IsRequired;
        state.IsBadInput = !string.IsNullOrEmpty(str);
      }
    }

    public override double? ConvertToNumber(string value)
    {
      DateTime? nullable = DateInputType.ConvertFromDate(value);
      return nullable.HasValue ? new double?(nullable.Value.Subtract(BaseInputType.UnixEpoch).TotalMilliseconds) : new double?();
    }

    public override string ConvertFromNumber(double value) => this.ConvertFromDate(BaseInputType.UnixEpoch.AddMilliseconds(value));

    public override DateTime? ConvertToDate(string value) => DateInputType.ConvertFromDate(value);

    public override string ConvertFromDate(DateTime value) => string.Format((IFormatProvider) CultureInfo.InvariantCulture, "{0:0000}-{1:00}-{2:00}", (object) value.Year, (object) value.Month, (object) value.Day);

    public override void DoStep(int n)
    {
      DateTime? nullable1 = DateInputType.ConvertFromDate(this.Input.Value);
      if (!nullable1.HasValue)
        return;
      DateTime dateTime = nullable1.Value.AddMilliseconds(this.GetStep() * (double) n);
      DateTime? nullable2 = DateInputType.ConvertFromDate(this.Input.Minimum);
      DateTime? nullable3 = DateInputType.ConvertFromDate(this.Input.Maximum);
      if (nullable2.HasValue && !(nullable2.Value <= dateTime) || nullable3.HasValue && !(nullable3.Value >= dateTime))
        return;
      this.Input.ValueAsDate = new DateTime?(dateTime);
    }

    protected override double GetDefaultStepBase() => 0.0;

    protected override double GetDefaultStep() => 1.0;

    protected override double GetStepScaleFactor() => 86400000.0;

    protected static DateTime? ConvertFromDate(string value)
    {
      if (!string.IsNullOrEmpty(value))
      {
        int num = BaseInputType.FetchDigits(value);
        if (DateInputType.IsLegalPosition(value, num))
        {
          int year = int.Parse(value.Substring(0, num));
          int month = int.Parse(value.Substring(num + 1, 2));
          int day = int.Parse(value.Substring(num + 4, 2));
          if (BaseInputType.IsLegalDay(day, month, year))
            return new DateTime?(new DateTime(year, month, day, 0, 0, 0, 0, DateTimeKind.Utc));
        }
      }
      return new DateTime?();
    }

    private static bool IsLegalPosition(string value, int position) => position >= 4 && position == value.Length - 6 && value[position] == '-' && value[position + 1].IsDigit() && value[position + 2].IsDigit() && value[position + 3] == '-' && value[position + 4].IsDigit() && value[position + 5].IsDigit();
  }
}
