// Decompiled with JetBrains decompiler
// Type: Microsoft.AdMediator.WindowsPhone81.AdMediator_WindowsPhone81_XamlTypeInfo.XamlMetaDataProvider
// Assembly: Microsoft.AdMediator.WindowsPhone81, Version=2.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1C586D37-9142-43D0-8912-08FBC7AC3DDA
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\Microsoft.AdMediator.WindowsPhone81.dll

using System;
using System.CodeDom.Compiler;
using Windows.UI.Xaml.Markup;

namespace Microsoft.AdMediator.WindowsPhone81.AdMediator_WindowsPhone81_XamlTypeInfo
{
  [GeneratedCode("Microsoft.Windows.UI.Xaml.Build.Tasks", "4.0.0.0")]
  public sealed class XamlMetaDataProvider : IXamlMetadataProvider
  {
    private XamlTypeInfoProvider _provider;

    public IXamlType GetXamlType(Type type)
    {
      if (this._provider == null)
        this._provider = new XamlTypeInfoProvider();
      return this._provider.GetXamlTypeByType(type);
    }

    public IXamlType GetXamlType(string fullName)
    {
      if (this._provider == null)
        this._provider = new XamlTypeInfoProvider();
      return this._provider.GetXamlTypeByName(fullName);
    }

    public XmlnsDefinition[] GetXmlnsDefinitions() => new XmlnsDefinition[0];
  }
}
