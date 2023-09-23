// Decompiled with JetBrains decompiler
// Type: Microsoft.Advertising.Shared.WinRT.__IAdExtensionPublicNonVirtuals
// Assembly: Microsoft.Advertising, Version=255.255.255.255, Culture=neutral, PublicKeyToken=null, ContentType=WindowsRuntime
// MVID: AAA22BA4-D3C2-42EA-A2EC-4B10E0D720BD
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\Microsoft.Advertising.winmd

using Windows.Foundation.Metadata;

namespace Microsoft.Advertising.Shared.WinRT
{
  [Guid(3469579653, 40555, 12643, 152, 151, 99, 97, 88, 239, 62, 24)]
  [ExclusiveTo(typeof (AdExtension))]
  [Version(1)]
  internal interface __IAdExtensionPublicNonVirtuals
  {
    string Type { get; }

    string XmlData { get; }

    string JsonData { get; }
  }
}
