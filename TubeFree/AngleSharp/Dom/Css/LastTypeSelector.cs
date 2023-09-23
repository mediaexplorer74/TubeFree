// Decompiled with JetBrains decompiler
// Type: AngleSharp.Dom.Css.LastTypeSelector
// Assembly: AngleSharp, Version=0.9.9.0, Culture=neutral, PublicKeyToken=e83494dcdc6d31ea
// MVID: 6D8FC1AC-F585-421F-BEC1-9105A73220DF
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\AngleSharp.dll

using AngleSharp.Css;
using AngleSharp.Extensions;
using System;

namespace AngleSharp.Dom.Css
{
  internal sealed class LastTypeSelector : ChildSelector
  {
    public LastTypeSelector()
      : base(PseudoClassNames.NthLastOfType)
    {
    }

    public override bool Match(IElement element)
    {
      IElement parentElement = element.ParentElement;
      if (parentElement != null)
      {
        int num1 = Math.Sign(this._step);
        int num2 = 0;
        for (int index = parentElement.ChildNodes.Length - 1; index >= 0; --index)
        {
          if (parentElement.ChildNodes[index] is IElement childNode && childNode.NodeName.Is(element.NodeName))
          {
            ++num2;
            if (childNode == element)
            {
              int num3 = num2 - this._offset;
              if (num3 == 0)
                return true;
              return Math.Sign(num3) == num1 && num3 % this._step == 0;
            }
          }
        }
      }
      return false;
    }
  }
}
