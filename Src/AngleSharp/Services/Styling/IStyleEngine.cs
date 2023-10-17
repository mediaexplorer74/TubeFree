// Decompiled with JetBrains decompiler
// Type: AngleSharp.Services.Styling.IStyleEngine
// Assembly: AngleSharp, Version=0.9.9.0, Culture=neutral, PublicKeyToken=e83494dcdc6d31ea
// MVID: 6D8FC1AC-F585-421F-BEC1-9105A73220DF
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\AngleSharp.dll

using AngleSharp.Dom;
using AngleSharp.Network;
using System.Threading;
using System.Threading.Tasks;

namespace AngleSharp.Services.Styling
{
  public interface IStyleEngine
  {
    string Type { get; }

    Task<IStyleSheet> ParseStylesheetAsync(
      IResponse response,
      StyleOptions options,
      CancellationToken cancel);
  }
}
