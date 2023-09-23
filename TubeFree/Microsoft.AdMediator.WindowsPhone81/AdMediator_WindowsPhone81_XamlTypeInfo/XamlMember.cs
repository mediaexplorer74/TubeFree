// Decompiled with JetBrains decompiler
// Type: Microsoft.AdMediator.WindowsPhone81.AdMediator_WindowsPhone81_XamlTypeInfo.XamlMember
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
  internal class XamlMember : IXamlMember
  {
    private XamlTypeInfoProvider _provider;
    private string _name;
    private bool _isAttachable;
    private bool _isDependencyProperty;
    private bool _isReadOnly;
    private string _typeName;
    private string _targetTypeName;

    public XamlMember(XamlTypeInfoProvider provider, string name, string typeName)
    {
      this._name = name;
      this._typeName = typeName;
      this._provider = provider;
    }

    public string Name => this._name;

    public IXamlType Type => this._provider.GetXamlTypeByName(this._typeName);

    public void SetTargetTypeName(string targetTypeName) => this._targetTypeName = targetTypeName;

    public IXamlType TargetType => this._provider.GetXamlTypeByName(this._targetTypeName);

    public void SetIsAttachable() => this._isAttachable = true;

    public bool IsAttachable => this._isAttachable;

    public void SetIsDependencyProperty() => this._isDependencyProperty = true;

    public bool IsDependencyProperty => this._isDependencyProperty;

    public void SetIsReadOnly() => this._isReadOnly = true;

    public bool IsReadOnly => this._isReadOnly;

    public Getter Getter { get; set; }

    public object GetValue(object instance)
    {
      if (this.Getter != null)
        return this.Getter(instance);
      throw new InvalidOperationException(nameof (GetValue));
    }

    public Setter Setter { get; set; }

    public void SetValue(object instance, object value)
    {
      if (this.Setter == null)
        throw new InvalidOperationException(nameof (SetValue));
      this.Setter(instance, value);
    }
  }
}
