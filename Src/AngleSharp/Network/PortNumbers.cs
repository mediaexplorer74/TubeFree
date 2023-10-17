// Decompiled with JetBrains decompiler
// Type: AngleSharp.Network.PortNumbers
// Assembly: AngleSharp, Version=0.9.9.0, Culture=neutral, PublicKeyToken=e83494dcdc6d31ea
// MVID: 6D8FC1AC-F585-421F-BEC1-9105A73220DF
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\AngleSharp.dll

using System.Collections.Generic;

namespace AngleSharp.Network
{
  internal static class PortNumbers
  {
    private static readonly Dictionary<string, string> Ports = new Dictionary<string, string>()
    {
      {
        ProtocolNames.Http,
        "80"
      },
      {
        ProtocolNames.Https,
        "443"
      },
      {
        ProtocolNames.Ftp,
        "21"
      },
      {
        ProtocolNames.File,
        ""
      },
      {
        ProtocolNames.Ws,
        "80"
      },
      {
        ProtocolNames.Wss,
        "443"
      },
      {
        ProtocolNames.Gopher,
        "70"
      },
      {
        ProtocolNames.Telnet,
        "23"
      },
      {
        ProtocolNames.Ssh,
        "22"
      }
    };

    public static string GetDefaultPort(string protocol)
    {
      string defaultPort = (string) null;
      PortNumbers.Ports.TryGetValue(protocol, out defaultPort);
      return defaultPort;
    }
  }
}
