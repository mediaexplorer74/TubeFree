// Decompiled with JetBrains decompiler
// Type: JetBrains.Annotations.BaseTypeRequiredAttribute
// Assembly: Explode, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D9BD94EC-1F8A-4D23-A0FC-F2CF6230133A
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\Explode.dll

using System;

namespace JetBrains.Annotations
{
  [AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
  [BaseTypeRequired(typeof (Attribute))]
  internal sealed class BaseTypeRequiredAttribute : Attribute
  {
    public BaseTypeRequiredAttribute([NotNull] Type baseType) => this.BaseType = baseType;

    [NotNull]
    public Type BaseType { get; private set; }
  }
}
