// Decompiled with JetBrains decompiler
// Type: TubeFree8_1.Program
// Assembly: TubeFree8-1, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B4DCF786-D976-4451-B6A4-B664A1A9ABDC
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\TubeFree8-1.exe

using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using Windows.UI.Xaml;

namespace TubeFree8_1
{
  public class Program
  {
    [MTAThread]
    [GeneratedCode("Microsoft.Windows.UI.Xaml.Build.Tasks", "4.0.0.0")]
    [DebuggerNonUserCode]
    public static void Main(string[] args)
    {
      ApplicationInitializationCallback initializationCallback;
      // ISSUE: reference to a compiler-generated field
      if (TubeFree8_1.Program._Closure\u0024__.\u0024IR1\u002D1 != null)
      {
        // ISSUE: reference to a compiler-generated field
        initializationCallback = TubeFree8_1.Program._Closure\u0024__.\u0024IR1\u002D1;
      }
      else
      {
        // ISSUE: reference to a compiler-generated field
        TubeFree8_1.Program._Closure\u0024__.\u0024IR1\u002D1 = initializationCallback = (ApplicationInitializationCallback) (a0 =>
        {
          // ISSUE: variable of a compiler-generated type
          VB\u0024AnonymousDelegate_0<ApplicationInitializationCallbackParams, App> anonymousDelegate0;
          // ISSUE: reference to a compiler-generated field
          if (TubeFree8_1.Program._Closure\u0024__.\u0024I1\u002D0 != null)
          {
            // ISSUE: reference to a compiler-generated field
            anonymousDelegate0 = TubeFree8_1.Program._Closure\u0024__.\u0024I1\u002D0;
          }
          else
          {
            // ISSUE: reference to a compiler-generated field
            TubeFree8_1.Program._Closure\u0024__.\u0024I1\u002D0 = anonymousDelegate0 = (VB\u0024AnonymousDelegate_0<ApplicationInitializationCallbackParams, App>) (p => new App());
          }
          App app = anonymousDelegate0(a0);
        });
      }
      Application.Start(initializationCallback);
    }

    [GeneratedCode("Microsoft.Windows.UI.Xaml.Build.Tasks", "4.0.0.0")]
    [DebuggerNonUserCode]
    public void Program()
    {
    }
  }
}
