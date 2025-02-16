﻿// Decompiled with JetBrains decompiler
// Type: AngleSharp.Html.InputTypes.BaseInputType
// Assembly: AngleSharp, Version=0.9.9.0, Culture=neutral, PublicKeyToken=e83494dcdc6d31ea
// MVID: 6D8FC1AC-F585-421F-BEC1-9105A73220DF
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\AngleSharp.dll

using AngleSharp.Dom;
using AngleSharp.Dom.Html;
using AngleSharp.Extensions;
using System;
using System.Globalization;
using System.Text.RegularExpressions;

namespace AngleSharp.Html.InputTypes
{
  internal abstract class BaseInputType
  {
    protected static readonly DateTime UnixEpoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
    protected static readonly Regex Number = new Regex("^\\-?\\d+(\\.\\d+)?([eE][\\-\\+]?\\d+)?$");
    private readonly IHtmlInputElement _input;
    private readonly bool _validate;
    private readonly string _name;

    public BaseInputType(IHtmlInputElement input, string name, bool validate)
    {
      this._input = input;
      this._validate = validate;
      this._name = name;
    }

    public string Name => this._name;

    public bool CanBeValidated => this._validate;

    public IHtmlInputElement Input => this._input;

    public virtual bool IsAppendingData(IHtmlElement submitter) => true;

    public virtual void Check(ValidityState state)
    {
    }

    public virtual double? ConvertToNumber(string value) => new double?();

    public virtual string ConvertFromNumber(double value) => throw new DomException(DomError.InvalidState);

    public virtual DateTime? ConvertToDate(string value) => new DateTime?();

    public virtual string ConvertFromDate(DateTime value) => throw new DomException(DomError.InvalidState);

    public virtual void ConstructDataSet(FormDataSet dataSet) => dataSet.Append(this._input.Name, this._input.Value, this._input.Type);

    public virtual void DoStep(int n) => throw new DomException(DomError.InvalidState);

    protected bool IsStepMismatch()
    {
      double step = this.GetStep();
      double? number = this.ConvertToNumber(this._input.Value);
      double stepBase = this.GetStepBase();
      if (step == 0.0)
        return false;
      double? nullable1 = number;
      double num1 = stepBase;
      double? nullable2 = nullable1.HasValue ? new double?(nullable1.GetValueOrDefault() - num1) : new double?();
      double num2 = step;
      double? nullable3;
      if (!nullable2.HasValue)
      {
        nullable1 = new double?();
        nullable3 = nullable1;
      }
      else
        nullable3 = new double?(nullable2.GetValueOrDefault() % num2);
      double? nullable4 = nullable3;
      double num3 = 0.0;
      return nullable4.GetValueOrDefault() != num3 || !nullable4.HasValue;
    }

    protected double GetStep()
    {
      string step = this._input.Step;
      if (string.IsNullOrEmpty(step))
        return this.GetDefaultStep() * this.GetStepScaleFactor();
      if (step.Isi(Keywords.Any))
        return 0.0;
      double? number = BaseInputType.ToNumber(step);
      if (number.HasValue)
      {
        double? nullable = number;
        double num = 0.0;
        if ((nullable.GetValueOrDefault() <= num ? (nullable.HasValue ? 1 : 0) : 0) == 0)
          return number.Value * this.GetStepScaleFactor();
      }
      return this.GetDefaultStep() * this.GetStepScaleFactor();
    }

    private double GetStepBase()
    {
      double? number1 = this.ConvertToNumber(this._input.Minimum);
      if (number1.HasValue)
        return number1.Value;
      double? number2 = this.ConvertToNumber(this._input.DefaultValue);
      return number2.HasValue ? number2.Value : this.GetDefaultStepBase();
    }

    protected virtual double GetDefaultStepBase() => 0.0;

    protected virtual double GetDefaultStep() => 1.0;

    protected virtual double GetStepScaleFactor() => 1.0;

    protected static bool IsInvalidPattern(string pattern, string value)
    {
      if (!string.IsNullOrEmpty(pattern))
      {
        if (!string.IsNullOrEmpty(value))
        {
          try
          {
            return !new Regex(pattern, RegexOptions.ECMAScript).IsMatch(value);
          }
          catch
          {
          }
        }
      }
      return false;
    }

    protected static double? ToNumber(string value) => !string.IsNullOrEmpty(value) && BaseInputType.Number.IsMatch(value) ? new double?(double.Parse(value, (IFormatProvider) CultureInfo.InvariantCulture)) : new double?();

    protected static TimeSpan? ToTime(string value, ref int position)
    {
      int startIndex1 = position;
      int seconds = 0;
      int milliseconds = 0;
      if (value.Length < 5 + startIndex1 || !value[position++].IsDigit() || !value[position++].IsDigit() || value[position++] != ':')
        return new TimeSpan?();
      int hours = int.Parse(value.Substring(startIndex1, 2));
      if (!BaseInputType.IsLegalHour(hours) || !value[position++].IsDigit() || !value[position++].IsDigit())
        return new TimeSpan?();
      int minutes = int.Parse(value.Substring(3 + startIndex1, 2));
      if (!BaseInputType.IsLegalMinute(minutes))
        return new TimeSpan?();
      if (value.Length >= 8 + startIndex1 && value[position] == ':')
      {
        ++position;
        if (!value[position++].IsDigit() || !value[position++].IsDigit())
          return new TimeSpan?();
        seconds = int.Parse(value.Substring(6 + startIndex1, 2));
        if (!BaseInputType.IsLegalSecond(seconds))
          return new TimeSpan?();
        if (position + 1 < value.Length && value[position] == '.')
        {
          ++position;
          int startIndex2 = position;
          while (position < value.Length && value[position].IsDigit())
            ++position;
          string s = value.Substring(startIndex2, position - startIndex2);
          milliseconds = int.Parse(s) * (int) Math.Pow(10.0, (double) (3 - s.Length));
        }
      }
      return new TimeSpan?(new TimeSpan(0, hours, minutes, seconds, milliseconds));
    }

    protected static int GetWeekOfYear(DateTime value) => CultureInfo.InvariantCulture.Calendar.GetWeekOfYear(value, CalendarWeekRule.FirstDay, DayOfWeek.Monday);

    protected static bool IsLegalHour(int value) => value >= 0 && value <= 23;

    protected static bool IsLegalSecond(int value) => value >= 0 && value <= 59;

    protected static bool IsLegalMinute(int value) => value >= 0 && value <= 59;

    protected static bool IsLegalMonth(int value) => value >= 1 && value <= 12;

    protected static bool IsLegalYear(int value) => value >= 0 && value <= 9999;

    protected static bool IsLegalDay(int day, int month, int year)
    {
      if (!BaseInputType.IsLegalYear(year) || !BaseInputType.IsLegalMonth(month))
        return false;
      Calendar calendar = CultureInfo.InvariantCulture.Calendar;
      return day >= 1 && day <= calendar.GetDaysInMonth(year, month);
    }

    protected static bool IsLegalWeek(int week, int year)
    {
      if (!BaseInputType.IsLegalYear(year))
        return false;
      int weekOfYear = BaseInputType.GetWeekOfYear(new DateTime(year, 12, 31, 0, 0, 0, 0, DateTimeKind.Utc));
      return week >= 0 && week < weekOfYear;
    }

    protected static bool IsTimeSeparator(char chr) => chr == ' ' || chr == 'T';

    protected static int FetchDigits(string value)
    {
      int index = 0;
      while (index < value.Length && value[index].IsDigit())
        ++index;
      return index;
    }

    protected static bool PositionIsValidForDateTime(string value, int position) => position >= 4 && position <= value.Length - 13 && value[position] == '-' && value[position + 1].IsDigit() && value[position + 2].IsDigit() && value[position + 3] == '-' && value[position + 4].IsDigit() && value[position + 5].IsDigit();
  }
}
