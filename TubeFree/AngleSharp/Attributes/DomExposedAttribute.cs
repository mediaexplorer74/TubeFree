﻿// Decompiled with JetBrains decompiler
// Type: AngleSharp.Attributes.DomExposedAttribute
// Assembly: AngleSharp, Version=0.9.9.0, Culture=neutral, PublicKeyToken=e83494dcdc6d31ea
// MVID: 6D8FC1AC-F585-421F-BEC1-9105A73220DF
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\AngleSharp.dll

using System;

namespace AngleSharp.Attributes
{
  [AttributeUsage(AttributeTargets.Class | AttributeTargets.Interface | AttributeTargets.Struct, AllowMultiple = true, Inherited = false)]
  public sealed class DomExposedAttribute : Attribute
  {
    public DomExposedAttribute(string target) => this.Target = target;

    public string Target { get; private set; }
  }
}
