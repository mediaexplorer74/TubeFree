// Decompiled with JetBrains decompiler
// Type: Microsoft.AdMediator.Core.Handlers.IAdAdapterProvider
// Assembly: Microsoft.AdMediator.Core, Version=2.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: DB70E93F-CF3F-46EC-9B00-17C400B010D8
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\Microsoft.AdMediator.Core.dll

using Microsoft.AdMediator.Core.Models;
using Microsoft.AdMediator.Core.Models.Runtime;
using Microsoft.AdMediator.Core.Utilities;

namespace Microsoft.AdMediator.Core.Handlers
{
  internal interface IAdAdapterProvider
  {
    IAdAdapter GetAdAdapter(
      AdAdapterRuntimeInfo adAdapterInfo,
      IParameterDictionary<string, object> parameters,
      Location location);

    void ReleaseAdAdapters();

    void PauseAdAdapters();

    void ResumeAdAdapters();
  }
}
