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
    /// Character switch class
    /// </summary>
    public sealed partial class CharacterSwitch : Page
    {
        public static string PlayerCharacter { get; set; }
        public CharacterSwitch()
        {
            this.InitializeComponent();
        }

        private void Back_Tapped(object sender, TappedRoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(MenuPage));
        }

        private void HayriBtn_Tapped(object sender, TappedRoutedEventArgs e)
        {
            PlayerCharacter = "Hayri";
            this.Frame.Navigate(typeof(MainPage));
        }

        private void DaanBtn_Tapped(object sender, TappedRoutedEventArgs e)
        {
            PlayerCharacter = "Daan";
            this.Frame.Navigate(typeof(MainPage));

        }

        private void MaxBtn_Tapped(object sender, TappedRoutedEventArgs e)
        {
            PlayerCharacter = "Max";
            this.Frame.Navigate(typeof(MainPage));

        }

        private void MatthewBtn_Tapped(object sender, TappedRoutedEventArgs e)
        {
            PlayerCharacter = "Matthew";
            this.Frame.Navigate(typeof(MainPage));

        }

        private void JordyBtn_Tapped(object sender, TappedRoutedEventArgs e)
        {
            PlayerCharacter = "Jordy";
            this.Frame.Navigate(typeof(MainPage));

        }

        private void JeffreyBtn_Tapped(object sender, TappedRoutedEventArgs e)
        {
            PlayerCharacter = "Jeffrey";
            this.Frame.Navigate(typeof(MainPage));

        }

        private void JeroenBtn_Tapped(object sender, TappedRoutedEventArgs e)
        {
            PlayerCharacter = "Jeroen";
            this.Frame.Navigate(typeof(MainPage));

        }
    }
}
