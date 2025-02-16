﻿// Decompiled with JetBrains decompiler
// Type: AngleSharp.Dom.IUrlUtilities
// Assembly: AngleSharp, Version=0.9.9.0, Culture=neutral, PublicKeyToken=e83494dcdc6d31ea
// MVID: 6D8FC1AC-F585-421F-BEC1-9105A73220DF
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\AngleSharp.dll

using AngleSharp.Attributes;

namespace AngleSharp.Dom
{
  [DomName("URLUtils")]
  [DomNoInterfaceObject]
  public interface IUrlUtilities
  {
    [DomName("href")]
    string Href { get; set; }

    [DomName("protocol")]
    string Protocol { get; set; }

    [DomName("host")]
    string Host { get; set; }

    [DomName("hostname")]
    string HostName { get; set; }

    [DomName("port")]
    string Port { get; set; }

    [DomName("pathname")]
    string PathName { get; set; }

    [DomName("search")]
    string Search { get; set; }

    [DomName("hash")]
    string Hash { get; set; }

    [DomName("username")]
    string UserName { get; set; }

    [DomName("password")]
    string Password { get; set; }

    [DomName("origin")]
    string Origin { get; }
  }
}
