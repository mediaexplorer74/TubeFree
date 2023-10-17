// Decompiled with JetBrains decompiler
// Type: AngleSharp.Dom.Events.InteractivityEvent`1
// Assembly: AngleSharp, Version=0.9.9.0, Culture=neutral, PublicKeyToken=e83494dcdc6d31ea
// MVID: 6D8FC1AC-F585-421F-BEC1-9105A73220DF
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\AngleSharp.dll

using System.Threading.Tasks;

namespace AngleSharp.Dom.Events
{
  public class InteractivityEvent<T> : Event
  {
    private Task _result;

    public InteractivityEvent(string eventName, T data)
      : base(eventName)
    {
      this.Data = data;
    }

    public Task Result => this._result;

    public void SetResult(Task value)
    {
      if (this._result != null)
        this._result = TaskEx.WhenAll(this._result, value);
      else
        this._result = value;
    }

    public T Data { get; private set; }
  }
}
