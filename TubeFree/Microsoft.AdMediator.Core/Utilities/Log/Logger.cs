// Decompiled with JetBrains decompiler
// Type: Microsoft.AdMediator.Core.Utilities.Log.Logger
// Assembly: Microsoft.AdMediator.Core, Version=2.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: DB70E93F-CF3F-46EC-9B00-17C400B010D8
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\Microsoft.AdMediator.Core.dll

using System;
using System.Collections.Generic;

namespace Microsoft.AdMediator.Core.Utilities.Log
{
  public class Logger : ILogger
  {
    private static ISet<IAppender> Appenders = (ISet<IAppender>) new HashSet<IAppender>();
    private readonly string baseLogMessage;

    public static LogLevel LogLevel { get; set; }

    public Logger(Type component) => this.baseLogMessage = Logger.FormatComponentName(component);

    public static void AddAppender(IAppender appender) => Logger.Appenders.Add(appender);

    public static void Remove(IAppender appender) => Logger.Appenders.Remove(appender);

    private static IEnumerable<IAppender> EnabledAppenders
    {
      get
      {
        foreach (IAppender appender in (IEnumerable<IAppender>) Logger.Appenders)
        {
          if (appender.IsEnabled)
            yield return appender;
        }
      }
    }

    private static bool IsEnabled(LogLevel level)
    {
      if (level < Logger.LogLevel)
        return false;
      using (IEnumerator<IAppender> enumerator = Logger.EnabledAppenders.GetEnumerator())
      {
        if (enumerator.MoveNext())
        {
          IAppender current = enumerator.Current;
          return true;
        }
      }
      return false;
    }

    public bool IsTraceEnabled => Logger.IsEnabled(LogLevel.Trace);

    public bool IsInformationEnabled => Logger.IsEnabled(LogLevel.Information);

    public bool IsWarningEnabled => Logger.IsEnabled(LogLevel.Warning);

    public bool IsErrorEnabled => Logger.IsEnabled(LogLevel.Error);

    public bool IsFatalEnabled => Logger.IsEnabled(LogLevel.Fatal);

    public void Trace(Exception exception, string format, params object[] args)
    {
      if (!this.IsTraceEnabled)
        return;
      this.Output(nameof (Trace), exception, format, args);
    }

    public void Trace(string format, params object[] args) => this.Trace((Exception) null, format, args);

    public void Information(Exception exception, string format, params object[] args)
    {
      if (!this.IsInformationEnabled)
        return;
      this.Output(nameof (Information), exception, format, args);
    }

    public void Information(string format, params object[] args) => this.Information((Exception) null, format, args);

    public void Warning(Exception exception, string format, params object[] args)
    {
      if (!this.IsWarningEnabled)
        return;
      this.Output(nameof (Warning), exception, format, args);
    }

    public void Warning(string format, params object[] args) => this.Warning((Exception) null, format, args);

    public void Error(Exception exception, string format, params object[] args)
    {
      if (!this.IsErrorEnabled)
        return;
      this.Output(nameof (Error), exception, format, args);
    }

    public void Error(string format, params object[] args) => this.Error((Exception) null, format, args);

    public void Fatal(Exception exception, string format, params object[] args)
    {
      if (!this.IsFatalEnabled)
        return;
      this.Output(nameof (Fatal), exception, format, args);
    }

    public void Fatal(string format, params object[] args) => this.Fatal((Exception) null, format, args);

    internal static string FormatComponentName(Type component)
    {
      if (component == null)
        return string.Empty;
      return StringHelper.FormatWithInvariantCulture("[{0}] ", (object) component);
    }

    internal static string FormatLogMessage(string formatMessage, params object[] args) => string.IsNullOrWhiteSpace(formatMessage) ? string.Empty : StringHelper.FormatWithInvariantCulture(formatMessage, args);

    internal static string FormatExceptionMessage(Exception exception) => exception == null ? string.Empty : exception.ToString();

    private void Output(
      string level,
      Exception exception,
      string formatMessage,
      params object[] args)
    {
      string message1 = StringHelper.FormatWithInvariantCulture("{0} [{1}] {2}", (object) DateTime.UtcNow, (object) level.ToUpperInvariant(), (object) this.FormatLogMessageInternal(formatMessage, args));
      string message2 = Logger.FormatExceptionMessage(exception);
      foreach (IAppender enabledAppender in Logger.EnabledAppenders)
      {
        enabledAppender.Append(message1);
        if (!string.IsNullOrEmpty(message2))
          enabledAppender.Append(message2);
      }
    }

    private string FormatLogMessageInternal(string formatMessage, params object[] args) => this.baseLogMessage + Logger.FormatLogMessage(formatMessage, args);
  }
}
