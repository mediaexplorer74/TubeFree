// Decompiled with JetBrains decompiler
// Type: Microsoft.AdMediator.Core.Utilities.IParameterDictionary`2
// Assembly: Microsoft.AdMediator.Core, Version=2.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: DB70E93F-CF3F-46EC-9B00-17C400B010D8
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\Microsoft.AdMediator.Core.dll

using System.Collections.Generic;
using System.Collections.Specialized;

namespace Microsoft.AdMediator.Core.Utilities
{
  public interface IParameterDictionary<TKey, TValue> : INotifyCollectionChanged
  {
    ICollection<TKey> Keys { get; }

    TValue this[TKey key] { get; set; }

    bool ContainsKey(TKey key);
  }
}
