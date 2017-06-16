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
using DiDo.Items;
using DiDo.MenuFolder;
using Windows.System.Threading;
// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace DiDo
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        // The images of the game
        public static CanvasBitmap BG, StartScreen, Bullet, Enemy1, Enemy2, CurrentWeapon, UI_Pistol, UI_SMG, UI_AR, CurrentArms, Arms_AR, Arms_Pistol, Arms_SMG, Player_sprite, Pistol, Assault_Rifle, Health_Full, Health_Half, Health_Empty, Char_UI;
        public static Transform2DEffect Bullets, PlayerA, PlayerS, PlayerD, PlayerW;
        public static Rect bounds = ApplicationView.GetForCurrentView().VisibleBounds;
        public Rect ui = new Rect(15, 700, 1000, 150); //UI element 
        public static float pointX, pointY;
        public Point playerPoint;
        public Point mousePoint;
        public static int countdown = 60; // 60
        private ClientController controller;
        public static bool RoundEnded = false;
        private Levels.Levels levels;
        private bool assetsLoaded = false;
        public static string[,] ChosenLevel;
        //Lists Projectile
        public List<Bullet> bullets = new List<Bullet>();

        public Weapon[] weapons;

        public static int GameState = 0; // startscreen

        public static DispatcherTimer RoundTimer = new DispatcherTimer();

        public MyPlayer player;

        public List<Enemy> enemies = new List<Enemy>();

        public float temp_x, temp_y; // Temporary

        public double frames = 0;

        public Random random = new Random();


        /// <summary>
        /// Creates the resources of the game
        /// </summary>
        private void GameCanvas_CreateResources(CanvasAnimatedControl sender, Microsoft.Graphics.Canvas.UI.CanvasCreateResourcesEventArgs args)
        {
            args.TrackAsyncAction(CreateResourcesAsync(sender).AsAsyncAction());
        }

        /// <summary>
        /// This method draws the player and the level 60 times per second
        /// </summary>
        private void GameCanvas_Draw(ICanvasAnimatedControl sender, CanvasAnimatedDrawEventArgs args)
        {
            this.frames++;
            GameStateManager.GSManager();

            // scales the player
            if (player.x == 0 && player.y == 0)
            {
                player.x = 32;
                player.y = 32;
            }


            // draws the Level
            drawLevel(sender, args);

            //character movement
            controller.movementCharacter(sender, args, player, levels);

            //bullet handling
            bulletHandling(sender, args);

    
            updatePoint(player);

            //draws the enemy
            foreach (Enemy enemy in enemies)
            {
                enemy.randomWalk();
                args.DrawingSession.DrawImage(ImageManipulation.image(Enemy1, radians(mousePoint, playerPoint)), enemy.x, enemy.y);
                args.DrawingSession.DrawText(enemy.debugName(), enemy.x - 16, enemy.y - 16, Colors.Black); // Toon de player location, Tijdelijk
            }

            //Debug
            foreach(Weapon weapon in weapons)
            {
                if(weapon != null)
                {
                    args.DrawingSession.DrawImage(Pistol, weapon.x, weapon.y);
                }
            }


            int tempHealth = player.getHealth() + 10;
            
            //Adding the healthbar to the UI element
            for (int i = 0; i < 5; i++)
            {
                tempHealth -= 20;
                int x = 605 + (i * 60);
                if (tempHealth >= 9)
                {
                    args.DrawingSession.DrawImage(Health_Full, x, 705);
                }
                else if (tempHealth >= -1)
                {
                    args.DrawingSession.DrawImage(Health_Half, x, 705);
                }
                else
                {
                    args.DrawingSession.DrawImage(Health_Empty, x, 705);
                }
            }

            reloadArms();

            args.DrawingSession.DrawImage(ImageManipulation.image(CurrentArms, radians(mousePoint, playerPoint)), player.x, player.y);
            args.DrawingSession.DrawImage(ImageManipulation.image(Player_sprite, radians(mousePoint, playerPoint)), player.x, player.y); // TODO: make it so that scaling and rotation is not processed each frame      
            args.DrawingSession.DrawImage(ImageManipulation.image(Player_sprite, radians(mousePoint, playerPoint)), player.x, player.y); // Later zorgen dat de scaling en rotation niet elke frame gebeurt
            args.DrawingSession.DrawImage(Char_UI, 25, 735); //Adding the character playing to the UI element
            args.DrawingSession.DrawImage(CurrentWeapon, 225, 735); //Adding the current weapon to the UI element
            //args.DrawingSession.DrawText("X1: " + xPos + " | Y1: " + yPos + " | X1: " + xPos2 + " | Y1: " + yPos2 + " | Type: " + levels.getTileType(player.x, player.y, levels.gekozenLevel), 10, 600, Colors.Black); // Toon welke Tile de player is, Tijdelijk
            //args.DrawingSession.DrawText("Player X: " + player.x + " | Player Y: " + player.y, 10, 650, Colors.Black); // Toon de player location, Tijdelijk
            //args.DrawingSession.DrawText("Player Point: " + playerPoint, 10, 550, Colors.Black);
            //args.DrawingSession.DrawText("Mouse Point: " + mousePoint, 10, 500, Colors.Black);
            //args.DrawingSession.DrawText("Radians: " + radians(playerPoint, mousePoint), 10, 450, Colors.Black);
            args.DrawingSession.DrawText("Player: " + player.name, 25, 705, Colors.Navy);
            args.DrawingSession.DrawText("Weapon: " + player.currentWeapon.name, 225, 705, Colors.Navy);
            args.DrawingSession.DrawText("Ammo: " + player.currentWeapon.getAmmo(), 425, 705, Colors.Navy);
            args.DrawingSession.DrawText("Additional ammo: " + player.currentWeapon.getAdditionalAmmo(), 425, 755, Colors.Navy);
            args.DrawingSession.DrawText("Health: " + player.getHealth(), 800, 705, Colors.DarkRed);
            args.DrawingSession.DrawRectangle(ui, Colors.Black); //UI element (5, 700, 800, 100)
            //Debug end

            // triggers the draw event 60 times per second
            GameCanvas.Invalidate();
        }

        public string inventory()
        {
            string inventory = "";
            foreach (Weapon weapon in weapons)
            {
                if (weapon != null)
                {
                    inventory = inventory + " | " + weapon.name;
                }
            }
            return inventory;
        }

        public double xPos, yPos, xPos2, yPos2; // Temporary
                                                //public String type_tile;

        /// <summary>
        /// Checks if the player ammo is null or not and returns the amount
        /// </summary>
        /// <returns></returns>
        public string getPlayerAmmo()
        {
            string ammo;
            if (player.currentWeapon == null)
            {
                ammo = "";
            }
            else
            {
                ammo = player.currentWeapon.getAmmo().ToString();
            }
            return ammo;
        }

        /// <summary>
        /// Checks if the player name is null or not and returns the name
        /// </summary>
        /// <returns></returns>
        public string getPlayerName()
        {
            string name;
            if (player.name == null)
            {
                name = "";
            }
            else
            {
                name = player.name;
            }
            return name;
        }

        /// <summary>
        /// Checks if the player weapon name is null or not and returns the name
        /// </summary>
        /// <returns></returns>
        public string getPlayerWeaponName()
        {
            string weaponName;
            if (player.currentWeapon == null)
            {
                weaponName = "";
            }
            else
            {
                weaponName = player.currentWeapon.name;
            }
            return weaponName;
        }

        /// <summary>
        /// Checks if playerAdditional ammo is null or not and returns the amount
        /// </summary>
        /// <returns></returns>
        public string getPlayerWeaponAdditionalAmmo()
        {
            string additionalAmmo;
            if(player.currentWeapon == null)
            {
                additionalAmmo = "";
            }
            else
            {
                additionalAmmo = player.currentWeapon.getAdditionalAmmo().ToString();
            }
            return additionalAmmo;
        }

        /// <summary>
        /// draws the sprites for the level
        /// </summary>
        public void  drawLevel(ICanvasAnimatedControl sender, CanvasAnimatedDrawEventArgs args)
        {
            var frames_sprite = (int)(this.frames / 15) + 1;

            for (int x = 0; x < levels.gekozenLevel.GetLength(0); x += 1)
            {
                for (int y = 0; y < levels.gekozenLevel.GetLength(1); y += 1)
                {
                    string tileType = levels.gekozenLevel[x, y].ToString();
                    string tmp = tileType + "_" + frames_sprite;

                    // makes the sprite move
                    if (Levels.Levels.tiles.ContainsKey(tmp))
                    {
                        //Debug.WriteLine(tmp);
                        Tile tile = Levels.Levels.tiles[tileType + "_" + frames_sprite];
                        args.DrawingSession.DrawImage(
                            tile.Effect,
                            y * 32,
                            x * 32
                        );
                    } else
                    {
                        Tile tile = Levels.Levels.tiles[tileType];
                        args.DrawingSession.DrawImage(
                            tile.Effect,
                            y * 32,
                            x * 32
                        );

                    }





                }
            }

            if (this.frames > 60)
            {
                this.frames = 0;
            }

        }
       /// <summary>
       /// Initialisation of the mainpage for singleplayer
       /// </summary>
        public MainPage()
        {
            weapons = new Weapon[100];
            levels = new Levels.Levels();
            controller = new ClientController(this, player.name, player.x, player.y);
            mousePoint = new Point();
            
            this.InitializeComponent();
            Window.Current.SizeChanged += Current_SizeChanged;
            
            RoundTimer.Tick += RoundTimer_Tick;
            RoundTimer.Interval = new TimeSpan(0, 0, 1);
            Window.Current.CoreWindow.KeyDown += controller.CoreWindow_Keydown;
            Window.Current.CoreWindow.KeyUp += controller.CoreWindow_Keyup;

            this.enemies.Add(new Enemy("Freek", 256, 128)); // The AI Enemy 1
            this.enemies.Add(new Enemy("Albert", 256, 128)); // The AI Enemy 2
            this.enemies.Add(new Enemy("Karel", 256, 128)); // The AI Enemy 3


            if (CharacterSwitch.PlayerCharacter.Equals("Jeroen"))
            {
                player = new MyPlayer("Jeroen", 32, 96);
            }
            else if (CharacterSwitch.PlayerCharacter.Equals("Jeffrey"))
            {
                player = new MyPlayer("Jeffrey", 32, 96);
            }
            else if (CharacterSwitch.PlayerCharacter.Equals("Daan"))
            {
                player = new MyPlayer("Daan", 32, 96);
            }
            else if (CharacterSwitch.PlayerCharacter.Equals("Jordy"))
            {
                player = new MyPlayer("Jordy", 32, 96);
            }
            else if (CharacterSwitch.PlayerCharacter.Equals("Matthew"))
            {
                player = new MyPlayer("Matthew", 32, 96);
            }
            else if (CharacterSwitch.PlayerCharacter.Equals("Hayri"))
            {
                player = new MyPlayer("Hayri", 32, 96);
            }
            else if (CharacterSwitch.PlayerCharacter.Equals("Max"))
            {
                player = new MyPlayer("Max", 32, 96);
            }
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

        public double radians(Point mouse, Point player, int size = 32)
        {
            int halfSize = size / 2;
            float x2 = (float)mouse.X;
            float x1 = (float)player.X + halfSize;
            float y2 = (float)mouse.Y;
            float y1 = (float)player.Y + halfSize;

            double radians = Math.Atan2((y2 - y1), (x2 - x1));
            double Angle = radians * (180 / Math.PI);
            return radians + (0.5 * Math.PI); // half of pi added, so that the players head follows the cursor, instead of its arms.
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

        public void addItem(Characters character)
        {
            for (int i = 0; i < weapons.Length; i++)
            {
                if (weapons[i] == null)
                {
                    weapons[i] = character.currentWeapon;
                    character.dropItem();
                }
            }
        }

        public void removeItem(Weapon item)
        {
            for (int i = 0; i < weapons.Length; i++)
            {
                if (weapons[i] == item)
                {
                    weapons[i] = null;
                }
            }
        }

        private void Current_SizeChanged(object sender, WindowSizeChangedEventArgs e)
        {
            bounds = ApplicationView.GetForCurrentView().VisibleBounds;
        }

        public void reloadArms()
        {
            if (player.currentWeapon.GetType() == typeof(ARWeapon))
            {
                CurrentArms = Arms_AR;
                CurrentWeapon = UI_AR;
            }
            else if (player.currentWeapon.GetType() == typeof(PistolWeapon))
            {
                CurrentArms = Arms_Pistol;
                CurrentWeapon = UI_Pistol;
            }
            else if (player.currentWeapon.GetType() == typeof(SMGWeapon))
            {
                CurrentArms = Arms_SMG;
                CurrentWeapon = UI_SMG;
            }
        }


        async Task CreateResourcesAsync(CanvasAnimatedControl sender)
        {
            Arms_AR = await CanvasBitmap.LoadAsync(sender, new Uri("ms-appx:///Assets/Char/arms/AR.png"));
            Arms_Pistol = await CanvasBitmap.LoadAsync(sender, new Uri("ms-appx:///Assets/Char/arms/Pistol.png"));
            Arms_SMG = await CanvasBitmap.LoadAsync(sender, new Uri("ms-appx:///Assets/Char/arms/SMG.png"));
            reloadArms();
            Player_sprite = await CanvasBitmap.LoadAsync(sender, new Uri("ms-appx:///Assets/Char/spr_jeroen.png"));
            StartScreen = await CanvasBitmap.LoadAsync(sender, new Uri("ms-appx:///Assets/BG/level.png"));
            Bullet = await CanvasBitmap.LoadAsync(sender, new Uri("ms-appx:///Assets/Bullets/bullet.png"));
            UI_AR = await CanvasBitmap.LoadAsync(sender, new Uri("ms-appx:///Assets/UI/gun-1.png"));
            UI_SMG = await CanvasBitmap.LoadAsync(sender, new Uri("ms-appx:///Assets/UI/gun-2.png"));
            UI_Pistol = await CanvasBitmap.LoadAsync(sender, new Uri("ms-appx:///Assets/UI/gun-3.png"));
            Bullets = ImageManipulation.img(Bullet);
            Enemy1 = await CanvasBitmap.LoadAsync(sender, new Uri("ms-appx:///Assets/Char/spr_hayri.png"));

            if (CharacterSwitch.PlayerCharacter.Equals("Jeroen"))
            {
                Player_sprite = await CanvasBitmap.LoadAsync(sender, new Uri("ms-appx:///Assets/Char/spr_jeroen.png"));
                Char_UI = await CanvasBitmap.LoadAsync(sender, new Uri("ms-appx:///Assets/Char/Char_UI/Jeroen.png"));
            }
            else if (CharacterSwitch.PlayerCharacter.Equals("Jeffrey"))
            {
                Player_sprite = await CanvasBitmap.LoadAsync(sender, new Uri("ms-appx:///Assets/Char/spr_jeffrey.png"));
                Char_UI = await CanvasBitmap.LoadAsync(sender, new Uri("ms-appx:///Assets/Char/Char_UI/Jeffrey.png"));
            }
            else if (CharacterSwitch.PlayerCharacter.Equals("Daan"))
            {
                Player_sprite = await CanvasBitmap.LoadAsync(sender, new Uri("ms-appx:///Assets/Char/spr_daan.png"));
                Char_UI = await CanvasBitmap.LoadAsync(sender, new Uri("ms-appx:///Assets/Char/Char_UI/Daan.png"));
            }
            else if (CharacterSwitch.PlayerCharacter.Equals("Jordy"))
            {
                Player_sprite = await CanvasBitmap.LoadAsync(sender, new Uri("ms-appx:///Assets/Char/spr_jordy.png"));
                Char_UI = await CanvasBitmap.LoadAsync(sender, new Uri("ms-appx:///Assets/Char/Char_UI/Jordy.png"));
            }
            else if (CharacterSwitch.PlayerCharacter.Equals("Matthew"))
            {
                Player_sprite = await CanvasBitmap.LoadAsync(sender, new Uri("ms-appx:///Assets/Char/spr_matthew.png"));
                Char_UI = await CanvasBitmap.LoadAsync(sender, new Uri("ms-appx:///Assets/Char/Char_UI/Matthew.png"));
            }
            else if (CharacterSwitch.PlayerCharacter.Equals("Hayri"))
            {
                Player_sprite = await CanvasBitmap.LoadAsync(sender, new Uri("ms-appx:///Assets/Char/spr_hayri.png"));
                Char_UI = await CanvasBitmap.LoadAsync(sender, new Uri("ms-appx:///Assets/Char/Char_UI/Hayri.png"));
            }
            else if (CharacterSwitch.PlayerCharacter.Equals("Max"))
            {
                Player_sprite = await CanvasBitmap.LoadAsync(sender, new Uri("ms-appx:///Assets/Char/spr_max.png"));
                Char_UI = await CanvasBitmap.LoadAsync(sender, new Uri("ms-appx:///Assets/Char/Char_UI/Max.png"));
            }
            Health_Full = await CanvasBitmap.LoadAsync(sender, new Uri("ms-appx:///Assets/UI/Health/health-full.png"));
            Health_Half = await CanvasBitmap.LoadAsync(sender, new Uri("ms-appx:///Assets/UI/Health/health-half.png"));
            Health_Empty = await CanvasBitmap.LoadAsync(sender, new Uri("ms-appx:///Assets/UI/Health/health-empty.png"));
            Char_UI = await CanvasBitmap.LoadAsync(sender, new Uri("ms-appx:///Assets/Char/Char_UI/Jeroen.png"));

            // So that this isn't done on each frame, but only once.

            foreach (Tile t in Levels.Levels.tiles.Values)
            {
                await t.InitBitmap(sender).AsAsyncAction();
            }
        }

        public void bulletHandling(ICanvasAnimatedControl sender, CanvasAnimatedDrawEventArgs args)
        {
            List<Bullet> bulletsToRemove = new List<Bullet>();
            List<int> enemiesToRemove = new List<int>();

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

                int enemiesCount = 0;
                foreach (Enemy enemy in enemies)
                {
                    if ((bullet.y > enemy.y-16 && bullet.y < enemy.y+16) && (bullet.x > enemy.x-16 && bullet.x < enemy.x+16))
                    {
                        enemy.hit(player.currentWeapon.getDamage());
                        if(enemy.getHealth() <= 0)
                        {
                            addItem(enemy);
                            enemiesToRemove.Add(enemiesCount); // Enemy klaar zetten om te verwijderen
                        }
                        bulletsToRemove.Add(bullet); // Remove the bullet upon impact
                    }
                    enemiesCount++;
                }
            }

            // Remove Bullets
            foreach (Bullet bullet in bulletsToRemove)
            {
                bullets.Remove(bullet);
            }

            // Remove enemies
            foreach (int removeEnemy in enemiesToRemove)
            {
                enemies.RemoveAt(removeEnemy);
            }
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

                    // pythagorasmagic
                    float distance = (float)Math.Sqrt(Math.Pow((double)xVel, 2) + Math.Pow((double)yVel, 2));
                    float scaling = distance / 25;

                    xVel = xVel / scaling;
                    yVel = yVel / scaling;
                    if(player.currentWeapon != null)
                    {
                        if (player.currentWeapon.getAmmo() >= 1)
                        {
                            //Debug.WriteLine(player.currentWeapon.getDamage());
                            bullets.Add(new DiDo.Bullet(player.x, player.y, xVel, yVel, player.currentWeapon.getDamage()));
                            player.currentWeapon.reduceAmmo();
                        }
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
