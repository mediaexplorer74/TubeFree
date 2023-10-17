// Decompiled with JetBrains decompiler
// Type: AngleSharp.Dom.Html.HtmlElement
// Assembly: AngleSharp, Version=0.9.9.0, Culture=neutral, PublicKeyToken=e83494dcdc6d31ea
// MVID: 6D8FC1AC-F585-421F-BEC1-9105A73220DF
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\AngleSharp.dll

using AngleSharp.Dom.Collections;
using AngleSharp.Dom.Css;
using AngleSharp.Dom.Events;
using AngleSharp.Extensions;
using AngleSharp.Html;
using AngleSharp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AngleSharp.Dom.Html
{
  internal class HtmlElement : 
    Element,
    IHtmlElement,
    IElement,
    INode,
    IEventTarget,
    IMarkupFormattable,
    IParentNode,
    IChildNode,
    INonDocumentTypeChildNode,
    IElementCssInlineStyle,
    IGlobalEventHandlers
  {
    private StringMap _dataset;
    private IHtmlMenuElement _menu;
    private SettableTokenList _dropZone;

    public event DomEventHandler Aborted
    {
      add => this.AddEventListener(EventNames.Abort, value, false);
      remove => this.RemoveEventListener(EventNames.Abort, value, false);
    }

    public event DomEventHandler Blurred
    {
      add => this.AddEventListener(EventNames.Blur, value, false);
      remove => this.RemoveEventListener(EventNames.Blur, value, false);
    }

    public event DomEventHandler Cancelled
    {
      add => this.AddEventListener(EventNames.Cancel, value, false);
      remove => this.RemoveEventListener(EventNames.Cancel, value, false);
    }

    public event DomEventHandler CanPlay
    {
      add => this.AddEventListener(EventNames.CanPlay, value, false);
      remove => this.RemoveEventListener(EventNames.CanPlay, value, false);
    }

    public event DomEventHandler CanPlayThrough
    {
      add => this.AddEventListener(EventNames.CanPlayThrough, value, false);
      remove => this.RemoveEventListener(EventNames.CanPlayThrough, value, false);
    }

    public event DomEventHandler Changed
    {
      add => this.AddEventListener(EventNames.Change, value, false);
      remove => this.RemoveEventListener(EventNames.Change, value, false);
    }

    public event DomEventHandler Clicked
    {
      add => this.AddEventListener(EventNames.Click, value, false);
      remove => this.RemoveEventListener(EventNames.Click, value, false);
    }

    public event DomEventHandler CueChanged
    {
      add => this.AddEventListener(EventNames.CueChange, value, false);
      remove => this.RemoveEventListener(EventNames.CueChange, value, false);
    }

    public event DomEventHandler DoubleClick
    {
      add => this.AddEventListener(EventNames.DblClick, value, false);
      remove => this.RemoveEventListener(EventNames.DblClick, value, false);
    }

    public event DomEventHandler Drag
    {
      add => this.AddEventListener(EventNames.Drag, value, false);
      remove => this.RemoveEventListener(EventNames.Drag, value, false);
    }

    public event DomEventHandler DragEnd
    {
      add => this.AddEventListener(EventNames.DragEnd, value, false);
      remove => this.RemoveEventListener(EventNames.DragEnd, value, false);
    }

    public event DomEventHandler DragEnter
    {
      add => this.AddEventListener(EventNames.DragEnter, value, false);
      remove => this.RemoveEventListener(EventNames.DragEnter, value, false);
    }

    public event DomEventHandler DragExit
    {
      add => this.AddEventListener(EventNames.DragExit, value, false);
      remove => this.RemoveEventListener(EventNames.DragExit, value, false);
    }

    public event DomEventHandler DragLeave
    {
      add => this.AddEventListener(EventNames.DragLeave, value, false);
      remove => this.RemoveEventListener(EventNames.DragLeave, value, false);
    }

    public event DomEventHandler DragOver
    {
      add => this.AddEventListener(EventNames.DragOver, value, false);
      remove => this.RemoveEventListener(EventNames.DragOver, value, false);
    }

    public event DomEventHandler DragStart
    {
      add => this.AddEventListener(EventNames.DragStart, value, false);
      remove => this.RemoveEventListener(EventNames.DragStart, value, false);
    }

    public event DomEventHandler Dropped
    {
      add => this.AddEventListener(EventNames.Drop, value, false);
      remove => this.RemoveEventListener(EventNames.Drop, value, false);
    }

    public event DomEventHandler DurationChanged
    {
      add => this.AddEventListener(EventNames.DurationChange, value, false);
      remove => this.RemoveEventListener(EventNames.DurationChange, value, false);
    }

    public event DomEventHandler Emptied
    {
      add => this.AddEventListener(EventNames.Emptied, value, false);
      remove => this.RemoveEventListener(EventNames.Emptied, value, false);
    }

    public event DomEventHandler Ended
    {
      add => this.AddEventListener(EventNames.Ended, value, false);
      remove => this.RemoveEventListener(EventNames.Ended, value, false);
    }

    public event DomEventHandler Error
    {
      add => this.AddEventListener(EventNames.Error, value, false);
      remove => this.RemoveEventListener(EventNames.Error, value, false);
    }

    public event DomEventHandler Focused
    {
      add => this.AddEventListener(EventNames.Focus, value, false);
      remove => this.RemoveEventListener(EventNames.Focus, value, false);
    }

    public event DomEventHandler Input
    {
      add => this.AddEventListener(EventNames.Input, value, false);
      remove => this.RemoveEventListener(EventNames.Input, value, false);
    }

    public event DomEventHandler Invalid
    {
      add => this.AddEventListener(EventNames.Invalid, value, false);
      remove => this.RemoveEventListener(EventNames.Invalid, value, false);
    }

    public event DomEventHandler KeyDown
    {
      add => this.AddEventListener(EventNames.Keydown, value, false);
      remove => this.RemoveEventListener(EventNames.Keydown, value, false);
    }

    public event DomEventHandler KeyPress
    {
      add => this.AddEventListener(EventNames.Keypress, value, false);
      remove => this.RemoveEventListener(EventNames.Keypress, value, false);
    }

    public event DomEventHandler KeyUp
    {
      add => this.AddEventListener(EventNames.Keyup, value, false);
      remove => this.RemoveEventListener(EventNames.Keyup, value, false);
    }

    public event DomEventHandler Loaded
    {
      add => this.AddEventListener(EventNames.Load, value, false);
      remove => this.RemoveEventListener(EventNames.Load, value, false);
    }

    public event DomEventHandler LoadedData
    {
      add => this.AddEventListener(EventNames.LoadedData, value, false);
      remove => this.RemoveEventListener(EventNames.LoadedData, value, false);
    }

    public event DomEventHandler LoadedMetadata
    {
      add => this.AddEventListener(EventNames.LoadedMetaData, value, false);
      remove => this.RemoveEventListener(EventNames.LoadedMetaData, value, false);
    }

    public event DomEventHandler Loading
    {
      add => this.AddEventListener(EventNames.LoadStart, value, false);
      remove => this.RemoveEventListener(EventNames.LoadStart, value, false);
    }

    public event DomEventHandler MouseDown
    {
      add => this.AddEventListener(EventNames.Mousedown, value, false);
      remove => this.RemoveEventListener(EventNames.Mousedown, value, false);
    }

    public event DomEventHandler MouseEnter
    {
      add => this.AddEventListener(EventNames.Mouseenter, value, false);
      remove => this.RemoveEventListener(EventNames.Mouseenter, value, false);
    }

    public event DomEventHandler MouseLeave
    {
      add => this.AddEventListener(EventNames.Mouseleave, value, false);
      remove => this.RemoveEventListener(EventNames.Mouseleave, value, false);
    }

    public event DomEventHandler MouseMove
    {
      add => this.AddEventListener(EventNames.Mousemove, value, false);
      remove => this.RemoveEventListener(EventNames.Mousemove, value, false);
    }

    public event DomEventHandler MouseOut
    {
      add => this.AddEventListener(EventNames.Mouseout, value, false);
      remove => this.RemoveEventListener(EventNames.Mouseout, value, false);
    }

    public event DomEventHandler MouseOver
    {
      add => this.AddEventListener(EventNames.Mouseover, value, false);
      remove => this.RemoveEventListener(EventNames.Mouseover, value, false);
    }

    public event DomEventHandler MouseUp
    {
      add => this.AddEventListener(EventNames.Mouseup, value, false);
      remove => this.RemoveEventListener(EventNames.Mouseup, value, false);
    }

    public event DomEventHandler MouseWheel
    {
      add => this.AddEventListener(EventNames.Wheel, value, false);
      remove => this.RemoveEventListener(EventNames.Wheel, value, false);
    }

    public event DomEventHandler Paused
    {
      add => this.AddEventListener(EventNames.Pause, value, false);
      remove => this.RemoveEventListener(EventNames.Pause, value, false);
    }

    public event DomEventHandler Played
    {
      add => this.AddEventListener(EventNames.Play, value, false);
      remove => this.RemoveEventListener(EventNames.Play, value, false);
    }

    public event DomEventHandler Playing
    {
      add => this.AddEventListener(EventNames.Playing, value, false);
      remove => this.RemoveEventListener(EventNames.Playing, value, false);
    }

    public event DomEventHandler Progress
    {
      add => this.AddEventListener(EventNames.Progress, value, false);
      remove => this.RemoveEventListener(EventNames.Progress, value, false);
    }

    public event DomEventHandler RateChanged
    {
      add => this.AddEventListener(EventNames.RateChange, value, false);
      remove => this.RemoveEventListener(EventNames.RateChange, value, false);
    }

    public event DomEventHandler Resetted
    {
      add => this.AddEventListener(EventNames.Reset, value, false);
      remove => this.RemoveEventListener(EventNames.Reset, value, false);
    }

    public event DomEventHandler Resized
    {
      add => this.AddEventListener(EventNames.Resize, value, false);
      remove => this.RemoveEventListener(EventNames.Resize, value, false);
    }

    public event DomEventHandler Scrolled
    {
      add => this.AddEventListener(EventNames.Scroll, value, false);
      remove => this.RemoveEventListener(EventNames.Scroll, value, false);
    }

    public event DomEventHandler Seeked
    {
      add => this.AddEventListener(EventNames.Seeked, value, false);
      remove => this.RemoveEventListener(EventNames.Seeked, value, false);
    }

    public event DomEventHandler Seeking
    {
      add => this.AddEventListener(EventNames.Seeking, value, false);
      remove => this.RemoveEventListener(EventNames.Seeking, value, false);
    }

    public event DomEventHandler Selected
    {
      add => this.AddEventListener(EventNames.Select, value, false);
      remove => this.RemoveEventListener(EventNames.Select, value, false);
    }

    public event DomEventHandler Shown
    {
      add => this.AddEventListener(EventNames.Show, value, false);
      remove => this.RemoveEventListener(EventNames.Show, value, false);
    }

    public event DomEventHandler Stalled
    {
      add => this.AddEventListener(EventNames.Stalled, value, false);
      remove => this.RemoveEventListener(EventNames.Stalled, value, false);
    }

    public event DomEventHandler Submitted
    {
      add => this.AddEventListener(EventNames.Submit, value, false);
      remove => this.RemoveEventListener(EventNames.Submit, value, false);
    }

    public event DomEventHandler Suspended
    {
      add => this.AddEventListener(EventNames.Suspend, value, false);
      remove => this.RemoveEventListener(EventNames.Suspend, value, false);
    }

    public event DomEventHandler TimeUpdated
    {
      add => this.AddEventListener(EventNames.TimeUpdate, value, false);
      remove => this.RemoveEventListener(EventNames.TimeUpdate, value, false);
    }

    public event DomEventHandler Toggled
    {
      add => this.AddEventListener(EventNames.Toggle, value, false);
      remove => this.RemoveEventListener(EventNames.Toggle, value, false);
    }

    public event DomEventHandler VolumeChanged
    {
      add => this.AddEventListener(EventNames.VolumeChange, value, false);
      remove => this.RemoveEventListener(EventNames.VolumeChange, value, false);
    }

    public event DomEventHandler Waiting
    {
      add => this.AddEventListener(EventNames.Waiting, value, false);
      remove => this.RemoveEventListener(EventNames.Waiting, value, false);
    }

    public HtmlElement(Document owner, string localName, string prefix = null, NodeFlags flags = NodeFlags.None)
      : base(owner, HtmlElement.Combine(prefix, localName), localName, prefix, NamespaceNames.HtmlUri, flags | NodeFlags.HtmlMember)
    {
    }

    public bool IsHidden
    {
      get => this.GetBoolAttribute(AttributeNames.Hidden);
      set => this.SetBoolAttribute(AttributeNames.Hidden, value);
    }

    public IHtmlMenuElement ContextMenu
    {
      get
      {
        if (this._menu == null)
        {
          string ownAttribute = this.GetOwnAttribute(AttributeNames.ContextMenu);
          if (!string.IsNullOrEmpty(ownAttribute))
            return this.Owner.GetElementById(ownAttribute) as IHtmlMenuElement;
        }
        return this._menu;
      }
      set => this._menu = value;
    }

    public ISettableTokenList DropZone
    {
      get
      {
        if (this._dropZone == null)
        {
          this._dropZone = new SettableTokenList(this.GetOwnAttribute(AttributeNames.DropZone));
          this._dropZone.Changed += (Action<string>) (value => this.UpdateAttribute(AttributeNames.DropZone, value));
        }
        return (ISettableTokenList) this._dropZone;
      }
    }

    public bool IsDraggable
    {
      get => this.GetOwnAttribute(AttributeNames.Draggable).ToBoolean();
      set => this.SetOwnAttribute(AttributeNames.Draggable, value.ToString());
    }

    public string AccessKey
    {
      get => this.GetOwnAttribute(AttributeNames.AccessKey) ?? string.Empty;
      set => this.SetOwnAttribute(AttributeNames.AccessKey, value);
    }

    public string AccessKeyLabel => this.AccessKey;

    public string Language
    {
      get => this.GetOwnAttribute(AttributeNames.Lang) ?? this.GetDefaultLanguage();
      set => this.SetOwnAttribute(AttributeNames.Lang, value);
    }

    public string Title
    {
      get => this.GetOwnAttribute(AttributeNames.Title);
      set => this.SetOwnAttribute(AttributeNames.Title, value);
    }

    public string Direction
    {
      get => this.GetOwnAttribute(AttributeNames.Dir);
      set => this.SetOwnAttribute(AttributeNames.Dir, value);
    }

    public bool IsSpellChecked
    {
      get => this.GetOwnAttribute(AttributeNames.Spellcheck).ToBoolean();
      set => this.SetOwnAttribute(AttributeNames.Spellcheck, value.ToString());
    }

    public int TabIndex
    {
      get => this.GetOwnAttribute(AttributeNames.TabIndex).ToInteger(0);
      set => this.SetOwnAttribute(AttributeNames.TabIndex, value.ToString());
    }

    public IStringMap Dataset => (IStringMap) this._dataset ?? (IStringMap) (this._dataset = new StringMap("data-", (Element) this));

    public string ContentEditable
    {
      get => this.GetOwnAttribute(AttributeNames.ContentEditable);
      set => this.SetOwnAttribute(AttributeNames.ContentEditable, value);
    }

    public bool IsContentEditable
    {
      get
      {
        ContentEditableMode contentEditableMode = this.ContentEditable.ToEnum<ContentEditableMode>(ContentEditableMode.Inherited);
        if (contentEditableMode == ContentEditableMode.True)
          return true;
        IHtmlElement parentElement = this.ParentElement as IHtmlElement;
        return contentEditableMode == ContentEditableMode.Inherited && parentElement != null && parentElement.IsContentEditable;
      }
    }

    public bool IsTranslated
    {
      get => this.GetOwnAttribute(AttributeNames.Translate).ToEnum<SimpleChoice>(SimpleChoice.Yes) == SimpleChoice.Yes;
      set => this.SetOwnAttribute(AttributeNames.Translate, value ? Keywords.Yes : Keywords.No);
    }

    public string InnerText
    {
      get
      {
        bool? nullable = new bool?();
        if (this.Owner == null)
          nullable = new bool?(true);
        if (!nullable.HasValue)
        {
          ICssStyleDeclaration currentStyle = this.ComputeCurrentStyle();
          if (!string.IsNullOrEmpty(currentStyle?.Display))
            nullable = new bool?(currentStyle.Display == "none");
        }
        if (!nullable.HasValue)
          nullable = new bool?(this.IsHidden);
        if (nullable.Value)
          return this.TextContent;
        StringBuilder sb1 = Pool.NewStringBuilder();
        Dictionary<int, int> source = new Dictionary<int, int>();
        StringBuilder sb2 = sb1;
        Dictionary<int, int> requiredLineBreakCounts = source;
        IElement parentElement = this.ParentElement;
        ICssStyleDeclaration currentStyle1 = parentElement != null ? parentElement.ComputeCurrentStyle() : (ICssStyleDeclaration) null;
        HtmlElement.InnerTextCollection((INode) this, sb2, requiredLineBreakCounts, currentStyle1);
        source.Remove(0);
        source.Remove(sb1.Length);
        int num = 0;
        foreach (KeyValuePair<int, int> keyValuePair in (IEnumerable<KeyValuePair<int, int>>) source.OrderBy<KeyValuePair<int, int>, int>((Func<KeyValuePair<int, int>, int>) (kv => kv.Key)))
        {
          int index = keyValuePair.Key + num;
          sb1.Insert(index, new string('\n', keyValuePair.Value));
          num += keyValuePair.Value;
        }
        return sb1.ToPool();
      }
      set
      {
        if (string.IsNullOrEmpty(value))
        {
          this.ReplaceAll((Node) null, false);
        }
        else
        {
          DocumentFragment documentFragment = new DocumentFragment(this.Owner);
          StringBuilder sb = Pool.NewStringBuilder();
          for (int index = 0; index < value.Length; ++index)
          {
            char ch = value[index];
            switch (ch)
            {
              case '\n':
              case '\r':
                if (ch != '\r' || index + 1 >= value.Length || value[index + 1] != '\n')
                {
                  if (sb.Length > 0)
                  {
                    documentFragment.AppendChild((INode) new TextNode(this.Owner, sb.ToPool()));
                    sb = Pool.NewStringBuilder();
                  }
                  documentFragment.AppendChild((INode) new HtmlBreakRowElement(this.Owner));
                  break;
                }
                break;
              default:
                sb.Append(ch);
                break;
            }
          }
          string pool = sb.ToPool();
          if (pool.Length > 0)
            documentFragment.Append(new INode[1]
            {
              (INode) new TextNode(this.Owner, pool)
            });
          this.ReplaceAll((Node) documentFragment, false);
        }
      }
    }

    private static void InnerTextCollection(
      INode node,
      StringBuilder sb,
      Dictionary<int, int> requiredLineBreakCounts,
      ICssStyleDeclaration parentStyle)
    {
      if (!HtmlElement.HasCssBox(node))
        return;
      ICssStyleDeclaration currentStyle1 = node is IElement element ? element.ComputeCurrentStyle() : (ICssStyleDeclaration) null;
      bool? nullable1 = new bool?();
      if (currentStyle1 != null)
      {
        if (!string.IsNullOrEmpty(currentStyle1.Display))
          nullable1 = new bool?(currentStyle1.Display == "none");
        if (!string.IsNullOrEmpty(currentStyle1.Visibility))
        {
          bool? nullable2 = nullable1;
          bool flag = true;
          if ((nullable2.GetValueOrDefault() == flag ? (!nullable2.HasValue ? 1 : 0) : 1) != 0)
            nullable1 = new bool?(currentStyle1.Visibility != "visible");
        }
      }
      if (!nullable1.HasValue)
        nullable1 = new bool?(node is IHtmlElement htmlElement && htmlElement.IsHidden);
      if (nullable1.Value)
        return;
      int length = sb.Length;
      foreach (INode childNode in (IEnumerable<INode>) node.ChildNodes)
        HtmlElement.InnerTextCollection(childNode, sb, requiredLineBreakCounts, currentStyle1);
      switch (node)
      {
        case IText _:
          HtmlElement.ProcessText(((ICharacterData) node).Data, sb, parentStyle);
          goto label_37;
        case IHtmlBreakRowElement _:
          sb.Append('\n');
          goto label_37;
        case IHtmlTableCellElement _:
          if (string.IsNullOrEmpty(currentStyle1.Display))
            break;
          goto default;
        default:
          if (!(currentStyle1.Display == "table-cell"))
          {
            if (node is IHtmlTableRowElement && string.IsNullOrEmpty(currentStyle1.Display) || currentStyle1.Display == "table-row")
            {
              if (node.NextSibling is IElement nextSibling1)
              {
                ICssStyleDeclaration currentStyle2 = nextSibling1.ComputeCurrentStyle();
                if (nextSibling1 is IHtmlTableRowElement && string.IsNullOrEmpty(currentStyle2.Display) || currentStyle2.Display == "table-row")
                {
                  sb.Append('\n');
                  goto label_37;
                }
                else
                  goto label_37;
              }
              else
                goto label_37;
            }
            else if (node is IHtmlParagraphElement)
            {
              int num1 = 0;
              requiredLineBreakCounts.TryGetValue(length, out num1);
              if (num1 < 2)
                requiredLineBreakCounts[length] = 2;
              int num2 = 0;
              requiredLineBreakCounts.TryGetValue(sb.Length, out num2);
              if (num2 < 2)
              {
                requiredLineBreakCounts[sb.Length] = 2;
                goto label_37;
              }
              else
                goto label_37;
            }
            else
              goto label_37;
          }
          else
            break;
      }
      if (node.NextSibling is IElement nextSibling2)
      {
        ICssStyleDeclaration currentStyle3 = nextSibling2.ComputeCurrentStyle();
        if (nextSibling2 is IHtmlTableCellElement && string.IsNullOrEmpty(currentStyle3.Display) || currentStyle3.Display == "table-cell")
          sb.Append('\t');
      }
label_37:
      bool? nullable3 = new bool?();
      if (currentStyle1 != null && HtmlElement.IsBlockLevelDisplay(currentStyle1.Display))
        nullable3 = new bool?(true);
      if (!nullable3.HasValue)
        nullable3 = new bool?(HtmlElement.IsBlockLevel(node));
      if (!nullable3.Value)
        return;
      int num3 = 0;
      requiredLineBreakCounts.TryGetValue(length, out num3);
      if (num3 < 1)
        requiredLineBreakCounts[length] = 1;
      int num4 = 0;
      requiredLineBreakCounts.TryGetValue(sb.Length, out num4);
      if (num4 >= 1)
        return;
      requiredLineBreakCounts[sb.Length] = 1;
    }

    private static bool HasCssBox(INode node)
    {
      switch (node.NodeName)
      {
        case "CANVAS":
        case "COL":
        case "COLGROUP":
        case "DETAILS":
        case "FRAME":
        case "FRAMESET":
        case "IFRAME":
        case "IMG":
        case "INPUT":
        case "LINK":
        case "METER":
        case "NOSCRIPT":
        case "PROGRESS":
        case "SCRIPT":
        case "STYLE":
        case "TEMPLATE":
        case "TEXTAREA":
        case "VIDEO":
        case "WBR":
          return false;
        default:
          return true;
      }
    }

    private static bool IsBlockLevelDisplay(string display) => display == "block" || display == "flow-root" || display == "flex" || display == "grid" || display == "table" || display == "table-caption";

    private static bool IsBlockLevel(INode node)
    {
      switch (node.NodeName)
      {
        case "ADDRESS":
        case "ARTICLE":
        case "ASIDE":
        case "BLOCKQUOTE":
        case "CANVAS":
        case "DD":
        case "DIV":
        case "DL":
        case "DT":
        case "FIELDSET":
        case "FIGCAPTION":
        case "FIGURE":
        case "FOOTER":
        case "FORM":
        case "GROUP":
        case "H1":
        case "H2":
        case "H3":
        case "H4":
        case "H5":
        case "H6":
        case "HEADER":
        case "HR":
        case "LI":
        case "MAIN":
        case "NAV":
        case "NOSCRIPT":
        case "OL":
        case "OPTION":
        case "OUTPUT":
        case "P":
        case "PRE":
        case "SECTION":
        case "TABLE":
        case "TFOOT":
        case "UL":
        case "VIDEO":
          return true;
        default:
          return false;
      }
    }

    private static void ProcessText(string text, StringBuilder sb, ICssStyleDeclaration style)
    {
      int length = sb.Length;
      string whiteSpace = style?.WhiteSpace;
      string textTransform = style?.TextTransform;
      bool flag = length <= 0 || char.IsWhiteSpace(sb[length - 1]) && sb[length - 1] != ' ';
      for (int index = 0; index < text.Length; ++index)
      {
        char c = text[index];
        if (char.IsWhiteSpace(c) && c != ' ')
        {
          switch (whiteSpace)
          {
            case "pre":
            case "pre-wrap":
              flag = true;
              break;
            case "pre-line":
              if (c == ' ' || c == '\t')
              {
                if (!flag)
                {
                  c = ' ';
                  goto case "pre";
                }
                else
                  continue;
              }
              else
                goto case "pre";
            default:
              if (!flag)
              {
                c = ' ';
                goto case "pre";
              }
              else
                continue;
          }
        }
        else
        {
          switch (textTransform)
          {
            case "uppercase":
              c = char.ToUpperInvariant(c);
              break;
            case "lowercase":
              c = char.ToLowerInvariant(c);
              break;
            case "capitalize":
              if (flag)
              {
                c = char.ToUpperInvariant(c);
                break;
              }
              break;
          }
          flag = false;
        }
        sb.Append(c);
      }
      if (!flag)
        return;
      for (int index = sb.Length - 1; index >= length; --index)
      {
        char c = sb[index];
        if (!char.IsWhiteSpace(c) || c == ' ')
        {
          sb.Remove(index + 1, sb.Length - 1 - index);
          break;
        }
      }
    }

    public void DoSpellCheck() => this.Owner.Options.GetSpellCheck(this.Language);

    public virtual void DoClick() => this.IsClickedCancelled();

    public virtual void DoFocus()
    {
    }

    public virtual void DoBlur()
    {
    }

    public override INode Clone(bool deep = true)
    {
      HtmlElement htmlElement = this.Owner.Options.GetFactory<IElementFactory<HtmlElement>>().Create(this.Owner, this.LocalName, this.Prefix);
      this.CloneElement((Element) htmlElement, deep);
      return (INode) htmlElement;
    }

    internal override void SetupElement()
    {
      base.SetupElement();
      string ownAttribute = this.GetOwnAttribute(AttributeNames.Style);
      if (ownAttribute == null)
        return;
      this.UpdateStyle(ownAttribute);
    }

    internal void UpdateDropZone(string value) => this._dropZone?.Update(value);

    protected bool IsClickedCancelled() => this.Fire<MouseEvent>((Action<MouseEvent>) (m => m.Init(EventNames.Click, true, true, this.Owner.DefaultView, 0, 0, 0, 0, 0, false, false, false, false, MouseButton.Primary, (IEventTarget) this)));

    protected IHtmlFormElement GetAssignedForm()
    {
      INode assignedForm = (INode) this.Parent;
      while (true)
      {
        switch (assignedForm)
        {
          case null:
          case IHtmlFormElement _:
            goto label_3;
          default:
            assignedForm = (INode) assignedForm.ParentElement;
            continue;
        }
      }
label_3:
      if (assignedForm == null)
      {
        string ownAttribute = this.GetOwnAttribute(AttributeNames.Form);
        Document owner = this.Owner;
        if (owner == null || assignedForm != null || string.IsNullOrEmpty(ownAttribute))
          return (IHtmlFormElement) null;
        assignedForm = (INode) owner.GetElementById(ownAttribute);
      }
      return assignedForm as IHtmlFormElement;
    }

    private string GetDefaultLanguage() => !(this.ParentElement is IHtmlElement parentElement) ? this.Owner.Options.GetLanguage() : parentElement.Language;

    private static string Combine(string prefix, string localName) => (prefix != null ? prefix + ":" + localName : localName).ToUpperInvariant();
  }
}
