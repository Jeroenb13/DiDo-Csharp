using Microsoft.Graphics.Canvas;
using Microsoft.Graphics.Canvas.UI.Xaml;
using System;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Core;
using DiDo.GameElements;
//using DiDo.Levels;
using System.Collections.Generic;
using Windows.UI;
using Windows.System;
using System.Diagnostics;
using Windows.Graphics.Imaging;
using Windows.UI.Xaml.Media;
using DiDo.Levels;
// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace DiDo
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        // The images of the game
        public static CanvasBitmap BG, StartScreen, Level1, Level2, Level3, Bullet, Enemy1, Enemy2, Player;
        public static Rect bounds = ApplicationView.GetForCurrentView().VisibleBounds;
        public static float DesignWidth = 1280;
        public static float DesignHeight = 720;
        public static float scaleWidth, scaleHeight, pointX, pointY, bulletX, bulletY, playerX, playerY, currPosPlayerX, currPosPlayerY;

        public static int countdown = 60; // 60

        public static bool RoundEnded = false;

        //Lists Projectile
        public static List<float> bulletXPOS = new List<float>();
        public static List<float> bulletYPOS = new List<float>();
        public static List<float> percent = new List<float>();

        public static int GameState = 0; // startscreen

        public static DispatcherTimer RoundTimer = new DispatcherTimer();

        public static string keyPress;


        public MainPage()
        {
            this.InitializeComponent();
            Window.Current.SizeChanged += Current_SizeChanged;
            ImageManipulation.SetScale();
            
            RoundTimer.Tick += RoundTimer_Tick;
            RoundTimer.Interval = new TimeSpan(0, 0, 1);
            Window.Current.CoreWindow.KeyDown += CoreWindow_Keydown;
        }

        private void CoreWindow_Keydown(CoreWindow sender, KeyEventArgs args)
        {
            int move_speed = 5;

            //to do keylijst maken keylijst
            if (args.VirtualKey == VirtualKey.A)
            {
                playerX -= move_speed;
                keyPress = "A";
            }

            if (args.VirtualKey == VirtualKey.D)
            {
                playerX += move_speed;
                keyPress = "D";
            }

            if (args.VirtualKey == VirtualKey.W)
            {
                playerY -= move_speed;
                keyPress = "W";
            }

            if (args.VirtualKey == VirtualKey.S)
            {
                playerY += move_speed;
                keyPress = "S";
            }
        }

        private void RoundTimer_Tick(object sender, object e)
        {
            countdown -= 1;
            if (countdown < 1)
            {
                RoundTimer.Stop();
                RoundEnded = true;

            }
        }

        private void Current_SizeChanged(object sender, WindowSizeChangedEventArgs e)
        {
            bounds = ApplicationView.GetForCurrentView().VisibleBounds;
            ImageManipulation.SetScale();
        }

        private void GameCanvas_CreateResources(CanvasControl sender, Microsoft.Graphics.Canvas.UI.CanvasCreateResourcesEventArgs args)
        {
            foreach(Tile t in Levels.Levels.tiles.Values)
            {
                t.InitBitmap(sender);
            }
        }

        async Task CreateResourcesAsync(CanvasControl sender)
        {
            StartScreen = await CanvasBitmap.LoadAsync(sender, new Uri("ms-appx:///Assets/BG/level.png"));
            Level1 = await CanvasBitmap.LoadAsync(sender, new Uri("ms-appx:///Assets/BG/ingame.png"));
            Level2 = await CanvasBitmap.LoadAsync(sender, new Uri("ms-appx:///Assets/Bullets/drink-4.png"));
            Bullet = await CanvasBitmap.LoadAsync(sender, new Uri("ms-appx:///Assets/Bullets/drink-4.png"));
            Player = await CanvasBitmap.LoadAsync(sender, new Uri("ms-appx:///Assets/Char/spr_jeroen.png"));
        }

        private void GameCanvas_Draw(CanvasControl sender, CanvasDrawEventArgs args)
        {
            GameStateManager.GSManager();   

            GameCanvas.Invalidate();

            // Level
            // Herschrijven zodat het niet elke level opnieuw moet, en zorgen dat het in buffer komt.
            for (int x = 0; x < Levels.Levels.levelOne.GetLength(0); x += 1)
            {
                for (int y = 0; y < Levels.Levels.levelOne.GetLength(1); y += 1)
                {
                    string tileType = Levels.Levels.levelOne[x, y].ToString();
                    Tile tile = Levels.Levels.tiles[tileType];
                    args.DrawingSession.DrawImage(ImageManipulation.img(tile.Bitmap), y * (32 * MainPage.scaleWidth), x * (32 * MainPage.scaleHeight));
                }
            }

            // Player
            if (keyPress == "A")
            {
                args.DrawingSession.DrawImage(ImageManipulation.imageA(Player), playerX, playerY);
            }
            else if (keyPress == "S")
            {
                args.DrawingSession.DrawImage(ImageManipulation.imageS(Player), playerX, playerY);
            }
            else if (keyPress == "D")
            {
                args.DrawingSession.DrawImage(ImageManipulation.imageD(Player), playerX, playerY);
            }
            else
            {
               args.DrawingSession.DrawImage(ImageManipulation.imageW(Player), playerX, playerY);
            }

            // Bullets
            for (int i = 0; i < bulletXPOS.Count; i++)
            {
                bulletX = playerX + (40 * scaleWidth);
                bulletY = playerY + (40 * scaleHeight);

                pointX = (bulletX + (bulletXPOS[i] - bulletX) * percent[i]);
                pointY = (bulletY + (bulletYPOS[i] - bulletY) * percent[i]);

                args.DrawingSession.DrawImage(ImageManipulation.img(Bullet), pointX - (34 * scaleWidth), pointY - (34 * scaleWidth));

                percent[i] += (0.050f * scaleHeight);

                if (pointY < 0f || pointY > 1080 || pointX > 1920f || pointX < 0f)
                {
                    bulletXPOS.RemoveAt(i);
                    bulletYPOS.RemoveAt(i);
                    percent.RemoveAt(i);
                }
            }

            // Countdown
            args.DrawingSession.DrawImage(ImageManipulation.img(BG));
            args.DrawingSession.DrawText(countdown.ToString(), 100, 100, Colors.Yellow);

        }

        private void GameCanvas_Tapped(object sender, Windows.UI.Xaml.Input.TappedRoutedEventArgs e)
        {
            if (RoundEnded == true)
            {
                GameState = 0;
                RoundEnded = false;
                countdown = 60;
            }
            else
            {
                if (GameState == 0)
                {
                    GameState += 1;
                    RoundTimer.Start();
                }
                else if (GameState > 0)
                {
                    bulletXPOS.Add((float)e.GetPosition(GameCanvas).X);
                    bulletYPOS.Add((float)e.GetPosition(GameCanvas).Y);
                    percent.Add(0f);
                }
            }
        }
        private void GameCanvas_PointerMoved(object sender, Windows.UI.Xaml.Input.PointerRoutedEventArgs e)
        {
            Debug.WriteLine(e.GetCurrentPoint(GameCanvas).RawPosition.ToString());
        }
    }
}
