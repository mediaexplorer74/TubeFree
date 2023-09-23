// Decompiled with JetBrains decompiler
// Type: Microsoft.AdMediator.Core.Managers.IConfigurationManager
// Assembly: Microsoft.AdMediator.Core, Version=2.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: DB70E93F-CF3F-46EC-9B00-17C400B010D8
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\Microsoft.AdMediator.Core.dll

using Microsoft.AdMediator.Core.Models.Runtime;
using System.Threading.Tasks;

namespace Microsoft.AdMediator.Core.Managers
{
  internal interface IConfigurationManager
  {
    Task<AdMediatorRuntimeConfiguration> GetAdControlConfigurationAsync(string adControlId);

    Task<bool> DownloadAndSaveNewConfiguration();
  }
}
