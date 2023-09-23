// Decompiled with JetBrains decompiler
// Type: Newtonsoft.Json.Utilities.ThreadSafeStore`2
// Assembly: Newtonsoft.Json, Version=12.0.0.0, Culture=neutral, PublicKeyToken=30ad4fe6b2a6aeed
// MVID: A4A4D6C6-3EFA-4DC8-AAEA-DA1EC7F2D4DE
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\Newtonsoft.Json.dll

using System;
using System.Collections.Generic;

namespace Newtonsoft.Json.Utilities
{
  internal class ThreadSafeStore<TKey, TValue>
  {
    private readonly object _lock = new object();
    private Dictionary<TKey, TValue> _store;
    private readonly Func<TKey, TValue> _creator;

    public ThreadSafeStore(Func<TKey, TValue> creator)
    {
      ValidationUtils.ArgumentNotNull((object) creator, nameof (creator));
      this._creator = creator;
      this._store = new Dictionary<TKey, TValue>();
    }

    public TValue Get(TKey key)
    {
      TValue obj;
      return !this._store.TryGetValue(key, out obj) ? this.AddValue(key) : obj;
    }

    private TValue AddValue(TKey key)
    {
      TValue obj1 = this._creator(key);
      lock (this._lock)
      {
        if (this._store == null)
        {
          this._store = new Dictionary<TKey, TValue>();
          this._store[key] = obj1;
        }
        else
        {
          TValue obj2;
          if (this._store.TryGetValue(key, out obj2))
            return obj2;
          this._store = new Dictionary<TKey, TValue>((IDictionary<TKey, TValue>) this._store)
          {
            [key] = obj1
          };
        }
        return obj1;
      }
    }
  }
}
