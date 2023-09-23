// Decompiled with JetBrains decompiler
// Type: Newtonsoft.Json.JsonObjectAttribute
// Assembly: Newtonsoft.Json, Version=12.0.0.0, Culture=neutral, PublicKeyToken=30ad4fe6b2a6aeed
// MVID: A4A4D6C6-3EFA-4DC8-AAEA-DA1EC7F2D4DE
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\Newtonsoft.Json.dll

using System;

namespace Newtonsoft.Json
{
  [AttributeUsage(AttributeTargets.Class | AttributeTargets.Interface | AttributeTargets.Struct, AllowMultiple = false)]
  public sealed class JsonObjectAttribute : JsonContainerAttribute
  {
    private MemberSerialization _memberSerialization;
    internal MissingMemberHandling? _missingMemberHandling;
    internal Required? _itemRequired;
    internal NullValueHandling? _itemNullValueHandling;

    public MemberSerialization MemberSerialization
    {
      get => this._memberSerialization;
      set => this._memberSerialization = value;
    }

    public MissingMemberHandling MissingMemberHandling
    {
      get => this._missingMemberHandling ?? MissingMemberHandling.Ignore;
      set => this._missingMemberHandling = new MissingMemberHandling?(value);
    }

    public NullValueHandling ItemNullValueHandling
    {
      get => this._itemNullValueHandling ?? NullValueHandling.Include;
      set => this._itemNullValueHandling = new NullValueHandling?(value);
    }

    public Required ItemRequired
    {
      get => this._itemRequired ?? Required.Default;
      set => this._itemRequired = new Required?(value);
    }

    public JsonObjectAttribute()
    {
    }

    public JsonObjectAttribute(MemberSerialization memberSerialization) => this.MemberSerialization = memberSerialization;

    public JsonObjectAttribute(string id)
      : base(id)
    {
    }
  }
}
