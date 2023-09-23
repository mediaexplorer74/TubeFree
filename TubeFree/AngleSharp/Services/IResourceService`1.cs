// Decompiled with JetBrains decompiler
// Type: AngleSharp.Services.IResourceService`1
// Assembly: AngleSharp, Version=0.9.9.0, Culture=neutral, PublicKeyToken=e83494dcdc6d31ea
// MVID: 6D8FC1AC-F585-421F-BEC1-9105A73220DF
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\AngleSharp.dll

using AngleSharp.Network;
using AngleSharp.Services.Media;
using System.Threading;
using System.Threading.Tasks;

namespace AngleSharp.Services
{
  public interface IResourceService<TResource> where TResource : IResourceInfo
  {
    bool SupportsType(string mimeType);

    Task<TResource> CreateAsync(IResponse response, CancellationToken cancel);
  }
}
