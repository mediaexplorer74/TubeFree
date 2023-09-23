// Decompiled with JetBrains decompiler
// Type: Microsoft.AdMediator.Core.Utilities.IPersistentStorage
// Assembly: Microsoft.AdMediator.Core, Version=2.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: DB70E93F-CF3F-46EC-9B00-17C400B010D8
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\Microsoft.AdMediator.Core.dll

using System.IO;
using System.Threading.Tasks;

namespace Microsoft.AdMediator.Core.Utilities
{
  internal interface IPersistentStorage
  {
    Task<bool> FileExistsInIsolatedStorageAsync(string relativePath);

    Task<Stream> OpenStreamFromAppInstallStorageForReadAsync(string relativePath);

    Task<Stream> OpenStreamFromIsolatedStorageForReadAsync(string relativePath);

    Task<Stream> OpenStreamFromIsolatedStorageForWriteAsync(string relativePath);

    Task CreateFolderInIsolatedStorageIfNotExistingAsync(string folderRelativePath);

    Task DeleteFileFromIsolatedStorageAsync(string relativePath);
  }
}
