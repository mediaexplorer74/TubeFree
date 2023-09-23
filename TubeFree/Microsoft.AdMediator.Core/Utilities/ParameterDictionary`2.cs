// Decompiled with JetBrains decompiler
// Type: Microsoft.AdMediator.Core.Utilities.ParameterDictionary`2
// Assembly: Microsoft.AdMediator.Core, Version=2.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: DB70E93F-CF3F-46EC-9B00-17C400B010D8
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\Microsoft.AdMediator.Core.dll

using System;
using System.Collections.Generic;
using System.Collections.Specialized;

namespace Microsoft.AdMediator.Core.Utilities
{
  internal class ParameterDictionary<TKey, TValue> : 
    IParameterDictionary<TKey, TValue>,
    INotifyCollectionChanged
  {
    private readonly IDictionary<TKey, TValue> dictionary;

    public ParameterDictionary() => this.dictionary = (IDictionary<TKey, TValue>) new Dictionary<TKey, TValue>();

    public ICollection<TKey> Keys => this.dictionary.Keys;

    public TValue this[TKey key]
    {
      get => this.dictionary[key];
      set
      {
        if ((object) key == null)
          throw new ArgumentNullException(nameof (key));
        TValue objA;
        if (this.dictionary.TryGetValue(key, out objA))
        {
          if (object.Equals((object) objA, (object) value))
            return;
          this.dictionary[key] = value;
          this.OnCollectionChanged(NotifyCollectionChangedAction.Replace, new KeyValuePair<TKey, TValue>(key, value), new KeyValuePair<TKey, TValue>(key, objA));
        }
        else
        {
          this.dictionary[key] = value;
          this.OnCollectionChanged(NotifyCollectionChangedAction.Add, new KeyValuePair<TKey, TValue>(key, value));
        }
      }
    }

    public event NotifyCollectionChangedEventHandler CollectionChanged;

    public bool ContainsKey(TKey key) => this.dictionary.ContainsKey(key);

    private void OnCollectionChanged(
      NotifyCollectionChangedAction action,
      KeyValuePair<TKey, TValue> newItem,
      KeyValuePair<TKey, TValue> oldItem)
    {
      if (this.CollectionChanged == null)
        return;
      this.CollectionChanged((object) this, new NotifyCollectionChangedEventArgs(action, (object) newItem, (object) oldItem));
    }

    private void OnCollectionChanged(
      NotifyCollectionChangedAction action,
      KeyValuePair<TKey, TValue> newItem)
    {
      if (this.CollectionChanged == null)
        return;
      this.CollectionChanged((object) this, new NotifyCollectionChangedEventArgs(action, (object) newItem));
    }
  }
}
