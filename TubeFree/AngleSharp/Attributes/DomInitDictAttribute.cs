// Decompiled with JetBrains decompiler
// Type: AngleSharp.Attributes.DomInitDictAttribute
// Assembly: AngleSharp, Version=0.9.9.0, Culture=neutral, PublicKeyToken=e83494dcdc6d31ea
// MVID: 6D8FC1AC-F585-421F-BEC1-9105A73220DF
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\AngleSharp.dll

using System;

namespace AngleSharp.Attributes
{
  [AttributeUsage(AttributeTargets.Constructor | AttributeTargets.Method, Inherited = false)]
  public sealed class DomInitDictAttribute : Attribute
  {
    public DomInitDictAttribute(int offset = 0, bool optional = false)
    {
      this.Offset = offset;
      this.IsOptional = optional;
    }

    public int Offset { get; private set; }

    public bool IsOptional { get; private set; }
  }
}
