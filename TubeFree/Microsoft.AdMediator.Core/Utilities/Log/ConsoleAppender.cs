// Decompiled with JetBrains decompiler
// Type: Microsoft.AdMediator.Core.Utilities.Log.ConsoleAppender
// Assembly: Microsoft.AdMediator.Core, Version=2.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: DB70E93F-CF3F-46EC-9B00-17C400B010D8
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\Microsoft.AdMediator.Core.dll

using System.Diagnostics;

namespace Microsoft.AdMediator.Core.Utilities.Log
{
  public class ConsoleAppender : IAppender
  {
    public bool IsEnabled => Debugger.IsAttached;

    public void Append(string message)
    {
    }
  }
}
