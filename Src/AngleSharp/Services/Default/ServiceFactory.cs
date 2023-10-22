using AngleSharp.Extensions;
using System;

namespace AngleSharp.Services.Default
{
  public class ServiceFactory : IServiceFactory
  {
    public TService Create<TService>(IBrowsingContext context)
    {
      Func<IBrowsingContext, TService> service = 
                context.Configuration.GetService<Func<IBrowsingContext, TService>>();

      return service == null ? default (TService) : service(context);
    }
  }
}
