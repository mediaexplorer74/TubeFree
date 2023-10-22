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
using TubeFreeApp;

namespace TubeFreeApp
{
    public sealed partial class MainPage : Page
    {
        //public static MainPage current;
        //private bool _contentLoaded;

        public MainPage()
        {
            //WindowsRuntimeMarshal.AddEventHandler<RoutedEventHandler>(
            //    new Func<RoutedEventHandler, EventRegistrationToken>(
            //        ((FrameworkElement)this).add_Loaded), 
            //    new Action<EventRegistrationToken>(((FrameworkElement)this).remove_Loaded), 
            //    new RoutedEventHandler(this.MainPage_Loaded));

            this.Loaded += MainPage_Loaded;
            this.InitializeComponent();
        }

        private void MainPage_Loaded(object sender, RoutedEventArgs e)
        {
            //this.myFrame.Navigate(typeof(Home));
            //MainPage.current = this;
            Frame.Navigate(typeof(Home));
        }

        //protected virtual async void OnNavigatedTo(NavigationEventArgs e)
        //  => base.OnNavigatedTo(e);


    }
}

