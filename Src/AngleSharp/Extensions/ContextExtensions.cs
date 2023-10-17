// Decompiled with JetBrains decompiler
// Type: AngleSharp.Extensions.ContextExtensions
// Assembly: AngleSharp, Version=0.9.9.0, Culture=neutral, PublicKeyToken=e83494dcdc6d31ea
// MVID: 6D8FC1AC-F585-421F-BEC1-9105A73220DF
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\AngleSharp.dll

using AngleSharp.Services;

namespace AngleSharp.Extensions
{
  internal static class ContextExtensions
  {
    public static TService CreateService<TService>(this IBrowsingContext context) => context.Configuration.GetFactory<IServiceFactory>().Create<TService>(context);
  }
}
