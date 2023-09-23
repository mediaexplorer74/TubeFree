// Decompiled with JetBrains decompiler
// Type: AngleSharp.Dom.Events.ModifierExtensions
// Assembly: AngleSharp, Version=0.9.9.0, Culture=neutral, PublicKeyToken=e83494dcdc6d31ea
// MVID: 6D8FC1AC-F585-421F-BEC1-9105A73220DF
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\AngleSharp.dll

namespace AngleSharp.Dom.Events
{
  internal static class ModifierExtensions
  {
    public static bool IsCtrlPressed(this string modifierList) => false;

    public static bool IsMetaPressed(this string modifierList) => false;

    public static bool IsShiftPressed(this string modifierList) => false;

    public static bool IsAltPressed(this string modifierList) => false;

    public static bool ContainsKey(this string modifierList, string key) => modifierList.Contains(key);
  }
}
