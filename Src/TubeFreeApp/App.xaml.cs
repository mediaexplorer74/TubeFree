using System;
using System.Collections.Generic;
using Windows.ApplicationModel;
using Windows.ApplicationModel.Activation;
using Windows.Storage;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;
using Microsoft.VisualBasic.CompilerServices;
using System.CodeDom.Compiler;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Globalization;
using Windows.Storage.Streams;
using Windows.UI.Xaml.Markup;
using Windows.UI.Xaml.Media.Animation;



namespace TubeFreeApp
{
    /// <summary>
    /// Provides application-specific behavior to supplement the default Application class.
    /// </summary>
    sealed partial class App : Application
    {

        public static Queue<CoreDownload> CodaDownload = new Queue<CoreDownload>();
        public static ObservableCollection<CoreDownload> listaDownloading 
            = new ObservableCollection<CoreDownload>();
        public static bool downloading = false;
        public static StorageFolder localFolder = ApplicationData.Current.LocalFolder;
        public static string musicFolder = "music";
        public static string videoFolder = "video";
        public static string picturFolder = "foto";
        public static ObservableCollection<ModelFile> 
            listaMusica = new ObservableCollection<ModelFile>();
        public static ObservableCollection<ModelFile> 
            listaVideo = new ObservableCollection<ModelFile>();
        public static string pubcenterAppID = "9wzdncrd8hmp";
        public static string pubcenterBannerID = "1100051284";
        public static string idApplicationPubcenter = "9fc894b7-04fc-4888-8f33-5d8d9feba034";
        public static string unitIdPubcenter = "11655184";
        public static object smaatoAdSpace = (object)"130365042";
        public static object smaatoPublisherId = (object)"1100038379";
        private TransitionCollection _transitions;
        private bool _contentLoaded;
        //private XamlTypeInfoProvider _provider;



        /// <summary>
        /// Initializes the singleton application object.  This is the first line of authored code
        /// executed, and as such is the logical equivalent of main() or WinMain().
        /// </summary>
        public App()
        {
            InitializeComponent();

            Suspending += OnSuspending;

            /*WindowsRuntimeMarshal.AddEventHandler<SuspendingEventHandler>(
                new Func<SuspendingEventHandler, EventRegistrationToken>(
                    ((Application)this).add_Suspending),
                new Action<EventRegistrationToken>(((Application)this).remove_Suspending),
                new SuspendingEventHandler(this.OnSuspending));
            this.InitializeComponent();*/
        }

        /// <summary>
        /// Invoked when the application is launched normally by the end user.  Other entry points
        /// will be used such as when the application is launched to open a specific file.
        /// </summary>
        /// <param name="e">Details about the launch request and process.</param>
        protected override void OnLaunched(LaunchActivatedEventArgs e)
        {

            Frame rootFrame = Window.Current.Content as Frame;

            // Do not repeat app initialization when the Window already has content,
            // just ensure that the window is active
            if (rootFrame == null)
            {
                // Create a Frame to act as the navigation context and navigate to the first page
                rootFrame = new Frame();

                rootFrame.NavigationFailed += OnNavigationFailed;

                if (e.PreviousExecutionState == ApplicationExecutionState.Terminated)
                {
                    //TODO: Load state from previously suspended application
                }

                // Place the frame in the current Window
                Window.Current.Content = rootFrame;
            }

            if (rootFrame.Content == null)
            {
                // When the navigation stack isn't restored navigate to the first page,
                // configuring the new page by passing required information as a navigation
                // parameter
                rootFrame.Navigate(typeof(MainPage), e.Arguments);
            }
            // Ensure the current window is active
            Window.Current.Activate();
        }

        /// <summary>
        /// Invoked when Navigation to a certain page fails
        /// </summary>
        /// <param name="sender">The Frame which failed navigation</param>
        /// <param name="e">Details about the navigation failure</param>
        void OnNavigationFailed(object sender, NavigationFailedEventArgs e)
        {
            throw new Exception("Failed to load Page " + e.SourcePageType.FullName);
        }

        /// <summary>
        /// Invoked when application execution is being suspended.  Application state is saved
        /// without knowing whether the application will be terminated or resumed with the contents
        /// of memory still intact.
        /// </summary>
        /// <param name="sender">The source of the suspend request.</param>
        /// <param name="e">Details about the suspend request.</param>
        private void OnSuspending(object sender, SuspendingEventArgs e)
        {
            var deferral = e.SuspendingOperation.GetDeferral();
            //TODO: Save application state and stop any background activity
            deferral.Complete();
        }
        
        public static async void Fine(CoreDownload obj)
        {
            obj = (CoreDownload)null;
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

        /*
        protected virtual void OnLaunched(LaunchActivatedEventArgs e)
        {
            if (!(Window.Current.Content is Frame frame))
            {
                frame = new Frame();
                frame.CacheSize = (1);
                ((FrameworkElement)frame).Language = (ApplicationLanguages.Languages[0]);
                ApplicationExecutionState previousExecutionState = e.PreviousExecutionState;
                Window.Current.Content = ((UIElement)frame);
            }
            if (((ContentControl)frame).Content == null)
            {
                if (((ContentControl)frame).ContentTransitions != null)
                {
                    this._transitions = new TransitionCollection();
                    try
                    {
                        foreach (Transition contentTransition in (IEnumerable<Transition>)((ContentControl)frame).ContentTransitions)
                            ((ICollection<Transition>)this._transitions).Add(contentTransition);
                    }
                    finally
                    {
                        IEnumerator<Transition> enumerator;
                        enumerator?.Dispose();
                    }
                }
              ((ContentControl)frame).put_ContentTransitions((TransitionCollection)null);
                WindowsRuntimeMarshal.AddEventHandler<NavigatedEventHandler>(new Func<NavigatedEventHandler, EventRegistrationToken>(frame.add_Navigated), new Action<EventRegistrationToken>(frame.remove_Navigated), new NavigatedEventHandler(this.RootFrame_FirstNavigated));
                if (!frame.Navigate(typeof(MainPage), (object)e.Arguments))
                    throw new Exception("Failed to create initial page");
            }
            Window.Current.Activate();
            this.InizializzaCartelle();
        }
        */


        // RootFrame_FirstNavigated
        private void RootFrame_FirstNavigated(object sender, NavigationEventArgs e)
        {
            /*
            TransitionCollection transitionCollection;
            if (this._transitions == null)
            {
                transitionCollection = new TransitionCollection();
                ((ICollection<Transition>)transitionCollection).Add((Transition)new NavigationThemeTransition());
            }
            else
            {
                transitionCollection = this._transitions;
            }
            Frame frame = (Frame)sender;
            ((ContentControl)frame).put_ContentTransitions(transitionCollection);

            // ISSUE: virtual method pointer
            WindowsRuntimeMarshal.RemoveEventHandler<NavigatedEventHandler>(
                new Action<EventRegistrationToken>((object)frame, 
                __vmethodptr(frame, remove_Navigated)), 
                new NavigatedEventHandler(this.RootFrame_FirstNavigated));
            */
        }


        // CreaCompatibilita
        public static async void CreaCompatibilita()
        {
            try
            {
                IReadOnlyList<StorageFile> filesAsync = await
                    ((IStorageFolder)await App.localFolder.GetFolderAsync("downloaded"))
                    .GetFilesAsync();

                try
                {
                    foreach (StorageFile storageFile in (IEnumerable<StorageFile>)filesAsync)
                        await storageFile.MoveAsync((IStorageFolder)App.localFolder
                            .GetFolderAsync(App.musicFolder));
                }
                finally
                {
                    IEnumerator<StorageFile> enumerator = default;
                    enumerator?.Dispose();
                }
            }
            catch (Exception ex)
            {
                ProjectData.SetProjectError(ex);
                ProjectData.ClearProjectError();
            }
        }//CreaCompatibilita


        // InizializzaCartelle
        private async void InizializzaCartelle()
        {
            object itemAsync1 = default;
            try
            {
                itemAsync1 = (object)await App.localFolder.GetItemAsync("downloaded");
            }
            catch (Exception ex)
            {
                ProjectData.SetProjectError(ex);
                ProjectData.ClearProjectError();
            }
            if (itemAsync1 == null)
            {
                StorageFolder folderAsync1 = 
                    await App.localFolder.CreateFolderAsync("downloaded");
            }

            object itemAsync2 = default;

            try
            {
                itemAsync2 = (object)await App.localFolder.GetItemAsync(App.musicFolder);
            }
            catch (Exception ex)
            {
                ProjectData.SetProjectError(ex);
                ProjectData.ClearProjectError();
            }
            
            if (itemAsync2 == null)
            {
                StorageFolder folderAsync2 = 
                    await App.localFolder.CreateFolderAsync(App.musicFolder);
            }

            object itemAsync3 = default;
            try
            {
                itemAsync3 = 
                    (object)await App.localFolder.GetItemAsync(App.videoFolder);
            }
            catch (Exception ex)
            {
                ProjectData.SetProjectError(ex);
                ProjectData.ClearProjectError();
            }
            if (itemAsync3 == null)
            {
                StorageFolder folderAsync3 = 
                    await App.localFolder.CreateFolderAsync(App.videoFolder);
            }
            object itemAsync4 = default;
            try
            {
                itemAsync4 = (object)await App.localFolder.GetItemAsync(App.picturFolder);
            }
            catch (Exception ex)
            {
                ProjectData.SetProjectError(ex);
                ProjectData.ClearProjectError();
            }

            if (itemAsync4 == null)
            {
                StorageFolder folderAsync4 = 
                    await App.localFolder.CreateFolderAsync(App.picturFolder);
            }
            App.CaricaListaMusica();
            App.CaricaListaVideo();

            StorageFolder folderAsync = default;
            try
            {
                folderAsync = 
                    await ApplicationData.Current.LocalFolder.GetFolderAsync("playlists");
            }
            catch (Exception ex)
            {
                ProjectData.SetProjectError(ex);
                ProjectData.ClearProjectError();
            }

            if (folderAsync != null)
                return;

            folderAsync = 
                await ApplicationData.Current.LocalFolder.CreateFolderAsync("playlists");
        }//


        // CaricaListaMusica
        public static async void CaricaListaMusica()
        {
            IReadOnlyList<StorageFile> filesAsync =
                await App.localFolder.GetFolderAsync(App.musicFolder)
                .AsTask<StorageFolder>().Result.GetFilesAsync();
            try
            {
                ((Collection<ModelFile>)App.listaMusica).Clear();
                try
                {
                    foreach (StorageFile storageFile in (IEnumerable<StorageFile>)filesAsync)
                        ((Collection<ModelFile>)App.listaMusica).Add(new ModelFile()
                        {
                            Nome = storageFile.Name,
                            Immagine =
                            "ms-appdata:///local/" + 
                            App.picturFolder + "/" + 
                            storageFile.Name.Replace(".mp3", ".png"),
                            Size = Conversions.ToString(
                                Math.Round((double)((IRandomAccessStream)storageFile
                                .OpenReadAsync()
                                .AsTask<IRandomAccessStreamWithContentType>().Result).Size
                                / 1048576.0, 2))
                        });
                }
                finally
                {
                    IEnumerator<StorageFile> enumerator = default;
                    enumerator?.Dispose();
                }
            }
            catch (Exception ex)
            {
                ProjectData.SetProjectError(ex);
                ProjectData.ClearProjectError();
            }
        }//CaricaListaMusica

        // CaricaListaVideo
        public static async void CaricaListaVideo()
        {
            IReadOnlyList<StorageFile> filesAsync = 
                await App.localFolder.GetFolderAsync(App.videoFolder)
                .AsTask<StorageFolder>().Result.GetFilesAsync();
            try
            {
                ((Collection<ModelFile>)App.listaVideo).Clear();
                try
                {
                    foreach (StorageFile storageFile in (IEnumerable<StorageFile>)filesAsync)
                        ((Collection<ModelFile>)App.listaVideo).Add(new ModelFile()
                        {
                            Nome = storageFile.Name,
                            Immagine = "ms-appdata:///local/"
                            + App.picturFolder + "/" 
                            + storageFile.Name.Replace(".mp4", ".png"),
                            Size = Conversions.ToString(
                                Math.Round((double)((IRandomAccessStream)storageFile
                                .OpenReadAsync()
                                .AsTask<IRandomAccessStreamWithContentType>().Result).Size 
                                / 1048576.0, 2))
                        });
                }
                finally
                {
                    IEnumerator<StorageFile> enumerator = default;
                    enumerator?.Dispose();
                }
            }
            catch (Exception ex)
            {
                ProjectData.SetProjectError(ex);
                ProjectData.ClearProjectError();
            }

        }//CaricaListaVideo

    }//class end

}//namespace end

