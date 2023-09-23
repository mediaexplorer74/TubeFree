// Decompiled with JetBrains decompiler
// Type: Microsoft.AdMediator.WindowsPhone81.AdMediator_WindowsPhone81_XamlTypeInfo.XamlSystemBaseType
// Assembly: Microsoft.AdMediator.WindowsPhone81, Version=2.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1C586D37-9142-43D0-8912-08FBC7AC3DDA
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\Microsoft.AdMediator.WindowsPhone81.dll

using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using Windows.UI.Xaml.Markup;

namespace Microsoft.AdMediator.WindowsPhone81.AdMediator_WindowsPhone81_XamlTypeInfo
{
  [GeneratedCode("Microsoft.Windows.UI.Xaml.Build.Tasks", "4.0.0.0")]
  [DebuggerNonUserCode]
  internal class XamlSystemBaseType : IXamlType
  {
    private string _fullName;
    private Type _underlyingType;

    public XamlSystemBaseType(string fullName, Type underlyingType)
    {
      this._fullName = fullName;
      this._underlyingType = underlyingType;
    }

    public string FullName => this._fullName;

    public Type UnderlyingType => this._underlyingType;

    public virtual IXamlType BaseType => throw new NotImplementedException();

    public virtual IXamlMember ContentProperty => throw new NotImplementedException();

    public virtual IXamlMember GetMember(string name) => throw new NotImplementedException();

    public virtual bool IsArray => throw new NotImplementedException();

    public virtual bool IsCollection => throw new NotImplementedException();

    public virtual bool IsConstructible => throw new NotImplementedException();

    public virtual bool IsDictionary => throw new NotImplementedException();

    public virtual bool IsMarkupExtension => throw new NotImplementedException();

    public virtual bool IsBindable => throw new NotImplementedException();

    public virtual bool IsReturnTypeStub => throw new NotImplementedException();

    public virtual bool IsLocalType => throw new NotImplementedException();

    public virtual IXamlType ItemType => throw new NotImplementedException();

    public virtual IXamlType KeyType => throw new NotImplementedException();

    public virtual object ActivateInstance() => throw new NotImplementedException();

    public virtual void AddToMap(object instance, object key, object item) => throw new NotImplementedException();

    public virtual void AddToVector(object instance, object item) => throw new NotImplementedException();

    public virtual void RunInitializer() => throw new NotImplementedException();

    public virtual object CreateFromString(string input) => throw new NotImplementedException();
  }
}
