using System;
using System.Collections.Generic;
using System.Diagnostics;
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
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace DiDo.MenuFolder
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class ChooseCharacter : Page
    {
        public Uri daan = new Uri("ms-appx:///Assets/Char/Char_UI/Daan.png");
        public Uri jordy = new Uri("ms-appx:///Assets/Char/Char_UI/Jordy.png");
        public Uri jeroen = new Uri("ms-appx:///Assets/Char/Char_UI/Jeroen.png");
        public Uri jeffrey = new Uri("ms-appx:///Assets/Char/Char_UI/Jeffrey.png");
        public Uri hayri = new Uri("ms-appx:///Assets/Char/Char_UI/Hayri.png");
        public Uri max = new Uri("ms-appx:///Assets/Char/Char_UI/Max.png");
        public Uri matthew = new Uri("ms-appx:///Assets/Char/Char_UI/Matthew.png");

        private int currentIndex;

        public List<Uri> players = new List<Uri>();

        public List<BitmapImage> images = new List<BitmapImage>();

        public ChooseCharacter()
        {
            this.InitializeComponent();
            addPlayer();
            getPlayer();
        }

        public void getPlayer()
        {
            for (int i = 0; i < players.Count; i++)
            {
                var source = new BitmapImage(players[i]);
                images.Add(source);
            }

            img_Player.Source = images[0];
        }

        public void addPlayer()
        {
            players.Add(daan);
            players.Add(jordy);
            players.Add(jeroen);
            players.Add(jeffrey);
            players.Add(hayri);
            players.Add(max);
            players.Add(matthew);
        }

        private void btn_Left_Click(object sender, RoutedEventArgs e)
        {
            currentIndex = players.Count;
            currentIndex--;
            img_Player.Source = images[currentIndex];
        }

        private void btn_Right_Click(object sender, RoutedEventArgs e)
        {
            if(currentIndex > 6)
            {
                currentIndex = 0;
            }
            currentIndex++;
            img_Player.Source = images[currentIndex];
        }
    }
}
