// Decompiled with JetBrains decompiler
// Type: AngleSharp.Dom.Css.ICssStyleDeclaration
// Assembly: AngleSharp, Version=0.9.9.0, Culture=neutral, PublicKeyToken=e83494dcdc6d31ea
// MVID: 6D8FC1AC-F585-421F-BEC1-9105A73220DF
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\AngleSharp.dll

using AngleSharp.Attributes;
using System.Collections;
using System.Collections.Generic;

namespace AngleSharp.Dom.Css
{
  [DomName("CSSStyleDeclaration")]
  public interface ICssStyleDeclaration : 
    ICssProperties,
    IEnumerable<ICssProperty>,
    IEnumerable,
    ICssNode,
    IStyleFormattable
  {
    [DomName("item")]
    [DomAccessor(Accessors.Getter)]
    string this[int index] { get; }

    [DomName("cssText")]
    string CssText { get; set; }

    [DomName("parentRule")]
    ICssRule Parent { get; }

    [DomName("accelerator")]
    string Accelerator { get; set; }

    [DomName("alignContent")]
    string AlignContent { get; set; }

    [DomName("alignItems")]
    string AlignItems { get; set; }

    [DomName("alignmentBaseline")]
    string AlignmentBaseline { get; set; }

    [DomName("alignSelf")]
    string AlignSelf { get; set; }

    [DomName("animation")]
    string Animation { get; set; }

    [DomName("animationDelay")]
    string AnimationDelay { get; set; }

    [DomName("animationDirection")]
    string AnimationDirection { get; set; }

    [DomName("animationDuration")]
    string AnimationDuration { get; set; }

    [DomName("animationFillMode")]
    string AnimationFillMode { get; set; }

    [DomName("animationIterationCount")]
    string AnimationIterationCount { get; set; }

    [DomName("animationName")]
    string AnimationName { get; set; }

    [DomName("animationPlayState")]
    string AnimationPlayState { get; set; }

    [DomName("animationTimingFunction")]
    string AnimationTimingFunction { get; set; }

    [DomName("backfaceVisibility")]
    string BackfaceVisibility { get; set; }

    [DomName("background")]
    string Background { get; set; }

    [DomName("backgroundAttachment")]
    string BackgroundAttachment { get; set; }

    [DomName("backgroundClip")]
    string BackgroundClip { get; set; }

    [DomName("backgroundColor")]
    string BackgroundColor { get; set; }

    [DomName("backgroundImage")]
    string BackgroundImage { get; set; }

    [DomName("backgroundOrigin")]
    string BackgroundOrigin { get; set; }

    [DomName("backgroundPosition")]
    string BackgroundPosition { get; set; }

    [DomName("backgroundPositionX")]
    string BackgroundPositionX { get; set; }

    [DomName("backgroundPositionY")]
    string BackgroundPositionY { get; set; }

    [DomName("backgroundRepeat")]
    string BackgroundRepeat { get; set; }

    [DomName("backgroundSize")]
    string BackgroundSize { get; set; }

    [DomName("baselineShift")]
    string BaselineShift { get; set; }

    [DomName("behavior")]
    string Behavior { get; set; }

    [DomName("border")]
    string Border { get; set; }

    [DomName("bottom")]
    string Bottom { get; set; }

    [DomName("borderBottom")]
    string BorderBottom { get; set; }

    [DomName("borderBottomColor")]
    string BorderBottomColor { get; set; }

    [DomName("borderBottomLeftRadius")]
    string BorderBottomLeftRadius { get; set; }

    [DomName("borderBottomRightRadius")]
    string BorderBottomRightRadius { get; set; }

    [DomName("borderBottomStyle")]
    string BorderBottomStyle { get; set; }

    [DomName("borderBottomWidth")]
    string BorderBottomWidth { get; set; }

    [DomName("borderCollapse")]
    string BorderCollapse { get; set; }

    [DomName("borderColor")]
    string BorderColor { get; set; }

    [DomName("borderImage")]
    string BorderImage { get; set; }

    [DomName("borderImageOutset")]
    string BorderImageOutset { get; set; }

    [DomName("borderImageRepeat")]
    string BorderImageRepeat { get; set; }

    [DomName("borderImageSlice")]
    string BorderImageSlice { get; set; }

    [DomName("borderImageSource")]
    string BorderImageSource { get; set; }

    [DomName("borderImageWidth")]
    string BorderImageWidth { get; set; }

    [DomName("borderLeft")]
    string BorderLeft { get; set; }

    [DomName("borderLeftColor")]
    string BorderLeftColor { get; set; }

    [DomName("borderLeftStyle")]
    string BorderLeftStyle { get; set; }

    [DomName("borderLeftWidth")]
    string BorderLeftWidth { get; set; }

    [DomName("borderRadius")]
    string BorderRadius { get; set; }

    [DomName("borderRight")]
    string BorderRight { get; set; }

    [DomName("borderRightColor")]
    string BorderRightColor { get; set; }

    [DomName("borderRightStyle")]
    string BorderRightStyle { get; set; }

    [DomName("borderRightWidth")]
    string BorderRightWidth { get; set; }

    [DomName("borderSpacing")]
    string BorderSpacing { get; set; }

    [DomName("borderStyle")]
    string BorderStyle { get; set; }

    [DomName("borderTop")]
    string BorderTop { get; set; }

    [DomName("borderTopColor")]
    string BorderTopColor { get; set; }

    [DomName("borderTopLeftRadius")]
    string BorderTopLeftRadius { get; set; }

    [DomName("borderTopRightRadius")]
    string BorderTopRightRadius { get; set; }

    [DomName("borderTopStyle")]
    string BorderTopStyle { get; set; }

    [DomName("borderTopWidth")]
    string BorderTopWidth { get; set; }

    [DomName("borderWidth")]
    string BorderWidth { get; set; }

    [DomName("boxShadow")]
    string BoxShadow { get; set; }

    [DomName("boxSizing")]
    string BoxSizing { get; set; }

    [DomName("breakAfter")]
    string BreakAfter { get; set; }

    [DomName("breakBefore")]
    string BreakBefore { get; set; }

    [DomName("breakInside")]
    string BreakInside { get; set; }

    [DomName("captionSide")]
    string CaptionSide { get; set; }

    [DomName("clear")]
    string Clear { get; set; }

    [DomName("clip")]
    string Clip { get; set; }

    [DomName("clipBottom")]
    string ClipBottom { get; set; }

    [DomName("clipLeft")]
    string ClipLeft { get; set; }

    [DomName("clipPath")]
    string ClipPath { get; set; }

    [DomName("clipRight")]
    string ClipRight { get; set; }

    [DomName("clipRule")]
    string ClipRule { get; set; }

    [DomName("clipTop")]
    string ClipTop { get; set; }

    [DomName("color")]
    string Color { get; set; }

    [DomName("colorInterpolationFilters")]
    string ColorInterpolationFilters { get; set; }

    [DomName("columnCount")]
    string ColumnCount { get; set; }

    [DomName("columnFill")]
    string ColumnFill { get; set; }

    [DomName("columnGap")]
    string ColumnGap { get; set; }

    [DomName("columnRule")]
    string ColumnRule { get; set; }

    [DomName("columnRuleColor")]
    string ColumnRuleColor { get; set; }

    [DomName("columnRuleStyle")]
    string ColumnRuleStyle { get; set; }

    [DomName("columnRuleWidth")]
    string ColumnRuleWidth { get; set; }

    [DomName("columns")]
    string Columns { get; set; }

    [DomName("columnSpan")]
    string ColumnSpan { get; set; }

    [DomName("columnWidth")]
    string ColumnWidth { get; set; }

    [DomName("content")]
    string Content { get; set; }

    [DomName("counterIncrement")]
    string CounterIncrement { get; set; }

    [DomName("counterReset")]
    string CounterReset { get; set; }

    [DomName("cursor")]
    string Cursor { get; set; }

    [DomName("direction")]
    string Direction { get; set; }

    [DomName("display")]
    string Display { get; set; }

    [DomName("dominantBaseline")]
    string DominantBaseline { get; set; }

    [DomName("emptyCells")]
    string EmptyCells { get; set; }

    [DomName("enableBackground")]
    string EnableBackground { get; set; }

    [DomName("fill")]
    string Fill { get; set; }

    [DomName("fillOpacity")]
    string FillOpacity { get; set; }

    [DomName("fillRule")]
    string FillRule { get; set; }

    [DomName("filter")]
    string Filter { get; set; }

    [DomName("flex")]
    string Flex { get; set; }

    [DomName("flexBasis")]
    string FlexBasis { get; set; }

    [DomName("flexDirection")]
    string FlexDirection { get; set; }

    [DomName("flexFlow")]
    string FlexFlow { get; set; }

    [DomName("flexGrow")]
    string FlexGrow { get; set; }

    [DomName("flexShrink")]
    string FlexShrink { get; set; }

    [DomName("flexWrap")]
    string FlexWrap { get; set; }

    [DomName("cssFloat")]
    string Float { get; set; }

    [DomName("font")]
    string Font { get; set; }

    [DomName("fontFamily")]
    string FontFamily { get; set; }

    [DomName("fontFeatureSettings")]
    string FontFeatureSettings { get; set; }

    [DomName("fontSize")]
    string FontSize { get; set; }

    [DomName("fontSizeAdjust")]
    string FontSizeAdjust { get; set; }

    [DomName("fontStretch")]
    string FontStretch { get; set; }

    [DomName("fontStyle")]
    string FontStyle { get; set; }

    [DomName("fontVariant")]
    string FontVariant { get; set; }

    [DomName("fontWeight")]
    string FontWeight { get; set; }

    [DomName("glyphOrientationHorizontal")]
    string GlyphOrientationHorizontal { get; set; }

    [DomName("glyphOrientationVertical")]
    string GlyphOrientationVertical { get; set; }

    [DomName("height")]
    string Height { get; set; }

    [DomName("imeMode")]
    string ImeMode { get; set; }

    [DomName("justifyContent")]
    string JustifyContent { get; set; }

    [DomName("layoutGrid")]
    string LayoutGrid { get; set; }

    [DomName("layoutGridChar")]
    string LayoutGridChar { get; set; }

    [DomName("layoutGridLine")]
    string LayoutGridLine { get; set; }

    [DomName("layoutGridMode")]
    string LayoutGridMode { get; set; }

    [DomName("layoutGridType")]
    string LayoutGridType { get; set; }

    [DomName("left")]
    string Left { get; set; }

    [DomName("letterSpacing")]
    string LetterSpacing { get; set; }

    [DomName("lineHeight")]
    string LineHeight { get; set; }

    [DomName("listStyle")]
    string ListStyle { get; set; }

    [DomName("listStyleImage")]
    string ListStyleImage { get; set; }

    [DomName("listStylePosition")]
    string ListStylePosition { get; set; }

    [DomName("listStyleType")]
    string ListStyleType { get; set; }

    [DomName("margin")]
    string Margin { get; set; }

    [DomName("marginBottom")]
    string MarginBottom { get; set; }

    [DomName("marginLeft")]
    string MarginLeft { get; set; }

    [DomName("marginRight")]
    string MarginRight { get; set; }

    [DomName("marginTop")]
    string MarginTop { get; set; }

    [DomName("marker")]
    string Marker { get; set; }

    [DomName("markerEnd")]
    string MarkerEnd { get; set; }

    [DomName("markerMid")]
    string MarkerMid { get; set; }

    [DomName("markerStart")]
    string MarkerStart { get; set; }

    [DomName("mask")]
    string Mask { get; set; }

    [DomName("maxHeight")]
    string MaxHeight { get; set; }

    [DomName("maxWidth")]
    string MaxWidth { get; set; }

    [DomName("minHeight")]
    string MinHeight { get; set; }

    [DomName("minWidth")]
    string MinWidth { get; set; }

    [DomName("opacity")]
    string Opacity { get; set; }

    [DomName("order")]
    string Order { get; set; }

    [DomName("orphans")]
    string Orphans { get; set; }

    [DomName("outline")]
    string Outline { get; set; }

    [DomName("outlineColor")]
    string OutlineColor { get; set; }

    [DomName("outlineStyle")]
    string OutlineStyle { get; set; }

    [DomName("outlineWidth")]
    string OutlineWidth { get; set; }

    [DomName("overflow")]
    string Overflow { get; set; }

    [DomName("overflowX")]
    string OverflowX { get; set; }

    [DomName("overflowY")]
    string OverflowY { get; set; }

    [DomName("overflowWrap")]
    string OverflowWrap { get; set; }

    [DomName("padding")]
    string Padding { get; set; }

    [DomName("paddingBottom")]
    string PaddingBottom { get; set; }

    [DomName("paddingLeft")]
    string PaddingLeft { get; set; }

    [DomName("paddingRight")]
    string PaddingRight { get; set; }

    [DomName("paddingTop")]
    string PaddingTop { get; set; }

    [DomName("pageBreakAfter")]
    string PageBreakAfter { get; set; }

    [DomName("pageBreakBefore")]
    string PageBreakBefore { get; set; }

    [DomName("pageBreakInside")]
    string PageBreakInside { get; set; }

    [DomName("perspective")]
    string Perspective { get; set; }

    [DomName("perspectiveOrigin")]
    string PerspectiveOrigin { get; set; }

    [DomName("pointerEvents")]
    string PointerEvents { get; set; }

    [DomName("position")]
    string Position { get; set; }

    [DomName("quotes")]
    string Quotes { get; set; }

    [DomName("right")]
    string Right { get; set; }

    [DomName("rubyAlign")]
    string RubyAlign { get; set; }

    [DomName("rubyOverhang")]
    string RubyOverhang { get; set; }

    [DomName("rubyPosition")]
    string RubyPosition { get; set; }

    [DomName("scrollbar3dLightColor")]
    string Scrollbar3dLightColor { get; set; }

    [DomName("scrollbarArrowColor")]
    string ScrollbarArrowColor { get; set; }

    [DomName("scrollbarDarkShadowColor")]
    string ScrollbarDarkShadowColor { get; set; }

    [DomName("scrollbarFaceColor")]
    string ScrollbarFaceColor { get; set; }

    [DomName("scrollbarHighlightColor")]
    string ScrollbarHighlightColor { get; set; }

    [DomName("scrollbarShadowColor")]
    string ScrollbarShadowColor { get; set; }

    [DomName("scrollbarTrackColor")]
    string ScrollbarTrackColor { get; set; }

    [DomName("stroke")]
    string Stroke { get; set; }

    [DomName("strokeDasharray")]
    string StrokeDasharray { get; set; }

    [DomName("strokeDashoffset")]
    string StrokeDashoffset { get; set; }

    [DomName("strokeLinecap")]
    string StrokeLinecap { get; set; }

    [DomName("strokeLinejoin")]
    string StrokeLinejoin { get; set; }

    [DomName("strokeMiterlimit")]
    string StrokeMiterlimit { get; set; }

    [DomName("strokeOpacity")]
    string StrokeOpacity { get; set; }

    [DomName("strokeWidth")]
    string StrokeWidth { get; set; }

    [DomName("tableLayout")]
    string TableLayout { get; set; }

    [DomName("textAlign")]
    string TextAlign { get; set; }

    [DomName("textAlignLast")]
    string TextAlignLast { get; set; }

    [DomName("textAnchor")]
    string TextAnchor { get; set; }

    [DomName("textAutospace")]
    string TextAutospace { get; set; }

    [DomName("textDecoration")]
    string TextDecoration { get; set; }

    [DomName("textIndent")]
    string TextIndent { get; set; }

    [DomName("textJustify")]
    string TextJustify { get; set; }

    [DomName("textOverflow")]
    string TextOverflow { get; set; }

    [DomName("textShadow")]
    string TextShadow { get; set; }

    [DomName("textTransform")]
    string TextTransform { get; set; }

    [DomName("textUnderlinePosition")]
    string TextUnderlinePosition { get; set; }

    [DomName("top")]
    string Top { get; set; }

    [DomName("transform")]
    string Transform { get; set; }

    [DomName("transformOrigin")]
    string TransformOrigin { get; set; }

    [DomName("transformStyle")]
    string TransformStyle { get; set; }

    [DomName("transition")]
    string Transition { get; set; }

    [DomName("transitionDelay")]
    string TransitionDelay { get; set; }

    [DomName("transitionDuration")]
    string TransitionDuration { get; set; }

    [DomName("transitionProperty")]
    string TransitionProperty { get; set; }

    [DomName("transitionTimingFunction")]
    string TransitionTimingFunction { get; set; }

    [DomName("unicodeBidi")]
    string UnicodeBidi { get; set; }

    [DomName("verticalAlign")]
    string VerticalAlign { get; set; }

    [DomName("visibility")]
    string Visibility { get; set; }

    [DomName("whiteSpace")]
    string WhiteSpace { get; set; }

    [DomName("widows")]
    string Widows { get; set; }

    [DomName("width")]
    string Width { get; set; }

    [DomName("wordBreak")]
    string WordBreak { get; set; }

    [DomName("wordSpacing")]
    string WordSpacing { get; set; }

    [DomName("writingMode")]
    string WritingMode { get; set; }

    [DomName("zIndex")]
    string ZIndex { get; set; }

    [DomName("zoom")]
    string Zoom { get; set; }
  }
}
