// Decompiled with JetBrains decompiler
// Type: AngleSharp.Dom.Css.CssNode
// Assembly: AngleSharp, Version=0.9.9.0, Culture=neutral, PublicKeyToken=e83494dcdc6d31ea
// MVID: 6D8FC1AC-F585-421F-BEC1-9105A73220DF
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\AngleSharp.dll

using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AngleSharp.Dom.Css
{
  internal abstract class CssNode : ICssNode, IStyleFormattable
  {
    private readonly List<ICssNode> _children;
    private TextView _source;

    public CssNode()
    {
      this._children = new List<ICssNode>();
      this._source = (TextView) null;
    }

    public TextView SourceCode
    {
      get => this._source;
      internal set => this._source = value;
    }

    public IEnumerable<ICssNode> Children => this._children.AsEnumerable<ICssNode>();

    public abstract void ToCss(TextWriter writer, IStyleFormatter formatter);

    public void AppendChild(ICssNode child)
    {
      this.Setup(child);
      this._children.Add(child);
    }

    public void ReplaceChild(ICssNode oldChild, ICssNode newChild)
    {
      for (int index = 0; index < this._children.Count; ++index)
      {
        if (oldChild == this._children[index])
        {
          this.Teardown(oldChild);
          this.Setup(newChild);
          this._children[index] = newChild;
          break;
        }
      }
    }

    public void InsertBefore(ICssNode referenceChild, ICssNode child)
    {
      if (referenceChild != null)
        this.InsertChild(this._children.IndexOf(referenceChild), child);
      else
        this.AppendChild(child);
    }

    public void InsertChild(int index, ICssNode child)
    {
      this.Setup(child);
      this._children.Insert(index, child);
    }

    public void RemoveChild(ICssNode child)
    {
      this.Teardown(child);
      this._children.Remove(child);
    }

    public void Clear()
    {
      for (int index = this._children.Count - 1; index >= 0; --index)
        this.RemoveChild(this._children[index]);
    }

    protected void ReplaceAll(ICssNode node)
    {
      this.Clear();
      this._source = node.SourceCode;
      foreach (ICssNode child in node.Children)
        this.AppendChild(child);
    }

    private void Setup(ICssNode child)
    {
      if (!(child is CssRule cssRule))
        return;
      cssRule.Owner = this as ICssStyleSheet;
      cssRule.Parent = this as ICssRule;
    }

    private void Teardown(ICssNode child)
    {
      if (!(child is CssRule cssRule))
        return;
      cssRule.Parent = (ICssRule) null;
      cssRule.Owner = (ICssStyleSheet) null;
    }
  }
}
