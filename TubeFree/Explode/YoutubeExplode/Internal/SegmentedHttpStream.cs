// Decompiled with JetBrains decompiler
// Type: YoutubeExplode.Internal.SegmentedHttpStream
// Assembly: Explode, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D9BD94EC-1F8A-4D23-A0FC-F2CF6230133A
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\Explode.dll

using System;
using System.IO;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace YoutubeExplode.Internal
{
  internal class SegmentedHttpStream : Stream
  {
    private readonly HttpClient _httpClient;
    private readonly string _url;
    private readonly long _segmentSize;
    private Stream _currentStream;
    private long _position;

    public SegmentedHttpStream(HttpClient httpClient, string url, long length, long segmentSize)
    {
      this._url = url;
      this._httpClient = httpClient;
      this.Length = length;
      this._segmentSize = segmentSize;
    }

    public override bool CanRead => true;

    public override bool CanSeek => true;

    public override bool CanWrite => false;

    public override long Length { get; }

    public override long Position
    {
      get => this._position;
      set
      {
        value.GuardNotNegative(nameof (value));
        if (this._position == value)
          return;
        this._position = value;
        this.ClearCurrentStream();
      }
    }

    private void ClearCurrentStream()
    {
      this._currentStream?.Dispose();
      this._currentStream = (Stream) null;
    }

    public override async Task<int> ReadAsync(
      byte[] buffer,
      int offset,
      int count,
      CancellationToken cancellationToken)
    {
      if (this.Position >= this.Length)
        return 0;
      if (this._currentStream == null)
      {
        SegmentedHttpStream segmentedHttpStream = this;
        Stream currentStream = segmentedHttpStream._currentStream;
        Stream stream = await this._httpClient.GetStreamAsync(this._url, new long?(this.Position), new long?(this.Position + this._segmentSize - 1L)).ConfigureAwait(false);
        segmentedHttpStream._currentStream = stream;
        segmentedHttpStream = (SegmentedHttpStream) null;
      }
      int num = await this._currentStream.ReadAsync(buffer, offset, count, cancellationToken).ConfigureAwait(false);
      this._position += (long) num;
      if (num == 0)
      {
        this.ClearCurrentStream();
        num = await this.ReadAsync(buffer, offset, count, cancellationToken).ConfigureAwait(false);
      }
      return num;
    }

    public override int Read(byte[] buffer, int offset, int count) => this.ReadAsync(buffer, offset, count).ConfigureAwait(false).GetAwaiter().GetResult();

    private long GetNewPosition(long offset, SeekOrigin origin)
    {
      switch (origin)
      {
        case SeekOrigin.Begin:
          return offset;
        case SeekOrigin.Current:
          return this.Position + offset;
        case SeekOrigin.End:
          return this.Length + offset;
        default:
          throw new ArgumentOutOfRangeException(nameof (origin));
      }
    }

    public override long Seek(long offset, SeekOrigin origin)
    {
      long newPosition = this.GetNewPosition(offset, origin);
      if (newPosition < 0L)
        throw new IOException("An attempt was made to move the position before the beginning of the stream.");
      return this.Position = newPosition;
    }

    public override void Flush() => throw new NotSupportedException();

    public override void SetLength(long value) => throw new NotSupportedException();

    public override void Write(byte[] buffer, int offset, int count) => throw new NotSupportedException();

    protected override void Dispose(bool disposing)
    {
      base.Dispose(disposing);
      if (!disposing)
        return;
      this.ClearCurrentStream();
    }
  }
}
