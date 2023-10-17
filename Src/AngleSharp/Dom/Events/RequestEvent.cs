// Decompiled with JetBrains decompiler
// Type: AngleSharp.Dom.Events.RequestEvent
// Assembly: AngleSharp, Version=0.9.9.0, Culture=neutral, PublicKeyToken=e83494dcdc6d31ea
// MVID: 6D8FC1AC-F585-421F-BEC1-9105A73220DF
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\AngleSharp.dll

using AngleSharp.Html;
using AngleSharp.Network;

namespace AngleSharp.Dom.Events
{
  public class RequestEvent : Event
  {
    public RequestEvent(IRequest request, IResponse response)
      : base(response != null ? EventNames.RequestEnd : EventNames.RequestStart)
    {
      this.Response = response;
      this.Request = request;
    }

    public IRequest Request { get; private set; }

    public IResponse Response { get; private set; }
  }
}
