﻿// Decompiled with JetBrains decompiler
// Type: Newtonsoft.Json.Serialization.SerializationBinderAdapter
// Assembly: Newtonsoft.Json, Version=12.0.0.0, Culture=neutral, PublicKeyToken=30ad4fe6b2a6aeed
// MVID: A4A4D6C6-3EFA-4DC8-AAEA-DA1EC7F2D4DE
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\Newtonsoft.Json.dll

using System;

namespace Newtonsoft.Json.Serialization
{
  internal class SerializationBinderAdapter : ISerializationBinder
  {
    public readonly SerializationBinder SerializationBinder;

    public SerializationBinderAdapter(SerializationBinder serializationBinder) => this.SerializationBinder = serializationBinder;

    public Type BindToType(string assemblyName, string typeName) => this.SerializationBinder.BindToType(assemblyName, typeName);

    public void BindToName(Type serializedType, out string assemblyName, out string typeName) => this.SerializationBinder.BindToName(serializedType, out assemblyName, out typeName);
  }
}
