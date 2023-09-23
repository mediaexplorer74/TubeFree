// Decompiled with JetBrains decompiler
// Type: AngleSharp.Network.Download
// Assembly: AngleSharp, Version=0.9.9.0, Culture=neutral, PublicKeyToken=e83494dcdc6d31ea
// MVID: 6D8FC1AC-F585-421F-BEC1-9105A73220DF
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\AngleSharp.dll

using AngleSharp.Dom;
using System.Threading;
using System.Threading.Tasks;

namespace AngleSharp.Network
{
  internal sealed class Download : IDownload, ICancellable<IResponse>, ICancellable
  {
    private readonly CancellationTokenSource _cts;
    private readonly System.Threading.Tasks.Task<IResponse> _task;
    private readonly Url _target;
    private readonly INode _originator;

    public Download(
      System.Threading.Tasks.Task<IResponse> task,
      CancellationTokenSource cts,
      Url target,
      INode originator)
    {
      this._task = task;
      this._cts = cts;
      this._target = target;
      this._originator = originator;
    }

    public INode Originator => this._originator;

    public Url Target => this._target;

    public System.Threading.Tasks.Task<IResponse> Task => this._task;

    public bool IsRunning => this._task.Status == TaskStatus.Running;

    public bool IsCompleted => this._task.Status == TaskStatus.Faulted || this._task.Status == TaskStatus.RanToCompletion || this._task.Status == TaskStatus.Canceled;

    public void Cancel() => this._cts.Cancel();
  }
}
