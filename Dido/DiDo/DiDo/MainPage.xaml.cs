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
using DiDo.Character;
using Windows.UI.Xaml.Input;
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
        public static float DesignWidth = 1920;
        public static float DesignHeight = 1080;
        public static float scaleWidth, scaleHeight, pointX, pointY;
        public Point playerPoint;
        public Point mousePoint;
        public static int countdown = 60; // 60
        private ClientController controller;
        public static bool RoundEnded = false;
        private Levels.Levels levels;
        private bool assetsLoaded = false;

        //Lists Projectile
        public List<Bullet> bullets = new List<Bullet>();

        public static int GameState = 0; // startscreen

        public static DispatcherTimer RoundTimer = new DispatcherTimer();

        public MyPlayer player = new MyPlayer("Spy",32, 32);

        public float temp_x, temp_y; // Tijdelijk
        public double xPos, yPos, xPos2, yPos2; // tijdelijk
        //public String type_tile;

        public MainPage()
        {
            levels = new Levels.Levels();
            controller = new ClientController(player.name, player.x, player.y);
            mousePoint = new Point();
            playerPoint = new Point(player.x, player.y);
            this.InitializeComponent();
            Window.Current.SizeChanged += Current_SizeChanged;
            ImageManipulation.SetScale();
            
            RoundTimer.Tick += RoundTimer_Tick;
            RoundTimer.Interval = new TimeSpan(0, 0, 1);
            Window.Current.CoreWindow.KeyDown += controller.CoreWindow_Keydown;
            Window.Current.CoreWindow.KeyUp += controller.CoreWindow_Keyup;
        }
        
        public void updatePoint(Player player)
        {
            Point newPoint = new Point(player.x, player.y);
            this.playerPoint = newPoint;
        }


        public void updateMousePoint(object sender, PointerRoutedEventArgs e)
        {
            var pointerPoint = e.GetCurrentPoint(GameCanvas);
            int xPos = (int)pointerPoint.Position.X;
            int yPos = (int)pointerPoint.Position.Y;
            Point newPoint = new Point(xPos, yPos);
            this.mousePoint = newPoint;
        }

        public double radians(Point mouse, Point player)
        {
            float x2 = (float)mouse.X;
            float x1 = (float)player.X;
            float y2 = (float)mouse.Y;
            float y1 = (float)player.Y;

            double radians = Math.Atan2((y2 - y1), (x2 - x1));
            double Angle = radians * (180 / Math.PI);
            return radians;
        }


        //---------->Character Movement Stop 

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
            Player_sprite = await CanvasBitmap.LoadAsync(sender, new Uri("ms-appx:///Assets/Char/spr_jeroen.png"));
            StartScreen = await CanvasBitmap.LoadAsync(sender, new Uri("ms-appx:///Assets/BG/level.png"));
            Bullet = await CanvasBitmap.LoadAsync(sender, new Uri("ms-appx:///Assets/Bullets/bullet.png"));
            Bullets = ImageManipulation.img(Bullet);
            Enemy1 = await CanvasBitmap.LoadAsync(sender, new Uri("ms-appx:///Assets/Char/spr_hayri.png"));
             // Zodat dit niet elk frame gebeurt maar slechts eenmalig

            foreach (Tile t in Levels.Levels.tiles.Values)
            {
                await t.InitBitmap(sender).AsAsyncAction();
            }
        }

        public void bulletHandling(CanvasControl sender, CanvasDrawEventArgs args)
        {
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
        }

        public void GameCanvas_Draw(CanvasControl sender, CanvasDrawEventArgs args)
        {
            GameStateManager.GSManager();
            
            if (player.x == 0 && player.y == 0)
            {
                player.x = 32 * scaleWidth;
                player.y = 32 * scaleHeight;
            }

            // Level
            for (int x = 0; x < levels.gekozenLevel.GetLength(0); x += 1)
            {
                for (int y = 0; y < levels.gekozenLevel.GetLength(1); y += 1)
                {
                    string tileType = levels.gekozenLevel[x, y].ToString();
                    Tile tile = Levels.Levels.tiles[tileType];
                    args.DrawingSession.DrawImage(
                        tile.Effect,
                        y * (32 * MainPage.scaleWidth),
                        x * (32 * MainPage.scaleHeight)
                    );

                }
            }

            controller.movementCharacter(sender, args, player, levels);
            bulletHandling(sender, args);
            updatePoint(player);

            //Debug
            args.DrawingSession.DrawImage(ImageManipulation.imageW(Player_sprite, radians(mousePoint, playerPoint)), player.x, player.y); // Later zorgen dat de scaling en rotation niet elke frame gebeurt
            args.DrawingSession.DrawText("X1: " + xPos + " | Y1: " + yPos + " | X1: " + xPos2 + " | Y1: " + yPos2 + " | Type: " + levels.getTileType(player.x, player.y, levels.gekozenLevel), 10, 600, Colors.Black); // Toon welke Tile de player is, Tijdelijk
            args.DrawingSession.DrawText("Player X: " + player.x + " | Player Y: " + player.y, 10, 650, Colors.Black); // Toon de player location, Tijdelijk
            args.DrawingSession.DrawText("Inventory: " + player.inventory(), 10, 700, Colors.Black);
            args.DrawingSession.DrawText("InHand: " + player.currentWeapon.name + " " + player.currentWeapon.getAmmo(), 10, 750, Colors.Black);
            args.DrawingSession.DrawText("Player Point: " + playerPoint, 10, 550, Colors.Black);
            args.DrawingSession.DrawText("Mouse Point: " + mousePoint, 10, 500, Colors.Black);
            args.DrawingSession.DrawText("Radians: " + radians(playerPoint, mousePoint), 10, 450, Colors.Black);
            //Debug end

            GameCanvas.Invalidate();
        }

        private void GameCanvas_Tapped(object sender, TappedRoutedEventArgs e)
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
                    RoundTimer.Start();
                    float xPos = (float)e.GetPosition(GameCanvas).X;
                    float yPos = (float)e.GetPosition(GameCanvas).Y;

                    float xVel = xPos - player.x;
                    float yVel = yPos - player.y;

                    // pythagorasmagie
                    float distance = (float)Math.Sqrt(Math.Pow((double)xVel, 2) + Math.Pow((double)yVel, 2));
                    float scaling = distance / 25;

                    xVel = xVel / scaling;
                    yVel = yVel / scaling;
                    if(player.currentWeapon.getAmmo() >= 1)
                    {
                        bullets.Add(new DiDo.Bullet(player.x, player.y, xVel, yVel));
                        player.currentWeapon.reduceAmmo();
                    }
                }
            }
        }
        private void GameCanvas_PointerMoved(object sender, Windows.UI.Xaml.Input.PointerRoutedEventArgs e)
        {
            updateMousePoint(sender, e);
            //Debug.WriteLine(e.GetCurrentPoint(GameCanvas).RawPosition.ToString());
        }
    }
}
