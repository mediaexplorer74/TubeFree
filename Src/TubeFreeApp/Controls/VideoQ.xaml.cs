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

// Документацию по шаблону элемента "Пользовательский элемент управления" см. по адресу https://go.microsoft.com/fwlink/?LinkId=234236

namespace TubeFreeApp
{
    public sealed partial class VideoQ : UserControl
    {
        public VideoQ()
        {
            this.InitializeComponent();
        }
    }
}

// Decompiled with JetBrains decompiler
// Type: TubeFreeApp.VideoQ
// Assembly: TubeFree8-1, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B4DCF786-D976-4451-B6A4-B664A1A9ABDC
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\TubeFree8-1.exe

using Microsoft.VisualBasic.CompilerServices;
using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Markup;

namespace TubeFreeApp
{
    [DesignerGenerated]
    public sealed class VideoQ : UserControl, IComponentConnector
    {
        private string _urlImg;
        private bool _contentLoaded;

        public event VideoQ.InviaAzioneEventHandler InviaAzione;

        public string UrlImage
        {
            get => this._urlImg;
            set => this._urlImg = value;
        }

        public VideoQ() => this.InitializeComponent();

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            // ISSUE: reference to a compiler-generated field
            VideoQ.InviaAzioneEventHandler inviaAzioneEvent = this.InviaAzioneEvent;
            if (inviaAzioneEvent == null)
                return;
            inviaAzioneEvent(VideoQ.Azione.Scarica, (ModelQuality)((Selector)this.listPickerQuality).SelectedItem);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            // ISSUE: reference to a compiler-generated field
            VideoQ.InviaAzioneEventHandler inviaAzioneEvent = this.InviaAzioneEvent;
            if (inviaAzioneEvent == null)
                return;
            inviaAzioneEvent(VideoQ.Azione.Cancella, (ModelQuality)null);
        }

        [field: AccessedThroughProperty("LayoutRoot")]
        [field: GeneratedCode("Microsoft.Windows.UI.Xaml.Build.Tasks", "4.0.0.0")]
        private virtual Grid LayoutRoot { get; [MethodImpl((MethodImplOptions)32)] set; }

        [field: AccessedThroughProperty("title")]
        [field: GeneratedCode("Microsoft.Windows.UI.Xaml.Build.Tasks", "4.0.0.0")]
        public virtual TextBlock title { get; [MethodImpl((MethodImplOptions)32)] set; }

        [field: AccessedThroughProperty("thumb")]
        [field: GeneratedCode("Microsoft.Windows.UI.Xaml.Build.Tasks", "4.0.0.0")]
        public virtual Image thumb { get; [MethodImpl((MethodImplOptions)32)] set; }

        [field: AccessedThroughProperty("listPickerQuality")]
        [field: GeneratedCode("Microsoft.Windows.UI.Xaml.Build.Tasks", "4.0.0.0")]
        public virtual ComboBox listPickerQuality { get; [MethodImpl((MethodImplOptions)32)] set; }

        [field: AccessedThroughProperty("btnDownload")]
        [field: GeneratedCode("Microsoft.Windows.UI.Xaml.Build.Tasks", "4.0.0.0")]
        private virtual Button btnDownload { get; [MethodImpl((MethodImplOptions)32)] set; }

        [field: AccessedThroughProperty("btnCancel")]
        [field: GeneratedCode("Microsoft.Windows.UI.Xaml.Build.Tasks", "4.0.0.0")]
        private virtual Button btnCancel { get; [MethodImpl((MethodImplOptions)32)] set; }

        [GeneratedCode("Microsoft.Windows.UI.Xaml.Build.Tasks", "4.0.0.0")]
        [DebuggerNonUserCode]
        public void InitializeComponent()
        {
            if (this._contentLoaded)
                return;
            this._contentLoaded = true;
            Application.LoadComponent((object)this, new Uri("ms-appx:///Controls/VideoQ.xaml"), (ComponentResourceLocation)0);
            this.LayoutRoot = (Grid)((FrameworkElement)this).FindName("LayoutRoot");
            this.title = (TextBlock)((FrameworkElement)this).FindName("title");
            this.thumb = (Image)((FrameworkElement)this).FindName("thumb");
            this.listPickerQuality = (ComboBox)((FrameworkElement)this).FindName("listPickerQuality");
            this.btnDownload = (Button)((FrameworkElement)this).FindName("btnDownload");
            this.btnCancel = (Button)((FrameworkElement)this).FindName("btnCancel");
        }

        [GeneratedCode("Microsoft.Windows.UI.Xaml.Build.Tasks", "4.0.0.0")]
        [DebuggerNonUserCode]
        public void Connect(int connectionId, object target)
        {
            switch (connectionId)
            {
                case 1:
                    ButtonBase buttonBase1 = (ButtonBase)target;
                    WindowsRuntimeMarshal.AddEventHandler<RoutedEventHandler>(new Func<RoutedEventHandler, EventRegistrationToken>(buttonBase1.add_Click), new Action<EventRegistrationToken>(buttonBase1.remove_Click), new RoutedEventHandler(this.Button_Click_2));
                    break;
                case 2:
                    ButtonBase buttonBase2 = (ButtonBase)target;
                    WindowsRuntimeMarshal.AddEventHandler<RoutedEventHandler>(new Func<RoutedEventHandler, EventRegistrationToken>(buttonBase2.add_Click), new Action<EventRegistrationToken>(buttonBase2.remove_Click), new RoutedEventHandler(this.Button_Click_1));
                    break;
            }
            this._contentLoaded = true;
        }

        public delegate void InviaAzioneEventHandler(VideoQ.Azione azione, ModelQuality quality);

        public enum Azione
        {
            Scarica,
            Cancella,
        }
    }
}

