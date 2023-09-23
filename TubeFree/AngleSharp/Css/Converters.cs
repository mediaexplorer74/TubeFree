// Decompiled with JetBrains decompiler
// Type: AngleSharp.Css.Converters
// Assembly: AngleSharp, Version=0.9.9.0, Culture=neutral, PublicKeyToken=e83494dcdc6d31ea
// MVID: 6D8FC1AC-F585-421F-BEC1-9105A73220DF
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\AngleSharp.dll

using AngleSharp.Css.ValueConverters;
using AngleSharp.Css.Values;
using AngleSharp.Dom;
using AngleSharp.Dom.Css;
using AngleSharp.Extensions;
using AngleSharp.Parser.Css;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AngleSharp.Css
{
  internal static class Converters
  {
    public static readonly IValueConverter LineWidthConverter = (IValueConverter) new StructValueConverter<Length>(new Func<IEnumerable<CssToken>, Length?>(ValueExtensions.ToBorderWidth));
    public static readonly IValueConverter LengthConverter = (IValueConverter) new StructValueConverter<Length>(new Func<IEnumerable<CssToken>, Length?>(ValueExtensions.ToLength));
    public static readonly IValueConverter ResolutionConverter = (IValueConverter) new StructValueConverter<Resolution>(new Func<IEnumerable<CssToken>, Resolution?>(ValueExtensions.ToResolution));
    public static readonly IValueConverter FrequencyConverter = (IValueConverter) new StructValueConverter<Frequency>(new Func<IEnumerable<CssToken>, Frequency?>(ValueExtensions.ToFrequency));
    public static readonly IValueConverter TimeConverter = (IValueConverter) new StructValueConverter<Time>(new Func<IEnumerable<CssToken>, Time?>(ValueExtensions.ToTime));
    public static readonly IValueConverter UrlConverter = (IValueConverter) new UrlValueConverter();
    public static readonly IValueConverter StringConverter = (IValueConverter) new StringValueConverter();
    public static readonly IValueConverter EvenStringsConverter = (IValueConverter) new StringsValueConverter();
    public static readonly IValueConverter LiteralsConverter = (IValueConverter) new IdentifierValueConverter(new Func<IEnumerable<CssToken>, string>(ValueExtensions.ToLiterals));
    public static readonly IValueConverter IdentifierConverter = (IValueConverter) new IdentifierValueConverter(new Func<IEnumerable<CssToken>, string>(ValueExtensions.ToIdentifier));
    public static readonly IValueConverter AnimatableConverter = (IValueConverter) new IdentifierValueConverter(new Func<IEnumerable<CssToken>, string>(ValueExtensions.ToAnimatableIdentifier));
    public static readonly IValueConverter IntegerConverter = (IValueConverter) new StructValueConverter<int>(new Func<IEnumerable<CssToken>, int?>(ValueExtensions.ToInteger));
    public static readonly IValueConverter NaturalIntegerConverter = (IValueConverter) new StructValueConverter<int>(new Func<IEnumerable<CssToken>, int?>(ValueExtensions.ToNaturalInteger));
    public static readonly IValueConverter WeightIntegerConverter = (IValueConverter) new StructValueConverter<int>(new Func<IEnumerable<CssToken>, int?>(ValueExtensions.ToWeightInteger));
    public static readonly IValueConverter PositiveIntegerConverter = (IValueConverter) new StructValueConverter<int>(new Func<IEnumerable<CssToken>, int?>(ValueExtensions.ToPositiveInteger));
    public static readonly IValueConverter BinaryConverter = (IValueConverter) new StructValueConverter<int>(new Func<IEnumerable<CssToken>, int?>(ValueExtensions.ToBinary));
    public static readonly IValueConverter AngleConverter = (IValueConverter) new StructValueConverter<Angle>(new Func<IEnumerable<CssToken>, Angle?>(ValueExtensions.ToAngle));
    public static readonly IValueConverter NumberConverter = (IValueConverter) new StructValueConverter<float>(new Func<IEnumerable<CssToken>, float?>(ValueExtensions.ToSingle));
    public static readonly IValueConverter NaturalNumberConverter = (IValueConverter) new StructValueConverter<float>(new Func<IEnumerable<CssToken>, float?>(ValueExtensions.ToNaturalSingle));
    public static readonly IValueConverter PercentConverter = (IValueConverter) new StructValueConverter<Percent>(new Func<IEnumerable<CssToken>, Percent?>(ValueExtensions.ToPercent));
    public static readonly IValueConverter RgbComponentConverter = (IValueConverter) new StructValueConverter<byte>(new Func<IEnumerable<CssToken>, byte?>(ValueExtensions.ToRgbComponent));
    public static readonly IValueConverter AlphaValueConverter = (IValueConverter) new StructValueConverter<float>(new Func<IEnumerable<CssToken>, float?>(ValueExtensions.ToAlphaValue));
    public static readonly IValueConverter PureColorConverter = (IValueConverter) new StructValueConverter<Color>(new Func<IEnumerable<CssToken>, Color?>(ValueExtensions.ToColor));
    public static readonly IValueConverter LengthOrPercentConverter = (IValueConverter) new StructValueConverter<Length>(new Func<IEnumerable<CssToken>, Length?>(ValueExtensions.ToDistance));
    public static readonly IValueConverter AngleNumberConverter = (IValueConverter) new StructValueConverter<Angle>(new Func<IEnumerable<CssToken>, Angle?>(ValueExtensions.ToAngleNumber));
    public static readonly IValueConverter SideOrCornerConverter = Converters.WithAny(Converters.Assign<double>(Keywords.Left, -1.0).Or<double>(Keywords.Right, 1.0).Option<double>(0.0), Converters.Assign<double>(Keywords.Top, 1.0).Or<double>(Keywords.Bottom, -1.0).Option<double>(0.0));
    public static readonly IValueConverter PointConverter = Converters.Construct((Func<IValueConverter>) (() =>
    {
      IValueConverter primary1 = Converters.Assign<Length>(Keywords.Left, Length.Zero).Or<Length>(Keywords.Right, new Length(100f, Length.Unit.Percent)).Or<Length>(Keywords.Center, new Length(50f, Length.Unit.Percent));
      IValueConverter primary2 = Converters.Assign<Length>(Keywords.Top, Length.Zero).Or<Length>(Keywords.Bottom, new Length(100f, Length.Unit.Percent)).Or<Length>(Keywords.Center, new Length(50f, Length.Unit.Percent));
      IValueConverter valueConverter1 = primary1.Or(Converters.LengthOrPercentConverter).Required();
      IValueConverter valueConverter2 = primary2.Or(Converters.LengthOrPercentConverter).Required();
      return Converters.LengthOrPercentConverter.Or(Converters.Toggle(Keywords.Left, Keywords.Right)).Or(Converters.Toggle(Keywords.Top, Keywords.Bottom)).Or<Point>(Keywords.Center, Point.Center).Or(Converters.WithOrder(valueConverter1, valueConverter2)).Or(Converters.WithOrder(valueConverter2, valueConverter1)).Or(Converters.WithOrder(primary1, primary2, Converters.LengthOrPercentConverter)).Or(Converters.WithOrder(primary1, Converters.LengthOrPercentConverter, primary2)).Or(Converters.WithOrder(primary1, Converters.LengthOrPercentConverter, primary2, Converters.LengthOrPercentConverter));
    }));
    public static readonly IValueConverter AttrConverter = (IValueConverter) new FunctionValueConverter(FunctionNames.Attr, Converters.WithArgs(Converters.StringConverter.Or(Converters.IdentifierConverter)));
    public static readonly IValueConverter StepsConverter = (IValueConverter) new FunctionValueConverter(FunctionNames.Steps, Converters.WithArgs(Converters.IntegerConverter.Required(), Converters.Assign<bool>(Keywords.Start, true).Or<bool>(Keywords.End, false).Option<bool>(false)));
    public static readonly IValueConverter CubicBezierConverter = Converters.Construct((Func<IValueConverter>) (() =>
    {
      IValueConverter valueConverter = Converters.NumberConverter.Required();
      return (IValueConverter) new FunctionValueConverter(FunctionNames.CubicBezier, Converters.WithArgs(valueConverter, valueConverter, valueConverter, valueConverter));
    }));
    public static readonly IValueConverter CounterConverter = Converters.Construct((Func<IValueConverter>) (() =>
    {
      IValueConverter valueConverter3 = Converters.IdentifierConverter.Required();
      IValueConverter valueConverter4 = Converters.IdentifierConverter.Option<string>(Keywords.Decimal);
      IValueConverter valueConverter5 = Converters.StringConverter.Required();
      return (IValueConverter) new FunctionValueConverter(FunctionNames.Counter, Converters.WithArgs(valueConverter3, valueConverter4).Or((IValueConverter) new FunctionValueConverter(FunctionNames.Counters, Converters.WithArgs(valueConverter3, valueConverter5, valueConverter4))));
    }));
    public static readonly IValueConverter ShapeConverter = Converters.Construct((Func<IValueConverter>) (() =>
    {
      IValueConverter valueConverter = Converters.LengthConverter.Required();
      return (IValueConverter) new FunctionValueConverter(FunctionNames.Rect, Converters.WithArgs(valueConverter, valueConverter, valueConverter, valueConverter).Or(Converters.WithArgs(Converters.LengthConverter.Many(4, 4))));
    })).OrAuto();
    public static readonly IValueConverter LinearGradientConverter = Converters.Construct((Func<IValueConverter>) (() => new FunctionValueConverter(FunctionNames.LinearGradient, (IValueConverter) new AngleSharp.Css.ValueConverters.LinearGradientConverter(false)).Or((IValueConverter) new FunctionValueConverter(FunctionNames.RepeatingLinearGradient, (IValueConverter) new AngleSharp.Css.ValueConverters.LinearGradientConverter(true)))));
    public static readonly IValueConverter RadialGradientConverter = Converters.Construct((Func<IValueConverter>) (() => new FunctionValueConverter(FunctionNames.RadialGradient, (IValueConverter) new AngleSharp.Css.ValueConverters.RadialGradientConverter(false)).Or((IValueConverter) new FunctionValueConverter(FunctionNames.RepeatingRadialGradient, (IValueConverter) new AngleSharp.Css.ValueConverters.RadialGradientConverter(true)))));
    public static readonly IValueConverter RgbColorConverter = Converters.Construct((Func<IValueConverter>) (() =>
    {
      IValueConverter valueConverter = Converters.RgbComponentConverter.Required();
      return (IValueConverter) new FunctionValueConverter(FunctionNames.Rgb, Converters.WithArgs(valueConverter, valueConverter, valueConverter));
    }));
    public static readonly IValueConverter RgbaColorConverter = Converters.Construct((Func<IValueConverter>) (() =>
    {
      IValueConverter valueConverter6 = Converters.RgbComponentConverter.Required();
      IValueConverter valueConverter7 = Converters.AlphaValueConverter.Required();
      return (IValueConverter) new FunctionValueConverter(FunctionNames.Rgba, Converters.WithArgs(valueConverter6, valueConverter6, valueConverter6, valueConverter7));
    }));
    public static readonly IValueConverter HslColorConverter = Converters.Construct((Func<IValueConverter>) (() =>
    {
      IValueConverter valueConverter8 = Converters.AngleNumberConverter.Required();
      IValueConverter valueConverter9 = Converters.PercentConverter.Required();
      return (IValueConverter) new FunctionValueConverter(FunctionNames.Hsl, Converters.WithArgs(valueConverter8, valueConverter9, valueConverter9));
    }));
    public static readonly IValueConverter HslaColorConverter = Converters.Construct((Func<IValueConverter>) (() =>
    {
      IValueConverter valueConverter10 = Converters.AngleNumberConverter.Required();
      IValueConverter valueConverter11 = Converters.PercentConverter.Required();
      IValueConverter valueConverter12 = Converters.AlphaValueConverter.Required();
      return (IValueConverter) new FunctionValueConverter(FunctionNames.Hsla, Converters.WithArgs(valueConverter10, valueConverter11, valueConverter11, valueConverter12));
    }));
    public static readonly IValueConverter GrayColorConverter = Converters.Construct((Func<IValueConverter>) (() =>
    {
      IValueConverter valueConverter13 = Converters.RgbComponentConverter.Required();
      IValueConverter valueConverter14 = Converters.AlphaValueConverter.Option<float>(1f);
      return (IValueConverter) new FunctionValueConverter(FunctionNames.Gray, Converters.WithArgs(valueConverter13, valueConverter14));
    }));
    public static readonly IValueConverter HwbColorConverter = Converters.Construct((Func<IValueConverter>) (() =>
    {
      IValueConverter valueConverter15 = Converters.AngleNumberConverter.Required();
      IValueConverter valueConverter16 = Converters.PercentConverter.Required();
      IValueConverter valueConverter17 = Converters.AlphaValueConverter.Option<float>(1f);
      return (IValueConverter) new FunctionValueConverter(FunctionNames.Hwb, Converters.WithArgs(valueConverter15, valueConverter16, valueConverter16, valueConverter17));
    }));
    public static readonly IValueConverter PerspectiveConverter = Converters.Construct((Func<IValueConverter>) (() => (IValueConverter) new FunctionValueConverter(FunctionNames.Perspective, Converters.WithArgs(Converters.LengthConverter))));
    public static readonly IValueConverter MatrixTransformConverter = Converters.Construct((Func<IValueConverter>) (() => new FunctionValueConverter(FunctionNames.Matrix, Converters.WithArgs(Converters.NumberConverter, 6)).Or((IValueConverter) new FunctionValueConverter(FunctionNames.Matrix3d, Converters.WithArgs(Converters.NumberConverter, 16)))));
    public static readonly IValueConverter TranslateTransformConverter = Converters.Construct((Func<IValueConverter>) (() =>
    {
      IValueConverter valueConverter18 = Converters.LengthOrPercentConverter.Required();
      IValueConverter valueConverter19 = Converters.LengthOrPercentConverter.Option<Length>(Length.Zero);
      return new FunctionValueConverter(FunctionNames.Translate, Converters.WithArgs(valueConverter18, valueConverter19)).Or((IValueConverter) new FunctionValueConverter(FunctionNames.Translate3d, Converters.WithArgs(valueConverter18, valueConverter19, valueConverter19))).Or((IValueConverter) new FunctionValueConverter(FunctionNames.TranslateX, Converters.WithArgs(Converters.LengthOrPercentConverter))).Or((IValueConverter) new FunctionValueConverter(FunctionNames.TranslateY, Converters.WithArgs(Converters.LengthOrPercentConverter))).Or((IValueConverter) new FunctionValueConverter(FunctionNames.TranslateZ, Converters.WithArgs(Converters.LengthOrPercentConverter)));
    }));
    public static readonly IValueConverter ScaleTransformConverter = Converters.Construct((Func<IValueConverter>) (() =>
    {
      IValueConverter valueConverter20 = Converters.NumberConverter.Required();
      IValueConverter valueConverter21 = Converters.NumberConverter.Option<float>(float.NaN);
      return new FunctionValueConverter(FunctionNames.Scale, Converters.WithArgs(valueConverter20, valueConverter21)).Or((IValueConverter) new FunctionValueConverter(FunctionNames.Scale3d, Converters.WithArgs(valueConverter20, valueConverter21, valueConverter21))).Or((IValueConverter) new FunctionValueConverter(FunctionNames.ScaleX, Converters.WithArgs(Converters.NumberConverter))).Or((IValueConverter) new FunctionValueConverter(FunctionNames.ScaleY, Converters.WithArgs(Converters.NumberConverter))).Or((IValueConverter) new FunctionValueConverter(FunctionNames.ScaleZ, Converters.WithArgs(Converters.NumberConverter)));
    }));
    public static readonly IValueConverter RotateTransformConverter = Converters.Construct((Func<IValueConverter>) (() =>
    {
      IValueConverter valueConverter = Converters.NumberConverter.Required();
      return new FunctionValueConverter(FunctionNames.Rotate, Converters.WithArgs(Converters.AngleConverter)).Or((IValueConverter) new FunctionValueConverter(FunctionNames.Rotate3d, Converters.WithArgs(valueConverter, valueConverter, valueConverter, Converters.AngleConverter.Required()))).Or((IValueConverter) new FunctionValueConverter(FunctionNames.RotateX, Converters.WithArgs(Converters.AngleConverter))).Or((IValueConverter) new FunctionValueConverter(FunctionNames.RotateY, Converters.WithArgs(Converters.AngleConverter))).Or((IValueConverter) new FunctionValueConverter(FunctionNames.RotateZ, Converters.WithArgs(Converters.AngleConverter)));
    }));
    public static readonly IValueConverter SkewTransformConverter = Converters.Construct((Func<IValueConverter>) (() =>
    {
      IValueConverter valueConverter = Converters.AngleConverter.Required();
      return new FunctionValueConverter(FunctionNames.Skew, Converters.WithArgs(valueConverter, valueConverter)).Or((IValueConverter) new FunctionValueConverter(FunctionNames.SkewX, Converters.WithArgs(Converters.AngleConverter))).Or((IValueConverter) new FunctionValueConverter(FunctionNames.SkewY, Converters.WithArgs(Converters.AngleConverter)));
    }));
    public static readonly IValueConverter DefaultFontFamiliesConverter = Map.DefaultFontFamilies.ToConverter<string>();
    public static readonly IValueConverter LineStyleConverter = Map.LineStyles.ToConverter<LineStyle>();
    public static readonly IValueConverter BackgroundAttachmentConverter = Map.BackgroundAttachments.ToConverter<BackgroundAttachment>();
    public static readonly IValueConverter BackgroundRepeatConverter = Map.BackgroundRepeats.ToConverter<BackgroundRepeat>();
    public static readonly IValueConverter BoxModelConverter = Map.BoxModels.ToConverter<BoxModel>();
    public static readonly IValueConverter AnimationDirectionConverter = Map.AnimationDirections.ToConverter<AnimationDirection>();
    public static readonly IValueConverter AnimationFillStyleConverter = Map.AnimationFillStyles.ToConverter<AnimationFillStyle>();
    public static readonly IValueConverter TextDecorationStyleConverter = Map.TextDecorationStyles.ToConverter<TextDecorationStyle>();
    public static readonly IValueConverter TextDecorationLinesConverter = Map.TextDecorationLines.ToConverter<TextDecorationLine>().Many().OrNone();
    public static readonly IValueConverter ListPositionConverter = Map.ListPositions.ToConverter<ListPosition>();
    public static readonly IValueConverter ListStyleConverter = Map.ListStyles.ToConverter<ListStyle>();
    public static readonly IValueConverter BreakModeConverter = Map.BreakModes.ToConverter<BreakMode>();
    public static readonly IValueConverter BreakInsideModeConverter = Map.BreakInsideModes.ToConverter<BreakMode>();
    public static readonly IValueConverter PageBreakModeConverter = Map.PageBreakModes.ToConverter<BreakMode>();
    public static readonly IValueConverter UnicodeModeConverter = Map.UnicodeModes.ToConverter<UnicodeMode>();
    public static readonly IValueConverter VisibilityConverter = Map.Visibilities.ToConverter<Visibility>();
    public static readonly IValueConverter PlayStateConverter = Map.PlayStates.ToConverter<PlayState>();
    public static readonly IValueConverter FontVariantConverter = Map.FontVariants.ToConverter<FontVariant>();
    public static readonly IValueConverter DirectionModeConverter = Map.DirectionModes.ToConverter<DirectionMode>();
    public static readonly IValueConverter HorizontalAlignmentConverter = Map.HorizontalAlignments.ToConverter<HorizontalAlignment>();
    public static readonly IValueConverter VerticalAlignmentConverter = Map.VerticalAlignments.ToConverter<VerticalAlignment>();
    public static readonly IValueConverter WhitespaceConverter = Map.WhitespaceModes.ToConverter<Whitespace>();
    public static readonly IValueConverter TextTransformConverter = Map.TextTransforms.ToConverter<TextTransform>();
    public static readonly IValueConverter TextAlignLastConverter = Map.TextAlignmentsLast.ToConverter<TextAlignLast>();
    public static readonly IValueConverter TextAnchorConverter = Map.TextAnchors.ToConverter<TextAnchor>();
    public static readonly IValueConverter TextJustifyConverter = Map.TextJustifyOptions.ToConverter<TextJustify>();
    public static readonly IValueConverter ObjectFittingConverter = Map.ObjectFittings.ToConverter<ObjectFitting>();
    public static readonly IValueConverter PositionModeConverter = Map.PositionModes.ToConverter<PositionMode>();
    public static readonly IValueConverter OverflowModeConverter = Map.OverflowModes.ToConverter<OverflowMode>();
    public static readonly IValueConverter FloatingConverter = Map.FloatingModes.ToConverter<Floating>();
    public static readonly IValueConverter DisplayModeConverter = Map.DisplayModes.ToConverter<DisplayMode>();
    public static readonly IValueConverter ClearModeConverter = Map.ClearModes.ToConverter<ClearMode>();
    public static readonly IValueConverter FontStretchConverter = Map.FontStretches.ToConverter<FontStretch>();
    public static readonly IValueConverter FontStyleConverter = Map.FontStyles.ToConverter<FontStyle>();
    public static readonly IValueConverter FontWeightConverter = Map.FontWeights.ToConverter<FontWeight>();
    public static readonly IValueConverter SystemFontConverter = Map.SystemFonts.ToConverter<SystemFont>();
    public static readonly IValueConverter StrokeLinecapConverter = Map.StrokeLinecaps.ToConverter<StrokeLinecap>();
    public static readonly IValueConverter StrokeLinejoinConverter = Map.StrokeLinejoins.ToConverter<StrokeLinejoin>();
    public static readonly IValueConverter WordBreakConverter = Map.WordBreaks.ToConverter<WordBreak>();
    public static readonly IValueConverter OverflowWrapConverter = Map.OverflowWraps.ToConverter<OverflowWrap>();
    public static readonly IValueConverter OptionalIntegerConverter = Converters.IntegerConverter.OrAuto();
    public static readonly IValueConverter PositiveOrInfiniteNumberConverter = Converters.NaturalNumberConverter.Or<float>(Keywords.Infinite, float.PositiveInfinity);
    public static readonly IValueConverter OptionalNumberConverter = Converters.NumberConverter.OrNone();
    public static readonly IValueConverter LengthOrNormalConverter = Converters.LengthConverter.Or<Length>(Keywords.Normal, new Length(1f, Length.Unit.Em));
    public static readonly IValueConverter OptionalLengthConverter = Converters.LengthConverter.Or(Keywords.Normal);
    public static readonly IValueConverter AutoLengthConverter = Converters.LengthConverter.OrAuto();
    public static readonly IValueConverter OptionalLengthOrPercentConverter = Converters.LengthOrPercentConverter.OrNone();
    public static readonly IValueConverter AutoLengthOrPercentConverter = Converters.LengthOrPercentConverter.OrAuto();
    public static readonly IValueConverter FontSizeConverter = Converters.LengthOrPercentConverter.Or(Map.FontSizes.ToConverter<FontSize>());
    public static readonly IValueConverter LineHeightConverter = Converters.LengthOrPercentConverter.Or(Converters.NumberConverter).Or(Keywords.Normal);
    public static readonly IValueConverter BorderSliceConverter = Converters.PercentConverter.Or(Converters.NumberConverter);
    public static readonly IValueConverter ImageBorderWidthConverter = Converters.LengthOrPercentConverter.Or(Converters.NumberConverter).Or(Keywords.Auto);
    public static readonly IValueConverter TransitionConverter = new DictionaryValueConverter<ITimingFunction>(Map.TimingFunctions).Or(Converters.StepsConverter).Or(Converters.CubicBezierConverter);
    public static readonly IValueConverter GradientConverter = Converters.LinearGradientConverter.Or(Converters.RadialGradientConverter);
    public static readonly IValueConverter TransformConverter = Converters.MatrixTransformConverter.Or(Converters.ScaleTransformConverter).Or(Converters.RotateTransformConverter).Or(Converters.TranslateTransformConverter).Or(Converters.SkewTransformConverter).Or(Converters.PerspectiveConverter);
    public static readonly IValueConverter ColorConverter = Converters.PureColorConverter.Or(Converters.RgbColorConverter.Or(Converters.RgbaColorConverter)).Or(Converters.HslColorConverter.Or(Converters.HslaColorConverter)).Or(Converters.GrayColorConverter.Or(Converters.HwbColorConverter));
    public static readonly IValueConverter CurrentColorConverter = Converters.ColorConverter.WithCurrentColor();
    public static readonly IValueConverter InvertedColorConverter = Converters.CurrentColorConverter.Or(Keywords.Invert);
    public static readonly IValueConverter PaintConverter = Converters.UrlConverter.Or(Converters.CurrentColorConverter.OrNone());
    public static readonly IValueConverter StrokeDasharrayConverter = Converters.LengthOrPercentConverter.Or(Converters.NumberConverter).Many().OrNone();
    public static readonly IValueConverter StrokeMiterlimitConverter = (IValueConverter) new StructValueConverter<float>(new Func<IEnumerable<CssToken>, float?>(ValueExtensions.ToGreaterOrEqualOneSingle));
    public static readonly IValueConverter RatioConverter = Converters.WithOrder(Converters.IntegerConverter.Required(), Converters.IntegerConverter.StartsWithDelimiter().Required());
    public static readonly IValueConverter ShadowConverter = Converters.WithAny(Converters.Assign<bool>(Keywords.Inset, true).Option<bool>(false), Converters.LengthConverter.Many(2, 4).Required(), Converters.ColorConverter.WithCurrentColor().Option<Color>(Color.Black));
    public static readonly IValueConverter MultipleShadowConverter = Converters.ShadowConverter.FromList().OrNone();
    public static readonly IValueConverter ImageSourceConverter = Converters.UrlConverter.Or(Converters.GradientConverter);
    public static readonly IValueConverter OptionalImageSourceConverter = Converters.ImageSourceConverter.OrNone();
    public static readonly IValueConverter MultipleImageSourceConverter = Converters.OptionalImageSourceConverter.FromList();
    public static readonly IValueConverter BorderRadiusShorthandConverter = (IValueConverter) new AngleSharp.Css.ValueConverters.BorderRadiusConverter();
    public static readonly IValueConverter BorderRadiusConverter = Converters.WithOrder(Converters.LengthOrPercentConverter.Required(), Converters.LengthOrPercentConverter.Option());
    public static readonly IValueConverter FontFamiliesConverter = Converters.DefaultFontFamiliesConverter.Or(Converters.StringConverter).Or(Converters.LiteralsConverter).FromList();
    public static readonly IValueConverter BackgroundSizeConverter = Converters.AutoLengthOrPercentConverter.Or(Keywords.Cover).Or(Keywords.Contain).Or(Converters.WithOrder(Converters.AutoLengthOrPercentConverter.Required(), Converters.AutoLengthOrPercentConverter.Required()));
    public static readonly IValueConverter BackgroundRepeatsConverter = Converters.BackgroundRepeatConverter.Or(Keywords.RepeatX).Or(Keywords.RepeatY).Or(Converters.WithOrder(Converters.BackgroundRepeatConverter.Required(), Converters.BackgroundRepeatConverter.Required()));
    public static readonly IValueConverter TableLayoutConverter = Converters.Toggle(Keywords.Fixed, Keywords.Auto);
    public static readonly IValueConverter EmptyCellsConverter = Converters.Toggle(Keywords.Show, Keywords.Hide);
    public static readonly IValueConverter CaptionSideConverter = Converters.Toggle(Keywords.Top, Keywords.Bottom);
    public static readonly IValueConverter BackfaceVisibilityConverter = Converters.Toggle(Keywords.Visible, Keywords.Hidden);
    public static readonly IValueConverter BorderCollapseConverter = Converters.Toggle(Keywords.Separate, Keywords.Collapse);
    public static readonly IValueConverter BoxDecorationConverter = Converters.Toggle(Keywords.Clone, Keywords.Slice);
    public static readonly IValueConverter ColumnSpanConverter = Converters.Toggle(Keywords.All, Keywords.None);
    public static readonly IValueConverter ColumnFillConverter = Converters.Toggle(Keywords.Balance, Keywords.Auto);
    public static IValueConverter Any = (IValueConverter) new AnyValueConverter();

    public static IValueConverter Assign<T>(string identifier, T result) => (IValueConverter) new IdentifierValueConverter<T>(identifier, result);

    public static IValueConverter Toggle(string on, string off) => Converters.Assign<bool>(on, true).Or<bool>(off, false);

    public static IValueConverter WithOrder(params IValueConverter[] converters) => (IValueConverter) new OrderedOptionsConverter(converters);

    public static IValueConverter WithAny(params IValueConverter[] converters) => (IValueConverter) new UnorderedOptionsConverter(converters);

    public static IValueConverter Continuous(IValueConverter converter) => (IValueConverter) new ContinuousValueConverter(converter);

    private static IValueConverter Construct(Func<IValueConverter> f) => f();

    private static IValueConverter WithArgs(IValueConverter converter, int arguments) => Converters.WithArgs(Enumerable.Repeat<IValueConverter>(converter, arguments).ToArray<IValueConverter>());

    private static IValueConverter WithArgs(IValueConverter converter) => (IValueConverter) new ArgumentsValueConverter(new IValueConverter[1]
    {
      converter
    });

    private static IValueConverter WithArgs(params IValueConverter[] converters) => (IValueConverter) new ArgumentsValueConverter(converters);
  }
}
