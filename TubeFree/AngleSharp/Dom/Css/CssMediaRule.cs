// Decompiled with JetBrains decompiler
// Type: AngleSharp.Dom.Css.CssMediaRule
// Assembly: AngleSharp, Version=0.9.9.0, Culture=neutral, PublicKeyToken=e83494dcdc6d31ea
// MVID: 6D8FC1AC-F585-421F-BEC1-9105A73220DF
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\AngleSharp.dll

using AngleSharp.Css;
using AngleSharp.Dom.Collections;
using AngleSharp.Parser.Css;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AngleSharp.Dom.Css
{
  internal sealed class CssMediaRule : 
    CssConditionRule,
    ICssMediaRule,
    ICssConditionRule,
    ICssGroupingRule,
    ICssRule,
    ICssNode,
    IStyleFormattable,
    ICssRuleCreator
  {
    internal CssMediaRule(CssParser parser)
      : base(CssRuleType.Media, parser)
    {
      this.AppendChild((ICssNode) new MediaList(parser));
    }

    public string ConditionText
    {
      get => this.Media.MediaText;
      set => this.Media.MediaText = value;
    }

    public MediaList Media => this.Children.OfType<MediaList>().FirstOrDefault<MediaList>();

    IMediaList ICssMediaRule.Media => (IMediaList) this.Media;

    internal override bool IsValid(RenderDevice device) => this.Media.Validate(device);

    public override void ToCss(TextWriter writer, IStyleFormatter formatter)
    {
      string rules = formatter.Block((IEnumerable<IStyleFormattable>) this.Rules);
      writer.Write(formatter.Rule("@media", this.Media.MediaText, rules));
    }
  }
}
