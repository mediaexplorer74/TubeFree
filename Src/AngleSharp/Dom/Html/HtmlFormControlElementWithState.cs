// Decompiled with JetBrains decompiler
// Type: AngleSharp.Dom.Html.HtmlFormControlElementWithState
// Assembly: AngleSharp, Version=0.9.9.0, Culture=neutral, PublicKeyToken=e83494dcdc6d31ea
// MVID: 6D8FC1AC-F585-421F-BEC1-9105A73220DF
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\AngleSharp.dll

using AngleSharp.Html;

namespace AngleSharp.Dom.Html
{
  internal abstract class HtmlFormControlElementWithState : HtmlFormControlElement
  {
    public HtmlFormControlElementWithState(
      Document owner,
      string name,
      string prefix,
      NodeFlags flags = NodeFlags.None)
      : base(owner, name, prefix, flags)
    {
      this.CanContainRangeEndpoint = false;
    }

    internal bool CanContainRangeEndpoint { get; private set; }

    internal bool ShouldSaveAndRestoreFormControlState { get; private set; }

    internal abstract FormControlState SaveControlState();

    internal abstract void RestoreFormControlState(FormControlState state);
  }
}
