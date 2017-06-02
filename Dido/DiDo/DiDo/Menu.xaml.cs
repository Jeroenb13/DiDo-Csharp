using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace DiDo
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Menu : Page
    {
        public Menu()
        {
            this.InitializeComponent();
        }

        private void Start_Tapped(object sender, TappedRoutedEventArgs e)
        {

        }

        private void Invade_Tapped(object sender, TappedRoutedEventArgs e)
        {

        }

        private void Settings_Tapped(object sender, TappedRoutedEventArgs e)
        {

        }

        private void Help_Tapped(object sender, TappedRoutedEventArgs e)
        {

        }

        private void Exit_Tapped(object sender, TappedRoutedEventArgs e)
        {
            Application.Current.Exit();
        }

        private void Start_Holding(object sender, HoldingRoutedEventArgs e)
        {
            
        }

        private void Invade_Holding(object sender, HoldingRoutedEventArgs e)
        {

        }

        private void Settings_Holding(object sender, HoldingRoutedEventArgs e)
        {

        }

        private void Help_Holding(object sender, HoldingRoutedEventArgs e)
        {

        }

        private void Exit_Holding(object sender, HoldingRoutedEventArgs e)
        {

        }
    }
}
