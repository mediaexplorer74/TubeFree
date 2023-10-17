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

// Документацию по шаблону элемента "Пустая страница" см. по адресу https://go.microsoft.com/fwlink/?LinkId=234238
/*
namespace TubeFreeApp
{
    /// <summary>
    /// Пустая страница, которую можно использовать саму по себе или для перехода внутри фрейма.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }
    }
}*/
// Decompiled with JetBrains decompiler
// Type: TubeFree8_1.MainPage
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
using Windows.UI.Xaml.Navigation;
using TubeFreeApp;

namespace TubeFree8_1
{
    [DesignerGenerated]
    public sealed class MainPage : Page, IComponentConnector
    {
        public static MainPage current;
        private bool _contentLoaded;

        public MainPage()
        {
            WindowsRuntimeMarshal.AddEventHandler<RoutedEventHandler>(new Func<RoutedEventHandler, EventRegistrationToken>(((FrameworkElement)this).add_Loaded), new Action<EventRegistrationToken>(((FrameworkElement)this).remove_Loaded), new RoutedEventHandler(this.MainPage_Loaded));
            this.InitializeComponent();
        }

        private void MainPage_Loaded(object sender, RoutedEventArgs e)
        {
            this.myFrame.Navigate(typeof(Home));
            MainPage.current = this;
        }

        protected virtual async void OnNavigatedTo(NavigationEventArgs e) => base.OnNavigatedTo(e);

        [field: AccessedThroughProperty("LayoutRoot")]
        [field: GeneratedCode("Microsoft.Windows.UI.Xaml.Build.Tasks", "4.0.0.0")]
        private virtual Grid LayoutRoot { get; [MethodImpl((MethodImplOptions)32)] set; }

        [field: AccessedThroughProperty("myFrame")]
        [field: GeneratedCode("Microsoft.Windows.UI.Xaml.Build.Tasks", "4.0.0.0")]
        public virtual Frame myFrame { get; [MethodImpl((MethodImplOptions)32)] set; }

        [GeneratedCode("Microsoft.Windows.UI.Xaml.Build.Tasks", "4.0.0.0")]
        [DebuggerNonUserCode]
        public void InitializeComponent()
        {
            if (this._contentLoaded)
                return;
            this._contentLoaded = true;
            Application.LoadComponent((object)this, new Uri("ms-appx:///MainPage.xaml"), (ComponentResourceLocation)0);
            this.LayoutRoot = (Grid)((FrameworkElement)this).FindName("LayoutRoot");
            this.myFrame = (Frame)((FrameworkElement)this).FindName("myFrame");
        }

        [GeneratedCode("Microsoft.Windows.UI.Xaml.Build.Tasks", "4.0.0.0")]
        [DebuggerNonUserCode]
        public void Connect(int connectionId, object target) => this._contentLoaded = true;
    }
}

