// Decompiled with JetBrains decompiler
// Type: AngleSharp.Dom.Css.CssRuleType
// Assembly: AngleSharp, Version=0.9.9.0, Culture=neutral, PublicKeyToken=e83494dcdc6d31ea
// MVID: 6D8FC1AC-F585-421F-BEC1-9105A73220DF
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\AngleSharp.dll

using AngleSharp.Attributes;

namespace AngleSharp.Dom.Css
{
  [DomName("CSSRule")]
  public enum CssRuleType : byte
  {
    Unknown = 0,
    [DomName("STYLE_RULE")] Style = 1,
    [DomName("CHARSET_RULE")] Charset = 2,
    [DomName("IMPORT_RULE")] Import = 3,
    [DomName("MEDIA_RULE")] Media = 4,
    [DomName("FONT_FACE_RULE")] FontFace = 5,
    [DomName("PAGE_RULE")] Page = 6,
    [DomName("KEYFRAMES_RULE")] Keyframes = 7,
    [DomName("KEYFRAME_RULE")] Keyframe = 8,
    [DomName("NAMESPACE_RULE")] Namespace = 10, // 0x0A
    [DomName("COUNTER_STYLE_RULE")] CounterStyle = 11, // 0x0B
    [DomName("SUPPORTS_RULE")] Supports = 12, // 0x0C
    [DomName("DOCUMENT_RULE")] Document = 13, // 0x0D
    [DomName("FONT_FEATURE_VALUES_RULE")] FontFeatureValues = 14, // 0x0E
    [DomName("VIEWPORT_RULE")] Viewport = 15, // 0x0F
    [DomName("REGION_STYLE_RULE")] RegionStyle = 16, // 0x10
  }
}
