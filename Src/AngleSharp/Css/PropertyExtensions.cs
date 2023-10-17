// Decompiled with JetBrains decompiler
// Type: AngleSharp.Css.PropertyExtensions
// Assembly: AngleSharp, Version=0.9.9.0, Culture=neutral, PublicKeyToken=e83494dcdc6d31ea
// MVID: 6D8FC1AC-F585-421F-BEC1-9105A73220DF
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\AngleSharp.dll

using AngleSharp.Dom.Css;

namespace AngleSharp.Css
{
  internal static class PropertyExtensions
  {
    public static IPropertyValue Guard<T>(this CssProperty[] properties)
    {
      if (properties.Length != 1)
        return (IPropertyValue) null;
      return !(properties[0].DeclaredValue is T) ? (IPropertyValue) null : properties[0].DeclaredValue;
    }
  }
}
