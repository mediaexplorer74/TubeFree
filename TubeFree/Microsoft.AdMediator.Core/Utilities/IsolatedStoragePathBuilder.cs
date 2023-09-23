// Decompiled with JetBrains decompiler
// Type: Microsoft.AdMediator.Core.Utilities.IsolatedStoragePathBuilder
// Assembly: Microsoft.AdMediator.Core, Version=2.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: DB70E93F-CF3F-46EC-9B00-17C400B010D8
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\Microsoft.AdMediator.Core.dll

using Microsoft.AdMediator.Core.Managers;
using System.IO;
using System.Threading.Tasks;

namespace Microsoft.AdMediator.Core.Utilities
{
  internal class IsolatedStoragePathBuilder : IIsolatedStoragePathBuilder
  {
    public IStateManager StateManager { get; set; }

    public async Task<string> BuildFullPathForIsolatedStorageAsync(string relativePath) => Path.Combine("AdMediator", Path.Combine(await this.StateManager.RetrieveAdMediatorAppVersionAsync(), relativePath));

    public async Task<string[]> RetrieveRootFolderComponentsAsync() => new string[2]
    {
      "AdMediator",
      await this.StateManager.RetrieveAdMediatorAppVersionAsync()
    };
  }
}
