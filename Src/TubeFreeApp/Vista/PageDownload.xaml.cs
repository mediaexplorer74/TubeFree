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
using System.Runtime.CompilerServices;
using Windows.Graphics.Display;
using Windows.Media.Playback;
using Windows.Storage;
using Windows.Storage.Streams;
using Windows.UI.Popups;
using Windows.UI.Xaml.Markup;
using System.Threading;


namespace TubeFreeApp
{
    public  partial class PageDownload : Page
    {
        private DispatcherTimer _timerFullScreen;
        private Panel relPanel;
        private TimerFullScreen timerFullScreen;
        private DispatcherTimer timerPubli;
        private ListView _listVideo;

        public PageDownload()
        {
            this.InitializeComponent();
        }

      
        private void PageDownload_Loaded(object sender, RoutedEventArgs e)
        {
            ((ItemsControl)this.listViewTop).ItemsSource = (object)App.listaDownloading;
            ((ItemsControl)this.listMusic).ItemsSource = (object)App.listaMusica;
            ((ItemsControl)this.listVideo).ItemsSource = (object)App.listaVideo;
           
        }

        //[field: AccessedThroughProperty("mediaPlayer")]
        public static MediaElement mediaPlayer 
        { 
            get; 
            [MethodImpl((MethodImplOptions)32)] 
            set; 
        }


        private void media_MediaEnded(object sender, RoutedEventArgs e)
        {
            DisplayInformation.AutoRotationPreferences = (DisplayOrientations)2;
            ((ICollection<UIElement>)((Panel)this.relPanel).Children)
                .Remove((UIElement)PageDownload.mediaPlayer);

            //WindowsRuntimeMarshal.RemoveEventHandler<RoutedEventHandler>(
            //    new Action<EventRegistrationToken>(PageDownload.mediaPlayer.remove_MediaEnded), 
            //    new RoutedEventHandler(this.media_MediaEnded));

            PageDownload.mediaPlayer.MediaEnded -= this.media_MediaEnded;

            PageDownload.mediaPlayer = (MediaElement)null;
            ((Selector)this.listVideo).SelectedIndex = -1;
        }

        public void NormalScreen()
        {
            ((ICollection<UIElement>)((Panel)this.relPanel).Children)
                .Remove((UIElement)PageDownload.mediaPlayer);

            ((Selector)this.listVideo).SelectedIndex = -1;

            DisplayInformation.AutoRotationPreferences = (DisplayOrientations)2;
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

        private void SymbolIcon_Tapped(object sender, TappedRoutedEventArgs e)
        {
            ((CoreDownload)(sender as FrameworkElement).DataContext).Arresta();
        }

        private async void flayoutDelete_Click(object sender, RoutedEventArgs e)
        {
            object objectValue = 
                RuntimeHelpers.GetObjectValue(((FrameworkElement)sender).DataContext);

            StorageFolder folderAsync = await App.localFolder.GetFolderAsync(App.videoFolder);
            Exception exception = (Exception)null;
            try
            {
                await (await folderAsync.GetFileAsync(
                    Conversions.ToString(RuntimeHelpers.GetObjectValue(
                        NewLateBinding.LateGet(objectValue, (Type)null, "Nome",
                        new object[0], (string[])null, (Type[])null, (bool[])null)))))
                        .DeleteAsync();

                ((Collection<ModelFile>)App.listaVideo).Remove((ModelFile)objectValue);
            }
            catch (Exception ex)
            {
                ProjectData.SetProjectError(ex);
                exception = ex;
                ProjectData.ClearProjectError();
            }
            if (exception == null)
                return;
            IUICommand iuiCommand = await new MessageDialog
                ("An error has occurred", "Error").ShowAsync();
        }

        private async void flayoutExportVideo_Click(object sender, RoutedEventArgs e)
        {
            object objectValue = RuntimeHelpers.GetObjectValue(
                ((FrameworkElement)sender).DataContext);

            StorageFolder folderAsync = await App.localFolder.GetFolderAsync(App.videoFolder);
            Exception exception = (Exception)null;
            try
            {
                StorageFile storageFile = await (
                    await folderAsync.GetFileAsync(
                        Conversions.ToString(RuntimeHelpers.GetObjectValue(
                            NewLateBinding.LateGet(objectValue, (Type)null, "Nome", 
                            new object[0], (string[])null, (Type[])null, (bool[])null)))))
                            .CopyAsync((IStorageFolder)KnownFolders.VideosLibrary);
            }
            catch (Exception ex)
            {
                ProjectData.SetProjectError(ex);
                exception = ex;
                ProjectData.ClearProjectError();
            }
            if (exception == null)
                return;

            IUICommand iuiCommand = await new MessageDialog("An error has occurred",
                "Error").ShowAsync();
        }

        private async void flayoutExportMusic_Click(object sender, RoutedEventArgs e)
        {
            object objectValue =
                RuntimeHelpers.GetObjectValue(((FrameworkElement)sender).DataContext);

            StorageFolder folderAsync = await App.localFolder.GetFolderAsync(App.musicFolder);
            Exception exception = (Exception)null;
            try
            {
                StorageFile storageFile = await (
                    await folderAsync.GetFileAsync(Conversions.ToString(
                        RuntimeHelpers.GetObjectValue(
                            NewLateBinding.LateGet(objectValue, (Type)null, 
                            "Nome", new object[0], (string[])null, 
                            (Type[])null, (bool[])null)))))
                            .CopyAsync((IStorageFolder)KnownFolders.MusicLibrary);
            }
            catch (Exception ex)
            {
                ProjectData.SetProjectError(ex);
                exception = ex;
                ProjectData.ClearProjectError();
            }
            if (exception == null)
                return;
            IUICommand iuiCommand = await new MessageDialog("An error has occurred"
                , "Error").ShowAsync();
        }

        private async void flayoutDeleteAudio_Click(object sender, RoutedEventArgs e)
        {
            object objectValue = RuntimeHelpers.GetObjectValue(
                ((FrameworkElement)sender).DataContext);

            StorageFolder folderAsync = await App.localFolder.GetFolderAsync(App.musicFolder);
            Exception exception = (Exception)null;
            try
            {
                await (await folderAsync.GetFileAsync(
                    Conversions.ToString(RuntimeHelpers.GetObjectValue(
                        NewLateBinding.LateGet(objectValue, (Type)null,
                        "Nome", new object[0], (string[])null, 
                        (Type[])null, (bool[])null))))).DeleteAsync();

                ((Collection<ModelFile>)App.listaMusica).Remove(
                    (ModelFile)objectValue);
            }
            catch (Exception ex)
            {
                ProjectData.SetProjectError(ex);
                exception = ex;
                ProjectData.ClearProjectError();
            }
            if (exception == null)
                return;

            IUICommand iuiCommand = await new MessageDialog(
                "An error has occurred", "Error").ShowAsync();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //
        }

        private void listVideo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //
        }

        private async void listVideo_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                ModelFile clickedItem = (ModelFile)e.ClickedItem;
                PageDownload.mediaPlayer = new MediaElement();

                ((ICollection<UIElement>)((Panel)this.relPanel).Children)
                    .Add((UIElement)PageDownload.mediaPlayer);
                PageDownload.mediaPlayer.IsFullWindow = true;
                PageDownload.mediaPlayer.AreTransportControlsEnabled = true;
                MediaElement mediaPlayer = PageDownload.mediaPlayer;

                //WindowsRuntimeMarshal.AddEventHandler<RoutedEventHandler>
                //    (new Func<RoutedEventHandler, 
                //    EventRegistrationToken>(mediaPlayer.add_MediaEnded),
                //    new Action<EventRegistrationToken>(mediaPlayer.remove_MediaEnded),
                //    new RoutedEventHandler(this.media_MediaEnded));
                mediaPlayer.MediaEnded += this.media_MediaEnded;
                mediaPlayer.MediaEnded -= this.media_MediaEnded;

                StorageFile fileAsync = 
                    await (await App.localFolder.GetFolderAsync(App.videoFolder))
                    .GetFileAsync(clickedItem.Nome);

                IRandomAccessStreamWithContentType streamWithContentType 
                    = await fileAsync.OpenReadAsync();

                BackgroundMediaPlayer.Shutdown();
                PageDownload.mediaPlayer.SetSource(
                    (IRandomAccessStream)streamWithContentType, fileAsync.ContentType);

                DisplayInformation.AutoRotationPreferences = (DisplayOrientations)5;
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
            //EasyTracker.GetTracker().SendView("New Banner 8.1 New");
        }

        
        private void timerPubli_Tick(object sender, object e)
        {
            try
            {
                //this.banner.Refresh();
            }
            catch (Exception ex)
            {
                ProjectData.SetProjectError(ex);
                ProjectData.ClearProjectError();
            }
        }

        public virtual ListView listMusic 
        { 
            get; 
            [MethodImpl((MethodImplOptions)32)] 
            set; 
        }

        public virtual ListView listVideo
        {
            get => this._listVideo;
            [MethodImpl((MethodImplOptions)32)]
            set
            {
                SelectionChangedEventHandler changedEventHandler 
                    = new SelectionChangedEventHandler(this.listVideo_SelectionChanged);

                ItemClickEventHandler clickEventHandler
                    = new ItemClickEventHandler(this.listVideo_ItemClick);

                ListView listVideo1 = this._listVideo;

                if (listVideo1 != null)
                {
                    //    WindowsRuntimeMarshal.RemoveEventHandler<SelectionChangedEventHandler>(
                    //        new Action<EventRegistrationToken>(((Selector)listVideo1)
                    //        .remove_SelectionChanged), changedEventHandler);
                    //listVideo1.SelectionChanged -= clickEventHandler;

                    //    WindowsRuntimeMarshal.RemoveEventHandler<ItemClickEventHandler>(
                    //        new Action<EventRegistrationToken>(((ListViewBase)listVideo1)
                    //        .remove_ItemClick), clickEventHandler);
                    listVideo1.ItemClick -= clickEventHandler;
                }
                
                this._listVideo = value;
                ListView listVideo2 = this._listVideo;
             
                if (listVideo2 == null)
                    return;
              
               // WindowsRuntimeMarshal.AddEventHandler<SelectionChangedEventHandler>(
               //     new Func<SelectionChangedEventHandler, EventRegistrationToken>(
               //         ((Selector)listVideo2).add_SelectionChanged),
               //     new Action<EventRegistrationToken>(((Selector)listVideo2)
               //     .remove_SelectionChanged), changedEventHandler);

                //RnD
                //listVideo2.SelectionChanged += clickEventHandler;
                //listVideo2.SelectionChanged -= clickEventHandler;

                //WindowsRuntimeMarshal.AddEventHandler<ItemClickEventHandler>(
                //    new Func<ItemClickEventHandler, EventRegistrationToken>(
                //        ((ListViewBase)listVideo2).add_ItemClick), 
                //    new Action<EventRegistrationToken>(
                //        ((ListViewBase)listVideo2).remove_ItemClick), clickEventHandler);

                listVideo2.ItemClick += clickEventHandler;
                listVideo2.ItemClick -= clickEventHandler;
            }
        }

        public ItemsControl listViewTop { get; private set; }
    }//class end

    internal class TimerFullScreen
    {
        internal void Start()
        {
            throw new NotImplementedException();
        }

        internal void Stop()
        {
            throw new NotImplementedException();
        }
    }
}//namespace end
