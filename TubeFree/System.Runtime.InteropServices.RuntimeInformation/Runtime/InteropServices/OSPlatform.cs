// Decompiled with JetBrains decompiler
// Type: System.Runtime.InteropServices.OSPlatform
// Assembly: System.Runtime.InteropServices.RuntimeInformation, Version=4.0.1.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a
// MVID: 47FA4072-36BC-4A9B-B059-56DFEB5D596B
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\System.Runtime.InteropServices.RuntimeInformation.dll

namespace System.Runtime.InteropServices
{
  public struct OSPlatform : IEquatable<OSPlatform>
  {
    private readonly string _osPlatform;

    public static OSPlatform Linux { get; } = new OSPlatform("LINUX");

    public static OSPlatform OSX { get; } = new OSPlatform(nameof (OSX));

    public static OSPlatform Windows { get; } = new OSPlatform("WINDOWS");

    private OSPlatform(string osPlatform)
    {
      switch (osPlatform)
      {
        case null:
          throw new ArgumentNullException(nameof (osPlatform));
        case "":
          throw new ArgumentException(SR.Argument_EmptyValue, nameof (osPlatform));
        default:
          this._osPlatform = osPlatform;
          break;
      }
    }

    public static OSPlatform Create(string osPlatform) => new OSPlatform(osPlatform);

    public bool Equals(OSPlatform other) => this.Equals(other._osPlatform);

    internal bool Equals(string other) => string.Equals(this._osPlatform, other, StringComparison.Ordinal);

    public override bool Equals(object obj) => obj is OSPlatform other && this.Equals(other);

    public override int GetHashCode() => this._osPlatform != null ? this._osPlatform.GetHashCode() : 0;

    public override string ToString() => this._osPlatform ?? string.Empty;

    public static bool operator ==(OSPlatform left, OSPlatform right) => left.Equals(right);

    public static bool operator !=(OSPlatform left, OSPlatform right) => !(left == right);
  }
}
