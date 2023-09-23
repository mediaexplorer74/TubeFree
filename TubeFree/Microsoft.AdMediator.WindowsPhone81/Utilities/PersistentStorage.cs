// Decompiled with JetBrains decompiler
// Type: Microsoft.AdMediator.WindowsPhone81.Utilities.PersistentStorage
// Assembly: Microsoft.AdMediator.WindowsPhone81, Version=2.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1C586D37-9142-43D0-8912-08FBC7AC3DDA
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\Microsoft.AdMediator.WindowsPhone81.dll

using Microsoft.AdMediator.Core.Utilities;
using System.IO;
using System.Threading.Tasks;
using Windows.ApplicationModel;
using Windows.Storage;
using Windows.Storage.Streams;

namespace Microsoft.AdMediator.WindowsPhone81.Utilities
{
  internal class PersistentStorage : IPersistentStorage
  {
    private readonly StorageFolder localFolder = ApplicationData.Current.LocalFolder;
    private readonly IIsolatedStoragePathBuilder isolatedStoragePathBuilder;

    public PersistentStorage(
      IIsolatedStoragePathBuilder isolatedStoragePathBuilder)
    {
      this.isolatedStoragePathBuilder = isolatedStoragePathBuilder;
    }

    private string GetFullPathForAppInstallStorage(string relativePath) => Path.Combine(new string[2]
    {
      Package.Current.InstalledLocation.Path,
      relativePath
    });

    public async Task<bool> FileExistsInIsolatedStorageAsync(string relativePath)
    {
      try
      {
        StorageFile fileAsync = await this.localFolder.GetFileAsync(await this.isolatedStoragePathBuilder.BuildFullPathForIsolatedStorageAsync(relativePath));
        return true;
      }
      catch (FileNotFoundException ex)
      {
        return false;
      }
    }

    public async Task<Stream> OpenStreamFromAppInstallStorageForReadAsync(string relativePath) => await ((IStorageFile) await StorageFile.GetFileFromPathAsync(this.GetFullPathForAppInstallStorage(relativePath))).OpenStreamForReadAsync();

    public async Task<Stream> OpenStreamFromIsolatedStorageForReadAsync(string relativePath) => ((IInputStream) await (await this.localFolder.CreateFileAsync(await this.isolatedStoragePathBuilder.BuildFullPathForIsolatedStorageAsync(relativePath), (CreationCollisionOption) 3)).OpenAsync((FileAccessMode) 0)).AsStreamForRead();

    public async Task<Stream> OpenStreamFromIsolatedStorageForWriteAsync(string relativePath) => ((IOutputStream) await (await this.localFolder.CreateFileAsync(await this.isolatedStoragePathBuilder.BuildFullPathForIsolatedStorageAsync(relativePath), (CreationCollisionOption) 1)).OpenAsync((FileAccessMode) 1)).AsStreamForWrite();

    public async Task CreateFolderInIsolatedStorageIfNotExistingAsync(string folderRelativePath) => await this.CreateFolderWithFullPathInIsolatedStorageIfNotExistAsync(await this.isolatedStoragePathBuilder.BuildFullPathForIsolatedStorageAsync(folderRelativePath));

    private async Task CreateFolderWithFullPathInIsolatedStorageIfNotExistAsync(
      string folderFullPath)
    {
      bool flag;
      try
      {
        StorageFolder folderAsync = await this.localFolder.GetFolderAsync(folderFullPath);
        flag = true;
      }
      catch (FileNotFoundException ex)
      {
        flag = false;
      }
      if (flag)
        return;
      StorageFolder folderAsync1 = await this.localFolder.CreateFolderAsync(folderFullPath);
    }

    public async Task DeleteFileFromIsolatedStorageAsync(string relativePath) => await (await this.localFolder.GetFileAsync(await this.isolatedStoragePathBuilder.BuildFullPathForIsolatedStorageAsync(relativePath))).DeleteAsync((StorageDeleteOption) 1);
  }
}
