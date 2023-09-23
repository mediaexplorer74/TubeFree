// Decompiled with JetBrains decompiler
// Type: TubeFree8_1.Home
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
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.ApplicationModel.DataTransfer;
using Windows.ApplicationModel.Store;
using Windows.Foundation;
using Windows.Graphics.Display;
using Windows.Media.SpeechRecognition;
using Windows.Phone.UI.Input;
using Windows.System;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Markup;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Animation;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;
using YoutubeExplode;
using YoutubeExplode.Models;
using YoutubeExplode.Models.MediaStreams;

namespace TubeFree8_1
{
  [DesignerGenerated]
  public sealed class Home : Page, IComponentConnector
  {
    private string uriBrowser;
    private string richiestaLink;
    private StatusBar bar1;
    private SpeechRecognizer reco;
    private Video videoInformazioni;
    private bool _contentLoaded;

    [field: AccessedThroughProperty("banner")]
    private virtual AdControl banner { get; [MethodImpl((MethodImplOptions) 32)] set; }

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

    [field: AccessedThroughProperty("intersitial")]
    private virtual InterstitialAd intersitial { get; [MethodImpl((MethodImplOptions) 32)] set; }

    public Home()
    {
      WindowsRuntimeMarshal.AddEventHandler<RoutedEventHandler>(new Func<RoutedEventHandler, EventRegistrationToken>(((FrameworkElement) this).add_Loaded), new Action<EventRegistrationToken>(((FrameworkElement) this).remove_Loaded), new RoutedEventHandler(this.Home_Loaded));
      this.uriBrowser = "";
      this.richiestaLink = "LQ";
      this.bar1 = StatusBar.GetForCurrentView();
      this.banner = new AdControl();
      this.intersitial = new InterstitialAd();
      this.InitializeComponent();
      this.reco = new SpeechRecognizer();
    }

    private async void Home_Loaded(object sender, RoutedEventArgs e)
    {
      this.banner.ApplicationId = Convert.ToString((object) App.pubcenterAppID);
      this.banner.AdUnitId = Convert.ToString((object) App.pubcenterBannerID);
      ((FrameworkElement) this.banner).put_Width(320.0);
      ((FrameworkElement) this.banner).put_Height(50.0);
      this.banner.IsAutoRefreshEnabled = false;
      this.banner.IsBackgroundTransparent = true;
      ((FrameworkElement) this.banner).put_VerticalAlignment((VerticalAlignment) 2);
      WebView webBrowser1 = this.WebBrowser1;
      // ISSUE: method pointer
      WindowsRuntimeMarshal.AddEventHandler<TypedEventHandler<WebView, object>>(new Func<TypedEventHandler<WebView, object>, EventRegistrationToken>(webBrowser1.add_ContainsFullScreenElementChanged), new Action<EventRegistrationToken>(webBrowser1.remove_ContainsFullScreenElementChanged), new TypedEventHandler<WebView, object>((object) this, __methodptr(browser_fullscreen_changed)));
      if (!((ICollection<UIElement>) ((Panel) this.contenitore).Children).Contains((UIElement) this.banner))
        ((ICollection<UIElement>) ((Panel) this.contenitore).Children).Add((UIElement) this.banner);
      App.CreaCompatibilita();
    }

    private void browser_fullscreen_changed(WebView sender, object args)
    {
      RuntimeHelpers.GetObjectValue(args);
      if (sender.ContainsFullScreenElement)
      {
        ((UIElement) this.banner).put_Visibility((Visibility) 1);
        ((UIElement) this.BottomAppBar).put_Visibility((Visibility) 1);
      }
      else
      {
        DisplayInformation.put_AutoRotationPreferences((DisplayOrientations) 2);
        ((UIElement) this.banner).put_Visibility((Visibility) 0);
        ((UIElement) this.BottomAppBar).put_Visibility((Visibility) 0);
        try
        {
          this.banner.Resume();
        }
        catch (Exception ex)
        {
          ProjectData.SetProjectError(ex);
          ProjectData.ClearProjectError();
        }
      }
    }

    protected virtual void OnNavigatedFrom(NavigationEventArgs e)
    {
      WindowsRuntimeMarshal.RemoveEventHandler<EventHandler<object>>(new Action<EventRegistrationToken>(this.intersitial.remove_AdReady), new EventHandler<object>(this.ad_ready));
      WindowsRuntimeMarshal.RemoveEventHandler<EventHandler<AdErrorEventArgs>>(new Action<EventRegistrationToken>(this.intersitial.remove_ErrorOccurred), new EventHandler<AdErrorEventArgs>(this.ad_error));
      WindowsRuntimeMarshal.RemoveEventHandler<EventHandler<RoutedEventArgs>>(new Action<EventRegistrationToken>(this.banner.remove_AdRefreshed), new EventHandler<RoutedEventArgs>(this.ad_refreshed));
      WindowsRuntimeMarshal.RemoveEventHandler<EventHandler<AdErrorEventArgs>>(new Action<EventRegistrationToken>(this.banner.remove_ErrorOccurred), new EventHandler<AdErrorEventArgs>(this.ad_error_occurred));
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
      base.OnNavigatedFrom(e);
    }

    protected virtual async void OnNavigatedTo(NavigationEventArgs e)
    {
      InterstitialAd intersitial1 = this.intersitial;
      WindowsRuntimeMarshal.AddEventHandler<EventHandler<object>>(new Func<EventHandler<object>, EventRegistrationToken>(intersitial1.add_AdReady), new Action<EventRegistrationToken>(intersitial1.remove_AdReady), new EventHandler<object>(this.ad_ready));
      InterstitialAd intersitial2 = this.intersitial;
      WindowsRuntimeMarshal.AddEventHandler<EventHandler<AdErrorEventArgs>>(new Func<EventHandler<AdErrorEventArgs>, EventRegistrationToken>(intersitial2.add_ErrorOccurred), new Action<EventRegistrationToken>(intersitial2.remove_ErrorOccurred), new EventHandler<AdErrorEventArgs>(this.ad_error));
      AdControl banner1 = this.banner;
      WindowsRuntimeMarshal.AddEventHandler<EventHandler<RoutedEventArgs>>(new Func<EventHandler<RoutedEventArgs>, EventRegistrationToken>(banner1.add_AdRefreshed), new Action<EventRegistrationToken>(banner1.remove_AdRefreshed), new EventHandler<RoutedEventArgs>(this.ad_refreshed));
      AdControl banner2 = this.banner;
      WindowsRuntimeMarshal.AddEventHandler<EventHandler<AdErrorEventArgs>>(new Func<EventHandler<AdErrorEventArgs>, EventRegistrationToken>(banner2.add_ErrorOccurred), new Action<EventRegistrationToken>(banner2.remove_ErrorOccurred), new EventHandler<AdErrorEventArgs>(this.ad_error_occurred));
      WindowsRuntimeMarshal.AddEventHandler<EventHandler<BackPressedEventArgs>>(new Func<EventHandler<BackPressedEventArgs>, EventRegistrationToken>(HardwareButtons.add_BackPressed), new Action<EventRegistrationToken>(HardwareButtons.remove_BackPressed), new EventHandler<BackPressedEventArgs>(this.HardwareButtons_BackPressed));
      this.ctrlQ.InviaAzione += new VideoQ.InviaAzioneEventHandler(this.RiceviAzione);
      await this.bar1.HideAsync();
      DataTransferManager forCurrentView = DataTransferManager.GetForCurrentView();
      // ISSUE: method pointer
      WindowsRuntimeMarshal.AddEventHandler<TypedEventHandler<DataTransferManager, DataRequestedEventArgs>>(new Func<TypedEventHandler<DataTransferManager, DataRequestedEventArgs>, EventRegistrationToken>(forCurrentView.add_DataRequested), new Action<EventRegistrationToken>(forCurrentView.remove_DataRequested), new TypedEventHandler<DataTransferManager, DataRequestedEventArgs>((object) this, __methodptr(shareLinkTransfer)));
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

    private void HardwareButtons_BackPressed(object sender, BackPressedEventArgs e)
    {
      try
      {
        if (PageDownload.mediaPlayer != null)
        {
          if (PageDownload.mediaPlayer.IsFullWindow)
          {
            PageDownload.mediaPlayer.put_IsFullWindow(false);
            e.put_Handled(true);
            return;
          }
        }
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        ProjectData.ClearProjectError();
      }
      if (this.WebBrowser1.Source.AbsoluteUri.Contains("v="))
        ((Control) this.Share).put_IsEnabled(true);
      else
        ((Control) this.Share).put_IsEnabled(false);
      try
      {
        if (((CompositeTransform) ((UIElement) this.ctrlQ).RenderTransform).TranslateY >= -700.0)
        {
          ((UIElement) this.BottomAppBar).put_Visibility((Visibility) 0);
          this.MyStoryboard1.Begin();
          e.put_Handled(true);
        }
        else
        {
          ((ContentControl) MainPage.current.myFrame).Content.GetType();
          if (!((ContentControl) MainPage.current.myFrame).Content.GetType().Equals(typeof (Home)))
          {
            MainPage.current.myFrame.GoBack();
            this.WebBrowser1.Navigate(new Uri(this.uriBrowser));
            e.put_Handled(true);
            return;
          }
          if (Operators.CompareString(this.uriBrowser, "https://m.youtube.com/", false) == 0)
          {
            e.put_Handled(false);
            return;
          }
          if (this.WebBrowser1.CanGoBack)
          {
            e.put_Handled(true);
            this.WebBrowser1.GoBack();
          }
        }
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        ProjectData.ClearProjectError();
      }
      this.WebBrowser1.Refresh();
    }

    private async void WebBrowser1_FrameContentLoading(
      WebView sender,
      WebViewContentLoadingEventArgs args)
    {
      if (!args.Uri.AbsoluteUri.StartsWith("http"))
        return;
      this.uriBrowser = args.Uri.AbsoluteUri;
      try
      {
        if (args.Uri.AbsoluteUri.Contains("v="))
        {
          ListaQuality listaQuality = new ListaQuality();
          List<ModelQuality> modelQualityList = new List<ModelQuality>();
          ((Control) this.down).put_IsEnabled(true);
          ((Control) this.Share).put_IsEnabled(true);
          string[] strArray = args.Uri.AbsoluteUri.Split('=');
          HttpClient httpClient = new HttpClient();
          httpClient.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0 (Windows NT 6.3; WOW64; rv:55.0) Gecko/20100101 Firefox/55.0");
          YoutubeClient youtubeClient = new YoutubeClient(httpClient);
          Home home = this;
          Video videoInformazioni = home.videoInformazioni;
          home.videoInformazioni = await youtubeClient.GetVideoAsync(strArray[1]);
          home = (Home) null;
          MediaStreamInfoSet streamInfosAsync = await youtubeClient.GetVideoMediaStreamInfosAsync(strArray[1]);
          try
          {
            foreach (MuxedStreamInfo muxedStreamInfo in (IEnumerable<MuxedStreamInfo>) streamInfosAsync.Muxed)
            {
              ModelQuality modelQuality = new ModelQuality();
              modelQuality.VideoId = strArray[1];
              if (muxedStreamInfo.VideoQuality == VideoQuality.High720)
              {
                modelQuality.TypeQuality = "Video - 720p High Quality";
                modelQuality.UrlVideo = muxedStreamInfo.Url;
                modelQuality.Quality = "HD";
              }
              else if (muxedStreamInfo.VideoQuality == VideoQuality.Medium360 & muxedStreamInfo.Container == YoutubeExplode.Models.MediaStreams.Container.Mp4)
              {
                modelQuality.TypeQuality = "Video - 360p Medium Quality";
                modelQuality.UrlVideo = muxedStreamInfo.Url;
                modelQuality.Quality = "HQ";
              }
              if (modelQuality.UrlVideo != null & Operators.CompareString(modelQuality.UrlVideo, "", false) != 0)
                modelQualityList.Add(modelQuality);
            }
          }
          finally
          {
            IEnumerator<MuxedStreamInfo> enumerator;
            enumerator?.Dispose();
          }
          try
          {
            foreach (AudioStreamInfo audioStreamInfo in (IEnumerable<AudioStreamInfo>) streamInfosAsync.Audio)
            {
              ModelQuality modelQuality = new ModelQuality();
              if (audioStreamInfo.Itag == 140)
              {
                modelQuality.VideoId = strArray[1];
                modelQuality.Quality = "AUDIO";
                modelQuality.TypeQuality = "Audio - MP3";
                modelQuality.UrlVideo = audioStreamInfo.Url;
              }
              if (modelQuality.UrlVideo != null & Operators.CompareString(modelQuality.UrlVideo, "", false) != 0)
                modelQualityList.Add(modelQuality);
            }
          }
          finally
          {
            IEnumerator<AudioStreamInfo> enumerator;
            enumerator?.Dispose();
          }
          this.ctrlQ.title.put_Text(this.videoInformazioni.Title);
          this.ctrlQ.thumb.put_Source((ImageSource) new BitmapImage(new Uri(this.videoInformazioni.Thumbnails.MediumResUrl, UriKind.RelativeOrAbsolute)));
          this.ctrlQ.UrlImage = this.videoInformazioni.Thumbnails.MediumResUrl;
          ((ItemsControl) this.ctrlQ.listPickerQuality).put_ItemsSource((object) modelQualityList);
          ((UIElement) this.down).put_Visibility((Visibility) 0);
        }
        else
        {
          ((Control) this.Share).put_IsEnabled(false);
          ((Control) this.down).put_IsEnabled(false);
        }
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        ProjectData.ClearProjectError();
      }
    }

    private async void Speech_Click(object sender, RoutedEventArgs e)
    {
      try
      {
        SpeechRecognitionCompilationResult compilationResult = await this.reco.CompileConstraintsAsync();
        this.WebBrowser1.Navigate(new Uri("https://m.youtube.com/results?q=" + (await this.reco.RecognizeWithUIAsync()).Text));
        ((ToggleButton) this.speech).put_IsChecked(new bool?(false));
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        ProjectData.ClearProjectError();
      }
    }

    private void Home_Click(object sender, RoutedEventArgs e)
    {
      this.WebBrowser1.Navigate(new Uri("https://m.youtube.com/"));
      ((ToggleButton) this.home).put_IsChecked(new bool?(false));
    }

    private void Download_Click(object sender, RoutedEventArgs e)
    {
      ((UIElement) this.BottomAppBar).put_Visibility((Visibility) 1);
      this.MyStoryboard.Begin();
      ((ToggleButton) this.down).put_IsChecked(new bool?(false));
    }

    private async void RiceviAzione(VideoQ.Azione azione, ModelQuality quality)
    {
      if (azione == VideoQ.Azione.Scarica)
      {
        CoreDownload coreDownload1 = new CoreDownload(quality.UrlVideo, this.ctrlQ.title.Text);
        coreDownload1.TipoFile = Operators.CompareString(quality.Quality, "AUDIO", false) != 0 ? CoreDownload.Tipo.Youtube : CoreDownload.Tipo.Music;
        coreDownload1.Immagine = this.ctrlQ.UrlImage;
        coreDownload1.Finito += new CoreDownload.FinitoEventHandler(App.Fine);
        ((Collection<CoreDownload>) App.listaDownloading).Add(coreDownload1);
        if (!App.downloading)
        {
          App.downloading = true;
          coreDownload1.Scarica();
        }
        else
          App.CodaDownload.Enqueue(coreDownload1);
        CoreDownload coreDownload2 = new CoreDownload(this.ctrlQ.UrlImage, this.ctrlQ.title.Text);
        coreDownload2.TipoFile = CoreDownload.Tipo.Foto;
        coreDownload2.Immagine = this.ctrlQ.UrlImage;
        coreDownload2.Finito += new CoreDownload.FinitoEventHandler(App.Fine);
        if (!App.downloading)
        {
          App.downloading = true;
          coreDownload2.Scarica();
        }
        else
          App.CodaDownload.Enqueue(coreDownload2);
      }
      Application current = Application.Current;
      this.MyStoryboard1.Begin();
      ((UIElement) this.BottomAppBar).put_Visibility((Visibility) 0);
    }

    private void click_video_page(object sender, RoutedEventArgs e) => this.Frame.Navigate(typeof (PageDownload));

    private void click_settings(object sender, RoutedEventArgs e) => this.Frame.Navigate(typeof (Settings));

    private void Share_Click(object sender, RoutedEventArgs e) => DataTransferManager.ShowShareUI();

    private void shareLinkTransfer(DataTransferManager sender, DataRequestedEventArgs args)
    {
      try
      {
        args.Request.Data.Properties.put_Title(this.videoInformazioni.ToString());
        args.Request.Data.Properties.put_Description(this.videoInformazioni.Description);
        args.Request.Data.SetWebLink(new Uri(this.uriBrowser));
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        ProjectData.ClearProjectError();
      }
    }

    private async void rate_Click(object sender, RoutedEventArgs e)
    {
      int num = await Launcher.LaunchUriAsync(new Uri("ms-windows-store:reviewapp?appid=" + CurrentApp.AppId.ToString())) ? 1 : 0;
    }

    private void ad_error(object sender, AdErrorEventArgs e)
    {
    }

    private void ad_ready(object sender, object e) => this.intersitial.Show();

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

    [field: AccessedThroughProperty("botAppBar")]
    [field: GeneratedCode("Microsoft.Windows.UI.Xaml.Build.Tasks", "4.0.0.0")]
    private virtual CommandBar botAppBar { get; [MethodImpl((MethodImplOptions) 32)] set; }

    [field: AccessedThroughProperty("speech")]
    [field: GeneratedCode("Microsoft.Windows.UI.Xaml.Build.Tasks", "4.0.0.0")]
    private virtual AppBarToggleButton speech { get; [MethodImpl((MethodImplOptions) 32)] set; }

    [field: AccessedThroughProperty("home")]
    [field: GeneratedCode("Microsoft.Windows.UI.Xaml.Build.Tasks", "4.0.0.0")]
    private virtual AppBarToggleButton home { get; [MethodImpl((MethodImplOptions) 32)] set; }

    [field: AccessedThroughProperty("down")]
    [field: GeneratedCode("Microsoft.Windows.UI.Xaml.Build.Tasks", "4.0.0.0")]
    private virtual AppBarToggleButton down { get; [MethodImpl((MethodImplOptions) 32)] set; }

    private virtual AppBarButton Share
    {
      get => this._Share;
      [MethodImpl((MethodImplOptions) 32)] set
      {
        RoutedEventHandler routedEventHandler = new RoutedEventHandler(this.Share_Click);
        AppBarButton share1 = this._Share;
        if (share1 != null)
          WindowsRuntimeMarshal.RemoveEventHandler<RoutedEventHandler>(new Action<EventRegistrationToken>(((ButtonBase) share1).remove_Click), routedEventHandler);
        this._Share = value;
        AppBarButton share2 = this._Share;
        if (share2 == null)
          return;
        WindowsRuntimeMarshal.AddEventHandler<RoutedEventHandler>(new Func<RoutedEventHandler, EventRegistrationToken>(((ButtonBase) share2).add_Click), new Action<EventRegistrationToken>(((ButtonBase) share2).remove_Click), routedEventHandler);
      }
    }

    private virtual AppBarButton rate
    {
      get => this._rate;
      [MethodImpl((MethodImplOptions) 32)] set
      {
        RoutedEventHandler routedEventHandler = new RoutedEventHandler(this.rate_Click);
        AppBarButton rate1 = this._rate;
        if (rate1 != null)
          WindowsRuntimeMarshal.RemoveEventHandler<RoutedEventHandler>(new Action<EventRegistrationToken>(((ButtonBase) rate1).remove_Click), routedEventHandler);
        this._rate = value;
        AppBarButton rate2 = this._rate;
        if (rate2 == null)
          return;
        WindowsRuntimeMarshal.AddEventHandler<RoutedEventHandler>(new Func<RoutedEventHandler, EventRegistrationToken>(((ButtonBase) rate2).add_Click), new Action<EventRegistrationToken>(((ButtonBase) rate2).remove_Click), routedEventHandler);
      }
    }

    [field: AccessedThroughProperty("contenitore")]
    [field: GeneratedCode("Microsoft.Windows.UI.Xaml.Build.Tasks", "4.0.0.0")]
    private virtual Grid contenitore { get; [MethodImpl((MethodImplOptions) 32)] set; }

    [field: AccessedThroughProperty("MyStoryboard")]
    [field: GeneratedCode("Microsoft.Windows.UI.Xaml.Build.Tasks", "4.0.0.0")]
    private virtual Storyboard MyStoryboard { get; [MethodImpl((MethodImplOptions) 32)] set; }

    [field: AccessedThroughProperty("MyStoryboard1")]
    [field: GeneratedCode("Microsoft.Windows.UI.Xaml.Build.Tasks", "4.0.0.0")]
    private virtual Storyboard MyStoryboard1 { get; [MethodImpl((MethodImplOptions) 32)] set; }

    private virtual WebView WebBrowser1
    {
      get => this._WebBrowser1;
      [MethodImpl((MethodImplOptions) 32)] set
      {
        TypedEventHandler<WebView, WebViewContentLoadingEventArgs> typedEventHandler = new TypedEventHandler<WebView, WebViewContentLoadingEventArgs>((object) this, __methodptr(WebBrowser1_FrameContentLoading));
        WebView webBrowser1_1 = this._WebBrowser1;
        if (webBrowser1_1 != null)
          WindowsRuntimeMarshal.RemoveEventHandler<TypedEventHandler<WebView, WebViewContentLoadingEventArgs>>(new Action<EventRegistrationToken>(webBrowser1_1.remove_FrameContentLoading), typedEventHandler);
        this._WebBrowser1 = value;
        WebView webBrowser1_2 = this._WebBrowser1;
        if (webBrowser1_2 == null)
          return;
        WindowsRuntimeMarshal.AddEventHandler<TypedEventHandler<WebView, WebViewContentLoadingEventArgs>>(new Func<TypedEventHandler<WebView, WebViewContentLoadingEventArgs>, EventRegistrationToken>(webBrowser1_2.add_FrameContentLoading), new Action<EventRegistrationToken>(webBrowser1_2.remove_FrameContentLoading), typedEventHandler);
      }
    }

    [field: AccessedThroughProperty("ctrlQ")]
    [field: GeneratedCode("Microsoft.Windows.UI.Xaml.Build.Tasks", "4.0.0.0")]
    public virtual VideoQ ctrlQ { get; [MethodImpl((MethodImplOptions) 32)] set; }

    [GeneratedCode("Microsoft.Windows.UI.Xaml.Build.Tasks", "4.0.0.0")]
    [DebuggerNonUserCode]
    public void InitializeComponent()
    {
      if (this._contentLoaded)
        return;
      this._contentLoaded = true;
      Application.LoadComponent((object) this, new Uri("ms-appx:///Vista/Home.xaml"), (ComponentResourceLocation) 0);
      this.botAppBar = (CommandBar) ((FrameworkElement) this).FindName("botAppBar");
      this.speech = (AppBarToggleButton) ((FrameworkElement) this).FindName("speech");
      this.home = (AppBarToggleButton) ((FrameworkElement) this).FindName("home");
      this.down = (AppBarToggleButton) ((FrameworkElement) this).FindName("down");
      this.Share = (AppBarButton) ((FrameworkElement) this).FindName("Share");
      this.rate = (AppBarButton) ((FrameworkElement) this).FindName("rate");
      this.contenitore = (Grid) ((FrameworkElement) this).FindName("contenitore");
      this.MyStoryboard = (Storyboard) ((FrameworkElement) this).FindName("MyStoryboard");
      this.MyStoryboard1 = (Storyboard) ((FrameworkElement) this).FindName("MyStoryboard1");
      this.WebBrowser1 = (WebView) ((FrameworkElement) this).FindName("WebBrowser1");
      this.ctrlQ = (VideoQ) ((FrameworkElement) this).FindName("ctrlQ");
    }

    [GeneratedCode("Microsoft.Windows.UI.Xaml.Build.Tasks", "4.0.0.0")]
    [DebuggerNonUserCode]
    public void Connect(int connectionId, object target)
    {
      switch (connectionId)
      {
        case 1:
          ButtonBase buttonBase1 = (ButtonBase) target;
          WindowsRuntimeMarshal.AddEventHandler<RoutedEventHandler>(new Func<RoutedEventHandler, EventRegistrationToken>(buttonBase1.add_Click), new Action<EventRegistrationToken>(buttonBase1.remove_Click), new RoutedEventHandler(this.Speech_Click));
          break;
        case 2:
          ButtonBase buttonBase2 = (ButtonBase) target;
          WindowsRuntimeMarshal.AddEventHandler<RoutedEventHandler>(new Func<RoutedEventHandler, EventRegistrationToken>(buttonBase2.add_Click), new Action<EventRegistrationToken>(buttonBase2.remove_Click), new RoutedEventHandler(this.Home_Click));
          break;
        case 3:
          ButtonBase buttonBase3 = (ButtonBase) target;
          WindowsRuntimeMarshal.AddEventHandler<RoutedEventHandler>(new Func<RoutedEventHandler, EventRegistrationToken>(buttonBase3.add_Click), new Action<EventRegistrationToken>(buttonBase3.remove_Click), new RoutedEventHandler(this.Download_Click));
          break;
        case 4:
          ButtonBase buttonBase4 = (ButtonBase) target;
          WindowsRuntimeMarshal.AddEventHandler<RoutedEventHandler>(new Func<RoutedEventHandler, EventRegistrationToken>(buttonBase4.add_Click), new Action<EventRegistrationToken>(buttonBase4.remove_Click), new RoutedEventHandler(this.click_video_page));
          break;
        case 5:
          ButtonBase buttonBase5 = (ButtonBase) target;
          WindowsRuntimeMarshal.AddEventHandler<RoutedEventHandler>(new Func<RoutedEventHandler, EventRegistrationToken>(buttonBase5.add_Click), new Action<EventRegistrationToken>(buttonBase5.remove_Click), new RoutedEventHandler(this.click_settings));
          break;
      }
      this._contentLoaded = true;
    }
  }
}
