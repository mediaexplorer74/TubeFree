// Decompiled with JetBrains decompiler
// Type: TubeFree8_1.TubeFree8_1_XamlTypeInfo.XamlTypeInfoProvider
// Assembly: TubeFree8-1, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B4DCF786-D976-4451-B6A4-B664A1A9ABDC
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\TubeFree8-1.exe

using Microsoft.VisualBasic.CompilerServices;
using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Diagnostics;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Markup;

namespace TubeFree8_1.TubeFree8_1_XamlTypeInfo
{
  [GeneratedCode("Microsoft.Windows.UI.Xaml.Build.Tasks", "4.0.0.0")]
  [DebuggerNonUserCode]
  internal class XamlTypeInfoProvider
  {
    private Dictionary<string, IXamlType> _xamlTypeCacheByName;
    private Dictionary<Type, IXamlType> _xamlTypeCacheByType;
    private Dictionary<string, IXamlMember> _xamlMembers;
    private string[] _typeNameTable;
    private Type[] _typeTable;
    private List<IXamlMetadataProvider> _otherProviders;

    public XamlTypeInfoProvider()
    {
      this._xamlTypeCacheByName = new Dictionary<string, IXamlType>();
      this._xamlTypeCacheByType = new Dictionary<Type, IXamlType>();
      this._xamlMembers = new Dictionary<string, IXamlMember>();
      this._typeNameTable = new string[12];
      this._typeTable = new Type[12];
    }

    public IXamlType GetXamlTypeByType(Type type)
    {
      IXamlType ixamlType1 = (IXamlType) null;
      IXamlType xamlTypeByType;
      if (this._xamlTypeCacheByType.TryGetValue(type, out ixamlType1))
      {
        xamlTypeByType = ixamlType1;
      }
      else
      {
        int typeIndex = this.LookupTypeIndexByType(type);
        if (typeIndex != -1)
          ixamlType1 = this.CreateXamlType(typeIndex);
        XamlUserType xamlUserType = ixamlType1 as XamlUserType;
        if (((ixamlType1 == null ? 1 : 0) | (xamlUserType == null || !xamlUserType.IsReturnTypeStub ? 0 : (!xamlUserType.IsLocalType ? 1 : 0))) != 0)
        {
          IXamlType ixamlType2 = this.CheckOtherMetadataProvidersForType(type);
          if (ixamlType2 != null && ixamlType2.IsConstructible | ixamlType1 == null)
            ixamlType1 = ixamlType2;
        }
        if (ixamlType1 != null)
        {
          this._xamlTypeCacheByName.Add(ixamlType1.FullName, ixamlType1);
          this._xamlTypeCacheByType.Add(ixamlType1.UnderlyingType, ixamlType1);
        }
        xamlTypeByType = ixamlType1;
      }
      return xamlTypeByType;
    }

    public IXamlType GetXamlTypeByName(string typeName)
    {
      IXamlType xamlTypeByName;
      if (string.IsNullOrEmpty(typeName))
      {
        xamlTypeByName = (IXamlType) null;
      }
      else
      {
        IXamlType ixamlType1 = (IXamlType) null;
        if (this._xamlTypeCacheByName.TryGetValue(typeName, out ixamlType1))
        {
          xamlTypeByName = ixamlType1;
        }
        else
        {
          int typeIndex = this.LookupTypeIndexByName(typeName);
          if (typeIndex != -1)
            ixamlType1 = this.CreateXamlType(typeIndex);
          XamlUserType xamlUserType = ixamlType1 as XamlUserType;
          if (((ixamlType1 == null ? 1 : 0) | (xamlUserType == null || !xamlUserType.IsReturnTypeStub ? 0 : (!xamlUserType.IsLocalType ? 1 : 0))) != 0)
          {
            IXamlType ixamlType2 = this.CheckOtherMetadataProvidersForName(typeName);
            if (ixamlType2 != null && ixamlType2.IsConstructible | ixamlType1 == null)
              ixamlType1 = ixamlType2;
          }
          if (ixamlType1 != null)
          {
            this._xamlTypeCacheByName.Add(ixamlType1.FullName, ixamlType1);
            this._xamlTypeCacheByType.Add(ixamlType1.UnderlyingType, ixamlType1);
          }
          xamlTypeByName = ixamlType1;
        }
      }
      return xamlTypeByName;
    }

    public IXamlMember GetMemberByLongName(string longMemberName)
    {
      IXamlMember memberByLongName;
      if (string.IsNullOrEmpty(longMemberName))
      {
        memberByLongName = (IXamlMember) null;
      }
      else
      {
        IXamlMember ixamlMember = (IXamlMember) null;
        if (this._xamlMembers.TryGetValue(longMemberName, out ixamlMember))
        {
          memberByLongName = ixamlMember;
        }
        else
        {
          ixamlMember = (IXamlMember) this.CreateXamlMember(longMemberName);
          if (ixamlMember != null)
            this._xamlMembers.Add(longMemberName, ixamlMember);
          memberByLongName = ixamlMember;
        }
      }
      return memberByLongName;
    }

    private void InitTypeTables()
    {
      this._typeNameTable[0] = "TubeFree8_1.VideoQ";
      this._typeNameTable[1] = "Windows.UI.Xaml.Controls.UserControl";
      this._typeNameTable[2] = "String";
      this._typeNameTable[3] = "Windows.UI.Xaml.Controls.TextBlock";
      this._typeNameTable[4] = "Windows.UI.Xaml.Controls.Image";
      this._typeNameTable[5] = "Windows.UI.Xaml.Controls.ComboBox";
      this._typeNameTable[6] = "TubeFree8_1.MainPage";
      this._typeNameTable[7] = "Windows.UI.Xaml.Controls.Page";
      this._typeNameTable[8] = "Windows.UI.Xaml.Controls.Frame";
      this._typeNameTable[9] = "TubeFree8_1.PageDownload";
      this._typeNameTable[10] = "TubeFree8_1.Home";
      this._typeNameTable[11] = "TubeFree8_1.Settings";
      this._typeTable[0] = typeof (VideoQ);
      this._typeTable[1] = typeof (UserControl);
      this._typeTable[2] = typeof (string);
      this._typeTable[3] = typeof (TextBlock);
      this._typeTable[4] = typeof (Image);
      this._typeTable[5] = typeof (ComboBox);
      this._typeTable[6] = typeof (MainPage);
      this._typeTable[7] = typeof (Page);
      this._typeTable[8] = typeof (Frame);
      this._typeTable[9] = typeof (PageDownload);
      this._typeTable[10] = typeof (Home);
      this._typeTable[11] = typeof (Settings);
    }

    private int LookupTypeIndexByName(string typeName)
    {
      if (this._typeNameTable[0] == null)
        this.InitTypeTables();
      int num1 = checked (this._typeNameTable.Length - 1);
      int index = 0;
      int num2;
      while (index <= num1)
      {
        if (string.CompareOrdinal(this._typeNameTable[index], typeName) == 0)
        {
          num2 = index;
          goto label_8;
        }
        else
          checked { ++index; }
      }
      num2 = -1;
label_8:
      return num2;
    }

    private int LookupTypeIndexByType(Type type)
    {
      if (this._typeTable[0] == null)
        this.InitTypeTables();
      int num1 = checked (this._typeTable.Length - 1);
      int index = 0;
      int num2;
      while (index <= num1)
      {
        if (object.Equals((object) type, (object) this._typeTable[index]))
        {
          num2 = index;
          goto label_8;
        }
        else
          checked { ++index; }
      }
      num2 = -1;
label_8:
      return num2;
    }

    private object Activate_0_VideoQ() => (object) new VideoQ();

    private object Activate_6_MainPage() => (object) new MainPage();

    private object Activate_9_PageDownload() => (object) new PageDownload();

    private object Activate_10_Home() => (object) new Home();

    private object Activate_11_Settings() => (object) new Settings();

    private IXamlType CreateXamlType(int typeIndex)
    {
      XamlSystemBaseType xamlType = (XamlSystemBaseType) null;
      string fullName = this._typeNameTable[typeIndex];
      Type type = this._typeTable[typeIndex];
      switch (typeIndex)
      {
        case 0:
          XamlUserType xamlUserType1 = new XamlUserType(this, fullName, type, this.GetXamlTypeByName("Windows.UI.Xaml.Controls.UserControl"));
          xamlUserType1.Activator = new Activator(this.Activate_0_VideoQ);
          xamlUserType1.AddMemberName("UrlImage");
          xamlUserType1.AddMemberName("title");
          xamlUserType1.AddMemberName("thumb");
          xamlUserType1.AddMemberName("listPickerQuality");
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
          xamlType = new XamlSystemBaseType(fullName, type);
          break;
        case 4:
          xamlType = new XamlSystemBaseType(fullName, type);
          break;
        case 5:
          xamlType = new XamlSystemBaseType(fullName, type);
          break;
        case 6:
          XamlUserType xamlUserType2 = new XamlUserType(this, fullName, type, this.GetXamlTypeByName("Windows.UI.Xaml.Controls.Page"));
          xamlUserType2.Activator = new Activator(this.Activate_6_MainPage);
          xamlUserType2.AddMemberName("myFrame");
          xamlUserType2.SetIsLocalType();
          xamlType = (XamlSystemBaseType) xamlUserType2;
          break;
        case 7:
          xamlType = new XamlSystemBaseType(fullName, type);
          break;
        case 8:
          xamlType = new XamlSystemBaseType(fullName, type);
          break;
        case 9:
          XamlUserType xamlUserType3 = new XamlUserType(this, fullName, type, this.GetXamlTypeByName("Windows.UI.Xaml.Controls.Page"));
          xamlUserType3.Activator = new Activator(this.Activate_9_PageDownload);
          xamlUserType3.SetIsLocalType();
          xamlType = (XamlSystemBaseType) xamlUserType3;
          break;
        case 10:
          XamlUserType xamlUserType4 = new XamlUserType(this, fullName, type, this.GetXamlTypeByName("Windows.UI.Xaml.Controls.Page"));
          xamlUserType4.Activator = new Activator(this.Activate_10_Home);
          xamlUserType4.AddMemberName("ctrlQ");
          xamlUserType4.SetIsLocalType();
          xamlType = (XamlSystemBaseType) xamlUserType4;
          break;
        case 11:
          XamlUserType xamlUserType5 = new XamlUserType(this, fullName, type, this.GetXamlTypeByName("Windows.UI.Xaml.Controls.Page"));
          xamlUserType5.Activator = new Activator(this.Activate_11_Settings);
          xamlUserType5.SetIsLocalType();
          xamlType = (XamlSystemBaseType) xamlUserType5;
          break;
      }
      return (IXamlType) xamlType;
    }

    private List<IXamlMetadataProvider> OtherProviders
    {
      get
      {
        if (this._otherProviders == null)
        {
          this._otherProviders = new List<IXamlMetadataProvider>();
          this._otherProviders.Add((IXamlMetadataProvider) new Microsoft.AdMediator.WindowsPhone81.AdMediator_WindowsPhone81_XamlTypeInfo.XamlMetaDataProvider());
          this._otherProviders.Add((IXamlMetadataProvider) new Microsoft.Advertising.UniversalXamlAdControl_WindowsPhone_XamlTypeInfo.XamlMetaDataProvider());
        }
        return this._otherProviders;
      }
    }

    private IXamlType CheckOtherMetadataProvidersForName(string typeName)
    {
      IXamlType ixamlType1 = (IXamlType) null;
      IXamlType ixamlType2;
      try
      {
        foreach (IXamlMetadataProvider otherProvider in this.OtherProviders)
        {
          IXamlType xamlType = otherProvider.GetXamlType(typeName);
          if (xamlType != null)
          {
            if (xamlType.IsConstructible)
            {
              ixamlType2 = xamlType;
              goto label_9;
            }
            else
              ixamlType1 = xamlType;
          }
        }
      }
      finally
      {
        List<IXamlMetadataProvider>.Enumerator enumerator;
        enumerator.Dispose();
      }
      ixamlType2 = ixamlType1;
label_9:
      return ixamlType2;
    }

    private IXamlType CheckOtherMetadataProvidersForType(Type type)
    {
      IXamlType ixamlType1 = (IXamlType) null;
      IXamlType ixamlType2;
      try
      {
        foreach (IXamlMetadataProvider otherProvider in this.OtherProviders)
        {
          IXamlType xamlType = otherProvider.GetXamlType(type);
          if (xamlType != null)
          {
            if (xamlType.IsConstructible)
            {
              ixamlType2 = xamlType;
              goto label_9;
            }
            else
              ixamlType1 = xamlType;
          }
        }
      }
      finally
      {
        List<IXamlMetadataProvider>.Enumerator enumerator;
        enumerator.Dispose();
      }
      ixamlType2 = ixamlType1;
label_9:
      return ixamlType2;
    }

    private object get_0_VideoQ_UrlImage(object instance) => (object) ((VideoQ) instance).UrlImage;

    private void set_0_VideoQ_UrlImage(object instance, object Value) => ((VideoQ) instance).UrlImage = Conversions.ToString(Value);

    private object get_1_VideoQ_title(object instance) => (object) ((VideoQ) instance).title;

    private void set_1_VideoQ_title(object instance, object Value) => ((VideoQ) instance).title = (TextBlock) Value;

    private object get_2_VideoQ_thumb(object instance) => (object) ((VideoQ) instance).thumb;

    private void set_2_VideoQ_thumb(object instance, object Value) => ((VideoQ) instance).thumb = (Image) Value;

    private object get_3_VideoQ_listPickerQuality(object instance) => (object) ((VideoQ) instance).listPickerQuality;

    private void set_3_VideoQ_listPickerQuality(object instance, object Value) => ((VideoQ) instance).listPickerQuality = (ComboBox) Value;

    private object get_4_MainPage_myFrame(object instance) => (object) ((MainPage) instance).myFrame;

    private void set_4_MainPage_myFrame(object instance, object Value) => ((MainPage) instance).myFrame = (Frame) Value;

    private object get_5_Home_ctrlQ(object instance) => (object) ((Home) instance).ctrlQ;

    private void set_5_Home_ctrlQ(object instance, object Value) => ((Home) instance).ctrlQ = (VideoQ) Value;

    private XamlMember CreateXamlMember(string longMemberName)
    {
      XamlMember xamlMember = (XamlMember) null;
      string Left = longMemberName;
      if (Operators.CompareString(Left, "TubeFree8_1.VideoQ.UrlImage", false) != 0)
      {
        if (Operators.CompareString(Left, "TubeFree8_1.VideoQ.title", false) != 0)
        {
          if (Operators.CompareString(Left, "TubeFree8_1.VideoQ.thumb", false) != 0)
          {
            if (Operators.CompareString(Left, "TubeFree8_1.VideoQ.listPickerQuality", false) != 0)
            {
              if (Operators.CompareString(Left, "TubeFree8_1.MainPage.myFrame", false) != 0)
              {
                if (Operators.CompareString(Left, "TubeFree8_1.Home.ctrlQ", false) == 0)
                {
                  XamlUserType xamlTypeByName = (XamlUserType) this.GetXamlTypeByName("TubeFree8_1.Home");
                  xamlMember = new XamlMember(this, "ctrlQ", "TubeFree8_1.VideoQ");
                  xamlMember.Getter = new Getter(this.get_5_Home_ctrlQ);
                  xamlMember.Setter = new Setter(this.set_5_Home_ctrlQ);
                }
              }
              else
              {
                XamlUserType xamlTypeByName = (XamlUserType) this.GetXamlTypeByName("TubeFree8_1.MainPage");
                xamlMember = new XamlMember(this, "myFrame", "Windows.UI.Xaml.Controls.Frame");
                xamlMember.Getter = new Getter(this.get_4_MainPage_myFrame);
                xamlMember.Setter = new Setter(this.set_4_MainPage_myFrame);
              }
            }
            else
            {
              XamlUserType xamlTypeByName = (XamlUserType) this.GetXamlTypeByName("TubeFree8_1.VideoQ");
              xamlMember = new XamlMember(this, "listPickerQuality", "Windows.UI.Xaml.Controls.ComboBox");
              xamlMember.Getter = new Getter(this.get_3_VideoQ_listPickerQuality);
              xamlMember.Setter = new Setter(this.set_3_VideoQ_listPickerQuality);
            }
          }
          else
          {
            XamlUserType xamlTypeByName = (XamlUserType) this.GetXamlTypeByName("TubeFree8_1.VideoQ");
            xamlMember = new XamlMember(this, "thumb", "Windows.UI.Xaml.Controls.Image");
            xamlMember.Getter = new Getter(this.get_2_VideoQ_thumb);
            xamlMember.Setter = new Setter(this.set_2_VideoQ_thumb);
          }
        }
        else
        {
          XamlUserType xamlTypeByName = (XamlUserType) this.GetXamlTypeByName("TubeFree8_1.VideoQ");
          xamlMember = new XamlMember(this, "title", "Windows.UI.Xaml.Controls.TextBlock");
          xamlMember.Getter = new Getter(this.get_1_VideoQ_title);
          xamlMember.Setter = new Setter(this.set_1_VideoQ_title);
        }
      }
      else
      {
        XamlUserType xamlTypeByName = (XamlUserType) this.GetXamlTypeByName("TubeFree8_1.VideoQ");
        xamlMember = new XamlMember(this, "UrlImage", "String");
        xamlMember.Getter = new Getter(this.get_0_VideoQ_UrlImage);
        xamlMember.Setter = new Setter(this.set_0_VideoQ_UrlImage);
      }
      return xamlMember;
    }
  }
}
