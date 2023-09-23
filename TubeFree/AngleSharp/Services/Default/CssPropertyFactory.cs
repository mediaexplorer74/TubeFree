// Decompiled with JetBrains decompiler
// Type: AngleSharp.Services.Default.CssPropertyFactory
// Assembly: AngleSharp, Version=0.9.9.0, Culture=neutral, PublicKeyToken=e83494dcdc6d31ea
// MVID: 6D8FC1AC-F585-421F-BEC1-9105A73220DF
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\AngleSharp.dll

using AngleSharp.Css;
using AngleSharp.Dom.Css;
using AngleSharp.Extensions;
using System;
using System.Collections.Generic;

namespace AngleSharp.Services.Default
{
  internal sealed class CssPropertyFactory : ICssPropertyFactory
  {
    private readonly Dictionary<string, CssPropertyFactory.LonghandCreator> longhands = new Dictionary<string, CssPropertyFactory.LonghandCreator>((IEqualityComparer<string>) StringComparer.OrdinalIgnoreCase);
    private readonly Dictionary<string, CssPropertyFactory.ShorthandCreator> shorthands = new Dictionary<string, CssPropertyFactory.ShorthandCreator>((IEqualityComparer<string>) StringComparer.OrdinalIgnoreCase);
    private readonly Dictionary<string, CssPropertyFactory.LonghandCreator> fonts = new Dictionary<string, CssPropertyFactory.LonghandCreator>((IEqualityComparer<string>) StringComparer.OrdinalIgnoreCase);
    private readonly Dictionary<string, string[]> mappings = new Dictionary<string, string[]>();
    private readonly List<string> animatables = new List<string>();

    public CssPropertyFactory()
    {
      this.AddShorthand(PropertyNames.Animation, (CssPropertyFactory.ShorthandCreator) (() => (CssShorthandProperty) new CssAnimationProperty()), PropertyNames.AnimationName, PropertyNames.AnimationDuration, PropertyNames.AnimationTimingFunction, PropertyNames.AnimationDelay, PropertyNames.AnimationDirection, PropertyNames.AnimationFillMode, PropertyNames.AnimationIterationCount, PropertyNames.AnimationPlayState);
      this.AddLonghand(PropertyNames.AnimationDelay, (CssPropertyFactory.LonghandCreator) (() => (CssProperty) new CssAnimationDelayProperty()));
      this.AddLonghand(PropertyNames.AnimationDirection, (CssPropertyFactory.LonghandCreator) (() => (CssProperty) new CssAnimationDirectionProperty()));
      this.AddLonghand(PropertyNames.AnimationDuration, (CssPropertyFactory.LonghandCreator) (() => (CssProperty) new CssAnimationDurationProperty()));
      this.AddLonghand(PropertyNames.AnimationFillMode, (CssPropertyFactory.LonghandCreator) (() => (CssProperty) new CssAnimationFillModeProperty()));
      this.AddLonghand(PropertyNames.AnimationIterationCount, (CssPropertyFactory.LonghandCreator) (() => (CssProperty) new CssAnimationIterationCountProperty()));
      this.AddLonghand(PropertyNames.AnimationName, (CssPropertyFactory.LonghandCreator) (() => (CssProperty) new CssAnimationNameProperty()));
      this.AddLonghand(PropertyNames.AnimationPlayState, (CssPropertyFactory.LonghandCreator) (() => (CssProperty) new CssAnimationPlayStateProperty()));
      this.AddLonghand(PropertyNames.AnimationTimingFunction, (CssPropertyFactory.LonghandCreator) (() => (CssProperty) new CssAnimationTimingFunctionProperty()));
      this.AddShorthand(PropertyNames.Background, (CssPropertyFactory.ShorthandCreator) (() => (CssShorthandProperty) new CssBackgroundProperty()), PropertyNames.BackgroundAttachment, PropertyNames.BackgroundClip, PropertyNames.BackgroundColor, PropertyNames.BackgroundImage, PropertyNames.BackgroundOrigin, PropertyNames.BackgroundPosition, PropertyNames.BackgroundRepeat, PropertyNames.BackgroundSize);
      this.AddLonghand(PropertyNames.BackgroundAttachment, (CssPropertyFactory.LonghandCreator) (() => (CssProperty) new CssBackgroundAttachmentProperty()));
      this.AddLonghand(PropertyNames.BackgroundColor, (CssPropertyFactory.LonghandCreator) (() => (CssProperty) new CssBackgroundColorProperty()), true);
      this.AddLonghand(PropertyNames.BackgroundClip, (CssPropertyFactory.LonghandCreator) (() => (CssProperty) new CssBackgroundClipProperty()));
      this.AddLonghand(PropertyNames.BackgroundOrigin, (CssPropertyFactory.LonghandCreator) (() => (CssProperty) new CssBackgroundOriginProperty()));
      this.AddLonghand(PropertyNames.BackgroundSize, (CssPropertyFactory.LonghandCreator) (() => (CssProperty) new CssBackgroundSizeProperty()), true);
      this.AddLonghand(PropertyNames.BackgroundImage, (CssPropertyFactory.LonghandCreator) (() => (CssProperty) new CssBackgroundImageProperty()));
      this.AddLonghand(PropertyNames.BackgroundPosition, (CssPropertyFactory.LonghandCreator) (() => (CssProperty) new CssBackgroundPositionProperty()), true);
      this.AddLonghand(PropertyNames.BackgroundRepeat, (CssPropertyFactory.LonghandCreator) (() => (CssProperty) new CssBackgroundRepeatProperty()));
      this.AddLonghand(PropertyNames.BorderSpacing, (CssPropertyFactory.LonghandCreator) (() => (CssProperty) new CssBorderSpacingProperty()));
      this.AddLonghand(PropertyNames.BorderCollapse, (CssPropertyFactory.LonghandCreator) (() => (CssProperty) new CssBorderCollapseProperty()));
      this.AddLonghand(PropertyNames.BoxShadow, (CssPropertyFactory.LonghandCreator) (() => (CssProperty) new CssBoxShadowProperty()), true);
      this.AddLonghand(PropertyNames.BoxDecorationBreak, (CssPropertyFactory.LonghandCreator) (() => (CssProperty) new CssBoxDecorationBreak()));
      this.AddLonghand(PropertyNames.BreakAfter, (CssPropertyFactory.LonghandCreator) (() => (CssProperty) new CssBreakAfterProperty()));
      this.AddLonghand(PropertyNames.BreakBefore, (CssPropertyFactory.LonghandCreator) (() => (CssProperty) new CssBreakBeforeProperty()));
      this.AddLonghand(PropertyNames.BreakInside, (CssPropertyFactory.LonghandCreator) (() => (CssProperty) new CssBreakInsideProperty()));
      this.AddLonghand(PropertyNames.BackfaceVisibility, (CssPropertyFactory.LonghandCreator) (() => (CssProperty) new CssBackfaceVisibilityProperty()));
      this.AddShorthand(PropertyNames.BorderRadius, (CssPropertyFactory.ShorthandCreator) (() => (CssShorthandProperty) new CssBorderRadiusProperty()), PropertyNames.BorderTopLeftRadius, PropertyNames.BorderTopRightRadius, PropertyNames.BorderBottomRightRadius, PropertyNames.BorderBottomLeftRadius);
      this.AddLonghand(PropertyNames.BorderTopLeftRadius, (CssPropertyFactory.LonghandCreator) (() => (CssProperty) new CssBorderTopLeftRadiusProperty()), true);
      this.AddLonghand(PropertyNames.BorderTopRightRadius, (CssPropertyFactory.LonghandCreator) (() => (CssProperty) new CssBorderTopRightRadiusProperty()), true);
      this.AddLonghand(PropertyNames.BorderBottomLeftRadius, (CssPropertyFactory.LonghandCreator) (() => (CssProperty) new CssBorderBottomLeftRadiusProperty()), true);
      this.AddLonghand(PropertyNames.BorderBottomRightRadius, (CssPropertyFactory.LonghandCreator) (() => (CssProperty) new CssBorderBottomRightRadiusProperty()), true);
      this.AddShorthand(PropertyNames.BorderImage, (CssPropertyFactory.ShorthandCreator) (() => (CssShorthandProperty) new CssBorderImageProperty()), PropertyNames.BorderImageOutset, PropertyNames.BorderImageRepeat, PropertyNames.BorderImageSlice, PropertyNames.BorderImageSource, PropertyNames.BorderImageWidth);
      this.AddLonghand(PropertyNames.BorderImageOutset, (CssPropertyFactory.LonghandCreator) (() => (CssProperty) new CssBorderImageOutsetProperty()));
      this.AddLonghand(PropertyNames.BorderImageRepeat, (CssPropertyFactory.LonghandCreator) (() => (CssProperty) new CssBorderImageRepeatProperty()));
      this.AddLonghand(PropertyNames.BorderImageSource, (CssPropertyFactory.LonghandCreator) (() => (CssProperty) new CssBorderImageSourceProperty()));
      this.AddLonghand(PropertyNames.BorderImageSlice, (CssPropertyFactory.LonghandCreator) (() => (CssProperty) new CssBorderImageSliceProperty()));
      this.AddLonghand(PropertyNames.BorderImageWidth, (CssPropertyFactory.LonghandCreator) (() => (CssProperty) new CssBorderImageWidthProperty()));
      this.AddShorthand(PropertyNames.BorderColor, (CssPropertyFactory.ShorthandCreator) (() => (CssShorthandProperty) new CssBorderColorProperty()), PropertyNames.BorderTopColor, PropertyNames.BorderRightColor, PropertyNames.BorderBottomColor, PropertyNames.BorderLeftColor);
      this.AddShorthand(PropertyNames.BorderStyle, (CssPropertyFactory.ShorthandCreator) (() => (CssShorthandProperty) new CssBorderStyleProperty()), PropertyNames.BorderTopStyle, PropertyNames.BorderRightStyle, PropertyNames.BorderBottomStyle, PropertyNames.BorderLeftStyle);
      this.AddShorthand(PropertyNames.BorderWidth, (CssPropertyFactory.ShorthandCreator) (() => (CssShorthandProperty) new CssBorderWidthProperty()), PropertyNames.BorderTopWidth, PropertyNames.BorderRightWidth, PropertyNames.BorderBottomWidth, PropertyNames.BorderLeftWidth);
      this.AddShorthand(PropertyNames.BorderTop, (CssPropertyFactory.ShorthandCreator) (() => (CssShorthandProperty) new CssBorderTopProperty()), PropertyNames.BorderTopWidth, PropertyNames.BorderTopStyle, PropertyNames.BorderTopColor);
      this.AddShorthand(PropertyNames.BorderRight, (CssPropertyFactory.ShorthandCreator) (() => (CssShorthandProperty) new CssBorderRightProperty()), PropertyNames.BorderRightWidth, PropertyNames.BorderRightStyle, PropertyNames.BorderRightColor);
      this.AddShorthand(PropertyNames.BorderBottom, (CssPropertyFactory.ShorthandCreator) (() => (CssShorthandProperty) new CssBorderBottomProperty()), PropertyNames.BorderBottomWidth, PropertyNames.BorderBottomStyle, PropertyNames.BorderBottomColor);
      this.AddShorthand(PropertyNames.BorderLeft, (CssPropertyFactory.ShorthandCreator) (() => (CssShorthandProperty) new CssBorderLeftProperty()), PropertyNames.BorderLeftWidth, PropertyNames.BorderLeftStyle, PropertyNames.BorderLeftColor);
      this.AddShorthand(PropertyNames.Border, (CssPropertyFactory.ShorthandCreator) (() => (CssShorthandProperty) new CssBorderProperty()), PropertyNames.BorderTopWidth, PropertyNames.BorderTopStyle, PropertyNames.BorderTopColor, PropertyNames.BorderRightWidth, PropertyNames.BorderRightStyle, PropertyNames.BorderRightColor, PropertyNames.BorderBottomWidth, PropertyNames.BorderBottomStyle, PropertyNames.BorderBottomColor, PropertyNames.BorderLeftWidth, PropertyNames.BorderLeftStyle, PropertyNames.BorderLeftColor);
      this.AddLonghand(PropertyNames.BorderTopColor, (CssPropertyFactory.LonghandCreator) (() => (CssProperty) new CssBorderTopColorProperty()), true);
      this.AddLonghand(PropertyNames.BorderLeftColor, (CssPropertyFactory.LonghandCreator) (() => (CssProperty) new CssBorderLeftColorProperty()), true);
      this.AddLonghand(PropertyNames.BorderRightColor, (CssPropertyFactory.LonghandCreator) (() => (CssProperty) new CssBorderRightColorProperty()), true);
      this.AddLonghand(PropertyNames.BorderBottomColor, (CssPropertyFactory.LonghandCreator) (() => (CssProperty) new CssBorderBottomColorProperty()), true);
      this.AddLonghand(PropertyNames.BorderTopStyle, (CssPropertyFactory.LonghandCreator) (() => (CssProperty) new CssBorderTopStyleProperty()));
      this.AddLonghand(PropertyNames.BorderLeftStyle, (CssPropertyFactory.LonghandCreator) (() => (CssProperty) new CssBorderLeftStyleProperty()));
      this.AddLonghand(PropertyNames.BorderRightStyle, (CssPropertyFactory.LonghandCreator) (() => (CssProperty) new CssBorderRightStyleProperty()));
      this.AddLonghand(PropertyNames.BorderBottomStyle, (CssPropertyFactory.LonghandCreator) (() => (CssProperty) new CssBorderBottomStyleProperty()));
      this.AddLonghand(PropertyNames.BorderTopWidth, (CssPropertyFactory.LonghandCreator) (() => (CssProperty) new CssBorderTopWidthProperty()), true);
      this.AddLonghand(PropertyNames.BorderLeftWidth, (CssPropertyFactory.LonghandCreator) (() => (CssProperty) new CssBorderLeftWidthProperty()), true);
      this.AddLonghand(PropertyNames.BorderRightWidth, (CssPropertyFactory.LonghandCreator) (() => (CssProperty) new CssBorderRightWidthProperty()), true);
      this.AddLonghand(PropertyNames.BorderBottomWidth, (CssPropertyFactory.LonghandCreator) (() => (CssProperty) new CssBorderBottomWidthProperty()), true);
      this.AddLonghand(PropertyNames.Bottom, (CssPropertyFactory.LonghandCreator) (() => (CssProperty) new CssBottomProperty()), true);
      this.AddShorthand(PropertyNames.Columns, (CssPropertyFactory.ShorthandCreator) (() => (CssShorthandProperty) new CssColumnsProperty()), PropertyNames.ColumnWidth, PropertyNames.ColumnCount);
      this.AddLonghand(PropertyNames.ColumnCount, (CssPropertyFactory.LonghandCreator) (() => (CssProperty) new CssColumnCountProperty()), true);
      this.AddLonghand(PropertyNames.ColumnWidth, (CssPropertyFactory.LonghandCreator) (() => (CssProperty) new CssColumnWidthProperty()), true);
      this.AddLonghand(PropertyNames.ColumnFill, (CssPropertyFactory.LonghandCreator) (() => (CssProperty) new CssColumnFillProperty()));
      this.AddLonghand(PropertyNames.ColumnGap, (CssPropertyFactory.LonghandCreator) (() => (CssProperty) new CssColumnGapProperty()), true);
      this.AddLonghand(PropertyNames.ColumnSpan, (CssPropertyFactory.LonghandCreator) (() => (CssProperty) new CssColumnSpanProperty()));
      this.AddShorthand(PropertyNames.ColumnRule, (CssPropertyFactory.ShorthandCreator) (() => (CssShorthandProperty) new CssColumnRuleProperty()), PropertyNames.ColumnRuleWidth, PropertyNames.ColumnRuleStyle, PropertyNames.ColumnRuleColor);
      this.AddLonghand(PropertyNames.ColumnRuleColor, (CssPropertyFactory.LonghandCreator) (() => (CssProperty) new CssColumnRuleColorProperty()), true);
      this.AddLonghand(PropertyNames.ColumnRuleStyle, (CssPropertyFactory.LonghandCreator) (() => (CssProperty) new CssColumnRuleStyleProperty()));
      this.AddLonghand(PropertyNames.ColumnRuleWidth, (CssPropertyFactory.LonghandCreator) (() => (CssProperty) new CssColumnRuleWidthProperty()), true);
      this.AddLonghand(PropertyNames.CaptionSide, (CssPropertyFactory.LonghandCreator) (() => (CssProperty) new CssCaptionSideProperty()));
      this.AddLonghand(PropertyNames.Clear, (CssPropertyFactory.LonghandCreator) (() => (CssProperty) new CssClearProperty()));
      this.AddLonghand(PropertyNames.Clip, (CssPropertyFactory.LonghandCreator) (() => (CssProperty) new CssClipProperty()), true);
      this.AddLonghand(PropertyNames.Color, (CssPropertyFactory.LonghandCreator) (() => (CssProperty) new CssColorProperty()), true);
      this.AddLonghand(PropertyNames.Content, (CssPropertyFactory.LonghandCreator) (() => (CssProperty) new CssContentProperty()));
      this.AddLonghand(PropertyNames.CounterIncrement, (CssPropertyFactory.LonghandCreator) (() => (CssProperty) new CssCounterIncrementProperty()));
      this.AddLonghand(PropertyNames.CounterReset, (CssPropertyFactory.LonghandCreator) (() => (CssProperty) new CssCounterResetProperty()));
      this.AddLonghand(PropertyNames.Cursor, (CssPropertyFactory.LonghandCreator) (() => (CssProperty) new CssCursorProperty()));
      this.AddLonghand(PropertyNames.Direction, (CssPropertyFactory.LonghandCreator) (() => (CssProperty) new CssDirectionProperty()));
      this.AddLonghand(PropertyNames.Display, (CssPropertyFactory.LonghandCreator) (() => (CssProperty) new CssDisplayProperty()));
      this.AddLonghand(PropertyNames.EmptyCells, (CssPropertyFactory.LonghandCreator) (() => (CssProperty) new CssEmptyCellsProperty()));
      this.AddLonghand(PropertyNames.Float, (CssPropertyFactory.LonghandCreator) (() => (CssProperty) new CssFloatProperty()));
      this.AddShorthand(PropertyNames.Font, (CssPropertyFactory.ShorthandCreator) (() => (CssShorthandProperty) new CssFontProperty()), PropertyNames.FontFamily, PropertyNames.FontSize, PropertyNames.FontStretch, PropertyNames.FontStyle, PropertyNames.FontVariant, PropertyNames.FontWeight, PropertyNames.LineHeight);
      this.AddLonghand(PropertyNames.FontFamily, (CssPropertyFactory.LonghandCreator) (() => (CssProperty) new CssFontFamilyProperty()), font: true);
      this.AddLonghand(PropertyNames.FontSize, (CssPropertyFactory.LonghandCreator) (() => (CssProperty) new CssFontSizeProperty()), true);
      this.AddLonghand(PropertyNames.FontSizeAdjust, (CssPropertyFactory.LonghandCreator) (() => (CssProperty) new CssFontSizeAdjustProperty()), true);
      this.AddLonghand(PropertyNames.FontStyle, (CssPropertyFactory.LonghandCreator) (() => (CssProperty) new CssFontStyleProperty()), font: true);
      this.AddLonghand(PropertyNames.FontVariant, (CssPropertyFactory.LonghandCreator) (() => (CssProperty) new CssFontVariantProperty()), font: true);
      this.AddLonghand(PropertyNames.FontWeight, (CssPropertyFactory.LonghandCreator) (() => (CssProperty) new CssFontWeightProperty()), true, true);
      this.AddLonghand(PropertyNames.FontStretch, (CssPropertyFactory.LonghandCreator) (() => (CssProperty) new CssFontStretchProperty()), true, true);
      this.AddLonghand(PropertyNames.LineHeight, (CssPropertyFactory.LonghandCreator) (() => (CssProperty) new CssLineHeightProperty()), true);
      this.AddLonghand(PropertyNames.Height, (CssPropertyFactory.LonghandCreator) (() => (CssProperty) new CssHeightProperty()), true);
      this.AddLonghand(PropertyNames.Left, (CssPropertyFactory.LonghandCreator) (() => (CssProperty) new CssLeftProperty()), true);
      this.AddLonghand(PropertyNames.LetterSpacing, (CssPropertyFactory.LonghandCreator) (() => (CssProperty) new CssLetterSpacingProperty()));
      this.AddShorthand(PropertyNames.ListStyle, (CssPropertyFactory.ShorthandCreator) (() => (CssShorthandProperty) new CssListStyleProperty()), PropertyNames.ListStyleType, PropertyNames.ListStyleImage, PropertyNames.ListStylePosition);
      this.AddLonghand(PropertyNames.ListStyleImage, (CssPropertyFactory.LonghandCreator) (() => (CssProperty) new CssListStyleImageProperty()));
      this.AddLonghand(PropertyNames.ListStylePosition, (CssPropertyFactory.LonghandCreator) (() => (CssProperty) new CssListStylePositionProperty()));
      this.AddLonghand(PropertyNames.ListStyleType, (CssPropertyFactory.LonghandCreator) (() => (CssProperty) new CssListStyleTypeProperty()));
      this.AddShorthand(PropertyNames.Margin, (CssPropertyFactory.ShorthandCreator) (() => (CssShorthandProperty) new CssMarginProperty()), PropertyNames.MarginTop, PropertyNames.MarginRight, PropertyNames.MarginBottom, PropertyNames.MarginLeft);
      this.AddLonghand(PropertyNames.MarginRight, (CssPropertyFactory.LonghandCreator) (() => (CssProperty) new CssMarginRightProperty()), true);
      this.AddLonghand(PropertyNames.MarginLeft, (CssPropertyFactory.LonghandCreator) (() => (CssProperty) new CssMarginLeftProperty()), true);
      this.AddLonghand(PropertyNames.MarginTop, (CssPropertyFactory.LonghandCreator) (() => (CssProperty) new CssMarginTopProperty()), true);
      this.AddLonghand(PropertyNames.MarginBottom, (CssPropertyFactory.LonghandCreator) (() => (CssProperty) new CssMarginBottomProperty()), true);
      this.AddLonghand(PropertyNames.MaxHeight, (CssPropertyFactory.LonghandCreator) (() => (CssProperty) new CssMaxHeightProperty()), true);
      this.AddLonghand(PropertyNames.MaxWidth, (CssPropertyFactory.LonghandCreator) (() => (CssProperty) new CssMaxWidthProperty()), true);
      this.AddLonghand(PropertyNames.MinHeight, (CssPropertyFactory.LonghandCreator) (() => (CssProperty) new CssMinHeightProperty()), true);
      this.AddLonghand(PropertyNames.MinWidth, (CssPropertyFactory.LonghandCreator) (() => (CssProperty) new CssMinWidthProperty()), true);
      this.AddLonghand(PropertyNames.Opacity, (CssPropertyFactory.LonghandCreator) (() => (CssProperty) new CssOpacityProperty()), true);
      this.AddLonghand(PropertyNames.Orphans, (CssPropertyFactory.LonghandCreator) (() => (CssProperty) new CssOrphansProperty()));
      this.AddShorthand(PropertyNames.Outline, (CssPropertyFactory.ShorthandCreator) (() => (CssShorthandProperty) new CssOutlineProperty()), PropertyNames.OutlineWidth, PropertyNames.OutlineStyle, PropertyNames.OutlineColor);
      this.AddLonghand(PropertyNames.OutlineColor, (CssPropertyFactory.LonghandCreator) (() => (CssProperty) new CssOutlineColorProperty()), true);
      this.AddLonghand(PropertyNames.OutlineStyle, (CssPropertyFactory.LonghandCreator) (() => (CssProperty) new CssOutlineStyleProperty()));
      this.AddLonghand(PropertyNames.OutlineWidth, (CssPropertyFactory.LonghandCreator) (() => (CssProperty) new CssOutlineWidthProperty()), true);
      this.AddLonghand(PropertyNames.Overflow, (CssPropertyFactory.LonghandCreator) (() => (CssProperty) new CssOverflowProperty()));
      this.AddLonghand(PropertyNames.OverflowWrap, (CssPropertyFactory.LonghandCreator) (() => (CssProperty) new CssOverflowWrapProperty()));
      this.AddShorthand(PropertyNames.Padding, (CssPropertyFactory.ShorthandCreator) (() => (CssShorthandProperty) new CssPaddingProperty()), PropertyNames.PaddingTop, PropertyNames.PaddingRight, PropertyNames.PaddingBottom, PropertyNames.PaddingLeft);
      this.AddLonghand(PropertyNames.PaddingTop, (CssPropertyFactory.LonghandCreator) (() => (CssProperty) new CssPaddingTopProperty()), true);
      this.AddLonghand(PropertyNames.PaddingRight, (CssPropertyFactory.LonghandCreator) (() => (CssProperty) new CssPaddingRightProperty()), true);
      this.AddLonghand(PropertyNames.PaddingLeft, (CssPropertyFactory.LonghandCreator) (() => (CssProperty) new CssPaddingLeftProperty()), true);
      this.AddLonghand(PropertyNames.PaddingBottom, (CssPropertyFactory.LonghandCreator) (() => (CssProperty) new CssPaddingBottomProperty()), true);
      this.AddLonghand(PropertyNames.PageBreakAfter, (CssPropertyFactory.LonghandCreator) (() => (CssProperty) new CssPageBreakAfterProperty()));
      this.AddLonghand(PropertyNames.PageBreakBefore, (CssPropertyFactory.LonghandCreator) (() => (CssProperty) new CssPageBreakBeforeProperty()));
      this.AddLonghand(PropertyNames.PageBreakInside, (CssPropertyFactory.LonghandCreator) (() => (CssProperty) new CssPageBreakInsideProperty()));
      this.AddLonghand(PropertyNames.Perspective, (CssPropertyFactory.LonghandCreator) (() => (CssProperty) new CssPerspectiveProperty()), true);
      this.AddLonghand(PropertyNames.PerspectiveOrigin, (CssPropertyFactory.LonghandCreator) (() => (CssProperty) new CssPerspectiveOriginProperty()), true);
      this.AddLonghand(PropertyNames.Position, (CssPropertyFactory.LonghandCreator) (() => (CssProperty) new CssPositionProperty()));
      this.AddLonghand(PropertyNames.Quotes, (CssPropertyFactory.LonghandCreator) (() => (CssProperty) new CssQuotesProperty()));
      this.AddLonghand(PropertyNames.Right, (CssPropertyFactory.LonghandCreator) (() => (CssProperty) new CssRightProperty()), true);
      this.AddLonghand(PropertyNames.Stroke, (CssPropertyFactory.LonghandCreator) (() => (CssProperty) new CssStrokeProperty()), true);
      this.AddLonghand(PropertyNames.StrokeDasharray, (CssPropertyFactory.LonghandCreator) (() => (CssProperty) new CssStrokeDasharrayProperty()), true);
      this.AddLonghand(PropertyNames.StrokeDashoffset, (CssPropertyFactory.LonghandCreator) (() => (CssProperty) new CssStrokeDashoffsetProperty()), true);
      this.AddLonghand(PropertyNames.StrokeLinecap, (CssPropertyFactory.LonghandCreator) (() => (CssProperty) new CssStrokeLinecapProperty()), true);
      this.AddLonghand(PropertyNames.StrokeLinejoin, (CssPropertyFactory.LonghandCreator) (() => (CssProperty) new CssStrokeLinejoinProperty()), true);
      this.AddLonghand(PropertyNames.StrokeMiterlimit, (CssPropertyFactory.LonghandCreator) (() => (CssProperty) new CssStrokeMiterlimitProperty()), true);
      this.AddLonghand(PropertyNames.StrokeOpacity, (CssPropertyFactory.LonghandCreator) (() => (CssProperty) new CssStrokeOpacityProperty()), true);
      this.AddLonghand(PropertyNames.StrokeWidth, (CssPropertyFactory.LonghandCreator) (() => (CssProperty) new CssStrokeWidthProperty()), true);
      this.AddLonghand(PropertyNames.TableLayout, (CssPropertyFactory.LonghandCreator) (() => (CssProperty) new CssTableLayoutProperty()));
      this.AddLonghand(PropertyNames.TextAlign, (CssPropertyFactory.LonghandCreator) (() => (CssProperty) new CssTextAlignProperty()));
      this.AddLonghand(PropertyNames.TextAlignLast, (CssPropertyFactory.LonghandCreator) (() => (CssProperty) new CssTextAlignLastProperty()));
      this.AddLonghand(PropertyNames.TextAnchor, (CssPropertyFactory.LonghandCreator) (() => (CssProperty) new CssTextAnchorProperty()));
      this.AddShorthand(PropertyNames.TextDecoration, (CssPropertyFactory.ShorthandCreator) (() => (CssShorthandProperty) new CssTextDecorationProperty()), PropertyNames.TextDecorationLine, PropertyNames.TextDecorationStyle, PropertyNames.TextDecorationColor);
      this.AddLonghand(PropertyNames.TextDecorationStyle, (CssPropertyFactory.LonghandCreator) (() => (CssProperty) new CssTextDecorationStyleProperty()));
      this.AddLonghand(PropertyNames.TextDecorationLine, (CssPropertyFactory.LonghandCreator) (() => (CssProperty) new CssTextDecorationLineProperty()));
      this.AddLonghand(PropertyNames.TextDecorationColor, (CssPropertyFactory.LonghandCreator) (() => (CssProperty) new CssTextDecorationColorProperty()), true);
      this.AddLonghand(PropertyNames.TextIndent, (CssPropertyFactory.LonghandCreator) (() => (CssProperty) new CssTextIndentProperty()), true);
      this.AddLonghand(PropertyNames.TextJustify, (CssPropertyFactory.LonghandCreator) (() => (CssProperty) new CssTextJustifyProperty()));
      this.AddLonghand(PropertyNames.TextTransform, (CssPropertyFactory.LonghandCreator) (() => (CssProperty) new CssTextTransformProperty()));
      this.AddLonghand(PropertyNames.TextShadow, (CssPropertyFactory.LonghandCreator) (() => (CssProperty) new CssTextShadowProperty()), true);
      this.AddLonghand(PropertyNames.Transform, (CssPropertyFactory.LonghandCreator) (() => (CssProperty) new CssTransformProperty()), true);
      this.AddLonghand(PropertyNames.TransformOrigin, (CssPropertyFactory.LonghandCreator) (() => (CssProperty) new CssTransformOriginProperty()), true);
      this.AddLonghand(PropertyNames.TransformStyle, (CssPropertyFactory.LonghandCreator) (() => (CssProperty) new CssTransformStyleProperty()));
      this.AddShorthand(PropertyNames.Transition, (CssPropertyFactory.ShorthandCreator) (() => (CssShorthandProperty) new CssTransitionProperty()), PropertyNames.TransitionProperty, PropertyNames.TransitionDuration, PropertyNames.TransitionTimingFunction, PropertyNames.TransitionDelay);
      this.AddLonghand(PropertyNames.TransitionDelay, (CssPropertyFactory.LonghandCreator) (() => (CssProperty) new CssTransitionDelayProperty()));
      this.AddLonghand(PropertyNames.TransitionDuration, (CssPropertyFactory.LonghandCreator) (() => (CssProperty) new CssTransitionDurationProperty()));
      this.AddLonghand(PropertyNames.TransitionTimingFunction, (CssPropertyFactory.LonghandCreator) (() => (CssProperty) new CssTransitionTimingFunctionProperty()));
      this.AddLonghand(PropertyNames.TransitionProperty, (CssPropertyFactory.LonghandCreator) (() => (CssProperty) new CssTransitionPropertyProperty()));
      this.AddLonghand(PropertyNames.Top, (CssPropertyFactory.LonghandCreator) (() => (CssProperty) new CssTopProperty()), true);
      this.AddLonghand(PropertyNames.UnicodeBidi, (CssPropertyFactory.LonghandCreator) (() => (CssProperty) new CssUnicodeBidiProperty()));
      this.AddLonghand(PropertyNames.VerticalAlign, (CssPropertyFactory.LonghandCreator) (() => (CssProperty) new CssVerticalAlignProperty()), true);
      this.AddLonghand(PropertyNames.Visibility, (CssPropertyFactory.LonghandCreator) (() => (CssProperty) new CssVisibilityProperty()), true);
      this.AddLonghand(PropertyNames.WhiteSpace, (CssPropertyFactory.LonghandCreator) (() => (CssProperty) new CssWhiteSpaceProperty()));
      this.AddLonghand(PropertyNames.Widows, (CssPropertyFactory.LonghandCreator) (() => (CssProperty) new CssWidowsProperty()));
      this.AddLonghand(PropertyNames.Width, (CssPropertyFactory.LonghandCreator) (() => (CssProperty) new CssWidthProperty()), true);
      this.AddLonghand(PropertyNames.WordBreak, (CssPropertyFactory.LonghandCreator) (() => (CssProperty) new CssWordBreakProperty()), true);
      this.AddLonghand(PropertyNames.WordSpacing, (CssPropertyFactory.LonghandCreator) (() => (CssProperty) new CssWordSpacingProperty()), true);
      this.AddLonghand(PropertyNames.WordWrap, (CssPropertyFactory.LonghandCreator) (() => (CssProperty) new CssOverflowWrapProperty()));
      this.AddLonghand(PropertyNames.ZIndex, (CssPropertyFactory.LonghandCreator) (() => (CssProperty) new CssZIndexProperty()), true);
      this.AddLonghand(PropertyNames.ObjectFit, (CssPropertyFactory.LonghandCreator) (() => (CssProperty) new CssObjectFitProperty()));
      this.AddLonghand(PropertyNames.ObjectPosition, (CssPropertyFactory.LonghandCreator) (() => (CssProperty) new CssObjectPositionProperty()), true);
      this.fonts.Add(PropertyNames.Src, (CssPropertyFactory.LonghandCreator) (() => (CssProperty) new CssSrcProperty()));
      this.fonts.Add(PropertyNames.UnicodeRange, (CssPropertyFactory.LonghandCreator) (() => (CssProperty) new CssUnicodeRangeProperty()));
    }

    private void AddShorthand(
      string name,
      CssPropertyFactory.ShorthandCreator creator,
      params string[] longhands)
    {
      this.shorthands.Add(name, creator);
      this.mappings.Add(name, longhands);
    }

    private void AddLonghand(
      string name,
      CssPropertyFactory.LonghandCreator creator,
      bool animatable = false,
      bool font = false)
    {
      this.longhands.Add(name, creator);
      if (animatable)
        this.animatables.Add(name);
      if (!font)
        return;
      this.fonts.Add(name, creator);
    }

    public CssProperty Create(string name) => this.CreateLonghand(name) ?? (CssProperty) this.CreateShorthand(name);

    public CssProperty CreateFont(string name)
    {
      CssPropertyFactory.LonghandCreator longhandCreator = (CssPropertyFactory.LonghandCreator) null;
      return this.fonts.TryGetValue(name, out longhandCreator) ? longhandCreator() : (CssProperty) null;
    }

    public CssProperty CreateViewport(string name)
    {
      MediaFeature feature = Factory.MediaFeatures.Create(name);
      return feature == null ? (CssProperty) null : (CssProperty) new CssFeatureProperty(feature);
    }

    public CssProperty CreateLonghand(string name)
    {
      CssPropertyFactory.LonghandCreator longhandCreator = (CssPropertyFactory.LonghandCreator) null;
      return this.longhands.TryGetValue(name, out longhandCreator) ? longhandCreator() : (CssProperty) null;
    }

    public CssShorthandProperty CreateShorthand(string name)
    {
      CssPropertyFactory.ShorthandCreator shorthandCreator = (CssPropertyFactory.ShorthandCreator) null;
      return this.shorthands.TryGetValue(name, out shorthandCreator) ? shorthandCreator() : (CssShorthandProperty) null;
    }

    public CssProperty[] CreateLonghandsFor(string name)
    {
      string[] longhands = this.GetLonghands(name);
      List<CssProperty> cssPropertyList = new List<CssProperty>();
      foreach (string name1 in longhands)
        cssPropertyList.Add(this.CreateLonghand(name1));
      return cssPropertyList.ToArray();
    }

    public bool IsLonghand(string name) => this.longhands.ContainsKey(name);

    public bool IsShorthand(string name) => this.shorthands.ContainsKey(name);

    public bool IsAnimatable(string name)
    {
      if (this.IsLonghand(name))
        return this.animatables.Contains(name);
      foreach (string longhand in this.GetLonghands(name))
      {
        if (this.animatables.Contains(name))
          return true;
      }
      return false;
    }

    public string[] GetLonghands(string name) => this.mappings.ContainsKey(name) ? this.mappings[name] : new string[0];

    public IEnumerable<string> GetShorthands(string name)
    {
      foreach (KeyValuePair<string, string[]> mapping in this.mappings)
      {
        if (mapping.Value.Contains(name, StringComparison.OrdinalIgnoreCase))
          yield return mapping.Key;
      }
    }

    private delegate CssProperty LonghandCreator();

    private delegate CssShorthandProperty ShorthandCreator();
  }
}
