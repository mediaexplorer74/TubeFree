// Decompiled with JetBrains decompiler
// Type: Microsoft.AdMediator.Core.Utilities.Log.ILogger
// Assembly: Microsoft.AdMediator.Core, Version=2.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: DB70E93F-CF3F-46EC-9B00-17C400B010D8
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\Microsoft.AdMediator.Core.dll

using System;

namespace Microsoft.AdMediator.Core.Utilities.Log
{
  public interface ILogger
  {
    bool IsTraceEnabled { get; }

    bool IsInformationEnabled { get; }

    bool IsWarningEnabled { get; }

    bool IsErrorEnabled { get; }

    bool IsFatalEnabled { get; }

    void Error(Exception exception, string format, params object[] args);

    void Error(string format, params object[] args);

    void Information(Exception exception, string format, params object[] args);

    void Information(string format, params object[] args);

    void Warning(Exception exception, string format, params object[] args);

    void Warning(string format, params object[] args);

    void Fatal(Exception exception, string format, params object[] args);

    void Fatal(string format, params object[] args);

    void Trace(Exception exception, string format, params object[] args);

    void Trace(string format, params object[] args);
  }
}
