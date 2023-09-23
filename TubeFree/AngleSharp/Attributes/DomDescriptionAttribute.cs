// Decompiled with JetBrains decompiler
// Type: AngleSharp.Attributes.DomDescriptionAttribute
// Assembly: AngleSharp, Version=0.9.9.0, Culture=neutral, PublicKeyToken=e83494dcdc6d31ea
// MVID: 6D8FC1AC-F585-421F-BEC1-9105A73220DF
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\AngleSharp.dll

using System;

namespace AngleSharp.Attributes
{
  [AttributeUsage(AttributeTargets.Class | AttributeTargets.Delegate | AttributeTargets.Event | AttributeTargets.Field | AttributeTargets.Interface | AttributeTargets.Method | AttributeTargets.Property | AttributeTargets.Struct, AllowMultiple = true, Inherited = false)]
  public sealed class DomDescriptionAttribute : Attribute
  {
    public DomDescriptionAttribute(string description) => this.Description = description;

    public string Description { get; private set; }
  }
}
