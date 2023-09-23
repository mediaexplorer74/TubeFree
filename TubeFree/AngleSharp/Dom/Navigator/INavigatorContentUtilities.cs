// Decompiled with JetBrains decompiler
// Type: AngleSharp.Dom.Navigator.INavigatorContentUtilities
// Assembly: AngleSharp, Version=0.9.9.0, Culture=neutral, PublicKeyToken=e83494dcdc6d31ea
// MVID: 6D8FC1AC-F585-421F-BEC1-9105A73220DF
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\AngleSharp.dll

using AngleSharp.Attributes;

namespace AngleSharp.Dom.Navigator
{
  [DomName("NavigatorContentUtils")]
  [DomNoInterfaceObject]
  public interface INavigatorContentUtilities
  {
    [DomName("registerProtocolHandler")]
    void RegisterProtocolHandler(string scheme, string url, string title);

    [DomName("registerContentHandler")]
    void RegisterContentHandler(string mimeType, string url, string title);

    [DomName("isProtocolHandlerRegistered")]
    bool IsProtocolHandlerRegistered(string scheme, string url);

    [DomName("isContentHandlerRegistered")]
    bool IsContentHandlerRegistered(string mimeType, string url);

    [DomName("unregisterProtocolHandler")]
    void UnregisterProtocolHandler(string scheme, string url);

    [DomName("unregisterContentHandler")]
    void UnregisterContentHandler(string mimeType, string url);
  }
}
