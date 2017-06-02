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
        public static float scaleWidth, scaleHeight, pointX, pointY;

        public static int countdown = 60; // 60

        public static bool RoundEnded = false;

        private bool assetsLoaded = false;

        //Lists Projectile
        public List<Bullet> bullets = new List<Bullet>();

        public static int GameState = 0; // startscreen

        public static DispatcherTimer RoundTimer = new DispatcherTimer();

        public static string keyPress;

        public Player player = new DiDo.Player(0, 0);

        public String level = "levelOne";
        public int levelGenerated = 0;


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
                player.x -= move_speed;
                keyPress = "A";
            }

            if (args.VirtualKey == VirtualKey.D)
            {
                player.x += move_speed;
                keyPress = "D";
            }

            if (args.VirtualKey == VirtualKey.W)
            {
                player.y -= move_speed;
                keyPress = "W";
            }

            if (args.VirtualKey == VirtualKey.S)
            {
                player.y += move_speed;
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
            args.TrackAsyncAction(CreateResourcesAsync(sender).AsAsyncAction());
        }

        async Task CreateResourcesAsync(CanvasControl sender)
        {
            StartScreen = await CanvasBitmap.LoadAsync(sender, new Uri("ms-appx:///Assets/BG/level.png"));
            Level1 = await CanvasBitmap.LoadAsync(sender, new Uri("ms-appx:///Assets/BG/ingame.png"));
            Level2 = await CanvasBitmap.LoadAsync(sender, new Uri("ms-appx:///Assets/Bullets/drink-4.png"));
            Bullet = await CanvasBitmap.LoadAsync(sender, new Uri("ms-appx:///Assets/Bullets/drink-4.png"));
            Player = await CanvasBitmap.LoadAsync(sender, new Uri("ms-appx:///Assets/Char/spr_jeroen.png"));

            foreach (Tile t in Levels.Levels.tiles.Values)
            {
                await t.InitBitmap(sender).AsAsyncAction();
            }
        }

        private void GameCanvas_Draw(CanvasControl sender, CanvasDrawEventArgs args)
        {
            GameStateManager.GSManager();   

            GameCanvas.Invalidate();
            
            // Level
            //if(this.levelGenerated == 0) // Zorgen dat de level maar 1 keer generated word
            //{
                var gekozenLevel = Levels.Levels.levelOne; // Dit later ook aanpassen
                for (int x = 0; x < gekozenLevel.GetLength(0); x += 1)
                {
                    for (int y = 0; y < gekozenLevel.GetLength(1); y += 1)
                    {
                        string tileType = gekozenLevel[x, y].ToString();
                        Tile tile = Levels.Levels.tiles[tileType];
                        args.DrawingSession.DrawImage(
                            tile.Effect,
                            y * (32 * MainPage.scaleWidth),
                            x * (32 * MainPage.scaleHeight)
                        );

                    }
                }
                this.levelGenerated = 1;
            //}
            

            // Player
            if (keyPress == "A")
            {
                args.DrawingSession.DrawImage(ImageManipulation.imageA(Player), player.x, player.y);
            }
            else if (keyPress == "S")
            {
                args.DrawingSession.DrawImage(ImageManipulation.imageS(Player), player.x, player.y);
            }
            else if (keyPress == "D")
            {
                args.DrawingSession.DrawImage(ImageManipulation.imageD(Player), player.x, player.y);
            }
            else
            {
                args.DrawingSession.DrawImage(ImageManipulation.imageW(Player), player.x, player.y);
            }

            List<Bullet> bulletsToRemove = new List<Bullet>();

            // Display projectiles
            foreach (Bullet bullet in bullets)
            {
                bullet.x += bullet.velX;
                bullet.y += bullet.velY;
                args.DrawingSession.DrawImage(ImageManipulation.img(Bullet), bullet.x, bullet.y);

                if (bullet.y < 0f || bullet.y > 1080 || bullet.x > 1920f || bullet.x < 0f)
                {
                    bulletsToRemove.Add(bullet);
                }
            }

            foreach (Bullet bullet in bulletsToRemove)
            {
                bullets.Remove(bullet);
            }

            // Background
            //args.DrawingSession.DrawImage(ImageManipulation.img(BG));

            // Countdown
            //args.DrawingSession.DrawText(countdown.ToString(), 100, 100, Colors.Yellow);

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
                    float xPos = (float)e.GetPosition(GameCanvas).X;
                    float yPos = (float)e.GetPosition(GameCanvas).Y;

                    float xVel = xPos - player.x;
                    float yVel = yPos - player.y;

                    // pythagorasmagie
                    float distance = (float)Math.Sqrt(Math.Pow((double)xVel, 2) + Math.Pow((double)yVel, 2));
                    float scaling = distance / 25;

                    xVel = xVel / scaling;
                    yVel = yVel / scaling;

                    bullets.Add(new DiDo.Bullet(player.x, player.y, xVel, yVel));
                }
            }
        }
        private void GameCanvas_PointerMoved(object sender, Windows.UI.Xaml.Input.PointerRoutedEventArgs e)
        {
            Debug.WriteLine(e.GetCurrentPoint(GameCanvas).RawPosition.ToString());
        }
    }
}
