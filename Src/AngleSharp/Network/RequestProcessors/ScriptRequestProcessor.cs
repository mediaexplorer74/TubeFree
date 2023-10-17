// Decompiled with JetBrains decompiler
// Type: AngleSharp.Network.RequestProcessors.ScriptRequestProcessor
// Assembly: AngleSharp, Version=0.9.9.0, Culture=neutral, PublicKeyToken=e83494dcdc6d31ea
// MVID: 6D8FC1AC-F585-421F-BEC1-9105A73220DF
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\AngleSharp.dll

using AngleSharp.Dom;
using AngleSharp.Dom.Html;
using AngleSharp.Extensions;
using AngleSharp.Html;
using AngleSharp.Services;
using AngleSharp.Services.Scripting;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace AngleSharp.Network.RequestProcessors
{
  internal sealed class ScriptRequestProcessor : IRequestProcessor
  {
    private readonly HtmlScriptElement _script;
    private readonly Document _document;
    private readonly IResourceLoader _loader;
    private IResponse _response;
    private IScriptEngine _engine;

    private ScriptRequestProcessor(
      HtmlScriptElement script,
      Document document,
      IResourceLoader loader)
    {
      this._script = script;
      this._document = document;
      this._loader = loader;
    }

    internal static ScriptRequestProcessor Create(HtmlScriptElement script)
    {
      Document owner = script.Owner;
      IResourceLoader loader = owner.Loader;
      return new ScriptRequestProcessor(script, owner, loader);
    }

    public IDownload Download { get; private set; }

    public IScriptEngine Engine => this._engine ?? (this._engine = this._document.Options.GetScriptEngine(this.ScriptLanguage));

    public string AlternativeLanguage
    {
      get
      {
        string ownAttribute = this._script.GetOwnAttribute(AttributeNames.Language);
        return ownAttribute == null ? (string) null : "text/" + ownAttribute;
      }
    }

    public string ScriptLanguage
    {
      get
      {
        string str = this._script.Type ?? this.AlternativeLanguage;
        return !string.IsNullOrEmpty(str) ? str : MimeTypeNames.DefaultJavaScript;
      }
    }

    public async Task RunAsync(CancellationToken cancel)
    {
      IDownload download = this.Download;
      if (download != null)
      {
        try
        {
          ScriptRequestProcessor requestProcessor = this;
          IResponse response1 = requestProcessor._response;
          IResponse response2 = await download.Task.ConfigureAwait(false);
          requestProcessor._response = response2;
          requestProcessor = (ScriptRequestProcessor) null;
        }
        catch (Exception ex)
        {
          this.FireErrorEvent();
        }
      }
      if (this._response == null || this._script.FireSimpleEvent(EventNames.BeforeScriptExecute, cancelable: true))
        return;
      ScriptOptions options = this.CreateOptions();
      int insert = this._document.Source.Index;
      try
      {
        await this._engine.EvaluateScriptAsync(this._response, options, cancel).ConfigureAwait(false);
      }
      catch
      {
      }
      this._document.Source.Index = insert;
      this.FireAfterScriptExecuteEvent();
      this._document.QueueTask(new Action(this.FireLoadEvent));
      this._response.Dispose();
      this._response = (IResponse) null;
    }

    public void Process(string content)
    {
      if (this.Engine == null)
        return;
      this._response = VirtualResponse.Create((Action<VirtualResponse>) (res => res.Content(content).Address(this._script.BaseUri)));
    }

    public Task ProcessAsync(ResourceRequest request)
    {
      if (this._loader == null || this.Engine == null)
        return (Task) null;
      this.Download = this._loader.FetchWithCors(new CorsRequest(request)
      {
        Behavior = OriginBehavior.Taint,
        Setting = this._script.CrossOrigin.ToEnum<CorsSetting>(CorsSetting.None),
        Integrity = this._document.Options.GetProvider<IIntegrityProvider>()
      });
      return (Task) this.Download.Task;
    }

    private ScriptOptions CreateOptions() => new ScriptOptions((IDocument) this._document)
    {
      Element = (IHtmlScriptElement) this._script,
      Encoding = TextEncoding.Resolve(this._script.CharacterSet)
    };

    private void FireLoadEvent() => this._script.FireSimpleEvent(EventNames.Load);

    private void FireErrorEvent() => this._script.FireSimpleEvent(EventNames.Error);

    private void FireAfterScriptExecuteEvent() => this._script.FireSimpleEvent(EventNames.AfterScriptExecute, true);
  }
}
