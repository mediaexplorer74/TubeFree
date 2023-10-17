// Decompiled with JetBrains decompiler
// Type: JetBrains.Annotations.AspMvcPartialViewLocationFormatAttribute
// Assembly: Explode, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D9BD94EC-1F8A-4D23-A0FC-F2CF6230133A
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\Explode.dll

using System;

namespace JetBrains.Annotations
{
  [AttributeUsage(AttributeTargets.Assembly | AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = true)]
  internal sealed class AspMvcPartialViewLocationFormatAttribute : Attribute
  {
    public AspMvcPartialViewLocationFormatAttribute([NotNull] string format) => this.Format = format;

    [NotNull]
    public string Format { get; private set; }
  }
}
