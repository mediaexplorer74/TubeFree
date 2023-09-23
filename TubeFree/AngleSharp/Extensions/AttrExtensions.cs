// Decompiled with JetBrains decompiler
// Type: AngleSharp.Extensions.AttrExtensions
// Assembly: AngleSharp, Version=0.9.9.0, Culture=neutral, PublicKeyToken=e83494dcdc6d31ea
// MVID: 6D8FC1AC-F585-421F-BEC1-9105A73220DF
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\AngleSharp.dll

using AngleSharp.Dom;
using System.Collections.Generic;

namespace AngleSharp.Extensions
{
  internal static class AttrExtensions
  {
    public static bool AreEqual(this INamedNodeMap sourceAttributes, INamedNodeMap targetAttributes)
    {
      if (sourceAttributes.Length != targetAttributes.Length)
        return false;
      foreach (IAttr sourceAttribute in (IEnumerable<IAttr>) sourceAttributes)
      {
        bool flag = false;
        foreach (IAttr targetAttribute in (IEnumerable<IAttr>) targetAttributes)
        {
          flag = sourceAttribute.GetHashCode() == targetAttribute.GetHashCode();
          if (flag)
            break;
        }
        if (!flag)
          return false;
      }
      return true;
    }
  }
}
