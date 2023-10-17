// Decompiled with JetBrains decompiler
// Type: JetBrains.Annotations.AspMvcActionAttribute
// Assembly: Explode, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D9BD94EC-1F8A-4D23-A0FC-F2CF6230133A
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\Explode.dll

using System;

namespace JetBrains.Annotations
{
  [AttributeUsage(AttributeTargets.Method | AttributeTargets.Parameter)]
  internal sealed class AspMvcActionAttribute : Attribute
  {
    public AspMvcActionAttribute()
    {
    }

    public AspMvcActionAttribute([NotNull] string anonymousProperty) => this.AnonymousProperty = anonymousProperty;

    [CanBeNull]
    public string AnonymousProperty { get; private set; }
  }
}
