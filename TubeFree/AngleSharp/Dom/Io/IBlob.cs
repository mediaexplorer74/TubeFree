// Decompiled with JetBrains decompiler
// Type: AngleSharp.Dom.Io.IBlob
// Assembly: AngleSharp, Version=0.9.9.0, Culture=neutral, PublicKeyToken=e83494dcdc6d31ea
// MVID: 6D8FC1AC-F585-421F-BEC1-9105A73220DF
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\AngleSharp.dll

using AngleSharp.Attributes;
using System;
using System.IO;

namespace AngleSharp.Dom.Io
{
  [DomName("Blob")]
  public interface IBlob : IDisposable
  {
    [DomName("size")]
    int Length { get; }

    [DomName("type")]
    string Type { get; }

    [DomName("isClosed")]
    bool IsClosed { get; }

    Stream Body { get; }

    [DomName("slice")]
    IBlob Slice(int start = 0, int end = 2147483647, string contentType = null);

    [DomName("close")]
    void Close();
  }
}
