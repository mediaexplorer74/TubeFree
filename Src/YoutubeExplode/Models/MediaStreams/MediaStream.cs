// Decompiled with JetBrains decompiler
// Type: YoutubeExplode.Models.MediaStreams.MediaStream
// Assembly: Explode, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D9BD94EC-1F8A-4D23-A0FC-F2CF6230133A
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\Explode.dll

using JetBrains.Annotations;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using YoutubeExplode.Internal;

namespace YoutubeExplode.Models.MediaStreams
{
  public class MediaStream : Stream
  {
    private readonly Stream _stream;

    [NotNull]
    public MediaStreamInfo Info { get; }

    public override bool CanRead => this._stream.CanRead;

    public override bool CanSeek => this._stream.CanSeek;

    public override bool CanWrite => this._stream.CanWrite;

    public override long Length => this.Info.Size;

    public override long Position
    {
      get => this._stream.Position;
      set => this._stream.Position = value;
    }

    public MediaStream(MediaStreamInfo info, Stream stream)
    {
      this.Info = info.GuardNotNull<MediaStreamInfo>(nameof (info));
      this._stream = stream.GuardNotNull<Stream>(nameof (stream));
    }

    public override int Read(byte[] buffer, int offset, int count) => this._stream.Read(buffer, offset, count);

    public override Task<int> ReadAsync(
      byte[] buffer,
      int offset,
      int count,
      CancellationToken cancellationToken)
    {
      return this._stream.ReadAsync(buffer, offset, count, cancellationToken);
    }

    public override long Seek(long offset, SeekOrigin origin) => this._stream.Seek(offset, origin);

    public override void Flush() => this._stream.Flush();

    public override void SetLength(long value) => this._stream.SetLength(value);

    public override void Write(byte[] buffer, int offset, int count) => this._stream.Write(buffer, offset, count);

    protected override void Dispose(bool disposing)
    {
      base.Dispose(disposing);
      if (!disposing)
        return;
      this._stream.Dispose();
    }
  }
}
