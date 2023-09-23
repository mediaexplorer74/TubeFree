// Decompiled with JetBrains decompiler
// Type: Microsoft.AdMediator.Core.Events.AdMediatorException
// Assembly: Microsoft.AdMediator.Core, Version=2.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: DB70E93F-CF3F-46EC-9B00-17C400B010D8
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\Microsoft.AdMediator.Core.dll

using System;

namespace Microsoft.AdMediator.Core.Events
{
  public class AdMediatorException : Exception
  {
    public AdMediatorException()
    {
    }

    public AdMediatorException(string message)
      : base(message)
    {
    }

    public AdMediatorException(string message, Exception inner)
      : base(message, inner)
    {
    }
  }
}
