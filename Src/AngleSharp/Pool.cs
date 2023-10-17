// Decompiled with JetBrains decompiler
// Type: AngleSharp.Pool
// Assembly: AngleSharp, Version=0.9.9.0, Culture=neutral, PublicKeyToken=e83494dcdc6d31ea
// MVID: 6D8FC1AC-F585-421F-BEC1-9105A73220DF
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\AngleSharp.dll

using AngleSharp.Dom.Css;
using AngleSharp.Parser.Css;
using AngleSharp.Services;
using System.Collections.Generic;
using System.Text;

namespace AngleSharp
{
  internal static class Pool
  {
    private static readonly Stack<StringBuilder> _builder = new Stack<StringBuilder>();
    private static readonly Stack<CssSelectorConstructor> _selector = new Stack<CssSelectorConstructor>();
    private static readonly Stack<CssValueBuilder> _value = new Stack<CssValueBuilder>();
    private static readonly object _lock = new object();

    public static StringBuilder NewStringBuilder()
    {
      lock (Pool._lock)
        return Pool._builder.Count == 0 ? new StringBuilder(1024) : Pool._builder.Pop().Clear();
    }

    public static CssSelectorConstructor NewSelectorConstructor(
      IAttributeSelectorFactory attributeSelector,
      IPseudoClassSelectorFactory pseudoClassSelector,
      IPseudoElementSelectorFactory pseudoElementSelector)
    {
      lock (Pool._lock)
        return Pool._selector.Count == 0 ? new CssSelectorConstructor(attributeSelector, pseudoClassSelector, pseudoElementSelector) : Pool._selector.Pop().Reset(attributeSelector, pseudoClassSelector, pseudoElementSelector);
    }

    public static CssValueBuilder NewValueBuilder()
    {
      lock (Pool._lock)
        return Pool._value.Count == 0 ? new CssValueBuilder() : Pool._value.Pop().Reset();
    }

    public static string ToPool(this StringBuilder sb)
    {
      string pool = sb.ToString();
      lock (Pool._lock)
        Pool._builder.Push(sb);
      return pool;
    }

    public static ISelector ToPool(this CssSelectorConstructor ctor)
    {
      ISelector result = ctor.GetResult();
      lock (Pool._lock)
        Pool._selector.Push(ctor);
      return result;
    }

    public static CssValue ToPool(this CssValueBuilder vb)
    {
      CssValue result = vb.GetResult();
      lock (Pool._lock)
        Pool._value.Push(vb);
      return result;
    }
  }
}
