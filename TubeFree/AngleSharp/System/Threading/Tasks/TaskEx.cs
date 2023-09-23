// Decompiled with JetBrains decompiler
// Type: System.Threading.Tasks.TaskEx
// Assembly: AngleSharp, Version=0.9.9.0, Culture=neutral, PublicKeyToken=e83494dcdc6d31ea
// MVID: 6D8FC1AC-F585-421F-BEC1-9105A73220DF
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\AngleSharp.dll

using System.Collections.Generic;

namespace System.Threading.Tasks
{
  internal static class TaskEx
  {
    public static Task WhenAll(params Task[] tasks) => Task.WhenAll(tasks);

    public static Task Run(Action action, CancellationToken cancel) => Task.Run(action, cancel);

    public static Task Delay(int millisecondsDelay, CancellationToken cancel) => Task.Delay(millisecondsDelay, cancel);

    public static Task WhenAll(IEnumerable<Task> tasks) => Task.WhenAll(tasks);

    public static Task<TResult> FromResult<TResult>(TResult result) => Task.FromResult<TResult>(result);
  }
}
