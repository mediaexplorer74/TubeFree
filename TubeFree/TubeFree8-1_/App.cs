// Decompiled with JetBrains decompiler
// Type: TubeFree8_1.App
// Assembly: TubeFree8-1, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B4DCF786-D976-4451-B6A4-B664A1A9ABDC
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\TubeFree8-1.exe

using Microsoft.VisualBasic.CompilerServices;
using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Runtime.InteropServices.WindowsRuntime;
using TubeFree8_1.TubeFree8_1_XamlTypeInfo;
using Windows.ApplicationModel;
using Windows.ApplicationModel.Activation;
using Windows.Globalization;
using Windows.Storage;
using Windows.Storage.Streams;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Markup;
using Windows.UI.Xaml.Media.Animation;
using Windows.UI.Xaml.Navigation;

namespace TubeFree8_1
{
  [DesignerGenerated]
  [GeneratedCode("Microsoft.Windows.UI.Xaml.Build.Tasks", "4.0.0.0")]
  public sealed class App : Application, IComponentConnector, IXamlMetadataProvider
  {
    public static Queue<CoreDownload> CodaDownload = new Queue<CoreDownload>();
    public static ObservableCollection<CoreDownload> listaDownloading = new ObservableCollection<CoreDownload>();
    public static bool downloading = false;
    public static StorageFolder localFolder = ApplicationData.Current.LocalFolder;
    public static string musicFolder = "music";
    public static string videoFolder = "video";
    public static string picturFolder = "foto";
    public static ObservableCollection<ModelFile> listaMusica = new ObservableCollection<ModelFile>();
    public static ObservableCollection<ModelFile> listaVideo = new ObservableCollection<ModelFile>();
    public static string pubcenterAppID = "9wzdncrd8hmp";
    public static string pubcenterBannerID = "1100051284";
    public static string idApplicationPubcenter = "9fc894b7-04fc-4888-8f33-5d8d9feba034";
    public static string unitIdPubcenter = "11655184";
    public static object smaatoAdSpace = (object) "130365042";
    public static object smaatoPublisherId = (object) "1100038379";
    private TransitionCollection _transitions;
    private bool _contentLoaded;
    private XamlTypeInfoProvider _provider;

    public static async void Fine(CoreDownload obj)
    {
      obj = (CoreDownload) null;
      if (App.CodaDownload.Count > 0)
      {
        CoreDownload coreDownload = App.CodaDownload.Dequeue();
        try
        {
          await coreDownload.Scarica();
        }
        catch (Exception ex)
        {
          ProjectData.SetProjectError(ex);
          ProjectData.ClearProjectError();
        }
      }
      App.CaricaListaMusica();
      App.CaricaListaVideo();
    }

    public App()
    {
      WindowsRuntimeMarshal.AddEventHandler<SuspendingEventHandler>(new Func<SuspendingEventHandler, EventRegistrationToken>(((Application) this).add_Suspending), new Action<EventRegistrationToken>(((Application) this).remove_Suspending), new SuspendingEventHandler(this.OnSuspending));
      this.InitializeComponent();
    }

    protected virtual void OnLaunched(LaunchActivatedEventArgs e)
    {
      if (!(Window.Current.Content is Frame frame))
      {
        frame = new Frame();
        frame.put_CacheSize(1);
        ((FrameworkElement) frame).put_Language(ApplicationLanguages.Languages[0]);
        ApplicationExecutionState previousExecutionState = e.PreviousExecutionState;
        Window.Current.put_Content((UIElement) frame);
      }
      if (((ContentControl) frame).Content == null)
      {
        if (((ContentControl) frame).ContentTransitions != null)
        {
          this._transitions = new TransitionCollection();
          try
          {
            foreach (Transition contentTransition in (IEnumerable<Transition>) ((ContentControl) frame).ContentTransitions)
              ((ICollection<Transition>) this._transitions).Add(contentTransition);
          }
          finally
          {
            IEnumerator<Transition> enumerator;
            enumerator?.Dispose();
          }
        }
        ((ContentControl) frame).put_ContentTransitions((TransitionCollection) null);
        WindowsRuntimeMarshal.AddEventHandler<NavigatedEventHandler>(new Func<NavigatedEventHandler, EventRegistrationToken>(frame.add_Navigated), new Action<EventRegistrationToken>(frame.remove_Navigated), new NavigatedEventHandler(this.RootFrame_FirstNavigated));
        if (!frame.Navigate(typeof (MainPage), (object) e.Arguments))
          throw new Exception("Failed to create initial page");
      }
      Window.Current.Activate();
      this.InizializzaCartelle();
    }

    private void RootFrame_FirstNavigated(object sender, NavigationEventArgs e)
    {
      TransitionCollection transitionCollection;
      if (this._transitions == null)
      {
        transitionCollection = new TransitionCollection();
        ((ICollection<Transition>) transitionCollection).Add((Transition) new NavigationThemeTransition());
      }
      else
        transitionCollection = this._transitions;
      Frame frame = (Frame) sender;
      ((ContentControl) frame).put_ContentTransitions(transitionCollection);
      // ISSUE: virtual method pointer
      WindowsRuntimeMarshal.RemoveEventHandler<NavigatedEventHandler>(new Action<EventRegistrationToken>((object) frame, __vmethodptr(frame, remove_Navigated)), new NavigatedEventHandler(this.RootFrame_FirstNavigated));
    }

    private void OnSuspending(object sender, SuspendingEventArgs e) => e.SuspendingOperation.GetDeferral().Complete();

    public static async void CreaCompatibilita()
    {
      try
      {
        IReadOnlyList<StorageFile> filesAsync = await ((IStorageFolder) await App.localFolder.GetFolderAsync("downloaded")).GetFilesAsync();
        try
        {
          foreach (StorageFile storageFile in (IEnumerable<StorageFile>) filesAsync)
            await storageFile.MoveAsync((IStorageFolder) App.localFolder.GetFolderAsync(App.musicFolder));
        }
        finally
        {
          IEnumerator<StorageFile> enumerator;
          enumerator?.Dispose();
        }
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        ProjectData.ClearProjectError();
      }
    }

    private async void InizializzaCartelle()
    {
      object itemAsync1;
      try
      {
        itemAsync1 = (object) await App.localFolder.GetItemAsync("downloaded");
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        ProjectData.ClearProjectError();
      }
      if (itemAsync1 == null)
      {
        StorageFolder folderAsync1 = await App.localFolder.CreateFolderAsync("downloaded");
      }
      object itemAsync2;
      try
      {
        itemAsync2 = (object) await App.localFolder.GetItemAsync(App.musicFolder);
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        ProjectData.ClearProjectError();
      }
      if (itemAsync2 == null)
      {
        StorageFolder folderAsync2 = await App.localFolder.CreateFolderAsync(App.musicFolder);
      }
      object itemAsync3;
      try
      {
        itemAsync3 = (object) await App.localFolder.GetItemAsync(App.videoFolder);
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        ProjectData.ClearProjectError();
      }
      if (itemAsync3 == null)
      {
        StorageFolder folderAsync3 = await App.localFolder.CreateFolderAsync(App.videoFolder);
      }
      object itemAsync4;
      try
      {
        itemAsync4 = (object) await App.localFolder.GetItemAsync(App.picturFolder);
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        ProjectData.ClearProjectError();
      }
      if (itemAsync4 == null)
      {
        StorageFolder folderAsync4 = await App.localFolder.CreateFolderAsync(App.picturFolder);
      }
      App.CaricaListaMusica();
      App.CaricaListaVideo();
      StorageFolder folderAsync;
      try
      {
        folderAsync = await ApplicationData.Current.LocalFolder.GetFolderAsync("playlists");
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        ProjectData.ClearProjectError();
      }
      if (folderAsync != null)
        return;
      folderAsync = await ApplicationData.Current.LocalFolder.CreateFolderAsync("playlists");
    }

    public static async void CaricaListaMusica()
    {
      IReadOnlyList<StorageFile> filesAsync = await App.localFolder.GetFolderAsync(App.musicFolder).AsTask<StorageFolder>().Result.GetFilesAsync();
      try
      {
        ((Collection<ModelFile>) App.listaMusica).Clear();
        try
        {
          foreach (StorageFile storageFile in (IEnumerable<StorageFile>) filesAsync)
            ((Collection<ModelFile>) App.listaMusica).Add(new ModelFile()
            {
              Nome = storageFile.Name,
              Immagine = "ms-appdata:///local/" + App.picturFolder + "/" + storageFile.Name.Replace(".mp3", ".png"),
              Size = Conversions.ToString(Math.Round((double) ((IRandomAccessStream) storageFile.OpenReadAsync().AsTask<IRandomAccessStreamWithContentType>().Result).Size / 1048576.0, 2))
            });
        }
        finally
        {
          IEnumerator<StorageFile> enumerator;
          enumerator?.Dispose();
        }
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        ProjectData.ClearProjectError();
      }
    }

    public static async void CaricaListaVideo()
    {
      IReadOnlyList<StorageFile> filesAsync = await App.localFolder.GetFolderAsync(App.videoFolder).AsTask<StorageFolder>().Result.GetFilesAsync();
      try
      {
        ((Collection<ModelFile>) App.listaVideo).Clear();
        try
        {
          foreach (StorageFile storageFile in (IEnumerable<StorageFile>) filesAsync)
            ((Collection<ModelFile>) App.listaVideo).Add(new ModelFile()
            {
              Nome = storageFile.Name,
              Immagine = "ms-appdata:///local/" + App.picturFolder + "/" + storageFile.Name.Replace(".mp4", ".png"),
              Size = Conversions.ToString(Math.Round((double) ((IRandomAccessStream) storageFile.OpenReadAsync().AsTask<IRandomAccessStreamWithContentType>().Result).Size / 1048576.0, 2))
            });
        }
        finally
        {
          IEnumerator<StorageFile> enumerator;
          enumerator?.Dispose();
        }
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        ProjectData.ClearProjectError();
      }
    }

    [GeneratedCode("Microsoft.Windows.UI.Xaml.Build.Tasks", "4.0.0.0")]
    [DebuggerNonUserCode]
    public void InitializeComponent()
    {
      if (this._contentLoaded)
        return;
      this._contentLoaded = true;
    }

    [GeneratedCode("Microsoft.Windows.UI.Xaml.Build.Tasks", "4.0.0.0")]
    [DebuggerNonUserCode]
    public void Connect(int connectionId, object target) => this._contentLoaded = true;

    public IXamlType GetXamlType(Type type)
    {
      if (this._provider == null)
        this._provider = new XamlTypeInfoProvider();
      return this._provider.GetXamlTypeByType(type);
    }

    public IXamlType GetXamlType(string fullName)
    {
      if (this._provider == null)
        this._provider = new XamlTypeInfoProvider();
      return this._provider.GetXamlTypeByName(fullName);
    }

    public XmlnsDefinition[] GetXmlnsDefinitions() => new XmlnsDefinition[0];
  }
}
