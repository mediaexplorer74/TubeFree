// Decompiled with JetBrains decompiler
// Type: AngleSharp.Dom.Css.OrCondition
// Assembly: AngleSharp, Version=0.9.9.0, Culture=neutral, PublicKeyToken=e83494dcdc6d31ea
// MVID: 6D8FC1AC-F585-421F-BEC1-9105A73220DF
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\AngleSharp.dll

using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AngleSharp.Dom.Css
{
  internal sealed class OrCondition : CssNode, IConditionFunction, ICssNode, IStyleFormattable
  {
    public bool Check()
    {
      foreach (IConditionFunction conditionFunction in this.Children.OfType<IConditionFunction>())
      {
        if (conditionFunction.Check())
          return true;
      }
      return false;
    }

    public override void ToCss(TextWriter writer, IStyleFormatter formatter)
    {
      IEnumerable<IConditionFunction> conditionFunctions = this.Children.OfType<IConditionFunction>();
      bool flag = true;
      foreach (IConditionFunction conditionFunction in conditionFunctions)
      {
        if (flag)
          flag = false;
        else
          writer.Write(" or ");
        TextWriter writer1 = writer;
        IStyleFormatter formatter1 = formatter;
        conditionFunction.ToCss(writer1, formatter1);
      }
    }
  }
}
