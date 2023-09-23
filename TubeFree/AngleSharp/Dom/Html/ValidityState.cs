// Decompiled with JetBrains decompiler
// Type: AngleSharp.Dom.Html.ValidityState
// Assembly: AngleSharp, Version=0.9.9.0, Culture=neutral, PublicKeyToken=e83494dcdc6d31ea
// MVID: 6D8FC1AC-F585-421F-BEC1-9105A73220DF
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\AngleSharp.dll

using System;

namespace AngleSharp.Dom.Html
{
  internal sealed class ValidityState : IValidityState
  {
    private ValidityState.ErrorType _err;

    internal ValidityState() => this._err = ValidityState.ErrorType.None;

    public bool IsValueMissing
    {
      get => (this._err & ValidityState.ErrorType.ValueMissing) == ValidityState.ErrorType.ValueMissing;
      set => this.Set(this.IsValueMissing, value, ValidityState.ErrorType.ValueMissing);
    }

    public bool IsTypeMismatch
    {
      get => (this._err & ValidityState.ErrorType.TypeMismatch) == ValidityState.ErrorType.TypeMismatch;
      set => this.Set(this.IsTypeMismatch, value, ValidityState.ErrorType.TypeMismatch);
    }

    public bool IsPatternMismatch
    {
      get => (this._err & ValidityState.ErrorType.PatternMismatch) == ValidityState.ErrorType.PatternMismatch;
      set => this.Set(this.IsPatternMismatch, value, ValidityState.ErrorType.PatternMismatch);
    }

    public bool IsBadInput
    {
      get => (this._err & ValidityState.ErrorType.BadInput) == ValidityState.ErrorType.BadInput;
      set => this.Set(this.IsBadInput, value, ValidityState.ErrorType.BadInput);
    }

    public bool IsTooLong
    {
      get => (this._err & ValidityState.ErrorType.TooLong) == ValidityState.ErrorType.TooLong;
      set => this.Set(this.IsTooLong, value, ValidityState.ErrorType.TooLong);
    }

    public bool IsTooShort
    {
      get => (this._err & ValidityState.ErrorType.TooShort) == ValidityState.ErrorType.TooShort;
      set => this.Set(this.IsTooShort, value, ValidityState.ErrorType.TooShort);
    }

    public bool IsRangeUnderflow
    {
      get => (this._err & ValidityState.ErrorType.RangeUnderflow) == ValidityState.ErrorType.RangeUnderflow;
      set => this.Set(this.IsRangeUnderflow, value, ValidityState.ErrorType.RangeUnderflow);
    }

    public bool IsRangeOverflow
    {
      get => (this._err & ValidityState.ErrorType.RangeOverflow) == ValidityState.ErrorType.RangeOverflow;
      set => this.Set(this.IsRangeOverflow, value, ValidityState.ErrorType.RangeOverflow);
    }

    public bool IsStepMismatch
    {
      get => (this._err & ValidityState.ErrorType.StepMismatch) == ValidityState.ErrorType.StepMismatch;
      set => this.Set(this.IsStepMismatch, value, ValidityState.ErrorType.StepMismatch);
    }

    public bool IsCustomError
    {
      get => (this._err & ValidityState.ErrorType.Custom) == ValidityState.ErrorType.Custom;
      set => this.Set(this.IsCustomError, value, ValidityState.ErrorType.Custom);
    }

    public bool IsValid => this._err == ValidityState.ErrorType.None;

    public void Reset() => this._err = ValidityState.ErrorType.None;

    private void Set(bool oldValue, bool newValue, ValidityState.ErrorType err)
    {
      if (newValue == oldValue)
        return;
      this._err ^= err;
    }

    [Flags]
    private enum ErrorType : ushort
    {
      None = 0,
      ValueMissing = 1,
      TypeMismatch = 2,
      PatternMismatch = 4,
      TooLong = 8,
      TooShort = 16, // 0x0010
      RangeUnderflow = 32, // 0x0020
      RangeOverflow = 64, // 0x0040
      StepMismatch = 128, // 0x0080
      BadInput = 256, // 0x0100
      Custom = 512, // 0x0200
    }
  }
}
