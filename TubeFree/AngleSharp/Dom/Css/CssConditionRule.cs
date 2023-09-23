// Decompiled with JetBrains decompiler
// Type: AngleSharp.Dom.Css.CssConditionRule
// Assembly: AngleSharp, Version=0.9.9.0, Culture=neutral, PublicKeyToken=e83494dcdc6d31ea
// MVID: 6D8FC1AC-F585-421F-BEC1-9105A73220DF
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\AngleSharp.dll

using AngleSharp.Css;
using AngleSharp.Parser.Css;

namespace AngleSharp.Dom.Css
{
  internal abstract class CssConditionRule : CssGroupingRule
  {
    internal CssConditionRule(CssRuleType type, CssParser parser)
      : base(type, parser)
    {
    }

    internal abstract bool IsValid(RenderDevice device);
  }
}
