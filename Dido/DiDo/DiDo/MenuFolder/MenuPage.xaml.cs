using DiDo.MenuFolder.Help;
using DiDo.MenuFolder.Settings;
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

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace DiDo.MenuFolder
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MenuPage : Page
    {
        FontFamily fffForward = new FontFamily("/Assets/FFFFORWARD.TTF#FFF Forward");
        public MenuPage()
        {
            this.InitializeComponent();

            Start.FontFamily = fffForward;
            Invade.FontFamily = fffForward;
            Settings.FontFamily = fffForward;
            Help.FontFamily = fffForward;
            Exit.FontFamily = fffForward;
        }
        private void Start_Tapped(object sender, TappedRoutedEventArgs e)
        {
            try
            {
                MainPage.countdown = 10;
                this.Frame.Navigate(typeof(MainPage));

            }
            catch (Exception ex)
            {
                var m = ex.Message;
            }
        }

        private void Invade_Tapped(object sender, TappedRoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(MainPage));
        }

        private async void Settings_Tapped(object sender, TappedRoutedEventArgs e)
        {
           
            this. Frame.Navigate(typeof(SettingPage), null);
        }

        private async void Help_Tapped(object sender, TappedRoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(HelpPage), null);
        }

        private void Exit_Tapped(object sender, TappedRoutedEventArgs e)
        {
            Application.Current.Exit();
        }

    
    }
}
