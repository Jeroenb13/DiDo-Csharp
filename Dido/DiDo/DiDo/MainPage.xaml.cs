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
using DiDo.Levels;
using System.Collections.Generic;
using Windows.UI;
using Windows.System;
using System.Diagnostics;
using Windows.Graphics.Imaging;
using Windows.UI.Xaml.Media;
using Microsoft.Graphics.Canvas.Effects;
// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace DiDo
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        // The images of the game
        public static CanvasBitmap BG, StartScreen, Bullet, Enemy1, Enemy2, Player_sprite;
        public static Transform2DEffect Bullets, PlayerA, PlayerS, PlayerD, PlayerW;
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

        public Dictionary<VirtualKey, Boolean> keysPressed = new Dictionary<VirtualKey, bool>();

        public Player player = new DiDo.Player(0, 0);

        public static String[,] gekozenLevel = Levels.Levels.levelOne;

        public MainPage()
        {
            this.InitializeComponent();
            Window.Current.SizeChanged += Current_SizeChanged;
            ImageManipulation.SetScale();
            
            RoundTimer.Tick += RoundTimer_Tick;
            RoundTimer.Interval = new TimeSpan(0, 0, 1);
            Window.Current.CoreWindow.KeyDown += CoreWindow_Keydown;
            Window.Current.CoreWindow.KeyUp += CoreWindow_Keyup;
        }

        private void CoreWindow_Keydown(CoreWindow sender, KeyEventArgs args)
        {
            int move_speed = 5;

            keysPressed[args.VirtualKey] = true;

            //to do keylijst maken keylijst
            if (args.VirtualKey == VirtualKey.A)
            {
                player.velX = -move_speed;
            }

            if (args.VirtualKey == VirtualKey.D)
            {
                player.velX = move_speed;
            }

            if (args.VirtualKey == VirtualKey.W)
            {
                player.velY = -move_speed;
            }

            if (args.VirtualKey == VirtualKey.S)
            {
                player.velY = move_speed;
            }
        }

        private void CoreWindow_Keyup(CoreWindow sender, KeyEventArgs args)
        {

            keysPressed[args.VirtualKey] = false;

            //to do keylijst maken keylijst
            if (args.VirtualKey == VirtualKey.A)
            {
                player.velX = 0;
            }

            if (args.VirtualKey == VirtualKey.D)
            {
                player.velX = 0;
            }

            if (args.VirtualKey == VirtualKey.W)
            {
                player.velY = 0;
            }

            if (args.VirtualKey == VirtualKey.S)
            {
                player.velY = 0;
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

        private Boolean keyPressed(VirtualKey key)
        {
            if (keysPressed.ContainsKey(key))
            {
                return keysPressed[key];
            }
            return false;
        }

        private void GameCanvas_CreateResources(CanvasControl sender, Microsoft.Graphics.Canvas.UI.CanvasCreateResourcesEventArgs args)
        {
            args.TrackAsyncAction(CreateResourcesAsync(sender).AsAsyncAction());
        }

        async Task CreateResourcesAsync(CanvasControl sender)
        {
            Player_sprite = await CanvasBitmap.LoadAsync(sender, new Uri("ms-appx:///Assets/Char/spr_jeroen.png"));
            StartScreen = await CanvasBitmap.LoadAsync(sender, new Uri("ms-appx:///Assets/BG/level.png"));
            Bullet = await CanvasBitmap.LoadAsync(sender, new Uri("ms-appx:///Assets/Bullets/bullet.png"));
            Bullets = ImageManipulation.img(Bullet);
            Enemy1 = await CanvasBitmap.LoadAsync(sender, new Uri("ms-appx:///Assets/Char/spr_enemy.png"));
            
            var PlayerA = ImageManipulation.imageA(Player_sprite);
            var PlayerS = ImageManipulation.imageS(Player_sprite);
            var PlayerD = ImageManipulation.imageD(Player_sprite);
            var PlayerW = ImageManipulation.imageW(Player_sprite); // Zodat dit niet elk frame gebeurt maar slechts eenmalig

            foreach (Tile t in Levels.Levels.tiles.Values)
            {
                await t.InitBitmap(sender).AsAsyncAction();
            }
        }

        public void GameCanvas_Draw(CanvasControl sender, CanvasDrawEventArgs args)
        {
            GameStateManager.GSManager();
            Collide collision = new Collide();
            // Level
            for (int x = 0; x < gekozenLevel.GetLength(0); x += 1)
            {
                for (int y = 0; y < gekozenLevel.GetLength(1); y += 1)
                {
                    string tileType = gekozenLevel[x, y].ToString();

                    if (collision.collide(tileType))
                    {
                        collision.collisionDetection(player, x, y);
                    }

                    Tile tile = Levels.Levels.tiles[tileType];
                    args.DrawingSession.DrawImage(
                        tile.Effect,
                        y * (32 * MainPage.scaleWidth),
                        x * (32 * MainPage.scaleHeight)
                    );

                }
            }

            player.x += player.velX;
            player.y += player.velY;

            // Player
            if (keyPressed(VirtualKey.A))
            {
                //args.DrawingSession.DrawImage(PlayerA, player.x, player.y);
                args.DrawingSession.DrawImage(ImageManipulation.imageA(Player_sprite), player.x, player.y); // Later zorgen dat de scaling en rotation niet elke frame gebeurt
            }
            else if (keyPressed(VirtualKey.S))
            {
                //args.DrawingSession.DrawImage(PlayerS, player.x, player.y);
                args.DrawingSession.DrawImage(ImageManipulation.imageS(Player_sprite), player.x, player.y); // Later zorgen dat de scaling en rotation niet elke frame gebeurt
            }
            else if (keyPressed(VirtualKey.D))
            {
                //args.DrawingSession.DrawImage(PlayerD, player.x, player.y);
                args.DrawingSession.DrawImage(ImageManipulation.imageD(Player_sprite), player.x, player.y); // Later zorgen dat de scaling en rotation niet elke frame gebeurt
            }
            else
            {
                //args.DrawingSession.DrawImage(PlayerW, player.x, player.y);
                args.DrawingSession.DrawImage(ImageManipulation.imageW(Player_sprite), player.x, player.y); // Later zorgen dat de scaling en rotation niet elke frame gebeurt
            }

            List<Bullet> bulletsToRemove = new List<Bullet>();

            // Show bullets
            foreach (Bullet bullet in bullets)
            {
                bullet.x += bullet.velX;
                bullet.y += bullet.velY;
                args.DrawingSession.DrawImage(Bullets, bullet.x, bullet.y);

                if (bullet.y < 0f || bullet.y > 1080 || bullet.x > 1920f || bullet.x < 0f)
                {
                    bulletsToRemove.Add(bullet);
                }
            }

            // Remove Bullets
            foreach (Bullet bullet in bulletsToRemove)
            {
                bullets.Remove(bullet);
            }

            GameCanvas.Invalidate();
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
