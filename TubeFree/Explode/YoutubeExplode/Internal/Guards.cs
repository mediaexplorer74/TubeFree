// Decompiled with JetBrains decompiler
// Type: YoutubeExplode.Internal.Guards
// Assembly: Explode, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D9BD94EC-1F8A-4D23-A0FC-F2CF6230133A
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\Explode.dll

using JetBrains.Annotations;
using System;

namespace YoutubeExplode.Internal
{
  internal static class Guards
  {
    [ContractAnnotation("o:null => halt")]
    public static T GuardNotNull<T>([NoEnumeration] this T o, string argName = null) where T : class => o;

    public static TimeSpan GuardNotNegative(this TimeSpan t, string argName = null) => t >= TimeSpan.Zero ? t : throw new ArgumentOutOfRangeException(argName, (object) t, "Cannot be negative.");

    public static int GuardNotNegative(this int i, string argName = null) => i >= 0 ? i : throw new ArgumentOutOfRangeException(argName, (object) i, "Cannot be negative.");

    public static long GuardNotNegative(this long i, string argName = null) => i >= 0L ? i : throw new ArgumentOutOfRangeException(argName, (object) i, "Cannot be negative.");

    public static int GuardPositive(this int i, string argName = null) => i > 0 ? i : throw new ArgumentOutOfRangeException(argName, (object) i, "Cannot be negative or zero.");

    public static long GuardPositive(this long i, string argName = null) => i > 0L ? i : throw new ArgumentOutOfRangeException(argName, (object) i, "Cannot be negative or zero.");
  }
}
