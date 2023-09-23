// Decompiled with JetBrains decompiler
// Type: System.Runtime.InteropServices.RuntimeInformation
// Assembly: System.Runtime.InteropServices.RuntimeInformation, Version=4.0.1.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a
// MVID: 47FA4072-36BC-4A9B-B059-56DFEB5D596B
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\System.Runtime.InteropServices.RuntimeInformation.dll

using System.Reflection;

namespace System.Runtime.InteropServices
{
  public static class RuntimeInformation
  {
    private static string s_osDescription = (string) null;
    private static object s_osLock = new object();
    private static object s_processLock = new object();
    private static Architecture? s_osArch = new Architecture?();
    private static Architecture? s_processArch = new Architecture?();
    private const string FrameworkName = ".NET Core";
    private static string s_frameworkDescription;

    public static bool IsOSPlatform(OSPlatform osPlatform) => OSPlatform.Windows == osPlatform;

    public static string OSDescription
    {
      get
      {
        if (RuntimeInformation.s_osDescription == null)
          RuntimeInformation.s_osDescription = "Microsoft Windows Phone";
        return RuntimeInformation.s_osDescription;
      }
    }

    public static Architecture OSArchitecture
    {
      get
      {
        lock (RuntimeInformation.s_osLock)
        {
          if (!RuntimeInformation.s_osArch.HasValue)
          {
            Interop.mincore.SYSTEM_INFO lpSystemInfo;
            Interop.mincore.GetNativeSystemInfo(out lpSystemInfo);
            switch ((Interop.mincore.ProcessorArchitecture) lpSystemInfo.wProcessorArchitecture)
            {
              case Interop.mincore.ProcessorArchitecture.Processor_Architecture_INTEL:
                RuntimeInformation.s_osArch = new Architecture?(Architecture.X86);
                break;
              case Interop.mincore.ProcessorArchitecture.Processor_Architecture_ARM:
                RuntimeInformation.s_osArch = new Architecture?(Architecture.Arm);
                break;
              case Interop.mincore.ProcessorArchitecture.Processor_Architecture_AMD64:
                RuntimeInformation.s_osArch = new Architecture?(Architecture.X64);
                break;
              case Interop.mincore.ProcessorArchitecture.Processor_Architecture_ARM64:
                RuntimeInformation.s_osArch = new Architecture?(Architecture.Arm64);
                break;
            }
          }
        }
        return RuntimeInformation.s_osArch.Value;
      }
    }

    public static Architecture ProcessArchitecture
    {
      get
      {
        lock (RuntimeInformation.s_processLock)
        {
          if (!RuntimeInformation.s_processArch.HasValue)
          {
            Interop.mincore.SYSTEM_INFO lpSystemInfo;
            Interop.mincore.GetNativeSystemInfo(out lpSystemInfo);
            switch ((Interop.mincore.ProcessorArchitecture) lpSystemInfo.wProcessorArchitecture)
            {
              case Interop.mincore.ProcessorArchitecture.Processor_Architecture_INTEL:
                RuntimeInformation.s_processArch = new Architecture?(Architecture.X86);
                break;
              case Interop.mincore.ProcessorArchitecture.Processor_Architecture_ARM:
                RuntimeInformation.s_processArch = new Architecture?(Architecture.Arm);
                break;
              case Interop.mincore.ProcessorArchitecture.Processor_Architecture_AMD64:
                RuntimeInformation.s_processArch = new Architecture?(Architecture.X64);
                if (IntPtr.Size == 4)
                {
                  RuntimeInformation.s_processArch = new Architecture?(Architecture.X86);
                  break;
                }
                break;
              case Interop.mincore.ProcessorArchitecture.Processor_Architecture_ARM64:
                RuntimeInformation.s_processArch = new Architecture?(Architecture.Arm64);
                break;
            }
          }
        }
        return RuntimeInformation.s_processArch.Value;
      }
    }

    public static string FrameworkDescription
    {
      get
      {
        if (RuntimeInformation.s_frameworkDescription == null)
          RuntimeInformation.s_frameworkDescription = string.Format("{0} {1}", new object[2]
          {
            (object) ".NET Core",
            (object) ((AssemblyFileVersionAttribute) typeof (object).GetTypeInfo().Assembly.GetCustomAttribute(typeof (AssemblyFileVersionAttribute))).Version
          });
        return RuntimeInformation.s_frameworkDescription;
      }
    }
  }
}
