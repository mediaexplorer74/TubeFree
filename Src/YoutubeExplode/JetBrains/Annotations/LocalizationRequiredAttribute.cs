// Decompiled with JetBrains decompiler
// Type: JetBrains.Annotations.LocalizationRequiredAttribute
// Assembly: Explode, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D9BD94EC-1F8A-4D23-A0FC-F2CF6230133A
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\Explode.dll

using System;

namespace JetBrains.Annotations
{
  [AttributeUsage(AttributeTargets.All)]
  internal sealed class LocalizationRequiredAttribute : Attribute
  {
    public LocalizationRequiredAttribute()
      : this(true)
    {
    }

    public LocalizationRequiredAttribute(bool required) => this.Required = required;

    public bool Required { get; private set; }
  }
}
