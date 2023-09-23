// Decompiled with JetBrains decompiler
// Type: Newtonsoft.Json.Utilities.BufferUtils
// Assembly: Newtonsoft.Json, Version=12.0.0.0, Culture=neutral, PublicKeyToken=30ad4fe6b2a6aeed
// MVID: A4A4D6C6-3EFA-4DC8-AAEA-DA1EC7F2D4DE
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\Newtonsoft.Json.dll

namespace Newtonsoft.Json.Utilities
{
  internal static class BufferUtils
  {
    public static char[] RentBuffer(IArrayPool<char> bufferPool, int minSize) => bufferPool == null ? new char[minSize] : bufferPool.Rent(minSize);

    public static void ReturnBuffer(IArrayPool<char> bufferPool, char[] buffer) => bufferPool?.Return(buffer);

    public static char[] EnsureBufferSize(IArrayPool<char> bufferPool, int size, char[] buffer)
    {
      if (bufferPool == null)
        return new char[size];
      if (buffer != null)
        bufferPool.Return(buffer);
      return bufferPool.Rent(size);
    }
  }
}
