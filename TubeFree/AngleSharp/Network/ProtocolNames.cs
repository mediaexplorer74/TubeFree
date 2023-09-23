// Decompiled with JetBrains decompiler
// Type: AngleSharp.Network.ProtocolNames
// Assembly: AngleSharp, Version=0.9.9.0, Culture=neutral, PublicKeyToken=e83494dcdc6d31ea
// MVID: 6D8FC1AC-F585-421F-BEC1-9105A73220DF
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\AngleSharp.dll

using AngleSharp.Extensions;

namespace AngleSharp.Network
{
  public static class ProtocolNames
  {
    public static readonly string Http = "http";
    public static readonly string Https = "https";
    public static readonly string Ftp = "ftp";
    public static readonly string JavaScript = "javascript";
    public static readonly string Data = "data";
    public static readonly string Mailto = "mailto";
    public static readonly string File = "file";
    public static readonly string Ws = "ws";
    public static readonly string Wss = "wss";
    public static readonly string Telnet = "telnet";
    public static readonly string Ssh = "ssh";
    public static readonly string Gopher = "gopher";
    public static readonly string Blob = "blob";
    private static readonly string[] RelativeProtocols = new string[7]
    {
      ProtocolNames.Http,
      ProtocolNames.Https,
      ProtocolNames.Ftp,
      ProtocolNames.File,
      ProtocolNames.Ws,
      ProtocolNames.Wss,
      ProtocolNames.Gopher
    };
    private static readonly string[] OriginalableProtocols = new string[6]
    {
      ProtocolNames.Http,
      ProtocolNames.Https,
      ProtocolNames.Ftp,
      ProtocolNames.Ws,
      ProtocolNames.Wss,
      ProtocolNames.Gopher
    };

    public static bool IsRelative(string protocol) => StringExtensions.Contains(ProtocolNames.RelativeProtocols, protocol);

    public static bool IsOriginable(string protocol) => StringExtensions.Contains(ProtocolNames.OriginalableProtocols, protocol);
  }
}
