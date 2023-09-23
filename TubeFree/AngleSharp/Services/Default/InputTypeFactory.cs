// Decompiled with JetBrains decompiler
// Type: AngleSharp.Services.Default.InputTypeFactory
// Assembly: AngleSharp, Version=0.9.9.0, Culture=neutral, PublicKeyToken=e83494dcdc6d31ea
// MVID: 6D8FC1AC-F585-421F-BEC1-9105A73220DF
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\AngleSharp.dll

using AngleSharp.Dom.Html;
using AngleSharp.Html;
using AngleSharp.Html.InputTypes;
using System;
using System.Collections.Generic;

namespace AngleSharp.Services.Default
{
  internal sealed class InputTypeFactory : IInputTypeFactory
  {
    private readonly Dictionary<string, InputTypeFactory.Creator> creators = new Dictionary<string, InputTypeFactory.Creator>((IEqualityComparer<string>) StringComparer.OrdinalIgnoreCase)
    {
      {
        InputTypeNames.Text,
        (InputTypeFactory.Creator) (input => (BaseInputType) new TextInputType(input, InputTypeNames.Text))
      },
      {
        InputTypeNames.Date,
        (InputTypeFactory.Creator) (input => (BaseInputType) new DateInputType(input, InputTypeNames.Date))
      },
      {
        InputTypeNames.Week,
        (InputTypeFactory.Creator) (input => (BaseInputType) new WeekInputType(input, InputTypeNames.Week))
      },
      {
        InputTypeNames.Datetime,
        (InputTypeFactory.Creator) (input => (BaseInputType) new DatetimeInputType(input, InputTypeNames.Datetime))
      },
      {
        InputTypeNames.DatetimeLocal,
        (InputTypeFactory.Creator) (input => (BaseInputType) new DatetimeLocalInputType(input, InputTypeNames.DatetimeLocal))
      },
      {
        InputTypeNames.Time,
        (InputTypeFactory.Creator) (input => (BaseInputType) new TimeInputType(input, InputTypeNames.Time))
      },
      {
        InputTypeNames.Month,
        (InputTypeFactory.Creator) (input => (BaseInputType) new MonthInputType(input, InputTypeNames.Month))
      },
      {
        InputTypeNames.Range,
        (InputTypeFactory.Creator) (input => (BaseInputType) new NumberInputType(input, InputTypeNames.Range))
      },
      {
        InputTypeNames.Number,
        (InputTypeFactory.Creator) (input => (BaseInputType) new NumberInputType(input, InputTypeNames.Number))
      },
      {
        InputTypeNames.Hidden,
        (InputTypeFactory.Creator) (input => (BaseInputType) new ButtonInputType(input, InputTypeNames.Hidden))
      },
      {
        InputTypeNames.Search,
        (InputTypeFactory.Creator) (input => (BaseInputType) new TextInputType(input, InputTypeNames.Search))
      },
      {
        InputTypeNames.Email,
        (InputTypeFactory.Creator) (input => (BaseInputType) new EmailInputType(input, InputTypeNames.Email))
      },
      {
        InputTypeNames.Tel,
        (InputTypeFactory.Creator) (input => (BaseInputType) new PatternInputType(input, InputTypeNames.Tel))
      },
      {
        InputTypeNames.Url,
        (InputTypeFactory.Creator) (input => (BaseInputType) new UrlInputType(input, InputTypeNames.Url))
      },
      {
        InputTypeNames.Password,
        (InputTypeFactory.Creator) (input => (BaseInputType) new PatternInputType(input, InputTypeNames.Password))
      },
      {
        InputTypeNames.Color,
        (InputTypeFactory.Creator) (input => (BaseInputType) new ColorInputType(input, InputTypeNames.Color))
      },
      {
        InputTypeNames.Checkbox,
        (InputTypeFactory.Creator) (input => (BaseInputType) new CheckedInputType(input, InputTypeNames.Checkbox))
      },
      {
        InputTypeNames.Radio,
        (InputTypeFactory.Creator) (input => (BaseInputType) new CheckedInputType(input, InputTypeNames.Radio))
      },
      {
        InputTypeNames.File,
        (InputTypeFactory.Creator) (input => (BaseInputType) new FileInputType(input, InputTypeNames.File))
      },
      {
        InputTypeNames.Submit,
        (InputTypeFactory.Creator) (input => (BaseInputType) new SubmitInputType(input, InputTypeNames.Submit))
      },
      {
        InputTypeNames.Reset,
        (InputTypeFactory.Creator) (input => (BaseInputType) new ButtonInputType(input, InputTypeNames.Reset))
      },
      {
        InputTypeNames.Image,
        (InputTypeFactory.Creator) (input => (BaseInputType) new ImageInputType(input, InputTypeNames.Image))
      },
      {
        InputTypeNames.Button,
        (InputTypeFactory.Creator) (input => (BaseInputType) new ButtonInputType(input, InputTypeNames.Button))
      }
    };

    public BaseInputType Create(IHtmlInputElement input, string type)
    {
      InputTypeFactory.Creator creator = (InputTypeFactory.Creator) null;
      if (string.IsNullOrEmpty(type))
        type = InputTypeNames.Text;
      if (!this.creators.TryGetValue(type, out creator))
        creator = this.creators[InputTypeNames.Text];
      return creator(input);
    }

    private delegate BaseInputType Creator(IHtmlInputElement input);
  }
}
