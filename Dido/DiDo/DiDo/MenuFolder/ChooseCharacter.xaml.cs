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
using Windows.UI.Xaml.Media.Animation;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace DiDo.MenuFolder
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class ChooseCharacter : Page
    {
        //Setup the variables
        public Uri daan = new Uri("ms-appx:///Assets/Char/Char_UI/Daan.png");
        public Uri jordy = new Uri("ms-appx:///Assets/Char/Char_UI/Jordy.png");
        public Uri jeroen = new Uri("ms-appx:///Assets/Char/Char_UI/Jeroen.png");
        public Uri jeffrey = new Uri("ms-appx:///Assets/Char/Char_UI/Jeffrey.png");
        public Uri hayri = new Uri("ms-appx:///Assets/Char/Char_UI/Hayri.png");
        public Uri max = new Uri("ms-appx:///Assets/Char/Char_UI/Max.png");
        public Uri matthew = new Uri("ms-appx:///Assets/Char/Char_UI/Matthew.png");
        public Uri samus = new Uri("ms-appx:///Assets/Char/Char_UI/samus.png");
        public static string PlayerCharacter { get; set; }
        private int currentIndex;
        public List<Uri> players = new List<Uri>();
        public List<BitmapImage> images = new List<BitmapImage>();

        public ChooseCharacter()
        {
            currentIndex = 0;
            this.InitializeComponent();
            addPlayer();
            getPlayer();
        }

        /// <summary>
        /// Method for getting the all the index numbers and setting them into a BitmapImage
        /// </summary>
        public void getPlayer()
        {
            for (int i = 0; i < players.Count; i++) //As long is i is smaller then the count of the list.
            {
                var source = new BitmapImage(players[i]); //Setting the index numbers into the BitmapImage
                images.Add(source); //Adding them to the List
            }

            img_Player.Source = images[currentIndex];
        }

        /// <summary>
        /// Method for adding the players into the List of Uri
        /// </summary>
        public void addPlayer()
        {
            players.Add(daan);
            players.Add(jordy);
            players.Add(jeroen);
            players.Add(jeffrey);
            players.Add(hayri);
            players.Add(max);
            players.Add(matthew);
            players.Add(samus);
        }

        private void btn_Left_Click(object sender, RoutedEventArgs e)
        { 
            if (currentIndex - 1 < 0) 
            {
                currentIndex = 7; //When the currentIndex is below 0, the currentIndex is set to 7
            }
            else
            {
                currentIndex--;
            }

            Debug.WriteLine(currentIndex);
            img_Player.Source = images[currentIndex]; //The Image object on the canvas is set each time the player clicks on the button
            
        }

        private void btn_Right_Click(object sender, RoutedEventArgs e)
        {
            if(currentIndex + 1 > 7)
            {
                currentIndex = 0;
            }
            else
            {
                currentIndex++;
            }
            Debug.WriteLine(currentIndex);
            img_Player.Source = images[currentIndex]; //The Image object on the canvas is set each time the player clicks on the button                
        }

        private void btn_ChoosePlayer_Click(object sender, RoutedEventArgs e)
        {
            //Switch the currentIndex to load the player into the game
            switch (currentIndex)
            {
                case 0:
                    PlayerCharacter = "Daan";
                    Frame.Navigate(typeof(MainPage));
                    break;

                case 1:
                    PlayerCharacter = "Jordy";
                    Frame.Navigate(typeof(MainPage));
                    break;

                case 2:
                    PlayerCharacter = "Jeroen";
                    Frame.Navigate(typeof(MainPage));
                    break;

                case 3:
                    PlayerCharacter = "Jeffrey";
                    Frame.Navigate(typeof(MainPage));
                    break;

                case 4:
                    PlayerCharacter = "Hayri";
                    Frame.Navigate(typeof(MainPage));
                    break;

                case 5:
                    PlayerCharacter = "Max";
                    Frame.Navigate(typeof(MainPage));
                    break;

                case 6:
                    PlayerCharacter = "Matthew";
                    Frame.Navigate(typeof(MainPage));
                    break;

                case 7:
                    PlayerCharacter = "Samus";
                    Frame.Navigate(typeof(MainPage));
                    break;

                default:
                    PlayerCharacter = "Hayri";
                    Frame.Navigate(typeof(MainPage));
                    break;
            }
        }

        private void btn_Back_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(MenuPage)); //Going back to the main menu
        }
    }
}
