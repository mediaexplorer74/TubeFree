// Decompiled with JetBrains decompiler
// Type: Microsoft.AdMediator.Core.Utilities.JsonDataContractSerializerHelper
// Assembly: Microsoft.AdMediator.Core, Version=2.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: DB70E93F-CF3F-46EC-9B00-17C400B010D8
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\Microsoft.AdMediator.Core.dll

using System;
using System.IO;
using System.Runtime.Serialization.Json;
using System.Text;

namespace Microsoft.AdMediator.Core.Utilities
{
  internal class JsonDataContractSerializerHelper : ISerializer
  {
    public string Serialize(Type typeToSerialize, object valueToSerialize)
    {
      using (MemoryStream memoryStream = new MemoryStream())
      {
        new DataContractJsonSerializer(typeToSerialize).WriteObject((Stream) memoryStream, valueToSerialize);
        return Encoding.UTF8.GetString(memoryStream.ToArray(), 0, (int) memoryStream.Length);
      }
    }

    public void Serialize(Type typeToSerialize, object valueToSerialize, Stream stream) => new DataContractJsonSerializer(typeToSerialize).WriteObject(stream, valueToSerialize);

    public object Deserialize(Type typeToDeserializeTo, Stream stream) => new DataContractJsonSerializer(typeToDeserializeTo).ReadObject(stream);

    public object Deserialize(Type typeToDeserializeTo, string buffer)
    {
      using (MemoryStream memoryStream = new MemoryStream(Encoding.UTF8.GetBytes(buffer)))
        return new DataContractJsonSerializer(typeToDeserializeTo).ReadObject((Stream) memoryStream);
    }
  }
}
