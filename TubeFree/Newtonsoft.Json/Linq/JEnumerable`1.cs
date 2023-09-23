﻿// Decompiled with JetBrains decompiler
// Type: Newtonsoft.Json.Linq.JEnumerable`1
// Assembly: Newtonsoft.Json, Version=12.0.0.0, Culture=neutral, PublicKeyToken=30ad4fe6b2a6aeed
// MVID: A4A4D6C6-3EFA-4DC8-AAEA-DA1EC7F2D4DE
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\Newtonsoft.Json.dll

using Newtonsoft.Json.Utilities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Newtonsoft.Json.Linq
{
  public readonly struct JEnumerable<T> : 
    IJEnumerable<T>,
    IEnumerable<T>,
    IEnumerable,
    IEquatable<JEnumerable<T>>
    where T : JToken
  {
    public static readonly JEnumerable<T> Empty = new JEnumerable<T>(Enumerable.Empty<T>());
    private readonly IEnumerable<T> _enumerable;

    public JEnumerable(IEnumerable<T> enumerable)
    {
      ValidationUtils.ArgumentNotNull((object) enumerable, nameof (enumerable));
      this._enumerable = enumerable;
    }

    public IEnumerator<T> GetEnumerator() => ((IEnumerable<T>) ((object) this._enumerable ?? (object) JEnumerable<T>.Empty)).GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator() => (IEnumerator) this.GetEnumerator();

    public IJEnumerable<JToken> this[object key] => this._enumerable == null ? (IJEnumerable<JToken>) JEnumerable<JToken>.Empty : (IJEnumerable<JToken>) new JEnumerable<JToken>(this._enumerable.Values<T, JToken>(key));

    public bool Equals(JEnumerable<T> other) => object.Equals((object) this._enumerable, (object) other._enumerable);

    public override bool Equals(object obj) => obj is JEnumerable<T> other && this.Equals(other);

    public override int GetHashCode() => this._enumerable == null ? 0 : this._enumerable.GetHashCode();
  }
}
