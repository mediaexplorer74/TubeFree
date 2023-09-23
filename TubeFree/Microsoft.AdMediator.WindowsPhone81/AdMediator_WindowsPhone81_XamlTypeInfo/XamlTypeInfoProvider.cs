// Decompiled with JetBrains decompiler
// Type: Microsoft.AdMediator.WindowsPhone81.AdMediator_WindowsPhone81_XamlTypeInfo.XamlTypeInfoProvider
// Assembly: Microsoft.AdMediator.WindowsPhone81, Version=2.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1C586D37-9142-43D0-8912-08FBC7AC3DDA
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\Microsoft.AdMediator.WindowsPhone81.dll

using Microsoft.AdMediator.Core.Models;
using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Diagnostics;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Markup;

namespace Microsoft.AdMediator.WindowsPhone81.AdMediator_WindowsPhone81_XamlTypeInfo
{
  [GeneratedCode("Microsoft.Windows.UI.Xaml.Build.Tasks", "4.0.0.0")]
  [DebuggerNonUserCode]
  internal class XamlTypeInfoProvider
  {
    private Dictionary<string, IXamlType> _xamlTypeCacheByName = new Dictionary<string, IXamlType>();
    private Dictionary<Type, IXamlType> _xamlTypeCacheByType = new Dictionary<Type, IXamlType>();
    private Dictionary<string, IXamlMember> _xamlMembers = new Dictionary<string, IXamlMember>();
    private string[] _typeNameTable;
    private Type[] _typeTable;

    public IXamlType GetXamlTypeByType(Type type)
    {
      IXamlType xamlType;
      if (this._xamlTypeCacheByType.TryGetValue(type, out xamlType))
        return xamlType;
      int typeIndex = this.LookupTypeIndexByType(type);
      if (typeIndex != -1)
        xamlType = this.CreateXamlType(typeIndex);
      if (xamlType != null)
      {
        this._xamlTypeCacheByName.Add(xamlType.FullName, xamlType);
        this._xamlTypeCacheByType.Add(xamlType.UnderlyingType, xamlType);
      }
      return xamlType;
    }

    public IXamlType GetXamlTypeByName(string typeName)
    {
      if (string.IsNullOrEmpty(typeName))
        return (IXamlType) null;
      IXamlType xamlType;
      if (this._xamlTypeCacheByName.TryGetValue(typeName, out xamlType))
        return xamlType;
      int typeIndex = this.LookupTypeIndexByName(typeName);
      if (typeIndex != -1)
        xamlType = this.CreateXamlType(typeIndex);
      if (xamlType != null)
      {
        this._xamlTypeCacheByName.Add(xamlType.FullName, xamlType);
        this._xamlTypeCacheByType.Add(xamlType.UnderlyingType, xamlType);
      }
      return xamlType;
    }

    public IXamlMember GetMemberByLongName(string longMemberName)
    {
      if (string.IsNullOrEmpty(longMemberName))
        return (IXamlMember) null;
      IXamlMember memberByLongName;
      if (this._xamlMembers.TryGetValue(longMemberName, out memberByLongName))
        return memberByLongName;
      IXamlMember xamlMember = this.CreateXamlMember(longMemberName);
      if (xamlMember != null)
        this._xamlMembers.Add(longMemberName, xamlMember);
      return xamlMember;
    }

    private void InitTypeTables()
    {
      this._typeNameTable = new string[11];
      this._typeNameTable[0] = "Microsoft.AdMediator.WindowsPhone81.AdMediatorControl";
      this._typeNameTable[1] = "Windows.UI.Xaml.Controls.Control";
      this._typeNameTable[2] = "String";
      this._typeNameTable[3] = "Microsoft.AdMediator.Core.Models.AdSdkParameters";
      this._typeNameTable[4] = "Object";
      this._typeNameTable[5] = "System.Collections.Generic.IDictionary`2<String, TimeSpan>";
      this._typeNameTable[6] = "TimeSpan";
      this._typeNameTable[7] = "System.ValueType";
      this._typeNameTable[8] = "Int32";
      this._typeNameTable[9] = "Int64";
      this._typeNameTable[10] = "Double";
      this._typeTable = new Type[11];
      this._typeTable[0] = typeof (AdMediatorControl);
      this._typeTable[1] = typeof (Control);
      this._typeTable[2] = typeof (string);
      this._typeTable[3] = typeof (AdSdkParameters);
      this._typeTable[4] = typeof (object);
      this._typeTable[5] = typeof (IDictionary<string, TimeSpan>);
      this._typeTable[6] = typeof (TimeSpan);
      this._typeTable[7] = typeof (ValueType);
      this._typeTable[8] = typeof (int);
      this._typeTable[9] = typeof (long);
      this._typeTable[10] = typeof (double);
    }

    private int LookupTypeIndexByName(string typeName)
    {
      if (this._typeNameTable == null)
        this.InitTypeTables();
      for (int index = 0; index < this._typeNameTable.Length; ++index)
      {
        if (string.CompareOrdinal(this._typeNameTable[index], typeName) == 0)
          return index;
      }
      return -1;
    }

    private int LookupTypeIndexByType(Type type)
    {
      if (this._typeTable == null)
        this.InitTypeTables();
      for (int index = 0; index < this._typeTable.Length; ++index)
      {
        if (type == this._typeTable[index])
          return index;
      }
      return -1;
    }

    private object Activate_0_AdMediatorControl() => (object) new AdMediatorControl();

    private object Activate_3_AdSdkParameters() => (object) new AdSdkParameters();

    private void MapAdd_5_IDictionary(object instance, object key, object item)
    {
      IDictionary<string, TimeSpan> dictionary = (IDictionary<string, TimeSpan>) instance;
      string str = (string) key;
      TimeSpan timeSpan1 = (TimeSpan) item;
      string key1 = str;
      TimeSpan timeSpan2 = timeSpan1;
      dictionary.Add(key1, timeSpan2);
    }

    private IXamlType CreateXamlType(int typeIndex)
    {
      XamlSystemBaseType xamlType = (XamlSystemBaseType) null;
      string fullName = this._typeNameTable[typeIndex];
      Type type = this._typeTable[typeIndex];
      switch (typeIndex)
      {
        case 0:
          XamlUserType xamlUserType1 = new XamlUserType(this, fullName, type, this.GetXamlTypeByName("Windows.UI.Xaml.Controls.Control"));
          xamlUserType1.Activator = new Activator(this.Activate_0_AdMediatorControl);
          xamlUserType1.AddMemberName("Id");
          xamlUserType1.AddMemberName("AdSdkOptionalParameters");
          xamlUserType1.AddMemberName("AdSdkTimeouts");
          xamlUserType1.SetIsLocalType();
          xamlType = (XamlSystemBaseType) xamlUserType1;
          break;
        case 1:
          xamlType = new XamlSystemBaseType(fullName, type);
          break;
        case 2:
          xamlType = new XamlSystemBaseType(fullName, type);
          break;
        case 3:
          XamlUserType xamlUserType2 = new XamlUserType(this, fullName, type, this.GetXamlTypeByName("Object"));
          xamlUserType2.SetIsReturnTypeStub();
          xamlType = (XamlSystemBaseType) xamlUserType2;
          break;
        case 4:
          xamlType = new XamlSystemBaseType(fullName, type);
          break;
        case 5:
          XamlUserType xamlUserType3 = new XamlUserType(this, fullName, type, (IXamlType) null);
          xamlUserType3.DictionaryAdd = new AddToDictionary(this.MapAdd_5_IDictionary);
          xamlUserType3.SetIsReturnTypeStub();
          xamlType = (XamlSystemBaseType) xamlUserType3;
          break;
        case 6:
          XamlUserType xamlUserType4 = new XamlUserType(this, fullName, type, this.GetXamlTypeByName("System.ValueType"));
          xamlUserType4.AddMemberName("Days");
          xamlUserType4.AddMemberName("Hours");
          xamlUserType4.AddMemberName("Milliseconds");
          xamlUserType4.AddMemberName("Minutes");
          xamlUserType4.AddMemberName("Seconds");
          xamlUserType4.AddMemberName("Ticks");
          xamlUserType4.AddMemberName("TotalDays");
          xamlUserType4.AddMemberName("TotalHours");
          xamlUserType4.AddMemberName("TotalMilliseconds");
          xamlUserType4.AddMemberName("TotalMinutes");
          xamlUserType4.AddMemberName("TotalSeconds");
          xamlType = (XamlSystemBaseType) xamlUserType4;
          break;
        case 7:
          xamlType = (XamlSystemBaseType) new XamlUserType(this, fullName, type, this.GetXamlTypeByName("Object"));
          break;
        case 8:
          xamlType = new XamlSystemBaseType(fullName, type);
          break;
        case 9:
          xamlType = new XamlSystemBaseType(fullName, type);
          break;
        case 10:
          xamlType = new XamlSystemBaseType(fullName, type);
          break;
      }
      return (IXamlType) xamlType;
    }

    private object get_0_AdMediatorControl_Id(object instance) => (object) ((AdMediatorControl) instance).Id;

    private void set_0_AdMediatorControl_Id(object instance, object Value) => ((AdMediatorControl) instance).Id = (string) Value;

    private object get_1_AdMediatorControl_AdSdkOptionalParameters(object instance) => (object) ((AdMediatorControl) instance).AdSdkOptionalParameters;

    private object get_2_AdMediatorControl_AdSdkTimeouts(object instance) => (object) ((AdMediatorControl) instance).AdSdkTimeouts;

    private object get_3_TimeSpan_Days(object instance) => (object) ((TimeSpan) instance).Days;

    private object get_4_TimeSpan_Hours(object instance) => (object) ((TimeSpan) instance).Hours;

    private object get_5_TimeSpan_Milliseconds(object instance) => (object) ((TimeSpan) instance).Milliseconds;

    private object get_6_TimeSpan_Minutes(object instance) => (object) ((TimeSpan) instance).Minutes;

    private object get_7_TimeSpan_Seconds(object instance) => (object) ((TimeSpan) instance).Seconds;

    private object get_8_TimeSpan_Ticks(object instance) => (object) ((TimeSpan) instance).Ticks;

    private object get_9_TimeSpan_TotalDays(object instance) => (object) ((TimeSpan) instance).TotalDays;

    private object get_10_TimeSpan_TotalHours(object instance) => (object) ((TimeSpan) instance).TotalHours;

    private object get_11_TimeSpan_TotalMilliseconds(object instance) => (object) ((TimeSpan) instance).TotalMilliseconds;

    private object get_12_TimeSpan_TotalMinutes(object instance) => (object) ((TimeSpan) instance).TotalMinutes;

    private object get_13_TimeSpan_TotalSeconds(object instance) => (object) ((TimeSpan) instance).TotalSeconds;

    private IXamlMember CreateXamlMember(string longMemberName)
    {
      XamlMember xamlMember = (XamlMember) null;
      switch (longMemberName)
      {
        case "Microsoft.AdMediator.WindowsPhone81.AdMediatorControl.AdSdkOptionalParameters":
          XamlUserType xamlTypeByName1 = (XamlUserType) this.GetXamlTypeByName("Microsoft.AdMediator.WindowsPhone81.AdMediatorControl");
          xamlMember = new XamlMember(this, "AdSdkOptionalParameters", "Microsoft.AdMediator.Core.Models.AdSdkParameters");
          xamlMember.Getter = new Getter(this.get_1_AdMediatorControl_AdSdkOptionalParameters);
          xamlMember.SetIsReadOnly();
          break;
        case "Microsoft.AdMediator.WindowsPhone81.AdMediatorControl.AdSdkTimeouts":
          XamlUserType xamlTypeByName2 = (XamlUserType) this.GetXamlTypeByName("Microsoft.AdMediator.WindowsPhone81.AdMediatorControl");
          xamlMember = new XamlMember(this, "AdSdkTimeouts", "System.Collections.Generic.IDictionary`2<String, TimeSpan>");
          xamlMember.Getter = new Getter(this.get_2_AdMediatorControl_AdSdkTimeouts);
          xamlMember.SetIsReadOnly();
          break;
        case "Microsoft.AdMediator.WindowsPhone81.AdMediatorControl.Id":
          XamlUserType xamlTypeByName3 = (XamlUserType) this.GetXamlTypeByName("Microsoft.AdMediator.WindowsPhone81.AdMediatorControl");
          xamlMember = new XamlMember(this, "Id", "String");
          xamlMember.Getter = new Getter(this.get_0_AdMediatorControl_Id);
          xamlMember.Setter = new Setter(this.set_0_AdMediatorControl_Id);
          break;
        case "TimeSpan.Days":
          XamlUserType xamlTypeByName4 = (XamlUserType) this.GetXamlTypeByName("TimeSpan");
          xamlMember = new XamlMember(this, "Days", "Int32");
          xamlMember.Getter = new Getter(this.get_3_TimeSpan_Days);
          xamlMember.SetIsReadOnly();
          break;
        case "TimeSpan.Hours":
          XamlUserType xamlTypeByName5 = (XamlUserType) this.GetXamlTypeByName("TimeSpan");
          xamlMember = new XamlMember(this, "Hours", "Int32");
          xamlMember.Getter = new Getter(this.get_4_TimeSpan_Hours);
          xamlMember.SetIsReadOnly();
          break;
        case "TimeSpan.Milliseconds":
          XamlUserType xamlTypeByName6 = (XamlUserType) this.GetXamlTypeByName("TimeSpan");
          xamlMember = new XamlMember(this, "Milliseconds", "Int32");
          xamlMember.Getter = new Getter(this.get_5_TimeSpan_Milliseconds);
          xamlMember.SetIsReadOnly();
          break;
        case "TimeSpan.Minutes":
          XamlUserType xamlTypeByName7 = (XamlUserType) this.GetXamlTypeByName("TimeSpan");
          xamlMember = new XamlMember(this, "Minutes", "Int32");
          xamlMember.Getter = new Getter(this.get_6_TimeSpan_Minutes);
          xamlMember.SetIsReadOnly();
          break;
        case "TimeSpan.Seconds":
          XamlUserType xamlTypeByName8 = (XamlUserType) this.GetXamlTypeByName("TimeSpan");
          xamlMember = new XamlMember(this, "Seconds", "Int32");
          xamlMember.Getter = new Getter(this.get_7_TimeSpan_Seconds);
          xamlMember.SetIsReadOnly();
          break;
        case "TimeSpan.Ticks":
          XamlUserType xamlTypeByName9 = (XamlUserType) this.GetXamlTypeByName("TimeSpan");
          xamlMember = new XamlMember(this, "Ticks", "Int64");
          xamlMember.Getter = new Getter(this.get_8_TimeSpan_Ticks);
          xamlMember.SetIsReadOnly();
          break;
        case "TimeSpan.TotalDays":
          XamlUserType xamlTypeByName10 = (XamlUserType) this.GetXamlTypeByName("TimeSpan");
          xamlMember = new XamlMember(this, "TotalDays", "Double");
          xamlMember.Getter = new Getter(this.get_9_TimeSpan_TotalDays);
          xamlMember.SetIsReadOnly();
          break;
        case "TimeSpan.TotalHours":
          XamlUserType xamlTypeByName11 = (XamlUserType) this.GetXamlTypeByName("TimeSpan");
          xamlMember = new XamlMember(this, "TotalHours", "Double");
          xamlMember.Getter = new Getter(this.get_10_TimeSpan_TotalHours);
          xamlMember.SetIsReadOnly();
          break;
        case "TimeSpan.TotalMilliseconds":
          XamlUserType xamlTypeByName12 = (XamlUserType) this.GetXamlTypeByName("TimeSpan");
          xamlMember = new XamlMember(this, "TotalMilliseconds", "Double");
          xamlMember.Getter = new Getter(this.get_11_TimeSpan_TotalMilliseconds);
          xamlMember.SetIsReadOnly();
          break;
        case "TimeSpan.TotalMinutes":
          XamlUserType xamlTypeByName13 = (XamlUserType) this.GetXamlTypeByName("TimeSpan");
          xamlMember = new XamlMember(this, "TotalMinutes", "Double");
          xamlMember.Getter = new Getter(this.get_12_TimeSpan_TotalMinutes);
          xamlMember.SetIsReadOnly();
          break;
        case "TimeSpan.TotalSeconds":
          XamlUserType xamlTypeByName14 = (XamlUserType) this.GetXamlTypeByName("TimeSpan");
          xamlMember = new XamlMember(this, "TotalSeconds", "Double");
          xamlMember.Getter = new Getter(this.get_13_TimeSpan_TotalSeconds);
          xamlMember.SetIsReadOnly();
          break;
      }
      return (IXamlMember) xamlMember;
    }
  }
}
