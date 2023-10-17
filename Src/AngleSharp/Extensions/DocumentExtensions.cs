// Decompiled with JetBrains decompiler
// Type: AngleSharp.Extensions.DocumentExtensions
// Assembly: AngleSharp, Version=0.9.9.0, Culture=neutral, PublicKeyToken=e83494dcdc6d31ea
// MVID: 6D8FC1AC-F585-421F-BEC1-9105A73220DF
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\AngleSharp.dll

using AngleSharp.Dom;
using AngleSharp.Dom.Collections;
using AngleSharp.Dom.Html;
using AngleSharp.Network;
using AngleSharp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace AngleSharp.Extensions
{
  internal static class DocumentExtensions
  {
    public static void ForEachRange(
      this Document document,
      Predicate<Range> condition,
      Action<Range> action)
    {
      foreach (Range attachedReference in document.GetAttachedReferences<Range>())
      {
        if (condition(attachedReference))
          action(attachedReference);
      }
    }

    public static void AdoptNode(this IDocument document, INode node)
    {
      if (!(node is Node node1))
        throw new DomException(DomError.NotSupported);
      node1.Parent?.RemoveChild(node1, false);
      node1.Owner = document as Document;
    }

    public static void QueueTask(this Document document, Action action) => document.Loop.Enqueue(action);

    public static void QueueMutation(this Document document, MutationRecord record)
    {
      MutationObserver[] array = document.Mutations.Observers.ToArray<MutationObserver>();
      if (array.Length == 0)
        return;
      IEnumerable<INode> inclusiveAncestors = record.Target.GetInclusiveAncestors();
      for (int index = 0; index < array.Length; ++index)
      {
        MutationObserver mutationObserver = array[index];
        bool? nullable = new bool?();
        foreach (INode node in inclusiveAncestors)
        {
          MutationObserver.MutationOptions mutationOptions = mutationObserver.ResolveOptions(node);
          if (!mutationOptions.IsInvalid && (node == record.Target || mutationOptions.IsObservingSubtree) && (!record.IsAttribute || mutationOptions.IsObservingAttributes) && (!record.IsAttribute || mutationOptions.AttributeFilters == null || mutationOptions.AttributeFilters.Contains<string>(record.AttributeName) && record.AttributeNamespace == null) && (!record.IsCharacterData || mutationOptions.IsObservingCharacterData) && (!record.IsChildList || mutationOptions.IsObservingChildNodes) && (!nullable.HasValue || nullable.Value))
            nullable = new bool?(record.IsAttribute && !mutationOptions.IsExaminingOldAttributeValue || record.IsCharacterData && !mutationOptions.IsExaminingOldCharacterData);
        }
        if (nullable.HasValue)
          mutationObserver.Enqueue(record.Copy(nullable.Value));
      }
      document.PerformMicrotaskCheckpoint();
    }

    public static void AddTransientObserver(this Document document, INode node)
    {
      IEnumerable<INode> ancestors = node.GetAncestors();
      IEnumerable<MutationObserver> observers = document.Mutations.Observers;
      foreach (INode ancestor in ancestors)
      {
        foreach (MutationObserver mutationObserver in observers)
          mutationObserver.AddTransient(ancestor, node);
      }
    }

    public static void ApplyManifest(this Document document)
    {
      if (!document.IsInBrowsingContext || !(document.DocumentElement is IHtmlHtmlElement documentElement))
        return;
      string manifest = documentElement.Manifest;
      Predicate<string> predicate = (Predicate<string>) (str => false);
      if (string.IsNullOrEmpty(manifest))
        return;
      int num = predicate(manifest) ? 1 : 0;
    }

    public static void PerformMicrotaskCheckpoint(this Document document) => document.Mutations.ScheduleCallback();

    public static void ProvideStableState(this Document document)
    {
    }

    public static IEnumerable<Task> GetDownloads<T>(this Document document) where T : INode
    {
      IResourceLoader loader = document.Loader;
      return loader == null ? Enumerable.Empty<Task>() : (IEnumerable<Task>) loader.GetDownloads().Where<IDownload>((Func<IDownload, bool>) (m => m.Originator is T)).Select<IDownload, Task<IResponse>>((Func<IDownload, Task<IResponse>>) (m => m.Task));
    }

    public static IEnumerable<Task> GetScriptDownloads(this Document document) => document.GetDownloads<HtmlScriptElement>();

    public static IEnumerable<Task> GetStyleSheetDownloads(this Document document) => document.GetDownloads<HtmlLinkElement>();

    public static async Task WaitForReadyAsync(this Document document)
    {
      ConfiguredTaskAwaitable configuredTaskAwaitable = TaskEx.WhenAll(document.GetScriptDownloads().ToArray<Task>()).ConfigureAwait(false);
      await configuredTaskAwaitable;
      configuredTaskAwaitable = TaskEx.WhenAll(document.GetStyleSheetDownloads().ToArray<Task>()).ConfigureAwait(false);
      await configuredTaskAwaitable;
    }

    public static IBrowsingContext GetTarget(this Document document, string target)
    {
      if (string.IsNullOrEmpty(target) || target.Is("_self"))
        return document.Context;
      if (target.Is("_parent"))
        return document.Context.Parent ?? document.Context;
      return target.Is("_top") ? document.Context : document.Options.FindContext(target);
    }

    public static IBrowsingContext CreateTarget(this Document document, string target)
    {
      Sandboxes security = Sandboxes.None;
      return target.Is("_blank") ? document.Options.NewContext(security) : document.NewContext(target, security);
    }

    public static IBrowsingContext NewContext(
      this Document document,
      string name,
      Sandboxes security)
    {
      return document.Options.GetFactory<IContextFactory>().Create(document.Context, name, security);
    }

    public static IBrowsingContext NewChildContext(this Document document, Sandboxes security)
    {
      IBrowsingContext browsingContext = document.NewContext(string.Empty, security);
      document.AttachReference((object) browsingContext);
      return browsingContext;
    }
  }
}
