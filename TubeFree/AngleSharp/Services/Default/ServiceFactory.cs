// Decompiled with JetBrains decompiler
// Type: AngleSharp.Services.Default.ServiceFactory
// Assembly: AngleSharp, Version=0.9.9.0, Culture=neutral, PublicKeyToken=e83494dcdc6d31ea
// MVID: 6D8FC1AC-F585-421F-BEC1-9105A73220DF
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\AngleSharp.dll

using System;

namespace AngleSharp.Services.Default
{
  public class ServiceFactory : IServiceFactory
  {
    public TService Create<TService>(IBrowsingContext context)
    {
      Func<IBrowsingContext, TService> service = context.Configuration.GetService<Func<IBrowsingContext, TService>>();
      return service == null ? default (TService) : service(context);
    }
  }
}
