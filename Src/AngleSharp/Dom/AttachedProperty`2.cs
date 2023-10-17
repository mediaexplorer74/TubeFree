// Decompiled with JetBrains decompiler
// Type: AngleSharp.Dom.AttachedProperty`2
// Assembly: AngleSharp, Version=0.9.9.0, Culture=neutral, PublicKeyToken=e83494dcdc6d31ea
// MVID: 6D8FC1AC-F585-421F-BEC1-9105A73220DF
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\AngleSharp.dll

using System.Runtime.CompilerServices;

namespace AngleSharp.Dom
{
  internal sealed class AttachedProperty<TObj, TProp>
    where TObj : class
    where TProp : class
  {
    private readonly ConditionalWeakTable<TObj, TProp> _properties = new ConditionalWeakTable<TObj, TProp>();

    public TProp Get(TObj item)
    {
      TProp prop = default (TProp);
      this._properties.TryGetValue(item, out prop);
      return prop;
    }

    public void Set(TObj item, TProp value) => this._properties.Add(item, value);
  }
}
