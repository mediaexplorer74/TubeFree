// Decompiled with JetBrains decompiler
// Type: Microsoft.AdMediator.Core.Handlers.ReflectionAdAdapterProvider
// Assembly: Microsoft.AdMediator.Core, Version=2.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: DB70E93F-CF3F-46EC-9B00-17C400B010D8
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\Microsoft.AdMediator.Core.dll

using Microsoft.AdMediator.Core.Display;
using Microsoft.AdMediator.Core.Events;
using Microsoft.AdMediator.Core.Models;
using Microsoft.AdMediator.Core.Models.Runtime;
using Microsoft.AdMediator.Core.Utilities;
using Microsoft.AdMediator.Core.Utilities.Log;
using System;
using System.Collections.Generic;
using System.Globalization;

namespace Microsoft.AdMediator.Core.Handlers
{
  internal class ReflectionAdAdapterProvider : IAdAdapterProvider
  {
    private static readonly ILogger Log = (ILogger) new Logger(typeof (ReflectionAdAdapterProvider));
    private readonly IDictionary<string, string> assemblyNameMapping;
    private readonly IPanelWrapper hostUiElement;
    private readonly IDictionary<string, IAdAdapter> loadedAdAdapters;
    private readonly IUIElementWrapperFactory controlFactory;

    public ReflectionAdAdapterProvider(
      IPanelWrapper hostUiElement,
      IDictionary<string, string> assemblyNameMapping,
      IUIElementWrapperFactory controlFactory)
    {
      this.hostUiElement = hostUiElement;
      this.assemblyNameMapping = assemblyNameMapping;
      this.controlFactory = controlFactory;
      this.loadedAdAdapters = (IDictionary<string, IAdAdapter>) new Dictionary<string, IAdAdapter>();
    }

    public IAdAdapter GetAdAdapter(
      AdAdapterRuntimeInfo adAdapterInfo,
      IParameterDictionary<string, object> parameters,
      Location location)
    {
      if (adAdapterInfo == null)
        throw new ArgumentNullException(nameof (adAdapterInfo));
      if (parameters == null)
        throw new ArgumentNullException(nameof (parameters));
      IAdAdapter adAdapter;
      if (this.loadedAdAdapters.ContainsKey(adAdapterInfo.Name))
      {
        ReflectionAdAdapterProvider.Log.Trace("Found loaded adapter for {0}", (object) adAdapterInfo.Name);
        adAdapter = this.loadedAdAdapters[adAdapterInfo.Name];
      }
      else
      {
        if (!this.assemblyNameMapping.ContainsKey(adAdapterInfo.Name))
          throw new AdMediatorException(string.Format((IFormatProvider) CultureInfo.InvariantCulture, "Invalid SDK {0}", (object) adAdapterInfo.Name));
        string typeName = this.assemblyNameMapping[adAdapterInfo.Name];
        ParameterDictionary<string, string> parameterDictionary = new ParameterDictionary<string, string>();
        foreach (KeyValuePair<string, string> keyValuePair in (IEnumerable<KeyValuePair<string, string>>) adAdapterInfo.Metadata)
          parameterDictionary[keyValuePair.Key] = keyValuePair.Value;
        adAdapter = (IAdAdapter) ReflectionHelper.ConstructType(typeName, (object) this.controlFactory, (object) this.hostUiElement, (object) parameterDictionary, (object) parameters);
        this.loadedAdAdapters[adAdapterInfo.Name] = adAdapter;
      }
      if (location != null)
        adAdapter.Location = location;
      return adAdapter;
    }

    public void ReleaseAdAdapters()
    {
      ISet<string> stringSet = (ISet<string>) new HashSet<string>();
      foreach (KeyValuePair<string, IAdAdapter> loadedAdAdapter in (IEnumerable<KeyValuePair<string, IAdAdapter>>) this.loadedAdAdapters)
      {
        loadedAdAdapter.Value.Release();
        if (loadedAdAdapter.Value.CanBeGarbageCollected())
          stringSet.Add(loadedAdAdapter.Key);
      }
      foreach (string key in (IEnumerable<string>) stringSet)
        this.loadedAdAdapters.Remove(key);
    }

    public void PauseAdAdapters()
    {
      foreach (KeyValuePair<string, IAdAdapter> loadedAdAdapter in (IEnumerable<KeyValuePair<string, IAdAdapter>>) this.loadedAdAdapters)
        loadedAdAdapter.Value.Pause();
    }

    public void ResumeAdAdapters()
    {
      foreach (KeyValuePair<string, IAdAdapter> loadedAdAdapter in (IEnumerable<KeyValuePair<string, IAdAdapter>>) this.loadedAdAdapters)
        loadedAdAdapter.Value.Resume();
    }
  }
}
