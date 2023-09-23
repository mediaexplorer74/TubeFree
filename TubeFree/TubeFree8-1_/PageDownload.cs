// Decompiled with JetBrains decompiler
// Type: TubeFree8_1.PageDownload
// Assembly: TubeFree8-1, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B4DCF786-D976-4451-B6A4-B664A1A9ABDC
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\TubeFree8-1.exe

using GoogleAnalytics;
using Microsoft.Advertising.WinRT.UI;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Graphics.Display;
using Windows.Media.Playback;
using Windows.Storage;
using Windows.Storage.Streams;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Markup;
using Windows.UI.Xaml.Navigation;

namespace TubeFree8_1
{
  [DesignerGenerated]
  public sealed class PageDownload : Page, IComponentConnector
  {
    private AdControl banner;
    private bool _contentLoaded;

    private virtual DispatcherTimer timerPubli
    {
      get => this._timerPubli;
      [MethodImpl((MethodImplOptions) 32)] set
      {
        EventHandler<object> eventHandler = new EventHandler<object>(this.timerPubli_Tick);
        DispatcherTimer timerPubli1 = this._timerPubli;
        if (timerPubli1 != null)
          WindowsRuntimeMarshal.RemoveEventHandler<EventHandler<object>>(new Action<EventRegistrationToken>(timerPubli1.remove_Tick), eventHandler);
        this._timerPubli = value;
        DispatcherTimer timerPubli2 = this._timerPubli;
        if (timerPubli2 == null)
          return;
        WindowsRuntimeMarshal.AddEventHandler<EventHandler<object>>(new Func<EventHandler<object>, EventRegistrationToken>(timerPubli2.add_Tick), new Action<EventRegistrationToken>(timerPubli2.remove_Tick), eventHandler);
      }
    }

    public PageDownload()
    {
      WindowsRuntimeMarshal.AddEventHandler<RoutedEventHandler>(new Func<RoutedEventHandler, EventRegistrationToken>(((FrameworkElement) this).add_Loaded), new Action<EventRegistrationToken>(((FrameworkElement) this).remove_Loaded), new RoutedEventHandler(this.PageDownload_Loaded));
      this.banner = new AdControl();
      this.InitializeComponent();
      this.timerFullScreen = new DispatcherTimer();
      this.timerFullScreen.put_Interval(TimeSpan.FromMilliseconds(100.0));
    }

    protected virtual void OnNavigatedTo(NavigationEventArgs e)
    {
      try
      {
        if (this.timerPubli != null)
          return;
        this.timerPubli = new DispatcherTimer();
        this.timerPubli.put_Interval(TimeSpan.FromSeconds(30.0));
        this.timerPubli.Start();
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        ProjectData.ClearProjectError();
      }
    }

    protected virtual void OnNavigatedFrom(NavigationEventArgs e)
    {
      try
      {
        this.timerPubli.Stop();
        this.timerPubli = (DispatcherTimer) null;
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        ProjectData.ClearProjectError();
      }
    }

    private void PageDownload_Loaded(object sender, RoutedEventArgs e)
    {
      ((ItemsControl) this.listViewTop).put_ItemsSource((object) App.listaDownloading);
      ((ItemsControl) this.listMusic).put_ItemsSource((object) App.listaMusica);
      ((ItemsControl) this.listVideo).put_ItemsSource((object) App.listaVideo);
      this.banner.ApplicationId = App.pubcenterAppID;
      this.banner.AdUnitId = App.pubcenterBannerID;
      ((FrameworkElement) this.banner).put_Width(300.0);
      ((FrameworkElement) this.banner).put_Height(50.0);
      this.banner.IsAutoRefreshEnabled = false;
      this.banner.IsBackgroundTransparent = true;
      ((FrameworkElement) this.banner).put_VerticalAlignment((VerticalAlignment) 2);
      AdControl banner1 = this.banner;
      WindowsRuntimeMarshal.AddEventHandler<EventHandler<RoutedEventArgs>>(new Func<EventHandler<RoutedEventArgs>, EventRegistrationToken>(banner1.add_AdRefreshed), new Action<EventRegistrationToken>(banner1.remove_AdRefreshed), new EventHandler<RoutedEventArgs>(this.ad_refreshed));
      AdControl banner2 = this.banner;
      WindowsRuntimeMarshal.AddEventHandler<EventHandler<AdErrorEventArgs>>(new Func<EventHandler<AdErrorEventArgs>, EventRegistrationToken>(banner2.add_ErrorOccurred), new Action<EventRegistrationToken>(banner2.remove_ErrorOccurred), new EventHandler<AdErrorEventArgs>(this.ad_error_occurred));
      if (((ICollection<UIElement>) ((Panel) this.relPanel).Children).Contains((UIElement) this.banner))
        return;
      ((ICollection<UIElement>) ((Panel) this.relPanel).Children).Add((UIElement) this.banner);
    }

    [field: AccessedThroughProperty("mediaPlayer")]
    public static MediaElement mediaPlayer { get; [MethodImpl((MethodImplOptions) 32)] set; }

    private virtual DispatcherTimer timerFullScreen
    {
      get => this._timerFullScreen;
      [MethodImpl((MethodImplOptions) 32)] set
      {
        EventHandler<object> eventHandler = new EventHandler<object>(this.timerFullScreen_Tick);
        DispatcherTimer timerFullScreen1 = this._timerFullScreen;
        if (timerFullScreen1 != null)
          WindowsRuntimeMarshal.RemoveEventHandler<EventHandler<object>>(new Action<EventRegistrationToken>(timerFullScreen1.remove_Tick), eventHandler);
        this._timerFullScreen = value;
        DispatcherTimer timerFullScreen2 = this._timerFullScreen;
        if (timerFullScreen2 == null)
          return;
        WindowsRuntimeMarshal.AddEventHandler<EventHandler<object>>(new Func<EventHandler<object>, EventRegistrationToken>(timerFullScreen2.add_Tick), new Action<EventRegistrationToken>(timerFullScreen2.remove_Tick), eventHandler);
      }
    }

    private void media_MediaEnded(object sender, RoutedEventArgs e)
    {
      DisplayInformation.put_AutoRotationPreferences((DisplayOrientations) 2);
      ((ICollection<UIElement>) ((Panel) this.relPanel).Children).Remove((UIElement) PageDownload.mediaPlayer);
      WindowsRuntimeMarshal.RemoveEventHandler<RoutedEventHandler>(new Action<EventRegistrationToken>(PageDownload.mediaPlayer.remove_MediaEnded), new RoutedEventHandler(this.media_MediaEnded));
      PageDownload.mediaPlayer = (MediaElement) null;
      ((Selector) this.listVideo).put_SelectedIndex(-1);
    }

    public void NormalScreen()
    {
      ((ICollection<UIElement>) ((Panel) this.relPanel).Children).Remove((UIElement) PageDownload.mediaPlayer);
      ((Selector) this.listVideo).put_SelectedIndex(-1);
      DisplayInformation.put_AutoRotationPreferences((DisplayOrientations) 2);
    }

    private void timerFullScreen_Tick(object sender, object e)
    {
      if (PageDownload.mediaPlayer.IsFullWindow)
        return;
      this.timerFullScreen.Stop();
      this.NormalScreen();
    }

    private void Grid_PointerEntered(object sender, PointerRoutedEventArgs e)
    {
    }

    private void SymbolIcon_Tapped(object sender, TappedRoutedEventArgs e) => ((CoreDownload) (sender as FrameworkElement).DataContext).Arresta();

    private async void flayoutDelete_Click(object sender, RoutedEventArgs e)
    {
      object objectValue = RuntimeHelpers.GetObjectValue(((FrameworkElement) sender).DataContext);
      StorageFolder folderAsync = await App.localFolder.GetFolderAsync(App.videoFolder);
      Exception exception = (Exception) null;
      try
      {
        await (await folderAsync.GetFileAsync(Conversions.ToString(RuntimeHelpers.GetObjectValue(NewLateBinding.LateGet(objectValue, (Type) null, "Nome", new object[0], (string[]) null, (Type[]) null, (bool[]) null))))).DeleteAsync();
        ((Collection<ModelFile>) App.listaVideo).Remove((ModelFile) objectValue);
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        exception = ex;
        ProjectData.ClearProjectError();
      }
      if (exception == null)
        return;
      IUICommand iuiCommand = await new MessageDialog("An error has occurred", "Error").ShowAsync();
    }

    private async void flayoutExportVideo_Click(object sender, RoutedEventArgs e)
    {
      object objectValue = RuntimeHelpers.GetObjectValue(((FrameworkElement) sender).DataContext);
      StorageFolder folderAsync = await App.localFolder.GetFolderAsync(App.videoFolder);
      Exception exception = (Exception) null;
      try
      {
        StorageFile storageFile = await (await folderAsync.GetFileAsync(Conversions.ToString(RuntimeHelpers.GetObjectValue(NewLateBinding.LateGet(objectValue, (Type) null, "Nome", new object[0], (string[]) null, (Type[]) null, (bool[]) null))))).CopyAsync((IStorageFolder) KnownFolders.VideosLibrary);
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        exception = ex;
        ProjectData.ClearProjectError();
      }
      if (exception == null)
        return;
      IUICommand iuiCommand = await new MessageDialog("An error has occurred", "Error").ShowAsync();
    }

    private async void flayoutExportMusic_Click(object sender, RoutedEventArgs e)
    {
      object objectValue = RuntimeHelpers.GetObjectValue(((FrameworkElement) sender).DataContext);
      StorageFolder folderAsync = await App.localFolder.GetFolderAsync(App.musicFolder);
      Exception exception = (Exception) null;
      try
      {
        StorageFile storageFile = await (await folderAsync.GetFileAsync(Conversions.ToString(RuntimeHelpers.GetObjectValue(NewLateBinding.LateGet(objectValue, (Type) null, "Nome", new object[0], (string[]) null, (Type[]) null, (bool[]) null))))).CopyAsync((IStorageFolder) KnownFolders.MusicLibrary);
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        exception = ex;
        ProjectData.ClearProjectError();
      }
      if (exception == null)
        return;
      IUICommand iuiCommand = await new MessageDialog("An error has occurred", "Error").ShowAsync();
    }

    private async void flayoutDeleteAudio_Click(object sender, RoutedEventArgs e)
    {
      object objectValue = RuntimeHelpers.GetObjectValue(((FrameworkElement) sender).DataContext);
      StorageFolder folderAsync = await App.localFolder.GetFolderAsync(App.musicFolder);
      Exception exception = (Exception) null;
      try
      {
        await (await folderAsync.GetFileAsync(Conversions.ToString(RuntimeHelpers.GetObjectValue(NewLateBinding.LateGet(objectValue, (Type) null, "Nome", new object[0], (string[]) null, (Type[]) null, (bool[]) null))))).DeleteAsync();
        ((Collection<ModelFile>) App.listaMusica).Remove((ModelFile) objectValue);
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        exception = ex;
        ProjectData.ClearProjectError();
      }
      if (exception == null)
        return;
      IUICommand iuiCommand = await new MessageDialog("An error has occurred", "Error").ShowAsync();
    }

    private void Button_Click(object sender, RoutedEventArgs e)
    {
    }

    private void listVideo_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
    }

    private async void listVideo_ItemClick(object sender, ItemClickEventArgs e)
    {
      try
      {
        ModelFile clickedItem = (ModelFile) e.ClickedItem;
        PageDownload.mediaPlayer = new MediaElement();
        ((ICollection<UIElement>) ((Panel) this.relPanel).Children).Add((UIElement) PageDownload.mediaPlayer);
        PageDownload.mediaPlayer.put_IsFullWindow(true);
        PageDownload.mediaPlayer.put_AreTransportControlsEnabled(true);
        MediaElement mediaPlayer = PageDownload.mediaPlayer;
        WindowsRuntimeMarshal.AddEventHandler<RoutedEventHandler>(new Func<RoutedEventHandler, EventRegistrationToken>(mediaPlayer.add_MediaEnded), new Action<EventRegistrationToken>(mediaPlayer.remove_MediaEnded), new RoutedEventHandler(this.media_MediaEnded));
        StorageFile fileAsync = await (await App.localFolder.GetFolderAsync(App.videoFolder)).GetFileAsync(clickedItem.Nome);
        IRandomAccessStreamWithContentType streamWithContentType = await fileAsync.OpenReadAsync();
        BackgroundMediaPlayer.Shutdown();
        PageDownload.mediaPlayer.SetSource((IRandomAccessStream) streamWithContentType, fileAsync.ContentType);
        DisplayInformation.put_AutoRotationPreferences((DisplayOrientations) 5);
        PageDownload.mediaPlayer.Play();
        this.timerFullScreen.Start();
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        this.NormalScreen();
        ProjectData.ClearProjectError();
      }
    }

    private void ad_refreshed(object sender, RoutedEventArgs e)
    {
      try
      {
        if (this.timerPubli.IsEnabled)
        {
          this.timerPubli.Stop();
          this.timerPubli.Start();
        }
        else
          this.timerPubli.Start();
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        ProjectData.ClearProjectError();
      }
      // ISSUE: reference to a compiler-generated method
      // ISSUE: reference to a compiler-generated method
      EasyTracker.GetTracker().SendView("New Banner 8.1 New");
    }

    private void ad_error_occurred(object sender, AdErrorEventArgs e)
    {
      try
      {
        if (this.timerPubli.IsEnabled)
        {
          this.timerPubli.Stop();
          this.timerPubli.Start();
        }
        else
          this.timerPubli.Start();
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        ProjectData.ClearProjectError();
      }
    }

    private void timerPubli_Tick(object sender, object e)
    {
      try
      {
        this.banner.Refresh();
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        ProjectData.ClearProjectError();
      }
    }

    [field: AccessedThroughProperty("relPanel")]
    [field: GeneratedCode("Microsoft.Windows.UI.Xaml.Build.Tasks", "4.0.0.0")]
    private virtual Grid relPanel { get; [MethodImpl((MethodImplOptions) 32)] set; }

    [field: AccessedThroughProperty("piv")]
    [field: GeneratedCode("Microsoft.Windows.UI.Xaml.Build.Tasks", "4.0.0.0")]
    private virtual Pivot piv { get; [MethodImpl((MethodImplOptions) 32)] set; }

    [field: AccessedThroughProperty("video")]
    [field: GeneratedCode("Microsoft.Windows.UI.Xaml.Build.Tasks", "4.0.0.0")]
    private virtual PivotItem video { get; [MethodImpl((MethodImplOptions) 32)] set; }

    [field: AccessedThroughProperty("pivMusic")]
    [field: GeneratedCode("Microsoft.Windows.UI.Xaml.Build.Tasks", "4.0.0.0")]
    private virtual PivotItem pivMusic { get; [MethodImpl((MethodImplOptions) 32)] set; }

    [field: AccessedThroughProperty("pivHot")]
    [field: GeneratedCode("Microsoft.Windows.UI.Xaml.Build.Tasks", "4.0.0.0")]
    private virtual PivotItem pivHot { get; [MethodImpl((MethodImplOptions) 32)] set; }

    [field: AccessedThroughProperty("listViewTop")]
    [field: GeneratedCode("Microsoft.Windows.UI.Xaml.Build.Tasks", "4.0.0.0")]
    private virtual ListView listViewTop { get; [MethodImpl((MethodImplOptions) 32)] set; }

    [field: AccessedThroughProperty("listMusic")]
    [field: GeneratedCode("Microsoft.Windows.UI.Xaml.Build.Tasks", "4.0.0.0")]
    private virtual ListView listMusic { get; [MethodImpl((MethodImplOptions) 32)] set; }

    private virtual ListView listVideo
    {
      get => this._listVideo;
      [MethodImpl((MethodImplOptions) 32)] set
      {
        SelectionChangedEventHandler changedEventHandler = new SelectionChangedEventHandler(this.listVideo_SelectionChanged);
        ItemClickEventHandler clickEventHandler = new ItemClickEventHandler(this.listVideo_ItemClick);
        ListView listVideo1 = this._listVideo;
        if (listVideo1 != null)
        {
          WindowsRuntimeMarshal.RemoveEventHandler<SelectionChangedEventHandler>(new Action<EventRegistrationToken>(((Selector) listVideo1).remove_SelectionChanged), changedEventHandler);
          WindowsRuntimeMarshal.RemoveEventHandler<ItemClickEventHandler>(new Action<EventRegistrationToken>(((ListViewBase) listVideo1).remove_ItemClick), clickEventHandler);
        }
        this._listVideo = value;
        ListView listVideo2 = this._listVideo;
        if (listVideo2 == null)
          return;
        WindowsRuntimeMarshal.AddEventHandler<SelectionChangedEventHandler>(new Func<SelectionChangedEventHandler, EventRegistrationToken>(((Selector) listVideo2).add_SelectionChanged), new Action<EventRegistrationToken>(((Selector) listVideo2).remove_SelectionChanged), changedEventHandler);
        WindowsRuntimeMarshal.AddEventHandler<ItemClickEventHandler>(new Func<ItemClickEventHandler, EventRegistrationToken>(((ListViewBase) listVideo2).add_ItemClick), new Action<EventRegistrationToken>(((ListViewBase) listVideo2).remove_ItemClick), clickEventHandler);
      }
    }

    [GeneratedCode("Microsoft.Windows.UI.Xaml.Build.Tasks", "4.0.0.0")]
    [DebuggerNonUserCode]
    public void InitializeComponent()
    {
      if (this._contentLoaded)
        return;
      this._contentLoaded = true;
      Application.LoadComponent((object) this, new Uri("ms-appx:///Vista/PageDownload.xaml"), (ComponentResourceLocation) 0);
      this.relPanel = (Grid) ((FrameworkElement) this).FindName("relPanel");
      this.piv = (Pivot) ((FrameworkElement) this).FindName("piv");
      this.video = (PivotItem) ((FrameworkElement) this).FindName("video");
      this.pivMusic = (PivotItem) ((FrameworkElement) this).FindName("pivMusic");
      this.pivHot = (PivotItem) ((FrameworkElement) this).FindName("pivHot");
      this.listViewTop = (ListView) ((FrameworkElement) this).FindName("listViewTop");
      this.listMusic = (ListView) ((FrameworkElement) this).FindName("listMusic");
      this.listVideo = (ListView) ((FrameworkElement) this).FindName("listVideo");
    }

    [GeneratedCode("Microsoft.Windows.UI.Xaml.Build.Tasks", "4.0.0.0")]
    [DebuggerNonUserCode]
    public void Connect(int connectionId, object target)
    {
      switch (connectionId)
      {
        case 1:
          UIElement uiElement1 = (UIElement) target;
          WindowsRuntimeMarshal.AddEventHandler<PointerEventHandler>(new Func<PointerEventHandler, EventRegistrationToken>(uiElement1.add_PointerEntered), new Action<EventRegistrationToken>(uiElement1.remove_PointerEntered), new PointerEventHandler(this.Grid_PointerEntered));
          break;
        case 2:
          UIElement uiElement2 = (UIElement) target;
          WindowsRuntimeMarshal.AddEventHandler<TappedEventHandler>(new Func<TappedEventHandler, EventRegistrationToken>(uiElement2.add_Tapped), new Action<EventRegistrationToken>(uiElement2.remove_Tapped), new TappedEventHandler(this.SymbolIcon_Tapped));
          break;
        case 3:
          UIElement uiElement3 = (UIElement) target;
          WindowsRuntimeMarshal.AddEventHandler<PointerEventHandler>(new Func<PointerEventHandler, EventRegistrationToken>(uiElement3.add_PointerEntered), new Action<EventRegistrationToken>(uiElement3.remove_PointerEntered), new PointerEventHandler(this.Grid_PointerEntered));
          break;
        case 4:
          ButtonBase buttonBase1 = (ButtonBase) target;
          WindowsRuntimeMarshal.AddEventHandler<RoutedEventHandler>(new Func<RoutedEventHandler, EventRegistrationToken>(buttonBase1.add_Click), new Action<EventRegistrationToken>(buttonBase1.remove_Click), new RoutedEventHandler(this.Button_Click));
          break;
        case 5:
          MenuFlyoutItem menuFlyoutItem1 = (MenuFlyoutItem) target;
          WindowsRuntimeMarshal.AddEventHandler<RoutedEventHandler>(new Func<RoutedEventHandler, EventRegistrationToken>(menuFlyoutItem1.add_Click), new Action<EventRegistrationToken>(menuFlyoutItem1.remove_Click), new RoutedEventHandler(this.flayoutDeleteAudio_Click));
          break;
        case 6:
          MenuFlyoutItem menuFlyoutItem2 = (MenuFlyoutItem) target;
          WindowsRuntimeMarshal.AddEventHandler<RoutedEventHandler>(new Func<RoutedEventHandler, EventRegistrationToken>(menuFlyoutItem2.add_Click), new Action<EventRegistrationToken>(menuFlyoutItem2.remove_Click), new RoutedEventHandler(this.flayoutExportMusic_Click));
          break;
        case 7:
          UIElement uiElement4 = (UIElement) target;
          WindowsRuntimeMarshal.AddEventHandler<PointerEventHandler>(new Func<PointerEventHandler, EventRegistrationToken>(uiElement4.add_PointerEntered), new Action<EventRegistrationToken>(uiElement4.remove_PointerEntered), new PointerEventHandler(this.Grid_PointerEntered));
          break;
        case 8:
          ButtonBase buttonBase2 = (ButtonBase) target;
          WindowsRuntimeMarshal.AddEventHandler<RoutedEventHandler>(new Func<RoutedEventHandler, EventRegistrationToken>(buttonBase2.add_Click), new Action<EventRegistrationToken>(buttonBase2.remove_Click), new RoutedEventHandler(this.Button_Click));
          break;
        case 9:
          MenuFlyoutItem menuFlyoutItem3 = (MenuFlyoutItem) target;
          WindowsRuntimeMarshal.AddEventHandler<RoutedEventHandler>(new Func<RoutedEventHandler, EventRegistrationToken>(menuFlyoutItem3.add_Click), new Action<EventRegistrationToken>(menuFlyoutItem3.remove_Click), new RoutedEventHandler(this.flayoutDelete_Click));
          break;
        case 10:
          MenuFlyoutItem menuFlyoutItem4 = (MenuFlyoutItem) target;
          WindowsRuntimeMarshal.AddEventHandler<RoutedEventHandler>(new Func<RoutedEventHandler, EventRegistrationToken>(menuFlyoutItem4.add_Click), new Action<EventRegistrationToken>(menuFlyoutItem4.remove_Click), new RoutedEventHandler(this.flayoutExportVideo_Click));
          break;
      }
      this._contentLoaded = true;
    }
  }
}
