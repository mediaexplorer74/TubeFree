// Decompiled with JetBrains decompiler
// Type: Newtonsoft.Json.Utilities.AsyncUtils
// Assembly: Newtonsoft.Json, Version=12.0.0.0, Culture=neutral, PublicKeyToken=30ad4fe6b2a6aeed
// MVID: A4A4D6C6-3EFA-4DC8-AAEA-DA1EC7F2D4DE
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\Newtonsoft.Json.dll

using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace Newtonsoft.Json.Utilities
{
  internal static class AsyncUtils
  {
    public static readonly Task<bool> False = Task.FromResult<bool>(false);
    public static readonly Task<bool> True = Task.FromResult<bool>(true);
    internal static readonly Task CompletedTask = Task.Delay(0);

    internal static Task<bool> ToAsync(this bool value) => !value ? AsyncUtils.False : AsyncUtils.True;

    public static Task CancelIfRequestedAsync(this CancellationToken cancellationToken) => !cancellationToken.IsCancellationRequested ? (Task) null : cancellationToken.FromCanceled();

    public static Task<T> CancelIfRequestedAsync<T>(this CancellationToken cancellationToken) => !cancellationToken.IsCancellationRequested ? (Task<T>) null : cancellationToken.FromCanceled<T>();

    public static Task FromCanceled(this CancellationToken cancellationToken) => new Task((Action) (() => { }), cancellationToken);

    public static Task<T> FromCanceled<T>(this CancellationToken cancellationToken) => new Task<T>((Func<T>) (() => default (T)), cancellationToken);

    public static Task WriteAsync(
      this TextWriter writer,
      char value,
      CancellationToken cancellationToken)
    {
      return !cancellationToken.IsCancellationRequested ? writer.WriteAsync(value) : cancellationToken.FromCanceled();
    }

    public static Task WriteAsync(
      this TextWriter writer,
      string value,
      CancellationToken cancellationToken)
    {
      return !cancellationToken.IsCancellationRequested ? writer.WriteAsync(value) : cancellationToken.FromCanceled();
    }

    public static Task WriteAsync(
      this TextWriter writer,
      char[] value,
      int start,
      int count,
      CancellationToken cancellationToken)
    {
      return !cancellationToken.IsCancellationRequested ? writer.WriteAsync(value, start, count) : cancellationToken.FromCanceled();
    }

    public static Task<int> ReadAsync(
      this TextReader reader,
      char[] buffer,
      int index,
      int count,
      CancellationToken cancellationToken)
    {
      return !cancellationToken.IsCancellationRequested ? reader.ReadAsync(buffer, index, count) : cancellationToken.FromCanceled<int>();
    }

    public static bool IsCompletedSucessfully(this Task task) => task.Status == TaskStatus.RanToCompletion;
  }
}
