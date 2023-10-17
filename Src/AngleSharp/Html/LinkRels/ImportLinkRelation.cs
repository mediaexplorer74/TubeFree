// Decompiled with JetBrains decompiler
// Type: AngleSharp.Html.LinkRels.ImportLinkRelation
// Assembly: AngleSharp, Version=0.9.9.0, Culture=neutral, PublicKeyToken=e83494dcdc6d31ea
// MVID: 6D8FC1AC-F585-421F-BEC1-9105A73220DF
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\AngleSharp.dll

using AngleSharp.Dom;
using AngleSharp.Dom.Html;
using AngleSharp.Extensions;
using AngleSharp.Network;
using AngleSharp.Network.RequestProcessors;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace AngleSharp.Html.LinkRels
{
  internal class ImportLinkRelation : BaseLinkRelation
  {
    private static readonly ConditionalWeakTable<IDocument, ImportLinkRelation.ImportList> ImportLists = new ConditionalWeakTable<IDocument, ImportLinkRelation.ImportList>();
    private bool _isasync;

    public ImportLinkRelation(HtmlLinkElement link)
      : base(link, (IRequestProcessor) DocumentRequestProcessor.Create((Element) link))
    {
    }

    public IDocument Import => !(this.Processor is DocumentRequestProcessor processor) ? (IDocument) null : processor.ChildDocument;

    public bool IsAsync => this._isasync;

    public override Task LoadAsync()
    {
      HtmlLinkElement link = this.Link;
      Document owner = link.Owner;
      ImportLinkRelation.ImportList importList = ImportLinkRelation.ImportLists.GetOrCreateValue((IDocument) owner);
      Url url = this.Url;
      IRequestProcessor processor = this.Processor;
      ImportLinkRelation.ImportEntry importEntry1 = new ImportLinkRelation.ImportEntry()
      {
        Relation = this,
        IsCycle = ImportLinkRelation.CheckCycle((IDocument) owner, url)
      };
      ImportLinkRelation.ImportEntry importEntry2 = importEntry1;
      importList.Add(importEntry2);
      if (importEntry1.IsCycle)
        return (Task) null;
      ResourceRequest requestFor = link.CreateRequestFor(url);
      this._isasync = link.HasAttribute(AttributeNames.Async);
      return processor?.ProcessAsync(requestFor);
    }

    private static bool CheckCycle(IDocument document, Url location)
    {
      IDocument importAncestor = document.ImportAncestor;
      ImportLinkRelation.ImportList importList = (ImportLinkRelation.ImportList) null;
      for (; importAncestor != null && ImportLinkRelation.ImportLists.TryGetValue(importAncestor, out importList); importAncestor = importAncestor.ImportAncestor)
      {
        if (importList.Contains(location))
          return true;
      }
      return false;
    }

    private sealed class ImportList
    {
      private readonly List<ImportLinkRelation.ImportEntry> _list;

      public ImportList() => this._list = new List<ImportLinkRelation.ImportEntry>();

      public bool Contains(Url location)
      {
        for (int index = 0; index < this._list.Count; ++index)
        {
          if (this._list[index].Relation.Url.Equals(location))
            return true;
        }
        return false;
      }

      public void Add(ImportLinkRelation.ImportEntry item) => this._list.Add(item);

      public void Remove(ImportLinkRelation.ImportEntry item) => this._list.Remove(item);
    }

    private struct ImportEntry
    {
      public ImportLinkRelation Relation;
      public bool IsCycle;
    }
  }
}
