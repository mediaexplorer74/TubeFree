// Decompiled with JetBrains decompiler
// Type: JetBrains.Annotations.RazorPageBaseTypeAttribute
// Assembly: Explode, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D9BD94EC-1F8A-4D23-A0FC-F2CF6230133A
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\Explode.dll

using System;

namespace JetBrains.Annotations
{
  [AttributeUsage(AttributeTargets.Assembly, AllowMultiple = true)]
  internal sealed class RazorPageBaseTypeAttribute : Attribute
  {
    public RazorPageBaseTypeAttribute([NotNull] string baseType) => this.BaseType = baseType;

    public RazorPageBaseTypeAttribute([NotNull] string baseType, string pageName)
    {
      this.BaseType = baseType;
      this.PageName = pageName;
    }

    [NotNull]
    public string BaseType { get; private set; }

    [CanBeNull]
    public string PageName { get; private set; }
  }
}
