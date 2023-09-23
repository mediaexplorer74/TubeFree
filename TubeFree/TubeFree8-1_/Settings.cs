// Decompiled with JetBrains decompiler
// Type: TubeFree8_1.Settings
// Assembly: TubeFree8-1, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B4DCF786-D976-4451-B6A4-B664A1A9ABDC
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\TubeFree8-1.exe

using Microsoft.VisualBasic.CompilerServices;
using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.ApplicationModel.Store;
using Windows.Storage;
using Windows.Storage.Streams;
using Windows.System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Markup;
using Windows.UI.Xaml.Navigation;

namespace TubeFree8_1
{
  [DesignerGenerated]
  public sealed class Settings : Page, IComponentConnector
  {
    private ulong spaceUtilized;
    private bool _contentLoaded;

    public Settings()
    {
      this.spaceUtilized = 0UL;
      this.InitializeComponent();
    }

    protected virtual void OnNavigatedTo(NavigationEventArgs e) => this.CalcolaSpazioUtilizatto();

    private async void CalcolaSpazioUtilizatto()
    {
      IReadOnlyList<StorageFile> filesAsync1 = await App.localFolder.GetFolderAsync(App.musicFolder).AsTask<StorageFolder>().Result.GetFilesAsync();
      try
      {
        foreach (StorageFile storageFile in (IEnumerable<StorageFile>) filesAsync1)
        {
          IRandomAccessStreamWithContentType streamWithContentType = await storageFile.OpenReadAsync();
          // ISSUE: variable of a reference type
          ulong& local;
          // ISSUE: explicit reference operation
          long num = (long) checked (^(local = ref this.spaceUtilized) + ((IRandomAccessStream) streamWithContentType).Size);
          local = (ulong) num;
        }
      }
      finally
      {
        IEnumerator<StorageFile> enumerator;
        enumerator?.Dispose();
      }
      IReadOnlyList<StorageFile> filesAsync2 = await App.localFolder.GetFolderAsync(App.videoFolder).AsTask<StorageFolder>().Result.GetFilesAsync();
      try
      {
        foreach (StorageFile storageFile in (IEnumerable<StorageFile>) filesAsync2)
        {
          IRandomAccessStreamWithContentType streamWithContentType = await storageFile.OpenReadAsync();
          // ISSUE: variable of a reference type
          ulong& local;
          // ISSUE: explicit reference operation
          long num = (long) checked (^(local = ref this.spaceUtilized) + ((IRandomAccessStream) streamWithContentType).Size);
          local = (ulong) num;
        }
      }
      finally
      {
        IEnumerator<StorageFile> enumerator;
        enumerator?.Dispose();
      }
      IReadOnlyList<StorageFile> filesAsync3 = await App.localFolder.GetFolderAsync(App.picturFolder).AsTask<StorageFolder>().Result.GetFilesAsync();
      try
      {
        foreach (StorageFile storageFile in (IEnumerable<StorageFile>) filesAsync3)
        {
          IRandomAccessStreamWithContentType streamWithContentType = await storageFile.OpenReadAsync();
          // ISSUE: variable of a reference type
          ulong& local;
          // ISSUE: explicit reference operation
          long num = (long) checked (^(local = ref this.spaceUtilized) + ((IRandomAccessStream) streamWithContentType).Size);
          local = (ulong) num;
        }
      }
      finally
      {
        IEnumerator<StorageFile> enumerator;
        enumerator?.Dispose();
      }
      this.totalMB.put_Text(Conversions.ToString(checked ((int) Math.Round(Math.Round(unchecked ((double) this.spaceUtilized / 1000000.0))))) + " MB");
    }

    private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
    }

    private async void btnRate_Click(object sender, RoutedEventArgs e)
    {
      int num = await Launcher.LaunchUriAsync(new Uri("ms-windows-store:reviewapp?appid=" + CurrentApp.AppId.ToString())) ? 1 : 0;
    }

    [field: AccessedThroughProperty("principale")]
    [field: GeneratedCode("Microsoft.Windows.UI.Xaml.Build.Tasks", "4.0.0.0")]
    private virtual Grid principale { get; [MethodImpl((MethodImplOptions) 32)] set; }

    [field: AccessedThroughProperty("cont")]
    [field: GeneratedCode("Microsoft.Windows.UI.Xaml.Build.Tasks", "4.0.0.0")]
    private virtual StackPanel cont { get; [MethodImpl((MethodImplOptions) 32)] set; }

    private virtual Button btnRate
    {
      get => this._btnRate;
      [MethodImpl((MethodImplOptions) 32)] set
      {
        RoutedEventHandler routedEventHandler = new RoutedEventHandler(this.btnRate_Click);
        Button btnRate1 = this._btnRate;
        if (btnRate1 != null)
          WindowsRuntimeMarshal.RemoveEventHandler<RoutedEventHandler>(new Action<EventRegistrationToken>(((ButtonBase) btnRate1).remove_Click), routedEventHandler);
        this._btnRate = value;
        Button btnRate2 = this._btnRate;
        if (btnRate2 == null)
          return;
        WindowsRuntimeMarshal.AddEventHandler<RoutedEventHandler>(new Func<RoutedEventHandler, EventRegistrationToken>(((ButtonBase) btnRate2).add_Click), new Action<EventRegistrationToken>(((ButtonBase) btnRate2).remove_Click), routedEventHandler);
      }
    }

    [field: AccessedThroughProperty("totalMB")]
    [field: GeneratedCode("Microsoft.Windows.UI.Xaml.Build.Tasks", "4.0.0.0")]
    private virtual TextBlock totalMB { get; [MethodImpl((MethodImplOptions) 32)] set; }

    [GeneratedCode("Microsoft.Windows.UI.Xaml.Build.Tasks", "4.0.0.0")]
    [DebuggerNonUserCode]
    public void InitializeComponent()
    {
      if (this._contentLoaded)
        return;
      this._contentLoaded = true;
      Application.LoadComponent((object) this, new Uri("ms-appx:///Vista/Settings.xaml"), (ComponentResourceLocation) 0);
      this.principale = (Grid) ((FrameworkElement) this).FindName("principale");
      this.cont = (StackPanel) ((FrameworkElement) this).FindName("cont");
      this.btnRate = (Button) ((FrameworkElement) this).FindName("btnRate");
      this.totalMB = (TextBlock) ((FrameworkElement) this).FindName("totalMB");
    }

    [GeneratedCode("Microsoft.Windows.UI.Xaml.Build.Tasks", "4.0.0.0")]
    [DebuggerNonUserCode]
    public void Connect(int connectionId, object target) => this._contentLoaded = true;
  }
}
