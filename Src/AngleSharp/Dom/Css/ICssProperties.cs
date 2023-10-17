// Decompiled with JetBrains decompiler
// Type: AngleSharp.Dom.Css.ICssProperties
// Assembly: AngleSharp, Version=0.9.9.0, Culture=neutral, PublicKeyToken=e83494dcdc6d31ea
// MVID: 6D8FC1AC-F585-421F-BEC1-9105A73220DF
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\AngleSharp.dll

using AngleSharp.Attributes;
using System.Collections;
using System.Collections.Generic;

namespace AngleSharp.Dom.Css
{
  [DomNoInterfaceObject]
  public interface ICssProperties : IEnumerable<ICssProperty>, IEnumerable
  {
    string this[string propertyName] { get; }

    [DomName("length")]
    int Length { get; }

    [DomName("getPropertyValue")]
    string GetPropertyValue(string propertyName);

    [DomName("getPropertyPriority")]
    string GetPropertyPriority(string propertyName);

    [DomName("setProperty")]
    void SetProperty(string propertyName, string propertyValue, string priority = null);

    [DomName("removeProperty")]
    string RemoveProperty(string propertyName);
  }
}
