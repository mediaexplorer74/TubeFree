// Decompiled with JetBrains decompiler
// Type: TubeFree8_1.TubeFree8_1_XamlTypeInfo.XamlUserType
// Assembly: TubeFree8-1, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B4DCF786-D976-4451-B6A4-B664A1A9ABDC
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\TubeFree8-1.exe

using Microsoft.VisualBasic.CompilerServices;
using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Windows.UI.Xaml.Markup;

namespace TubeFree8_1.TubeFree8_1_XamlTypeInfo
{
  [GeneratedCode("Microsoft.Windows.UI.Xaml.Build.Tasks", "4.0.0.0")]
  [DebuggerNonUserCode]
  internal class XamlUserType : XamlSystemBaseType
  {
    private XamlTypeInfoProvider _provider;
    private IXamlType _baseType;
    private bool _isArray;
    private bool _isMarkupExtension;
    private bool _isBindable;
    private bool _isReturnTypeStub;
    private bool _isLocalType;
    private string _contentPropertyName;
    private string _itemTypeName;
    private string _keyTypeName;
    private Dictionary<string, string> _memberNames;
    private Dictionary<string, object> _enumValues;

    public XamlUserType(
      XamlTypeInfoProvider provider,
      string fullName,
      Type fullType,
      IXamlType baseType)
      : base(fullName, fullType)
    {
      this._provider = provider;
      this._baseType = baseType;
    }

    public override IXamlType BaseType => this._baseType;

    public override bool IsArray => this._isArray;

    public override bool IsCollection => (MulticastDelegate) this.CollectionAdd != (MulticastDelegate) null;

    public override bool IsConstructible => (MulticastDelegate) this.Activator != (MulticastDelegate) null;

    public override bool IsDictionary => (MulticastDelegate) this.DictionaryAdd != (MulticastDelegate) null;

    public override bool IsMarkupExtension => this._isMarkupExtension;

    public override bool IsBindable => this._isBindable;

    public override IXamlMember ContentProperty => this._provider.GetMemberByLongName(this._contentPropertyName);

    public override IXamlType ItemType => this._provider.GetXamlTypeByName(this._itemTypeName);

    public override IXamlType KeyType => this._provider.GetXamlTypeByName(this._keyTypeName);

    public override IXamlMember GetMember(string name)
    {
      IXamlMember member;
      if (this._memberNames == null)
      {
        member = (IXamlMember) null;
      }
      else
      {
        string longMemberName = (string) null;
        member = !this._memberNames.TryGetValue(name, out longMemberName) ? (IXamlMember) null : this._provider.GetMemberByLongName(longMemberName);
      }
      return member;
    }

    public override object ActivateInstance() => this.Activator();

    public override void AddToMap(object instance, object key, object item) => this.DictionaryAdd(RuntimeHelpers.GetObjectValue(instance), RuntimeHelpers.GetObjectValue(key), RuntimeHelpers.GetObjectValue(item));

    public override void AddToVector(object instance, object item) => this.CollectionAdd(RuntimeHelpers.GetObjectValue(instance), RuntimeHelpers.GetObjectValue(item));

    public override void RunInitializer() => RuntimeHelpers.RunClassConstructor(this.UnderlyingType.TypeHandle);

    public override object CreateFromString(string input)
    {
      if (this._enumValues == null)
        throw new ArgumentException(input, this.FullName);
      int fromString = 0;
      string[] strArray = input.Split(',');
      int index = 0;
      while (index < strArray.Length)
      {
        string str = strArray[index];
        object obj = (object) null;
        int num = 0;
        try
        {
          if (this._enumValues.TryGetValue(str.Trim(), out obj))
          {
            num = Convert.ToInt32(RuntimeHelpers.GetObjectValue(obj));
          }
          else
          {
            try
            {
              num = Convert.ToInt32(str.Trim());
            }
            catch (FormatException ex)
            {
              ProjectData.SetProjectError((Exception) ex);
              Dictionary<string, object>.KeyCollection.Enumerator enumerator;
              try
              {
                enumerator = this._enumValues.Keys.GetEnumerator();
                while (enumerator.MoveNext())
                {
                  string current = enumerator.Current;
                  if (string.Compare(str.Trim(), current, StringComparison.OrdinalIgnoreCase) == 0)
                  {
                    if (this._enumValues.TryGetValue(current.Trim(), out obj))
                    {
                      num = Convert.ToInt32(RuntimeHelpers.GetObjectValue(obj));
                      break;
                    }
                    break;
                  }
                }
              }
              finally
              {
                enumerator.Dispose();
              }
              ProjectData.ClearProjectError();
            }
          }
          fromString |= num;
        }
        catch (Exception ex)
        {
          ProjectData.SetProjectError(ex);
          throw new ArgumentException(input, this.FullName);
        }
        checked { ++index; }
      }
      return (object) fromString;
    }

    public override bool IsReturnTypeStub => this._isReturnTypeStub;

    public override bool IsLocalType => this._isLocalType;

    public Activator Activator { get; set; }

    public AddToCollection CollectionAdd { get; set; }

    public AddToDictionary DictionaryAdd { get; set; }

    public void SetContentPropertyName(string contentPropertyName) => this._contentPropertyName = contentPropertyName;

    public void SetIsArray() => this._isArray = true;

    public void SetIsMarkupExtension() => this._isMarkupExtension = true;

    public void SetIsBindable() => this._isBindable = true;

    public void SetIsReturnTypeStub() => this._isReturnTypeStub = true;

    public void SetIsLocalType() => this._isLocalType = true;

    public void SetItemTypeName(string itemTypeName) => this._itemTypeName = itemTypeName;

    public void SetKeyTypeName(string keyTypeName) => this._keyTypeName = keyTypeName;

    public void AddMemberName(string shortName)
    {
      if (this._memberNames == null)
        this._memberNames = new Dictionary<string, string>();
      this._memberNames.Add(shortName, this.FullName + "." + shortName);
    }

    public void AddEnumValue(string name, object value)
    {
      if (this._enumValues == null)
        this._enumValues = new Dictionary<string, object>();
      this._enumValues.Add(name, RuntimeHelpers.GetObjectValue(value));
    }
  }
}
