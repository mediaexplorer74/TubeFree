// Decompiled with JetBrains decompiler
// Type: YoutubeExplode.Models.ClosedCaptions.Language
// Assembly: Explode, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D9BD94EC-1F8A-4D23-A0FC-F2CF6230133A
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\Explode.dll

using JetBrains.Annotations;
using YoutubeExplode.Internal;

namespace YoutubeExplode.Models.ClosedCaptions
{
  public class Language
  {
    [NotNull]
    public string Code { get; }

    [NotNull]
    public string Name { get; }

    public Language(string code, string name)
    {
      this.Code = code.GuardNotNull<string>(nameof (code));
      this.Name = name.GuardNotNull<string>(nameof (name));
    }

    public override string ToString() => string.Format("{0} ({1})", new object[2]
    {
      (object) this.Code,
      (object) this.Name
    });
  }
}
