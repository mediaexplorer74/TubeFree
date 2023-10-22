using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Microsoft.VisualBasic.CompilerServices;
using System.CodeDom.Compiler;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Net.Http;
using System.Runtime.CompilerServices;
using Windows.ApplicationModel.DataTransfer;
using Windows.ApplicationModel.Store;
using Windows.Graphics.Display;
using Windows.Media.SpeechRecognition;
using Windows.Phone.UI.Input;
using Windows.System;
using Windows.UI.ViewManagement;
//using Windows.UI.Xaml;
//using Windows.UI.Xaml.Controls;
//using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Markup;
using Windows.UI.Xaml.Media.Animation;
using Windows.UI.Xaml.Media.Imaging;
using YoutubeExplode;
using YoutubeExplode.Models;
using YoutubeExplode.Models.MediaStreams;

namespace TubeFreeApp
{
    public sealed partial class Home : Page//, IComponentConnector
    {
        private string uriBrowser;
        private string richiestaLink;
        //private StatusBar bar1;
        private SpeechRecognizer reco;
        private Video videoInformazioni;
        private bool _contentLoaded;
        private DispatcherTimer timerPubli;

        //[field: AccessedThroughProperty("banner")]
        //public virtual AdControl banner { get; set; }

        /*
        public virtual DispatcherTimer timerPubli
        {
            get
            {
                return this._timerPubli;
            }
                       
            set
            {
                EventHandler<object> eventHandler = new EventHandler<object>(
                    this.timerPubli_Tick);
                DispatcherTimer timerPubli1 = this._timerPubli;

                if (timerPubli1 != null)
                    WindowsRuntimeMarshal.RemoveEventHandler<EventHandler<object>>(
                        new Action<EventRegistrationToken>(timerPubli1.remove_Tick), eventHandler);
                this._timerPubli = value;
                DispatcherTimer timerPubli2 = this._timerPubli;
                if (timerPubli2 == null)
                    return;
                WindowsRuntimeMarshal.AddEventHandler<EventHandler<object>>(
                    new Func<EventHandler<object>, EventRegistrationToken>(timerPubli2.add_Tick), new Action<EventRegistrationToken>(timerPubli2.remove_Tick), eventHandler);
            }
        }
        */

        //[field: AccessedThroughProperty("intersitial")]
        //private virtual InterstitialAd intersitial
        //{ get; 
        //    [MethodImpl((MethodImplOptions)32)] 
        //  set; 
        //}

        public Home()
        {
            //WindowsRuntimeMarshal.AddEventHandler<RoutedEventHandler>(
            //    new Func<RoutedEventHandler, EventRegistrationToken>(
            //        ((FrameworkElement)this).add_Loaded), 
            //    new Action<EventRegistrationToken>(((FrameworkElement)this).remove_Loaded), 
            //    new RoutedEventHandler(this.Home_Loaded));
            this.uriBrowser = "";
            this.richiestaLink = "LQ";

            //this.bar1 = StatusBar.GetForCurrentView();
            
            //this.banner = new AdControl();
            //this.intersitial = new InterstitialAd();

            this.InitializeComponent();
            
            this.reco = new SpeechRecognizer();
        }

        private async void Home_Loaded(object sender, RoutedEventArgs e)
        {
            //this.banner.ApplicationId = Convert.ToString((object)App.pubcenterAppID);
            //this.banner.AdUnitId = Convert.ToString((object)App.pubcenterBannerID);
            
            //((FrameworkElement)this.banner).put_Width(320.0);
            //((FrameworkElement)this.banner).put_Height(50.0);
            
            //this.banner.IsAutoRefreshEnabled = false;
            //this.banner.IsBackgroundTransparent = true;
            //((FrameworkElement)this.banner).VerticalAlignment=((VerticalAlignment)2);
            
            WebView webBrowser1 = this.WebBrowser1;
            
            // ISSUE: method pointer
            WindowsRuntimeMarshal.AddEventHandler<TypedEventHandler<WebView, object>>(
                new Func<TypedEventHandler<WebView, object>, EventRegistrationToken>(
                    webBrowser1.add_ContainsFullScreenElementChanged), 
                new Action<EventRegistrationToken>(
                    webBrowser1.remove_ContainsFullScreenElementChanged),
                new TypedEventHandler<WebView, object>((object)this,
                __methodptr(browser_fullscreen_changed)));

            //if (!((ICollection<UIElement>)((Panel)this.contenitore).Children).Contains(
            //    (UIElement)this.banner))
            //{
            //    ((ICollection<UIElement>)((Panel)this.contenitore).Children).Add(
            //        (UIElement)this.banner);
            //}
            
            App.CreaCompatibilita();
        }

        private void browser_fullscreen_changed(WebView sender, object args)
        {
            RuntimeHelpers.GetObjectValue(args);
            if (sender.ContainsFullScreenElement)
            {
                //((UIElement)this.banner).Visibility = (Visibility)1;
                ((UIElement)this.BottomAppBar).Visibility =(Visibility)1;
            }
            else
            {
                DisplayInformation.AutoRotationPreferences = (DisplayOrientations)2;
                ((UIElement)this.banner).Visibility = (Visibility)0;
                ((UIElement)this.BottomAppBar).Visibility = ((Visibility)0);
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
            WindowsRuntimeMarshal.RemoveEventHandler<EventHandler<object>>(
                new Action<EventRegistrationToken>(this.intersitial.remove_AdReady),
                new EventHandler<object>(this.ad_ready));
            WindowsRuntimeMarshal.RemoveEventHandler<EventHandler<AdErrorEventArgs>>(
                new Action<EventRegistrationToken>(this.intersitial.remove_ErrorOccurred),
                new EventHandler<AdErrorEventArgs>(this.ad_error));
            WindowsRuntimeMarshal.RemoveEventHandler<EventHandler<RoutedEventArgs>>(
                new Action<EventRegistrationToken>(this.banner.remove_AdRefreshed),
                new EventHandler<RoutedEventArgs>(this.ad_refreshed));
            WindowsRuntimeMarshal.RemoveEventHandler<EventHandler<AdErrorEventArgs>>(
                new Action<EventRegistrationToken>(this.banner.remove_ErrorOccurred), 
                new EventHandler<AdErrorEventArgs>(this.ad_error_occurred));
            try
            {
                this.timerPubli.Stop();
                this.timerPubli = (DispatcherTimer)null;
            }
            catch (Exception ex)
            {
                ProjectData.SetProjectError(ex);
                ProjectData.ClearProjectError();
            }
            base.OnNavigatedFrom(e);
        }


        private void HardwareButtons_BackPressed(object sender, EventArgs e)
        {
            try
            {
                if (PageDownload.mediaPlayer != null)
                {
                    if (PageDownload.mediaPlayer.IsFullWindow)
                    {
                        PageDownload.mediaPlayer.IsFullWindow = (false);
                        
                        //e.Handled = (true);
                        
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
                ((Control)this.Share).IsEnabled = (true);
            else
                ((Control)this.Share).IsEnabled = (false);
            try
            {
                if (((CompositeTransform)(
                    (UIElement)this.ctrlQ).RenderTransform).TranslateY >= -700.0)
                {
                    ((UIElement)this.BottomAppBar).Visibility = ((Visibility)0);
                    this.MyStoryboard1.Begin();
                    //e.Handled = (true);
                }
                else
                {
                    ((ContentControl)MainPage.current.myFrame).Content.GetType();
                    if (!((ContentControl)MainPage.current.myFrame)
                        .Content.GetType().Equals(typeof(Home)))
                    {
                        MainPage.current.myFrame.GoBack();
                        this.WebBrowser1.Navigate(new Uri(this.uriBrowser));
                        //e.put_Handled(true);
                        return;
                    }
                    if (Operators.CompareString(this.uriBrowser,
                        "https://m.youtube.com/", false) == 0)
                    {
                        //e.put_Handled(false);
                        return;
                    }
                    if (this.WebBrowser1.CanGoBack)
                    {
                        //e.put_Handled(true);
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
                    ((Control)this.down).IsEnabled = (true);
                    ((Control)this.Share).IsEnabled = (true);
                    string[] strArray = args.Uri.AbsoluteUri.Split('=');
                    HttpClient httpClient = new HttpClient();

                    httpClient.DefaultRequestHeaders.Add("User-Agent", 
                        "Mozilla/5.0 (Windows NT 6.3; WOW64; rv:55.0) Gecko/20100101 Firefox/55.0");

                    YoutubeClient youtubeClient = new YoutubeClient(httpClient);
                    Home home = this;
                    Video videoInformazioni = home.videoInformazioni;

                    home.videoInformazioni = await youtubeClient.GetVideoAsync(strArray[1]);
                    home = (Home)null;
                    MediaStreamInfoSet streamInfosAsync = 
                        await youtubeClient.GetVideoMediaStreamInfosAsync(strArray[1]);

                    try
                    {
                        foreach (MuxedStreamInfo muxedStreamInfo
                            in (IEnumerable<MuxedStreamInfo>)streamInfosAsync.Muxed)
                        {
                            ModelQuality modelQuality = new ModelQuality();
                            modelQuality.VideoId = strArray[1];
                            if (muxedStreamInfo.VideoQuality == VideoQuality.High720)
                            {
                                modelQuality.TypeQuality = "Video - 720p High Quality";
                                modelQuality.UrlVideo = muxedStreamInfo.Url;
                                modelQuality.Quality = "HD";
                            }
                            else if (muxedStreamInfo.VideoQuality == VideoQuality.Medium360
                                & muxedStreamInfo.Container == YoutubeExplode.Models.MediaStreams.Container.Mp4)
                            {
                                modelQuality.TypeQuality = "Video - 360p Medium Quality";
                                modelQuality.UrlVideo = muxedStreamInfo.Url;
                                modelQuality.Quality = "HQ";
                            }
                            if (modelQuality.UrlVideo != null 
                                & Operators.CompareString(modelQuality.UrlVideo, "", false) != 0)
                                modelQualityList.Add(modelQuality);
                        }
                    }
                    finally
                    {
                        IEnumerator<MuxedStreamInfo> enumerator = default;
                        enumerator?.Dispose();
                    }
                    try
                    {
                        foreach (AudioStreamInfo audioStreamInfo
                            in (IEnumerable<AudioStreamInfo>)streamInfosAsync.Audio)
                        {
                            ModelQuality modelQuality = new ModelQuality();
                            if (audioStreamInfo.Itag == 140)
                            {
                                modelQuality.VideoId = strArray[1];
                                modelQuality.Quality = "AUDIO";
                                modelQuality.TypeQuality = "Audio - MP3";
                                modelQuality.UrlVideo = audioStreamInfo.Url;
                            }
                            if (modelQuality.UrlVideo != null
                                & Operators.CompareString(modelQuality.UrlVideo, "", false) != 0)
                                modelQualityList.Add(modelQuality);
                        }
                    }
                    finally
                    {
                        IEnumerator<AudioStreamInfo> enumerator = default;
                        enumerator?.Dispose();
                    }
                    this.ctrlQ.title.Text = 
                        (this.videoInformazioni.Title);
                    this.ctrlQ.thumb.Source = 
                        ((ImageSource)new BitmapImage(
                            new Uri(this.videoInformazioni.Thumbnails.MediumResUrl, 
                            UriKind.RelativeOrAbsolute)));

                    this.ctrlQ.UrlImage = this.videoInformazioni.Thumbnails.MediumResUrl;
                    ((ItemsControl)this.ctrlQ.listPickerQuality).ItemsSource = 
                        ((object)modelQualityList);

                    ((UIElement)this.down).Visibility = ((Visibility)0);
                }
                else
                {
                    ((Control)this.Share).IsEnabled = (false);
                    ((Control)this.down).IsEnabled = (false);
                }
            }
            catch (Exception ex)
            {
                ProjectData.SetProjectError(ex);
                ProjectData.ClearProjectError();
            }
        }

        // Speech_Click
        private async void Speech_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                SpeechRecognitionCompilationResult compilationResult = 
                    await this.reco.CompileConstraintsAsync();

                this.WebBrowser1.Navigate(new Uri("https://m.youtube.com/results?q=" 
                    + (await this.reco.RecognizeWithUIAsync()).Text));
                ((ToggleButton)this.speech).put_IsChecked(new bool?(false));
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
            ((ToggleButton)this.home).put_IsChecked(new bool?(false));
        }

        private void Download_Click(object sender, RoutedEventArgs e)
        {
            ((UIElement)this.BottomAppBar).put_Visibility((Visibility)1);
            this.MyStoryboard.Begin();
            ((ToggleButton)this.down).put_IsChecked(new bool?(false));
        }

        private async void RiceviAzione(VideoQ.Azione azione, ModelQuality quality)
        {
            if (azione == VideoQ.Azione.Scarica)
            {
                CoreDownload coreDownload1 = new CoreDownload(quality.UrlVideo, 
                    this.ctrlQ.title.Text);
                coreDownload1.TipoFile = Operators.CompareString(
                    quality.Quality, "AUDIO", false) != 0 
                    ? CoreDownload.Tipo.Youtube : CoreDownload.Tipo.Music;

                coreDownload1.Immagine = this.ctrlQ.UrlImage;
                coreDownload1.Finito += new CoreDownload.FinitoEventHandler(App.Fine);
                ((Collection<CoreDownload>)App.listaDownloading).Add(coreDownload1);
                if (!App.downloading)
                {
                    App.downloading = true;
                    coreDownload1.Scarica();
                }
                else
                {
                    App.CodaDownload.Enqueue(coreDownload1);
                }

                CoreDownload coreDownload2 = new CoreDownload(this.ctrlQ.UrlImage,
                    this.ctrlQ.title.Text);
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
            ((UIElement)this.BottomAppBar).Visibility((Visibility) = 0);
        }

        private void click_video_page(object sender, RoutedEventArgs e)
        { 
            this.Frame.Navigate(typeof(PageDownload));
        }

        private void click_settings(object sender, RoutedEventArgs e)
        { 
            this.Frame.Navigate(typeof(Settings)); 
        }

        private void Share_Click(object sender, RoutedEventArgs e)
        { 
            DataTransferManager.ShowShareUI(); 
        }

        private void shareLinkTransfer(DataTransferManager sender, DataRequestedEventArgs args)
        {
            try
            {
                args.Request.Data.Properties.Title = this.videoInformazioni.ToString();
                args.Request.Data.Properties.Description = this.videoInformazioni.Description;
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
            int num = await Launcher.LaunchUriAsync(
                new Uri("ms-windows-store:reviewapp?appid="
                + CurrentApp.AppId.ToString())) ? 1 : 0;
        }

        private void ad_error(object sender, AdErrorEventArgs e)
        {
        }

        private void ad_ready(object sender, object e)
        {
            this.intersitial.Show();
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
                
    }
}

