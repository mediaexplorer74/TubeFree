// Decompiled with JetBrains decompiler
// Type: AngleSharp.Dom.MutationObserver
// Assembly: AngleSharp, Version=0.9.9.0, Culture=neutral, PublicKeyToken=e83494dcdc6d31ea
// MVID: 6D8FC1AC-F585-421F-BEC1-9105A73220DF
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\AngleSharp.dll

using AngleSharp.Attributes;
using System;
using System.Collections.Generic;

namespace AngleSharp.Dom
{
  [DomName("MutationObserver")]
  public sealed class MutationObserver
  {
    private readonly Queue<IMutationRecord> _records;
    private readonly MutationCallback _callback;
    private readonly List<MutationObserver.MutationObserving> _observing;

    [DomConstructor]
    public MutationObserver(MutationCallback callback)
    {
      if (callback == null)
        throw new ArgumentNullException(nameof (callback));
      this._records = new Queue<IMutationRecord>();
      this._callback = callback;
      this._observing = new List<MutationObserver.MutationObserving>();
    }

    private MutationObserver.MutationObserving this[INode node]
    {
      get
      {
        foreach (MutationObserver.MutationObserving mutationObserving in this._observing)
        {
          if (mutationObserving.Target == node)
            return mutationObserving;
        }
        return (MutationObserver.MutationObserving) null;
      }
    }

    internal void Enqueue(MutationRecord record)
    {
      int count = this._records.Count;
      this._records.Enqueue((IMutationRecord) record);
    }

    internal void Trigger()
    {
      IMutationRecord[] array = this._records.ToArray();
      this._records.Clear();
      this.ClearTransients();
      if (array.Length == 0)
        return;
      this.TriggerWith(array);
    }

    internal void TriggerWith(IMutationRecord[] records) => this._callback(records, this);

    internal MutationObserver.MutationOptions ResolveOptions(INode node)
    {
      foreach (MutationObserver.MutationObserving mutationObserving in this._observing)
      {
        if (mutationObserving.Target == node || mutationObserving.TransientNodes.Contains(node))
          return mutationObserving.Options;
      }
      return new MutationObserver.MutationOptions();
    }

    internal void AddTransient(INode ancestor, INode node)
    {
      MutationObserver.MutationObserving mutationObserving = this[ancestor];
      if (mutationObserving == null || !mutationObserving.Options.IsObservingSubtree)
        return;
      mutationObserving.TransientNodes.Add(node);
    }

    internal void ClearTransients()
    {
      foreach (MutationObserver.MutationObserving mutationObserving in this._observing)
        mutationObserving.TransientNodes.Clear();
    }

    [DomName("disconnect")]
    public void Disconnect()
    {
      foreach (MutationObserver.MutationObserving mutationObserving in this._observing)
        ((Node) mutationObserving.Target).Owner.Mutations.Unregister(this);
      this._records.Clear();
    }

    [DomName("observe")]
    [DomInitDict(1, false)]
    public void Connect(
      INode target,
      bool childList = false,
      bool subtree = false,
      bool? attributes = null,
      bool? characterData = null,
      bool? attributeOldValue = null,
      bool? characterDataOldValue = null,
      IEnumerable<string> attributeFilter = null)
    {
      if (!(target is Node node))
        return;
      bool? nullable = characterDataOldValue;
      bool flag1 = ((int) nullable ?? 0) != 0;
      nullable = attributeOldValue;
      bool flag2 = ((int) nullable ?? 0) != 0;
      MutationObserver.MutationOptions mutationOptions = new MutationObserver.MutationOptions();
      mutationOptions.IsObservingChildNodes = childList;
      mutationOptions.IsObservingSubtree = subtree;
      mutationOptions.IsExaminingOldCharacterData = flag1;
      mutationOptions.IsExaminingOldAttributeValue = flag2;
      ref MutationObserver.MutationOptions local1 = ref mutationOptions;
      nullable = characterData;
      int num1 = (int) nullable ?? (flag1 ? 1 : 0);
      local1.IsObservingCharacterData = num1 != 0;
      ref MutationObserver.MutationOptions local2 = ref mutationOptions;
      nullable = attributes;
      int num2 = (int) nullable ?? (flag2 ? 1 : (attributeFilter != null ? 1 : 0));
      local2.IsObservingAttributes = num2 != 0;
      mutationOptions.AttributeFilters = attributeFilter;
      MutationObserver.MutationOptions options = mutationOptions;
      if (options.IsExaminingOldAttributeValue && !options.IsObservingAttributes)
        throw new DomException(DomError.TypeMismatch);
      if (options.AttributeFilters != null && !options.IsObservingAttributes)
        throw new DomException(DomError.TypeMismatch);
      if (options.IsExaminingOldCharacterData && !options.IsObservingCharacterData)
        throw new DomException(DomError.TypeMismatch);
      if (options.IsInvalid)
        throw new DomException(DomError.Syntax);
      node.Owner.Mutations.Register(this);
      MutationObserver.MutationObserving mutationObserving = this[target];
      if (mutationObserving != null)
      {
        mutationObserving.TransientNodes.Clear();
        this._observing.Remove(mutationObserving);
      }
      this._observing.Add(new MutationObserver.MutationObserving(target, options));
    }

    [DomName("takeRecords")]
    public IEnumerable<IMutationRecord> Flush()
    {
      while (this._records.Count > 0)
        yield return this._records.Dequeue();
    }

    internal struct MutationOptions
    {
      public bool IsObservingChildNodes;
      public bool IsObservingSubtree;
      public bool IsObservingCharacterData;
      public bool IsObservingAttributes;
      public bool IsExaminingOldCharacterData;
      public bool IsExaminingOldAttributeValue;
      public IEnumerable<string> AttributeFilters;

      public bool IsInvalid => !this.IsObservingAttributes && !this.IsObservingCharacterData && !this.IsObservingChildNodes;
    }

    private sealed class MutationObserving
    {
      private readonly INode _target;
      private readonly MutationObserver.MutationOptions _options;
      private readonly List<INode> _transientNodes;

      public MutationObserving(INode target, MutationObserver.MutationOptions options)
      {
        this._target = target;
        this._options = options;
        this._transientNodes = new List<INode>();
      }

      public INode Target => this._target;

      public MutationObserver.MutationOptions Options => this._options;

      public List<INode> TransientNodes => this._transientNodes;
    }
  }
}
