// Decompiled with JetBrains decompiler
// Type: System.SR
// Assembly: System.Runtime.InteropServices.RuntimeInformation, Version=4.0.1.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a
// MVID: 47FA4072-36BC-4A9B-B059-56DFEB5D596B
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\System.Runtime.InteropServices.RuntimeInformation.dll

using System.Resources;
using System.Runtime.CompilerServices;

namespace System
{
  internal static class SR
  {
    private static ResourceManager s_resourceManager;
    private const string s_resourcesName = "FxResources.System.Runtime.InteropServices.RuntimeInformation.SR";

    private static ResourceManager ResourceManager
    {
      get
      {
        if (SR.s_resourceManager == null)
          SR.s_resourceManager = new ResourceManager(SR.ResourceType);
        return SR.s_resourceManager;
      }
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    private static bool UsingResourceKeys() => false;

    internal static string GetResourceString(string resourceKey, string defaultString)
    {
      string str = (string) null;
      try
      {
        str = SR.ResourceManager.GetString(resourceKey);
      }
      catch (MissingManifestResourceException ex)
      {
      }
      return defaultString != null && resourceKey.Equals(str, StringComparison.Ordinal) ? defaultString : str;
    }

    internal static string Format(string resourceFormat, params object[] args)
    {
      if (args == null)
        return resourceFormat;
      return SR.UsingResourceKeys() ? resourceFormat + string.Join(", ", args) : string.Format(resourceFormat, args);
    }

    internal static string Format(string resourceFormat, object p1) => SR.UsingResourceKeys() ? string.Join(", ", (object) resourceFormat, p1) : string.Format(resourceFormat, new object[1]
    {
      p1
    });

    internal static string Format(string resourceFormat, object p1, object p2) => SR.UsingResourceKeys() ? string.Join(", ", (object) resourceFormat, p1, p2) : string.Format(resourceFormat, new object[2]
    {
      p1,
      p2
    });

    internal static string Format(string resourceFormat, object p1, object p2, object p3) => SR.UsingResourceKeys() ? string.Join(", ", (object) resourceFormat, p1, p2, p3) : string.Format(resourceFormat, new object[3]
    {
      p1,
      p2,
      p3
    });

    internal static string Argument_EmptyValue => SR.GetResourceString(nameof (Argument_EmptyValue), (string) null);

    internal static Type ResourceType => typeof (FxResources.System.Runtime.InteropServices.RuntimeInformation.SR);
  }
}
