// Decompiled with JetBrains decompiler
// Type: Microsoft.AdMediator.Core.Events.SdkError
// Assembly: Microsoft.AdMediator.Core, Version=2.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: DB70E93F-CF3F-46EC-9B00-17C400B010D8
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\Microsoft.AdMediator.Core.dll

using System.Runtime.Serialization;

namespace Microsoft.AdMediator.Core.Events
{
  [DataContract(Namespace = "")]
  internal class SdkError
  {
    [DataMember(EmitDefaultValue = false)]
    internal string Name { get; set; }

    [DataMember(EmitDefaultValue = false)]
    internal string ErrorCode { get; set; }

    [DataMember(EmitDefaultValue = false)]
    internal string ErrorText { get; set; }
  }
}
