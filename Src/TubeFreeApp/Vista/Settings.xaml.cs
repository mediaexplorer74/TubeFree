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
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Windows.ApplicationModel.Store;
using Windows.Storage;
using Windows.Storage.Streams;
using Windows.System;
using Windows.UI.Xaml.Markup;

namespace TubeFreeApp
{
    public sealed partial class Settings : Page
    {
        private ulong spaceUtilized;
        private bool _contentLoaded;
        private Button _btnRate;

        public Settings()
        {
            this.spaceUtilized = 0UL;

            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            this.CalcolaSpazioUtilizatto();
        }

        private async void CalcolaSpazioUtilizatto()
        {
            IReadOnlyList<StorageFile> filesAsync1 
                = await App.localFolder.GetFolderAsync(App.musicFolder)
                .AsTask<StorageFolder>().Result.GetFilesAsync();
            try
            {
                foreach (StorageFile storageFile in (IEnumerable<StorageFile>)filesAsync1)
                {
                    IRandomAccessStreamWithContentType streamWithContentType 
                        = await storageFile.OpenReadAsync();
                    // ISSUE: variable of a reference type
                    //ulong&local;
                    // ISSUE: explicit reference operation
                    //long num = (long)checked(^(local = ref this.spaceUtilized) 
                    //    + ((IRandomAccessStream)streamWithContentType).Size);
                    //local = (ulong)num;
                }
            }
            finally
            {
                IEnumerator<StorageFile> enumerator = default;
                enumerator?.Dispose();
            }
            IReadOnlyList<StorageFile> filesAsync2
                = await App.localFolder.GetFolderAsync(App.videoFolder)
                .AsTask<StorageFolder>().Result.GetFilesAsync();
            try
            {
                foreach (StorageFile storageFile in (IEnumerable<StorageFile>)filesAsync2)
                {
                    IRandomAccessStreamWithContentType streamWithContentType 
                        = await storageFile.OpenReadAsync();
                    // ISSUE: variable of a reference type
                    //ulong&local;
                    // ISSUE: explicit reference operation
                    //long num = (long)checked(^(local = ref this.spaceUtilized)
                    //  + ((IRandomAccessStream)streamWithContentType).Size);
                    //local = (ulong)num;
                }
            }
            finally
            {
                IEnumerator<StorageFile> enumerator = default;
                enumerator?.Dispose();
            }
            IReadOnlyList<StorageFile> filesAsync3 =
                await App.localFolder.GetFolderAsync(App.picturFolder)
                .AsTask<StorageFolder>().Result.GetFilesAsync();
            try
            {
                foreach (StorageFile storageFile in (IEnumerable<StorageFile>)filesAsync3)
                {
                    IRandomAccessStreamWithContentType streamWithContentType 
                        = await storageFile.OpenReadAsync();
                    // ISSUE: variable of a reference type
                    //ulong&local;
                    // ISSUE: explicit reference operation
                    //long num = (long)checked(^(local = ref this.spaceUtilized)
                    //+ ((IRandomAccessStream)streamWithContentType).Size);
                    //local = (ulong)num;
                }
            }
            finally
            {
                IEnumerator<StorageFile> enumerator = default;
                enumerator?.Dispose();
            }
            this.totalMB.Text = 
                (Conversions.ToString(checked((int)Math.Round(
                    Math.Round(unchecked((double)this.spaceUtilized / 1000000.0))))) + " MB");
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
        }

        private async void btnRate_Click(object sender, RoutedEventArgs e)
        {
            int num = await Launcher.LaunchUriAsync(new Uri("ms-windows-store:reviewapp?appid="
                + CurrentApp.AppId.ToString())) ? 1 : 0;
        }

        
        public Grid principale 
        { 
            get; 
            [MethodImpl((MethodImplOptions)32)] set; 
        }

        
        public StackPanel cont 
        { 
            get; 
            [MethodImpl((MethodImplOptions)32)] 
            set; 
        }

        public /*virtual*/ Button btnRate
        {
            get => this._btnRate;
            [MethodImpl((MethodImplOptions)32)]
            set
            {
                RoutedEventHandler routedEventHandler 
                    = new RoutedEventHandler(this.btnRate_Click);

                Button btnRate1 = this._btnRate;

                if (btnRate1 != null)
                {
                    // WindowsRuntimeMarshal.RemoveEventHandler<RoutedEventHandler>(
                    //     new Action<EventRegistrationToken>(((ButtonBase)btnRate1).remove_Click),
                    //     routedEventHandler);
                    btnRate1.Click -= routedEventHandler;
                }

                this._btnRate = value;
                Button btnRate2 = this._btnRate;

                if (btnRate2 == null)
                    return;

                //WindowsRuntimeMarshal.AddEventHandler<RoutedEventHandler>(
                //    new Func<RoutedEventHandler, EventRegistrationToken>(
                //        ((ButtonBase)btnRate2).add_Click),
                //    new Action<EventRegistrationToken>(((ButtonBase)btnRate2).remove_Click),
                //    routedEventHandler);
                btnRate2.Click += routedEventHandler;
                btnRate2.Click -= routedEventHandler;
            }
        }

       
        public /*override*/ TextBlock totalMB 
        { 
            get; 
            [MethodImpl((MethodImplOptions)32)] 
            set; 
        }      
     
    }
}

