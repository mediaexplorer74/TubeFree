// Decompiled with JetBrains decompiler
// Type: Microsoft.Advertising.UniversalXamlAdControl_WindowsPhone_XamlTypeInfo.XamlMetaDataProvider
// Assembly: Microsoft.Advertising, Version=255.255.255.255, Culture=neutral, PublicKeyToken=null, ContentType=WindowsRuntime
// MVID: AAA22BA4-D3C2-42EA-A2EC-4B10E0D720BD
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\Microsoft.Advertising.winmd

using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Windows.Foundation.Metadata;
using Windows.UI.Xaml.Interop;
using Windows.UI.Xaml.Markup;

namespace Microsoft.Advertising.UniversalXamlAdControl_WindowsPhone_XamlTypeInfo
{
  [Threading]
  [MarshalingBehavior]
  [Version(1)]
  [WebHostHidden]
  [Activatable(1)]
  public sealed class XamlMetaDataProvider : 
    IXamlMetadataProvider,
    __IXamlMetaDataProviderPublicNonVirtuals
  {
    [Overload("GetXamlTypeByFullName")]
    [MethodImpl(MethodCodeType = MethodCodeType.Runtime)]
    public extern IXamlType GetXamlType([In] string fullName);

    [DefaultOverload]
    [Overload("GetXamlType")]
    [MethodImpl(MethodCodeType = MethodCodeType.Runtime)]
    public extern IXamlType GetXamlType([In] TypeName type);

    [MethodImpl(MethodCodeType = MethodCodeType.Runtime)]
    public extern XmlnsDefinition[] GetXmlnsDefinitions();

    [Overload("CreateInstance1")]
    [MethodImpl(MethodCodeType = MethodCodeType.Runtime)]
    public extern XamlMetaDataProvider();
  }
}
