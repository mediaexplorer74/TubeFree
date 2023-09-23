// Decompiled with JetBrains decompiler
// Type: AngleSharp.Dom.Css.CssStyleDeclaration
// Assembly: AngleSharp, Version=0.9.9.0, Culture=neutral, PublicKeyToken=e83494dcdc6d31ea
// MVID: 6D8FC1AC-F585-421F-BEC1-9105A73220DF
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\AngleSharp.dll

using AngleSharp.Css;
using AngleSharp.Extensions;
using AngleSharp.Parser.Css;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AngleSharp.Dom.Css
{
  internal sealed class CssStyleDeclaration : 
    CssNode,
    ICssStyleDeclaration,
    ICssProperties,
    IEnumerable<ICssProperty>,
    IEnumerable,
    ICssNode,
    IStyleFormattable,
    IBindable
  {
    private readonly CssRule _parent;
    private readonly CssParser _parser;

    public event Action<string> Changed;

    private CssStyleDeclaration(CssRule parent, CssParser parser)
    {
      this._parent = parent;
      this._parser = parser;
    }

    internal CssStyleDeclaration(CssParser parser)
      : this((CssRule) null, parser)
    {
    }

    internal CssStyleDeclaration()
      : this((CssRule) null, (CssParser) null)
    {
    }

    internal CssStyleDeclaration(CssRule parent)
      : this(parent, parent.Parser)
    {
    }

    public string this[int index] => this.Declarations.GetItemByIndex<CssProperty>(index).Name;

    public string this[string name] => this.GetPropertyValue(name);

    public IEnumerable<CssProperty> Declarations => this.Children.OfType<CssProperty>();

    public bool IsStrictMode => this.IsReadOnly || !this._parser.Options.IsIncludingUnknownDeclarations;

    public string CssText
    {
      get => this.ToCss();
      set
      {
        this.Update(value);
        this.RaiseChanged();
      }
    }

    public bool IsReadOnly => this._parser == null;

    public int Length => this.Declarations.Count<CssProperty>();

    public ICssRule Parent => (ICssRule) this._parent;

    string ICssStyleDeclaration.AlignContent
    {
      get => this.GetPropertyValue(PropertyNames.AlignContent);
      set => this.SetProperty(PropertyNames.AlignContent, value, (string) null);
    }

    string ICssStyleDeclaration.AlignItems
    {
      get => this.GetPropertyValue(PropertyNames.AlignItems);
      set => this.SetProperty(PropertyNames.AlignItems, value, (string) null);
    }

    string ICssStyleDeclaration.AlignSelf
    {
      get => this.GetPropertyValue(PropertyNames.AlignSelf);
      set => this.SetProperty(PropertyNames.AlignSelf, value, (string) null);
    }

    string ICssStyleDeclaration.Accelerator
    {
      get => this.GetPropertyValue(PropertyNames.Accelerator);
      set => this.SetProperty(PropertyNames.Accelerator, value, (string) null);
    }

    string ICssStyleDeclaration.AlignmentBaseline
    {
      get => this.GetPropertyValue(PropertyNames.AlignBaseline);
      set => this.SetProperty(PropertyNames.AlignBaseline, value, (string) null);
    }

    string ICssStyleDeclaration.Animation
    {
      get => this.GetPropertyValue(PropertyNames.Animation);
      set => this.SetProperty(PropertyNames.Animation, value, (string) null);
    }

    string ICssStyleDeclaration.AnimationDelay
    {
      get => this.GetPropertyValue(PropertyNames.AnimationDelay);
      set => this.SetProperty(PropertyNames.AnimationDelay, value, (string) null);
    }

    string ICssStyleDeclaration.AnimationDirection
    {
      get => this.GetPropertyValue(PropertyNames.AnimationDirection);
      set => this.SetProperty(PropertyNames.AnimationDirection, value, (string) null);
    }

    string ICssStyleDeclaration.AnimationDuration
    {
      get => this.GetPropertyValue(PropertyNames.AnimationDuration);
      set => this.SetProperty(PropertyNames.AnimationDuration, value, (string) null);
    }

    string ICssStyleDeclaration.AnimationFillMode
    {
      get => this.GetPropertyValue(PropertyNames.AnimationFillMode);
      set => this.SetProperty(PropertyNames.AnimationFillMode, value, (string) null);
    }

    string ICssStyleDeclaration.AnimationIterationCount
    {
      get => this.GetPropertyValue(PropertyNames.AnimationIterationCount);
      set => this.SetProperty(PropertyNames.AnimationIterationCount, value, (string) null);
    }

    string ICssStyleDeclaration.AnimationName
    {
      get => this.GetPropertyValue(PropertyNames.AnimationName);
      set => this.SetProperty(PropertyNames.AnimationName, value, (string) null);
    }

    string ICssStyleDeclaration.AnimationPlayState
    {
      get => this.GetPropertyValue(PropertyNames.AnimationPlayState);
      set => this.SetProperty(PropertyNames.AnimationPlayState, value, (string) null);
    }

    string ICssStyleDeclaration.AnimationTimingFunction
    {
      get => this.GetPropertyValue(PropertyNames.AnimationTimingFunction);
      set => this.SetProperty(PropertyNames.AnimationTimingFunction, value, (string) null);
    }

    string ICssStyleDeclaration.BackfaceVisibility
    {
      get => this.GetPropertyValue(PropertyNames.BackfaceVisibility);
      set => this.SetProperty(PropertyNames.BackfaceVisibility, value, (string) null);
    }

    string ICssStyleDeclaration.Background
    {
      get => this.GetPropertyValue(PropertyNames.Background);
      set => this.SetProperty(PropertyNames.Background, value, (string) null);
    }

    string ICssStyleDeclaration.BackgroundAttachment
    {
      get => this.GetPropertyValue(PropertyNames.BackgroundAttachment);
      set => this.SetProperty(PropertyNames.BackgroundAttachment, value, (string) null);
    }

    string ICssStyleDeclaration.BackgroundClip
    {
      get => this.GetPropertyValue(PropertyNames.BackgroundClip);
      set => this.SetProperty(PropertyNames.BackgroundClip, value, (string) null);
    }

    string ICssStyleDeclaration.BackgroundColor
    {
      get => this.GetPropertyValue(PropertyNames.BackgroundColor);
      set => this.SetProperty(PropertyNames.BackgroundColor, value, (string) null);
    }

    string ICssStyleDeclaration.BackgroundImage
    {
      get => this.GetPropertyValue(PropertyNames.BackgroundImage);
      set => this.SetProperty(PropertyNames.BackgroundImage, value, (string) null);
    }

    string ICssStyleDeclaration.BackgroundOrigin
    {
      get => this.GetPropertyValue(PropertyNames.BackgroundOrigin);
      set => this.SetProperty(PropertyNames.BackgroundOrigin, value, (string) null);
    }

    string ICssStyleDeclaration.BackgroundPosition
    {
      get => this.GetPropertyValue(PropertyNames.BackgroundPosition);
      set => this.SetProperty(PropertyNames.BackgroundPosition, value, (string) null);
    }

    string ICssStyleDeclaration.BackgroundPositionX
    {
      get => this.GetPropertyValue(PropertyNames.BackgroundPositionX);
      set => this.SetProperty(PropertyNames.BackgroundPositionX, value, (string) null);
    }

    string ICssStyleDeclaration.BackgroundPositionY
    {
      get => this.GetPropertyValue(PropertyNames.BackgroundPositionY);
      set => this.SetProperty(PropertyNames.BackgroundPositionY, value, (string) null);
    }

    string ICssStyleDeclaration.BackgroundRepeat
    {
      get => this.GetPropertyValue(PropertyNames.BackgroundRepeat);
      set => this.SetProperty(PropertyNames.BackgroundRepeat, value, (string) null);
    }

    string ICssStyleDeclaration.BackgroundSize
    {
      get => this.GetPropertyValue(PropertyNames.BackgroundSize);
      set => this.SetProperty(PropertyNames.BackgroundSize, value, (string) null);
    }

    string ICssStyleDeclaration.BaselineShift
    {
      get => this.GetPropertyValue(PropertyNames.BaselineShift);
      set => this.SetProperty(PropertyNames.BaselineShift, value, (string) null);
    }

    string ICssStyleDeclaration.Behavior
    {
      get => this.GetPropertyValue(PropertyNames.Behavior);
      set => this.SetProperty(PropertyNames.Behavior, value, (string) null);
    }

    string ICssStyleDeclaration.Bottom
    {
      get => this.GetPropertyValue(PropertyNames.Bottom);
      set => this.SetProperty(PropertyNames.Bottom, value, (string) null);
    }

    string ICssStyleDeclaration.Border
    {
      get => this.GetPropertyValue(PropertyNames.Border);
      set => this.SetProperty(PropertyNames.Border, value, (string) null);
    }

    string ICssStyleDeclaration.BorderBottom
    {
      get => this.GetPropertyValue(PropertyNames.BorderBottom);
      set => this.SetProperty(PropertyNames.BorderBottom, value, (string) null);
    }

    string ICssStyleDeclaration.BorderBottomColor
    {
      get => this.GetPropertyValue(PropertyNames.BorderBottomColor);
      set => this.SetProperty(PropertyNames.BorderBottomColor, value, (string) null);
    }

    string ICssStyleDeclaration.BorderBottomLeftRadius
    {
      get => this.GetPropertyValue(PropertyNames.BorderBottomLeftRadius);
      set => this.SetProperty(PropertyNames.BorderBottomLeftRadius, value, (string) null);
    }

    string ICssStyleDeclaration.BorderBottomRightRadius
    {
      get => this.GetPropertyValue(PropertyNames.BorderBottomRightRadius);
      set => this.SetProperty(PropertyNames.BorderBottomRightRadius, value, (string) null);
    }

    string ICssStyleDeclaration.BorderBottomStyle
    {
      get => this.GetPropertyValue(PropertyNames.BorderBottomStyle);
      set => this.SetProperty(PropertyNames.BorderBottomStyle, value, (string) null);
    }

    string ICssStyleDeclaration.BorderBottomWidth
    {
      get => this.GetPropertyValue(PropertyNames.BorderBottomWidth);
      set => this.SetProperty(PropertyNames.BorderBottomWidth, value, (string) null);
    }

    string ICssStyleDeclaration.BorderCollapse
    {
      get => this.GetPropertyValue(PropertyNames.BorderCollapse);
      set => this.SetProperty(PropertyNames.BorderCollapse, value, (string) null);
    }

    string ICssStyleDeclaration.BorderColor
    {
      get => this.GetPropertyValue(PropertyNames.BorderColor);
      set => this.SetProperty(PropertyNames.BorderColor, value, (string) null);
    }

    string ICssStyleDeclaration.BorderImage
    {
      get => this.GetPropertyValue(PropertyNames.BorderImage);
      set => this.SetProperty(PropertyNames.BorderImage, value, (string) null);
    }

    string ICssStyleDeclaration.BorderImageOutset
    {
      get => this.GetPropertyValue(PropertyNames.BorderImageOutset);
      set => this.SetProperty(PropertyNames.BorderImageOutset, value, (string) null);
    }

    string ICssStyleDeclaration.BorderImageRepeat
    {
      get => this.GetPropertyValue(PropertyNames.BorderImageRepeat);
      set => this.SetProperty(PropertyNames.BorderImageRepeat, value, (string) null);
    }

    string ICssStyleDeclaration.BorderImageSlice
    {
      get => this.GetPropertyValue(PropertyNames.BorderImageSlice);
      set => this.SetProperty(PropertyNames.BorderImageSlice, value, (string) null);
    }

    string ICssStyleDeclaration.BorderImageSource
    {
      get => this.GetPropertyValue(PropertyNames.BorderImageSource);
      set => this.SetProperty(PropertyNames.BorderImageSource, value, (string) null);
    }

    string ICssStyleDeclaration.BorderImageWidth
    {
      get => this.GetPropertyValue(PropertyNames.BorderImageWidth);
      set => this.SetProperty(PropertyNames.BorderImageWidth, value, (string) null);
    }

    string ICssStyleDeclaration.BorderLeft
    {
      get => this.GetPropertyValue(PropertyNames.BorderLeft);
      set => this.SetProperty(PropertyNames.BorderLeft, value, (string) null);
    }

    string ICssStyleDeclaration.BorderLeftColor
    {
      get => this.GetPropertyValue(PropertyNames.BorderLeftColor);
      set => this.SetProperty(PropertyNames.BorderLeftColor, value, (string) null);
    }

    string ICssStyleDeclaration.BorderLeftStyle
    {
      get => this.GetPropertyValue(PropertyNames.BorderLeftStyle);
      set => this.SetProperty(PropertyNames.BorderLeftStyle, value, (string) null);
    }

    string ICssStyleDeclaration.BorderLeftWidth
    {
      get => this.GetPropertyValue(PropertyNames.BorderLeftWidth);
      set => this.SetProperty(PropertyNames.BorderLeftWidth, value, (string) null);
    }

    string ICssStyleDeclaration.BorderRadius
    {
      get => this.GetPropertyValue(PropertyNames.BorderRadius);
      set => this.SetProperty(PropertyNames.BorderRadius, value, (string) null);
    }

    string ICssStyleDeclaration.BorderRight
    {
      get => this.GetPropertyValue(PropertyNames.BorderRight);
      set => this.SetProperty(PropertyNames.BorderRight, value, (string) null);
    }

    string ICssStyleDeclaration.BorderRightColor
    {
      get => this.GetPropertyValue(PropertyNames.BorderRightColor);
      set => this.SetProperty(PropertyNames.BorderRightColor, value, (string) null);
    }

    string ICssStyleDeclaration.BorderRightStyle
    {
      get => this.GetPropertyValue(PropertyNames.BorderRightStyle);
      set => this.SetProperty(PropertyNames.BorderRightStyle, value, (string) null);
    }

    string ICssStyleDeclaration.BorderRightWidth
    {
      get => this.GetPropertyValue(PropertyNames.BorderRightWidth);
      set => this.SetProperty(PropertyNames.BorderRightWidth, value, (string) null);
    }

    string ICssStyleDeclaration.BorderSpacing
    {
      get => this.GetPropertyValue(PropertyNames.BorderSpacing);
      set => this.SetProperty(PropertyNames.BorderSpacing, value, (string) null);
    }

    string ICssStyleDeclaration.BorderStyle
    {
      get => this.GetPropertyValue(PropertyNames.BorderStyle);
      set => this.SetProperty(PropertyNames.BorderStyle, value, (string) null);
    }

    string ICssStyleDeclaration.BorderTop
    {
      get => this.GetPropertyValue(PropertyNames.BorderTop);
      set => this.SetProperty(PropertyNames.BorderTop, value, (string) null);
    }

    string ICssStyleDeclaration.BorderTopColor
    {
      get => this.GetPropertyValue(PropertyNames.BorderTopColor);
      set => this.SetProperty(PropertyNames.BorderTopColor, value, (string) null);
    }

    string ICssStyleDeclaration.BorderTopLeftRadius
    {
      get => this.GetPropertyValue(PropertyNames.BorderTopLeftRadius);
      set => this.SetProperty(PropertyNames.BorderTopLeftRadius, value, (string) null);
    }

    string ICssStyleDeclaration.BorderTopRightRadius
    {
      get => this.GetPropertyValue(PropertyNames.BorderTopRightRadius);
      set => this.SetProperty(PropertyNames.BorderTopRightRadius, value, (string) null);
    }

    string ICssStyleDeclaration.BorderTopStyle
    {
      get => this.GetPropertyValue(PropertyNames.BorderTopStyle);
      set => this.SetProperty(PropertyNames.BorderTopStyle, value, (string) null);
    }

    string ICssStyleDeclaration.BorderTopWidth
    {
      get => this.GetPropertyValue(PropertyNames.BorderTopWidth);
      set => this.SetProperty(PropertyNames.BorderTopWidth, value, (string) null);
    }

    string ICssStyleDeclaration.BorderWidth
    {
      get => this.GetPropertyValue(PropertyNames.BorderWidth);
      set => this.SetProperty(PropertyNames.BorderWidth, value, (string) null);
    }

    string ICssStyleDeclaration.BoxShadow
    {
      get => this.GetPropertyValue(PropertyNames.BoxShadow);
      set => this.SetProperty(PropertyNames.BoxShadow, value, (string) null);
    }

    string ICssStyleDeclaration.BoxSizing
    {
      get => this.GetPropertyValue(PropertyNames.BoxSizing);
      set => this.SetProperty(PropertyNames.BoxSizing, value, (string) null);
    }

    string ICssStyleDeclaration.BreakAfter
    {
      get => this.GetPropertyValue(PropertyNames.BreakAfter);
      set => this.SetProperty(PropertyNames.BreakAfter, value, (string) null);
    }

    string ICssStyleDeclaration.BreakBefore
    {
      get => this.GetPropertyValue(PropertyNames.BreakBefore);
      set => this.SetProperty(PropertyNames.BreakBefore, value, (string) null);
    }

    string ICssStyleDeclaration.BreakInside
    {
      get => this.GetPropertyValue(PropertyNames.BreakInside);
      set => this.SetProperty(PropertyNames.BreakInside, value, (string) null);
    }

    string ICssStyleDeclaration.CaptionSide
    {
      get => this.GetPropertyValue(PropertyNames.CaptionSide);
      set => this.SetProperty(PropertyNames.CaptionSide, value, (string) null);
    }

    string ICssStyleDeclaration.Clear
    {
      get => this.GetPropertyValue(PropertyNames.Clear);
      set => this.SetProperty(PropertyNames.Clear, value, (string) null);
    }

    string ICssStyleDeclaration.Clip
    {
      get => this.GetPropertyValue(PropertyNames.Clip);
      set => this.SetProperty(PropertyNames.Clip, value, (string) null);
    }

    string ICssStyleDeclaration.ClipBottom
    {
      get => this.GetPropertyValue(PropertyNames.ClipBottom);
      set => this.SetProperty(PropertyNames.ClipBottom, value, (string) null);
    }

    string ICssStyleDeclaration.ClipLeft
    {
      get => this.GetPropertyValue(PropertyNames.ClipLeft);
      set => this.SetProperty(PropertyNames.ClipLeft, value, (string) null);
    }

    string ICssStyleDeclaration.ClipPath
    {
      get => this.GetPropertyValue(PropertyNames.ClipPath);
      set => this.SetProperty(PropertyNames.ClipPath, value, (string) null);
    }

    string ICssStyleDeclaration.ClipRight
    {
      get => this.GetPropertyValue(PropertyNames.ClipRight);
      set => this.SetProperty(PropertyNames.ClipRight, value, (string) null);
    }

    string ICssStyleDeclaration.ClipRule
    {
      get => this.GetPropertyValue(PropertyNames.ClipRule);
      set => this.SetProperty(PropertyNames.ClipRule, value, (string) null);
    }

    string ICssStyleDeclaration.ClipTop
    {
      get => this.GetPropertyValue(PropertyNames.ClipTop);
      set => this.SetProperty(PropertyNames.ClipTop, value, (string) null);
    }

    string ICssStyleDeclaration.Color
    {
      get => this.GetPropertyValue(PropertyNames.Color);
      set => this.SetProperty(PropertyNames.Color, value, (string) null);
    }

    string ICssStyleDeclaration.ColorInterpolationFilters
    {
      get => this.GetPropertyValue(PropertyNames.ColorInterpolationFilters);
      set => this.SetProperty(PropertyNames.ColorInterpolationFilters, value, (string) null);
    }

    string ICssStyleDeclaration.ColumnCount
    {
      get => this.GetPropertyValue(PropertyNames.ColumnCount);
      set => this.SetProperty(PropertyNames.ColumnCount, value, (string) null);
    }

    string ICssStyleDeclaration.ColumnFill
    {
      get => this.GetPropertyValue(PropertyNames.ColumnFill);
      set => this.SetProperty(PropertyNames.ColumnFill, value, (string) null);
    }

    string ICssStyleDeclaration.ColumnGap
    {
      get => this.GetPropertyValue(PropertyNames.ColumnGap);
      set => this.SetProperty(PropertyNames.ColumnGap, value, (string) null);
    }

    string ICssStyleDeclaration.ColumnRule
    {
      get => this.GetPropertyValue(PropertyNames.ColumnRule);
      set => this.SetProperty(PropertyNames.ColumnRule, value, (string) null);
    }

    string ICssStyleDeclaration.ColumnRuleColor
    {
      get => this.GetPropertyValue(PropertyNames.ColumnRuleColor);
      set => this.SetProperty(PropertyNames.ColumnRuleColor, value, (string) null);
    }

    string ICssStyleDeclaration.ColumnRuleStyle
    {
      get => this.GetPropertyValue(PropertyNames.ColumnRuleStyle);
      set => this.SetProperty(PropertyNames.ColumnRuleStyle, value, (string) null);
    }

    string ICssStyleDeclaration.ColumnRuleWidth
    {
      get => this.GetPropertyValue(PropertyNames.ColumnRuleWidth);
      set => this.SetProperty(PropertyNames.ColumnRuleWidth, value, (string) null);
    }

    string ICssStyleDeclaration.Columns
    {
      get => this.GetPropertyValue(PropertyNames.Columns);
      set => this.SetProperty(PropertyNames.Columns, value, (string) null);
    }

    string ICssStyleDeclaration.ColumnSpan
    {
      get => this.GetPropertyValue(PropertyNames.ColumnSpan);
      set => this.SetProperty(PropertyNames.ColumnSpan, value, (string) null);
    }

    string ICssStyleDeclaration.ColumnWidth
    {
      get => this.GetPropertyValue(PropertyNames.ColumnWidth);
      set => this.SetProperty(PropertyNames.ColumnWidth, value, (string) null);
    }

    string ICssStyleDeclaration.Content
    {
      get => this.GetPropertyValue(PropertyNames.Content);
      set => this.SetProperty(PropertyNames.Content, value, (string) null);
    }

    string ICssStyleDeclaration.CounterIncrement
    {
      get => this.GetPropertyValue(PropertyNames.CounterIncrement);
      set => this.SetProperty(PropertyNames.CounterIncrement, value, (string) null);
    }

    string ICssStyleDeclaration.CounterReset
    {
      get => this.GetPropertyValue(PropertyNames.CounterReset);
      set => this.SetProperty(PropertyNames.CounterReset, value, (string) null);
    }

    string ICssStyleDeclaration.Float
    {
      get => this.GetPropertyValue(PropertyNames.Float);
      set => this.SetProperty(PropertyNames.Float, value, (string) null);
    }

    string ICssStyleDeclaration.Cursor
    {
      get => this.GetPropertyValue(PropertyNames.Cursor);
      set => this.SetProperty(PropertyNames.Cursor, value, (string) null);
    }

    string ICssStyleDeclaration.Direction
    {
      get => this.GetPropertyValue(PropertyNames.Direction);
      set => this.SetProperty(PropertyNames.Direction, value, (string) null);
    }

    string ICssStyleDeclaration.Display
    {
      get => this.GetPropertyValue(PropertyNames.Display);
      set => this.SetProperty(PropertyNames.Display, value, (string) null);
    }

    string ICssStyleDeclaration.DominantBaseline
    {
      get => this.GetPropertyValue(PropertyNames.DominantBaseline);
      set => this.SetProperty(PropertyNames.DominantBaseline, value, (string) null);
    }

    string ICssStyleDeclaration.EmptyCells
    {
      get => this.GetPropertyValue(PropertyNames.EmptyCells);
      set => this.SetProperty(PropertyNames.EmptyCells, value, (string) null);
    }

    string ICssStyleDeclaration.EnableBackground
    {
      get => this.GetPropertyValue(PropertyNames.EnableBackground);
      set => this.SetProperty(PropertyNames.EnableBackground, value, (string) null);
    }

    string ICssStyleDeclaration.Fill
    {
      get => this.GetPropertyValue(PropertyNames.Fill);
      set => this.SetProperty(PropertyNames.Fill, value, (string) null);
    }

    string ICssStyleDeclaration.FillOpacity
    {
      get => this.GetPropertyValue(PropertyNames.FillOpacity);
      set => this.SetProperty(PropertyNames.FillOpacity, value, (string) null);
    }

    string ICssStyleDeclaration.FillRule
    {
      get => this.GetPropertyValue(PropertyNames.FillRule);
      set => this.SetProperty(PropertyNames.FillRule, value, (string) null);
    }

    string ICssStyleDeclaration.Filter
    {
      get => this.GetPropertyValue(PropertyNames.Filter);
      set => this.SetProperty(PropertyNames.Filter, value, (string) null);
    }

    string ICssStyleDeclaration.Flex
    {
      get => this.GetPropertyValue(PropertyNames.Flex);
      set => this.SetProperty(PropertyNames.Flex, value, (string) null);
    }

    string ICssStyleDeclaration.FlexBasis
    {
      get => this.GetPropertyValue(PropertyNames.FlexBasis);
      set => this.SetProperty(PropertyNames.FlexBasis, value, (string) null);
    }

    string ICssStyleDeclaration.FlexDirection
    {
      get => this.GetPropertyValue(PropertyNames.FlexDirection);
      set => this.SetProperty(PropertyNames.FlexDirection, value, (string) null);
    }

    string ICssStyleDeclaration.FlexFlow
    {
      get => this.GetPropertyValue(PropertyNames.FlexFlow);
      set => this.SetProperty(PropertyNames.FlexFlow, value, (string) null);
    }

    string ICssStyleDeclaration.FlexGrow
    {
      get => this.GetPropertyValue(PropertyNames.FlexGrow);
      set => this.SetProperty(PropertyNames.FlexGrow, value, (string) null);
    }

    string ICssStyleDeclaration.FlexShrink
    {
      get => this.GetPropertyValue(PropertyNames.FlexShrink);
      set => this.SetProperty(PropertyNames.FlexShrink, value, (string) null);
    }

    string ICssStyleDeclaration.FlexWrap
    {
      get => this.GetPropertyValue(PropertyNames.FlexWrap);
      set => this.SetProperty(PropertyNames.FlexWrap, value, (string) null);
    }

    string ICssStyleDeclaration.Font
    {
      get => this.GetPropertyValue(PropertyNames.Font);
      set => this.SetProperty(PropertyNames.Font, value, (string) null);
    }

    string ICssStyleDeclaration.FontFamily
    {
      get => this.GetPropertyValue(PropertyNames.FontFamily);
      set => this.SetProperty(PropertyNames.FontFamily, value, (string) null);
    }

    string ICssStyleDeclaration.FontFeatureSettings
    {
      get => this.GetPropertyValue(PropertyNames.FontFeatureSettings);
      set => this.SetProperty(PropertyNames.FontFeatureSettings, value, (string) null);
    }

    string ICssStyleDeclaration.FontSize
    {
      get => this.GetPropertyValue(PropertyNames.FontSize);
      set => this.SetProperty(PropertyNames.FontSize, value, (string) null);
    }

    string ICssStyleDeclaration.FontSizeAdjust
    {
      get => this.GetPropertyValue(PropertyNames.FontSizeAdjust);
      set => this.SetProperty(PropertyNames.FontSizeAdjust, value, (string) null);
    }

    string ICssStyleDeclaration.FontStretch
    {
      get => this.GetPropertyValue(PropertyNames.FontStretch);
      set => this.SetProperty(PropertyNames.FontStretch, value, (string) null);
    }

    string ICssStyleDeclaration.FontStyle
    {
      get => this.GetPropertyValue(PropertyNames.FontStyle);
      set => this.SetProperty(PropertyNames.FontStyle, value, (string) null);
    }

    string ICssStyleDeclaration.FontVariant
    {
      get => this.GetPropertyValue(PropertyNames.FontVariant);
      set => this.SetProperty(PropertyNames.FontVariant, value, (string) null);
    }

    string ICssStyleDeclaration.FontWeight
    {
      get => this.GetPropertyValue(PropertyNames.FontWeight);
      set => this.SetProperty(PropertyNames.FontWeight, value, (string) null);
    }

    string ICssStyleDeclaration.GlyphOrientationHorizontal
    {
      get => this.GetPropertyValue(PropertyNames.GlyphOrientationHorizontal);
      set => this.SetProperty(PropertyNames.GlyphOrientationHorizontal, value, (string) null);
    }

    string ICssStyleDeclaration.GlyphOrientationVertical
    {
      get => this.GetPropertyValue(PropertyNames.GlyphOrientationVertical);
      set => this.SetProperty(PropertyNames.GlyphOrientationVertical, value, (string) null);
    }

    string ICssStyleDeclaration.Height
    {
      get => this.GetPropertyValue(PropertyNames.Height);
      set => this.SetProperty(PropertyNames.Height, value, (string) null);
    }

    string ICssStyleDeclaration.ImeMode
    {
      get => this.GetPropertyValue(PropertyNames.ImeMode);
      set => this.SetProperty(PropertyNames.ImeMode, value, (string) null);
    }

    string ICssStyleDeclaration.JustifyContent
    {
      get => this.GetPropertyValue(PropertyNames.JustifyContent);
      set => this.SetProperty(PropertyNames.JustifyContent, value, (string) null);
    }

    string ICssStyleDeclaration.LayoutGrid
    {
      get => this.GetPropertyValue(PropertyNames.LayoutGrid);
      set => this.SetProperty(PropertyNames.LayoutGrid, value, (string) null);
    }

    string ICssStyleDeclaration.LayoutGridChar
    {
      get => this.GetPropertyValue(PropertyNames.LayoutGridChar);
      set => this.SetProperty(PropertyNames.LayoutGridChar, value, (string) null);
    }

    string ICssStyleDeclaration.LayoutGridLine
    {
      get => this.GetPropertyValue(PropertyNames.LayoutGridLine);
      set => this.SetProperty(PropertyNames.LayoutGridLine, value, (string) null);
    }

    string ICssStyleDeclaration.LayoutGridMode
    {
      get => this.GetPropertyValue(PropertyNames.LayoutGridMode);
      set => this.SetProperty(PropertyNames.LayoutGridMode, value, (string) null);
    }

    string ICssStyleDeclaration.LayoutGridType
    {
      get => this.GetPropertyValue(PropertyNames.LayoutGridType);
      set => this.SetProperty(PropertyNames.LayoutGridType, value, (string) null);
    }

    string ICssStyleDeclaration.Left
    {
      get => this.GetPropertyValue(PropertyNames.Left);
      set => this.SetProperty(PropertyNames.Left, value, (string) null);
    }

    string ICssStyleDeclaration.LetterSpacing
    {
      get => this.GetPropertyValue(PropertyNames.LetterSpacing);
      set => this.SetProperty(PropertyNames.LetterSpacing, value, (string) null);
    }

    string ICssStyleDeclaration.LineHeight
    {
      get => this.GetPropertyValue(PropertyNames.LineHeight);
      set => this.SetProperty(PropertyNames.LineHeight, value, (string) null);
    }

    string ICssStyleDeclaration.ListStyle
    {
      get => this.GetPropertyValue(PropertyNames.ListStyle);
      set => this.SetProperty(PropertyNames.ListStyle, value, (string) null);
    }

    string ICssStyleDeclaration.ListStyleImage
    {
      get => this.GetPropertyValue(PropertyNames.ListStyleImage);
      set => this.SetProperty(PropertyNames.ListStyleImage, value, (string) null);
    }

    string ICssStyleDeclaration.ListStylePosition
    {
      get => this.GetPropertyValue(PropertyNames.ListStylePosition);
      set => this.SetProperty(PropertyNames.ListStylePosition, value, (string) null);
    }

    string ICssStyleDeclaration.ListStyleType
    {
      get => this.GetPropertyValue(PropertyNames.ListStyleType);
      set => this.SetProperty(PropertyNames.ListStyleType, value, (string) null);
    }

    string ICssStyleDeclaration.Margin
    {
      get => this.GetPropertyValue(PropertyNames.Margin);
      set => this.SetProperty(PropertyNames.Margin, value, (string) null);
    }

    string ICssStyleDeclaration.MarginBottom
    {
      get => this.GetPropertyValue(PropertyNames.MarginBottom);
      set => this.SetProperty(PropertyNames.MarginBottom, value, (string) null);
    }

    string ICssStyleDeclaration.MarginLeft
    {
      get => this.GetPropertyValue(PropertyNames.MarginLeft);
      set => this.SetProperty(PropertyNames.MarginLeft, value, (string) null);
    }

    string ICssStyleDeclaration.MarginRight
    {
      get => this.GetPropertyValue(PropertyNames.MarginRight);
      set => this.SetProperty(PropertyNames.MarginRight, value, (string) null);
    }

    string ICssStyleDeclaration.MarginTop
    {
      get => this.GetPropertyValue(PropertyNames.MarginTop);
      set => this.SetProperty(PropertyNames.MarginTop, value, (string) null);
    }

    string ICssStyleDeclaration.Marker
    {
      get => this.GetPropertyValue(PropertyNames.Marker);
      set => this.SetProperty(PropertyNames.Marker, value, (string) null);
    }

    string ICssStyleDeclaration.MarkerEnd
    {
      get => this.GetPropertyValue(PropertyNames.MarkerEnd);
      set => this.SetProperty(PropertyNames.MarkerEnd, value, (string) null);
    }

    string ICssStyleDeclaration.MarkerMid
    {
      get => this.GetPropertyValue(PropertyNames.MarkerMid);
      set => this.SetProperty(PropertyNames.MarkerMid, value, (string) null);
    }

    string ICssStyleDeclaration.MarkerStart
    {
      get => this.GetPropertyValue(PropertyNames.MarkerStart);
      set => this.SetProperty(PropertyNames.MarkerStart, value, (string) null);
    }

    string ICssStyleDeclaration.Mask
    {
      get => this.GetPropertyValue(PropertyNames.Mask);
      set => this.SetProperty(PropertyNames.Mask, value, (string) null);
    }

    string ICssStyleDeclaration.MaxHeight
    {
      get => this.GetPropertyValue(PropertyNames.MaxHeight);
      set => this.SetProperty(PropertyNames.MaxHeight, value, (string) null);
    }

    string ICssStyleDeclaration.MaxWidth
    {
      get => this.GetPropertyValue(PropertyNames.MaxWidth);
      set => this.SetProperty(PropertyNames.MaxWidth, value, (string) null);
    }

    string ICssStyleDeclaration.MinHeight
    {
      get => this.GetPropertyValue(PropertyNames.MinHeight);
      set => this.SetProperty(PropertyNames.MinHeight, value, (string) null);
    }

    string ICssStyleDeclaration.MinWidth
    {
      get => this.GetPropertyValue(PropertyNames.MinWidth);
      set => this.SetProperty(PropertyNames.MinWidth, value, (string) null);
    }

    string ICssStyleDeclaration.Opacity
    {
      get => this.GetPropertyValue(PropertyNames.Opacity);
      set => this.SetProperty(PropertyNames.Opacity, value, (string) null);
    }

    string ICssStyleDeclaration.Order
    {
      get => this.GetPropertyValue(PropertyNames.Order);
      set => this.SetProperty(PropertyNames.Order, value, (string) null);
    }

    string ICssStyleDeclaration.Orphans
    {
      get => this.GetPropertyValue(PropertyNames.Orphans);
      set => this.SetProperty(PropertyNames.Orphans, value, (string) null);
    }

    string ICssStyleDeclaration.Outline
    {
      get => this.GetPropertyValue(PropertyNames.Outline);
      set => this.SetProperty(PropertyNames.Outline, value, (string) null);
    }

    string ICssStyleDeclaration.OutlineColor
    {
      get => this.GetPropertyValue(PropertyNames.OutlineColor);
      set => this.SetProperty(PropertyNames.OutlineColor, value, (string) null);
    }

    string ICssStyleDeclaration.OutlineStyle
    {
      get => this.GetPropertyValue(PropertyNames.OutlineStyle);
      set => this.SetProperty(PropertyNames.OutlineStyle, value, (string) null);
    }

    string ICssStyleDeclaration.OutlineWidth
    {
      get => this.GetPropertyValue(PropertyNames.OutlineWidth);
      set => this.SetProperty(PropertyNames.OutlineWidth, value, (string) null);
    }

    string ICssStyleDeclaration.Overflow
    {
      get => this.GetPropertyValue(PropertyNames.Overflow);
      set => this.SetProperty(PropertyNames.Overflow, value, (string) null);
    }

    string ICssStyleDeclaration.OverflowX
    {
      get => this.GetPropertyValue(PropertyNames.OverflowX);
      set => this.SetProperty(PropertyNames.OverflowX, value, (string) null);
    }

    string ICssStyleDeclaration.OverflowY
    {
      get => this.GetPropertyValue(PropertyNames.OverflowY);
      set => this.SetProperty(PropertyNames.OverflowY, value, (string) null);
    }

    string ICssStyleDeclaration.OverflowWrap
    {
      get => this.GetPropertyValue(PropertyNames.WordWrap);
      set => this.SetProperty(PropertyNames.WordWrap, value, (string) null);
    }

    string ICssStyleDeclaration.Padding
    {
      get => this.GetPropertyValue(PropertyNames.Padding);
      set => this.SetProperty(PropertyNames.Padding, value, (string) null);
    }

    string ICssStyleDeclaration.PaddingBottom
    {
      get => this.GetPropertyValue(PropertyNames.PaddingBottom);
      set => this.SetProperty(PropertyNames.PaddingBottom, value, (string) null);
    }

    string ICssStyleDeclaration.PaddingLeft
    {
      get => this.GetPropertyValue(PropertyNames.PaddingLeft);
      set => this.SetProperty(PropertyNames.PaddingLeft, value, (string) null);
    }

    string ICssStyleDeclaration.PaddingRight
    {
      get => this.GetPropertyValue(PropertyNames.PaddingRight);
      set => this.SetProperty(PropertyNames.PaddingRight, value, (string) null);
    }

    string ICssStyleDeclaration.PaddingTop
    {
      get => this.GetPropertyValue(PropertyNames.PaddingTop);
      set => this.SetProperty(PropertyNames.PaddingTop, value, (string) null);
    }

    string ICssStyleDeclaration.PageBreakAfter
    {
      get => this.GetPropertyValue(PropertyNames.PageBreakAfter);
      set => this.SetProperty(PropertyNames.PageBreakAfter, value, (string) null);
    }

    string ICssStyleDeclaration.PageBreakBefore
    {
      get => this.GetPropertyValue(PropertyNames.PageBreakBefore);
      set => this.SetProperty(PropertyNames.PageBreakBefore, value, (string) null);
    }

    string ICssStyleDeclaration.PageBreakInside
    {
      get => this.GetPropertyValue(PropertyNames.PageBreakInside);
      set => this.SetProperty(PropertyNames.PageBreakInside, value, (string) null);
    }

    string ICssStyleDeclaration.Perspective
    {
      get => this.GetPropertyValue(PropertyNames.Perspective);
      set => this.SetProperty(PropertyNames.Perspective, value, (string) null);
    }

    string ICssStyleDeclaration.PerspectiveOrigin
    {
      get => this.GetPropertyValue(PropertyNames.PerspectiveOrigin);
      set => this.SetProperty(PropertyNames.PerspectiveOrigin, value, (string) null);
    }

    string ICssStyleDeclaration.PointerEvents
    {
      get => this.GetPropertyValue(PropertyNames.PointerEvents);
      set => this.SetProperty(PropertyNames.PointerEvents, value, (string) null);
    }

    string ICssStyleDeclaration.Quotes
    {
      get => this.GetPropertyValue(PropertyNames.Quotes);
      set => this.SetProperty(PropertyNames.Quotes, value, (string) null);
    }

    string ICssStyleDeclaration.Position
    {
      get => this.GetPropertyValue(PropertyNames.Position);
      set => this.SetProperty(PropertyNames.Position, value, (string) null);
    }

    string ICssStyleDeclaration.Right
    {
      get => this.GetPropertyValue(PropertyNames.Right);
      set => this.SetProperty(PropertyNames.Right, value, (string) null);
    }

    string ICssStyleDeclaration.RubyAlign
    {
      get => this.GetPropertyValue(PropertyNames.RubyAlign);
      set => this.SetProperty(PropertyNames.RubyAlign, value, (string) null);
    }

    string ICssStyleDeclaration.RubyOverhang
    {
      get => this.GetPropertyValue(PropertyNames.RubyOverhang);
      set => this.SetProperty(PropertyNames.RubyOverhang, value, (string) null);
    }

    string ICssStyleDeclaration.RubyPosition
    {
      get => this.GetPropertyValue(PropertyNames.RubyPosition);
      set => this.SetProperty(PropertyNames.RubyPosition, value, (string) null);
    }

    string ICssStyleDeclaration.Scrollbar3dLightColor
    {
      get => this.GetPropertyValue(PropertyNames.Scrollbar3dLightColor);
      set => this.SetProperty(PropertyNames.Scrollbar3dLightColor, value, (string) null);
    }

    string ICssStyleDeclaration.ScrollbarArrowColor
    {
      get => this.GetPropertyValue(PropertyNames.ScrollbarArrowColor);
      set => this.SetProperty(PropertyNames.ScrollbarArrowColor, value, (string) null);
    }

    string ICssStyleDeclaration.ScrollbarDarkShadowColor
    {
      get => this.GetPropertyValue(PropertyNames.ScrollbarDarkShadowColor);
      set => this.SetProperty(PropertyNames.ScrollbarDarkShadowColor, value, (string) null);
    }

    string ICssStyleDeclaration.ScrollbarFaceColor
    {
      get => this.GetPropertyValue(PropertyNames.ScrollbarFaceColor);
      set => this.SetProperty(PropertyNames.ScrollbarFaceColor, value, (string) null);
    }

    string ICssStyleDeclaration.ScrollbarHighlightColor
    {
      get => this.GetPropertyValue(PropertyNames.ScrollbarHighlightColor);
      set => this.SetProperty(PropertyNames.ScrollbarHighlightColor, value, (string) null);
    }

    string ICssStyleDeclaration.ScrollbarShadowColor
    {
      get => this.GetPropertyValue(PropertyNames.ScrollbarShadowColor);
      set => this.SetProperty(PropertyNames.ScrollbarShadowColor, value, (string) null);
    }

    string ICssStyleDeclaration.ScrollbarTrackColor
    {
      get => this.GetPropertyValue(PropertyNames.ScrollbarTrackColor);
      set => this.SetProperty(PropertyNames.ScrollbarTrackColor, value, (string) null);
    }

    string ICssStyleDeclaration.Stroke
    {
      get => this.GetPropertyValue(PropertyNames.Stroke);
      set => this.SetProperty(PropertyNames.Stroke, value, (string) null);
    }

    string ICssStyleDeclaration.StrokeDasharray
    {
      get => this.GetPropertyValue(PropertyNames.StrokeDasharray);
      set => this.SetProperty(PropertyNames.StrokeDasharray, value, (string) null);
    }

    string ICssStyleDeclaration.StrokeDashoffset
    {
      get => this.GetPropertyValue(PropertyNames.StrokeDashoffset);
      set => this.SetProperty(PropertyNames.StrokeDashoffset, value, (string) null);
    }

    string ICssStyleDeclaration.StrokeLinecap
    {
      get => this.GetPropertyValue(PropertyNames.StrokeLinecap);
      set => this.SetProperty(PropertyNames.StrokeLinecap, value, (string) null);
    }

    string ICssStyleDeclaration.StrokeLinejoin
    {
      get => this.GetPropertyValue(PropertyNames.StrokeLinejoin);
      set => this.SetProperty(PropertyNames.StrokeLinejoin, value, (string) null);
    }

    string ICssStyleDeclaration.StrokeMiterlimit
    {
      get => this.GetPropertyValue(PropertyNames.StrokeMiterlimit);
      set => this.SetProperty(PropertyNames.StrokeMiterlimit, value, (string) null);
    }

    string ICssStyleDeclaration.StrokeOpacity
    {
      get => this.GetPropertyValue(PropertyNames.StrokeOpacity);
      set => this.SetProperty(PropertyNames.StrokeOpacity, value, (string) null);
    }

    string ICssStyleDeclaration.StrokeWidth
    {
      get => this.GetPropertyValue(PropertyNames.StrokeWidth);
      set => this.SetProperty(PropertyNames.StrokeWidth, value, (string) null);
    }

    string ICssStyleDeclaration.TableLayout
    {
      get => this.GetPropertyValue(PropertyNames.TableLayout);
      set => this.SetProperty(PropertyNames.TableLayout, value, (string) null);
    }

    string ICssStyleDeclaration.TextAlign
    {
      get => this.GetPropertyValue(PropertyNames.TextAlign);
      set => this.SetProperty(PropertyNames.TextAlign, value, (string) null);
    }

    string ICssStyleDeclaration.TextAlignLast
    {
      get => this.GetPropertyValue(PropertyNames.TextAlignLast);
      set => this.SetProperty(PropertyNames.TextAlignLast, value, (string) null);
    }

    string ICssStyleDeclaration.TextAnchor
    {
      get => this.GetPropertyValue(PropertyNames.TextAnchor);
      set => this.SetProperty(PropertyNames.TextAnchor, value, (string) null);
    }

    string ICssStyleDeclaration.TextAutospace
    {
      get => this.GetPropertyValue(PropertyNames.TextAutospace);
      set => this.SetProperty(PropertyNames.TextAutospace, value, (string) null);
    }

    string ICssStyleDeclaration.TextDecoration
    {
      get => this.GetPropertyValue(PropertyNames.TextDecoration);
      set => this.SetProperty(PropertyNames.TextDecoration, value, (string) null);
    }

    string ICssStyleDeclaration.TextIndent
    {
      get => this.GetPropertyValue(PropertyNames.TextIndent);
      set => this.SetProperty(PropertyNames.TextIndent, value, (string) null);
    }

    string ICssStyleDeclaration.TextJustify
    {
      get => this.GetPropertyValue(PropertyNames.TextJustify);
      set => this.SetProperty(PropertyNames.TextJustify, value, (string) null);
    }

    string ICssStyleDeclaration.TextOverflow
    {
      get => this.GetPropertyValue(PropertyNames.TextOverflow);
      set => this.SetProperty(PropertyNames.TextOverflow, value, (string) null);
    }

    string ICssStyleDeclaration.TextShadow
    {
      get => this.GetPropertyValue(PropertyNames.TextShadow);
      set => this.SetProperty(PropertyNames.TextShadow, value, (string) null);
    }

    string ICssStyleDeclaration.TextTransform
    {
      get => this.GetPropertyValue(PropertyNames.TextTransform);
      set => this.SetProperty(PropertyNames.TextTransform, value, (string) null);
    }

    string ICssStyleDeclaration.TextUnderlinePosition
    {
      get => this.GetPropertyValue(PropertyNames.TextUnderlinePosition);
      set => this.SetProperty(PropertyNames.TextUnderlinePosition, value, (string) null);
    }

    string ICssStyleDeclaration.Top
    {
      get => this.GetPropertyValue(PropertyNames.Top);
      set => this.SetProperty(PropertyNames.Top, value, (string) null);
    }

    string ICssStyleDeclaration.Transform
    {
      get => this.GetPropertyValue(PropertyNames.Transform);
      set => this.SetProperty(PropertyNames.Transform, value, (string) null);
    }

    string ICssStyleDeclaration.TransformOrigin
    {
      get => this.GetPropertyValue(PropertyNames.TransformOrigin);
      set => this.SetProperty(PropertyNames.TransformOrigin, value, (string) null);
    }

    string ICssStyleDeclaration.TransformStyle
    {
      get => this.GetPropertyValue(PropertyNames.TransformStyle);
      set => this.SetProperty(PropertyNames.TransformStyle, value, (string) null);
    }

    string ICssStyleDeclaration.Transition
    {
      get => this.GetPropertyValue(PropertyNames.Transition);
      set => this.SetProperty(PropertyNames.Transition, value, (string) null);
    }

    string ICssStyleDeclaration.TransitionDelay
    {
      get => this.GetPropertyValue(PropertyNames.TransitionDelay);
      set => this.SetProperty(PropertyNames.TransitionDelay, value, (string) null);
    }

    string ICssStyleDeclaration.TransitionDuration
    {
      get => this.GetPropertyValue(PropertyNames.TransitionDuration);
      set => this.SetProperty(PropertyNames.TransitionDuration, value, (string) null);
    }

    string ICssStyleDeclaration.TransitionProperty
    {
      get => this.GetPropertyValue(PropertyNames.TransitionProperty);
      set => this.SetProperty(PropertyNames.TransitionProperty, value, (string) null);
    }

    string ICssStyleDeclaration.TransitionTimingFunction
    {
      get => this.GetPropertyValue(PropertyNames.TransitionTimingFunction);
      set => this.SetProperty(PropertyNames.TransitionTimingFunction, value, (string) null);
    }

    string ICssStyleDeclaration.UnicodeBidi
    {
      get => this.GetPropertyValue(PropertyNames.UnicodeBidi);
      set => this.SetProperty(PropertyNames.UnicodeBidi, value, (string) null);
    }

    string ICssStyleDeclaration.VerticalAlign
    {
      get => this.GetPropertyValue(PropertyNames.VerticalAlign);
      set => this.SetProperty(PropertyNames.VerticalAlign, value, (string) null);
    }

    string ICssStyleDeclaration.Visibility
    {
      get => this.GetPropertyValue(PropertyNames.Visibility);
      set => this.SetProperty(PropertyNames.Visibility, value, (string) null);
    }

    string ICssStyleDeclaration.WhiteSpace
    {
      get => this.GetPropertyValue(PropertyNames.WhiteSpace);
      set => this.SetProperty(PropertyNames.WhiteSpace, value, (string) null);
    }

    string ICssStyleDeclaration.Widows
    {
      get => this.GetPropertyValue(PropertyNames.Widows);
      set => this.SetProperty(PropertyNames.Widows, value, (string) null);
    }

    string ICssStyleDeclaration.Width
    {
      get => this.GetPropertyValue(PropertyNames.Width);
      set => this.SetProperty(PropertyNames.Width, value, (string) null);
    }

    string ICssStyleDeclaration.WordBreak
    {
      get => this.GetPropertyValue(PropertyNames.WordBreak);
      set => this.SetProperty(PropertyNames.WordBreak, value, (string) null);
    }

    string ICssStyleDeclaration.WordSpacing
    {
      get => this.GetPropertyValue(PropertyNames.WordSpacing);
      set => this.SetProperty(PropertyNames.WordSpacing, value, (string) null);
    }

    string ICssStyleDeclaration.WritingMode
    {
      get => this.GetPropertyValue(PropertyNames.WritingMode);
      set => this.SetProperty(PropertyNames.WritingMode, value, (string) null);
    }

    string ICssStyleDeclaration.ZIndex
    {
      get => this.GetPropertyValue(PropertyNames.ZIndex);
      set => this.SetProperty(PropertyNames.ZIndex, value, (string) null);
    }

    string ICssStyleDeclaration.Zoom
    {
      get => this.GetPropertyValue(PropertyNames.Zoom);
      set => this.SetProperty(PropertyNames.Zoom, value, (string) null);
    }

    public void Update(string value)
    {
      if (this.IsReadOnly)
        throw new DomException(DomError.NoModificationAllowed);
      this.Clear();
      if (string.IsNullOrEmpty(value))
        return;
      this._parser.AppendDeclarations(this, value);
    }

    public override void ToCss(TextWriter writer, IStyleFormatter formatter)
    {
      List<string> declarations = new List<string>();
      List<string> serialized = new List<string>();
      foreach (CssProperty declaration in this.Declarations)
      {
        string name1 = declaration.Name;
        if (this.IsStrictMode)
        {
          if (!serialized.Contains(name1))
          {
            IEnumerable<string> shorthands = Factory.Properties.GetShorthands(name1);
            if (shorthands.Any<string>())
            {
              List<CssProperty> list = this.Declarations.Where<CssProperty>((Func<CssProperty, bool>) (m => !serialized.Contains(m.Name))).ToList<CssProperty>();
              foreach (string name2 in (IEnumerable<string>) shorthands.OrderByDescending<string, int>((Func<string, int>) (m => ((IEnumerable<string>) Factory.Properties.GetLonghands(m)).Count<string>())))
              {
                CssShorthandProperty shorthand = Factory.Properties.CreateShorthand(name2);
                string[] properties = Factory.Properties.GetLonghands(name2);
                CssProperty[] array = list.Where<CssProperty>((Func<CssProperty, bool>) (m => StringExtensions.Contains(properties, m.Name))).ToArray<CssProperty>();
                if (array.Length != 0)
                {
                  int num = ((IEnumerable<CssProperty>) array).Count<CssProperty>((Func<CssProperty, bool>) (m => m.IsImportant));
                  if ((num <= 0 || num == array.Length) && properties.Length == array.Length)
                  {
                    string str = shorthand.Stringify(array);
                    if (!string.IsNullOrEmpty(str))
                    {
                      declarations.Add(CssStyleFormatter.Instance.Declaration(name2, str, num != 0));
                      foreach (CssProperty cssProperty in array)
                      {
                        serialized.Add(cssProperty.Name);
                        list.Remove(cssProperty);
                      }
                    }
                  }
                }
              }
            }
            if (!serialized.Contains(name1))
              serialized.Add(name1);
            else
              continue;
          }
          else
            continue;
        }
        declarations.Add(declaration.ToCss(formatter));
      }
      writer.Write(formatter.Declarations((IEnumerable<string>) declarations));
    }

    public string RemoveProperty(string propertyName)
    {
      if (this.IsReadOnly)
        throw new DomException(DomError.NoModificationAllowed);
      string propertyValue = this.GetPropertyValue(propertyName);
      this.RemovePropertyByName(propertyName);
      this.RaiseChanged();
      return propertyValue;
    }

    private void RemovePropertyByName(string propertyName)
    {
      foreach (CssProperty declaration in this.Declarations)
      {
        if (declaration.Name.Is(propertyName))
        {
          this.RemoveChild((ICssNode) declaration);
          break;
        }
      }
      if (!this.IsStrictMode || !Factory.Properties.IsShorthand(propertyName))
        return;
      foreach (string longhand in Factory.Properties.GetLonghands(propertyName))
        this.RemovePropertyByName(longhand);
    }

    public string GetPropertyPriority(string propertyName)
    {
      CssProperty property = this.GetProperty(propertyName);
      if (property != null && property.IsImportant)
        return Keywords.Important;
      if (!this.IsStrictMode || !Factory.Properties.IsShorthand(propertyName))
        return string.Empty;
      foreach (string longhand in Factory.Properties.GetLonghands(propertyName))
      {
        if (!this.GetPropertyPriority(longhand).Isi(Keywords.Important))
          return string.Empty;
      }
      return Keywords.Important;
    }

    public string GetPropertyValue(string propertyName)
    {
      CssProperty property1 = this.GetProperty(propertyName);
      if (property1 != null)
        return property1.Value;
      if (!this.IsStrictMode || !Factory.Properties.IsShorthand(propertyName))
        return string.Empty;
      CssShorthandProperty shorthand = Factory.Properties.CreateShorthand(propertyName);
      string[] longhands = Factory.Properties.GetLonghands(propertyName);
      List<CssProperty> cssPropertyList = new List<CssProperty>();
      foreach (string name in longhands)
      {
        CssProperty property2 = this.GetProperty(name);
        if (property2 == null)
          return string.Empty;
        cssPropertyList.Add(property2);
      }
      return shorthand.Stringify(cssPropertyList.ToArray());
    }

    public void SetPropertyValue(string propertyName, string propertyValue) => this.SetProperty(propertyName, propertyValue, (string) null);

    public void SetPropertyPriority(string propertyName, string priority)
    {
      if (this.IsReadOnly)
        throw new DomException(DomError.NoModificationAllowed);
      if (!string.IsNullOrEmpty(priority) && !priority.Isi(Keywords.Important))
        return;
      bool flag = !string.IsNullOrEmpty(priority);
      foreach (string name in !this.IsStrictMode || !Factory.Properties.IsShorthand(propertyName) ? Enumerable.Repeat<string>(propertyName, 1) : (IEnumerable<string>) Factory.Properties.GetLonghands(propertyName))
      {
        CssProperty property = this.GetProperty(name);
        if (property != null)
          property.IsImportant = flag;
      }
    }

    public void SetProperty(string propertyName, string propertyValue, string priority = null)
    {
      if (this.IsReadOnly)
        throw new DomException(DomError.NoModificationAllowed);
      if (!string.IsNullOrEmpty(propertyValue))
      {
        if (priority != null && !priority.Isi(Keywords.Important))
          return;
        CssValue newValue = this._parser.ParseValue(propertyValue);
        if (newValue == null)
          return;
        CssProperty property = this.CreateProperty(propertyName);
        if (property == null || !property.TrySetValue(newValue))
          return;
        property.IsImportant = priority != null;
        this.SetProperty(property);
        this.RaiseChanged();
      }
      else
        this.RemoveProperty(propertyName);
    }

    internal CssProperty CreateProperty(string propertyName)
    {
      CssProperty property = this.GetProperty(propertyName);
      if (property != null)
        return property;
      CssProperty cssProperty = Factory.Properties.Create(propertyName);
      return cssProperty != null || this.IsStrictMode ? cssProperty : (CssProperty) new CssUnknownProperty(propertyName);
    }

    internal CssProperty GetProperty(string name) => this.Declarations.Where<CssProperty>((Func<CssProperty, bool>) (m => m.Name.Isi(name))).FirstOrDefault<CssProperty>();

    internal void SetProperty(CssProperty property)
    {
      if (property is CssShorthandProperty)
        this.SetShorthand((CssShorthandProperty) property);
      else
        this.SetLonghand(property);
    }

    internal void SetDeclarations(IEnumerable<CssProperty> decls) => this.ChangeDeclarations(decls, (Predicate<CssProperty>) (m => false), (Func<CssProperty, CssProperty, bool>) ((o, n) => !o.IsImportant || n.IsImportant));

    internal void UpdateDeclarations(IEnumerable<CssProperty> decls) => this.ChangeDeclarations(decls, (Predicate<CssProperty>) (m => !m.CanBeInherited), (Func<CssProperty, CssProperty, bool>) ((o, n) => o.IsInherited));

    private void ChangeDeclarations(
      IEnumerable<CssProperty> decls,
      Predicate<CssProperty> defaultSkip,
      Func<CssProperty, CssProperty, bool> removeExisting)
    {
      List<CssProperty> cssPropertyList = new List<CssProperty>();
      foreach (CssProperty decl in decls)
      {
        bool flag = defaultSkip(decl);
        foreach (CssProperty declaration in this.Declarations)
        {
          if (declaration.Name.Is(decl.Name))
          {
            if (removeExisting(declaration, decl))
            {
              this.RemoveChild((ICssNode) declaration);
              break;
            }
            flag = true;
            break;
          }
        }
        if (!flag)
          cssPropertyList.Add(decl);
      }
      foreach (ICssNode child in cssPropertyList)
        this.AppendChild(child);
    }

    private void SetLonghand(CssProperty property)
    {
      foreach (CssProperty declaration in this.Declarations)
      {
        if (declaration.Name.Is(property.Name))
        {
          this.RemoveChild((ICssNode) declaration);
          break;
        }
      }
      this.AppendChild((ICssNode) property);
    }

    private void SetShorthand(CssShorthandProperty shorthand)
    {
      CssProperty[] longhandsFor = Factory.Properties.CreateLonghandsFor(shorthand.Name);
      shorthand.Export(longhandsFor);
      foreach (CssProperty property in longhandsFor)
        this.SetLonghand(property);
    }

    private void RaiseChanged()
    {
      Action<string> changed = this.Changed;
      if (changed == null)
        return;
      changed(this.CssText);
    }

    public IEnumerator<ICssProperty> GetEnumerator() => (IEnumerator<ICssProperty>) this.Declarations.GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator() => (IEnumerator) this.GetEnumerator();
  }
}
