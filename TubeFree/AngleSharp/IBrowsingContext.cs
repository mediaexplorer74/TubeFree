// Decompiled with JetBrains decompiler
// Type: AngleSharp.IBrowsingContext
// Assembly: AngleSharp, Version=0.9.9.0, Culture=neutral, PublicKeyToken=e83494dcdc6d31ea
// MVID: 6D8FC1AC-F585-421F-BEC1-9105A73220DF
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\AngleSharp.dll

using AngleSharp.Dom;
using AngleSharp.Network;

namespace AngleSharp
{
  public interface IBrowsingContext : IEventTarget
  {
    IWindow Current { get; }

    IDocument Active { get; set; }

    IHistory SessionHistory { get; }

    Sandboxes Security { get; }

    IConfiguration Configuration { get; }

    IDocumentLoader Loader { get; }

    IBrowsingContext Parent { get; }

    IDocument Creator { get; }

    event DomEventHandler Parsing;

    event DomEventHandler Parsed;

    event DomEventHandler ParseError;

    event DomEventHandler Requesting;

    event DomEventHandler Requested;
  }
}
