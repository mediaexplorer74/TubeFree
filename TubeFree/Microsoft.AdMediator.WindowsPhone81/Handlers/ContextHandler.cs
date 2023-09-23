// Decompiled with JetBrains decompiler
// Type: Microsoft.AdMediator.WindowsPhone81.Handlers.ContextHandler
// Assembly: Microsoft.AdMediator.WindowsPhone81, Version=2.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1C586D37-9142-43D0-8912-08FBC7AC3DDA
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\Microsoft.AdMediator.WindowsPhone81.dll

using Microsoft.AdMediator.Core.Handlers;
using System;
using System.Linq;
using System.Reflection;
using System.Runtime.Versioning;
using Windows.ApplicationModel.Store;
using Windows.Globalization;
using Windows.Security.ExchangeActiveSyncProvisioning;

namespace Microsoft.AdMediator.WindowsPhone81.Handlers
{
  internal class ContextHandler : IContextHandler
  {
    private readonly EasClientDeviceInformation deviceInfo;

    internal ContextHandler() => this.deviceInfo = new EasClientDeviceInformation();

    public string DeviceName => this.deviceInfo.SystemProductName;

    public string DeviceManufacturer => this.deviceInfo.SystemManufacturer;

    public string OsVersion => this.deviceInfo.OperatingSystem;

    public string Market => new GeographicRegion().CodeTwoLetter;

    public string ApplicationId
    {
      get
      {
        try
        {
          return CurrentApp.AppId.ToString();
        }
        catch (Exception ex)
        {
          return string.Empty;
        }
      }
    }

    public string Framework => ContextHandler.GetFramework();

    public bool IsTestMode => string.Equals(this.deviceInfo.SystemSku, "Microsoft Virtual") || string.Equals(this.deviceInfo.SystemProductName, "Virtual");

    private static string GetFramework() => Enumerable.First<Attribute>(CustomAttributeExtensions.GetCustomAttributes(IntrospectionExtensions.GetTypeInfo(typeof (ContextHandler)).Assembly, typeof (TargetFrameworkAttribute))) is TargetFrameworkAttribute frameworkAttribute ? frameworkAttribute.FrameworkName : string.Empty;
  }
}
