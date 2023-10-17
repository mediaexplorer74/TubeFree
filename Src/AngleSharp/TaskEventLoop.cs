// Decompiled with JetBrains decompiler
// Type: AngleSharp.TaskEventLoop
// Assembly: AngleSharp, Version=0.9.9.0, Culture=neutral, PublicKeyToken=e83494dcdc6d31ea
// MVID: 6D8FC1AC-F585-421F-BEC1-9105A73220DF
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\AngleSharp.dll

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace AngleSharp
{
  internal sealed class TaskEventLoop : IEventLoop
  {
    private readonly Dictionary<TaskPriority, Queue<TaskEventLoop.TaskEventLoopEntry>> _queues;
    private TaskEventLoop.TaskEventLoopEntry _current;

    public TaskEventLoop()
    {
      this._queues = new Dictionary<TaskPriority, Queue<TaskEventLoop.TaskEventLoopEntry>>();
      this._current = (TaskEventLoop.TaskEventLoopEntry) null;
    }

    public ICancellable Enqueue(Action<CancellationToken> task, TaskPriority priority)
    {
      TaskEventLoop.TaskEventLoopEntry entry = new TaskEventLoop.TaskEventLoopEntry(task);
      lock (this)
      {
        Queue<TaskEventLoop.TaskEventLoopEntry> taskEventLoopEntryQueue = (Queue<TaskEventLoop.TaskEventLoopEntry>) null;
        if (!this._queues.TryGetValue(priority, out taskEventLoopEntryQueue))
        {
          taskEventLoopEntryQueue = new Queue<TaskEventLoop.TaskEventLoopEntry>();
          this._queues.Add(priority, taskEventLoopEntryQueue);
        }
        if (this._current == null)
          this.SetCurrent(entry);
        else
          taskEventLoopEntryQueue.Enqueue(entry);
      }
      return (ICancellable) entry;
    }

    public void Spin()
    {
      lock (this)
      {
        TaskEventLoop.TaskEventLoopEntry current = this._current;
        if ((current != null ? (!current.IsRunning ? 1 : 0) : 1) == 0)
          return;
        this.SetCurrent(this.Dequeue(TaskPriority.Critical) ?? this.Dequeue(TaskPriority.Microtask) ?? this.Dequeue(TaskPriority.Normal) ?? this.Dequeue(TaskPriority.None));
      }
    }

    public void CancelAll()
    {
      lock (this)
      {
        foreach (KeyValuePair<TaskPriority, Queue<TaskEventLoop.TaskEventLoopEntry>> queue in this._queues)
        {
          Queue<TaskEventLoop.TaskEventLoopEntry> taskEventLoopEntryQueue = queue.Value;
          while (taskEventLoopEntryQueue.Count > 0)
            taskEventLoopEntryQueue.Dequeue().Cancel();
        }
        this._queues.Clear();
        this._current?.Cancel();
      }
    }

    private void SetCurrent(TaskEventLoop.TaskEventLoopEntry entry)
    {
      this._current = entry;
      entry?.Run(new Action(this.Continue));
    }

    private void Continue()
    {
      lock (this)
        this._current = (TaskEventLoop.TaskEventLoopEntry) null;
      this.Spin();
    }

    private TaskEventLoop.TaskEventLoopEntry Dequeue(TaskPriority priority) => this._queues.ContainsKey(priority) && this._queues[priority].Count != 0 ? this._queues[priority].Dequeue() : (TaskEventLoop.TaskEventLoopEntry) null;

    private sealed class TaskEventLoopEntry : ICancellable
    {
      private readonly CancellationTokenSource _cts;
      private readonly Action<CancellationToken> _action;
      private Task _task;

      public TaskEventLoopEntry(Action<CancellationToken> action)
      {
        this._cts = new CancellationTokenSource();
        this._action = action;
      }

      public bool IsCompleted => this._task != null && this._task.IsCompleted;

      public bool IsRunning => this._task != null && this._task.Status == TaskStatus.Running || this._task.Status == TaskStatus.WaitingForActivation || this._task.Status == TaskStatus.WaitingToRun || this._task.Status == TaskStatus.WaitingForChildrenToComplete;

      public void Run(Action callback)
      {
        if (this._task != null)
          return;
        this._task = TaskEx.Run((Action) (() =>
        {
          this._action(this._cts.Token);
          callback();
        }), this._cts.Token);
      }

      public void Cancel() => this._cts.Cancel();
    }
  }
}
