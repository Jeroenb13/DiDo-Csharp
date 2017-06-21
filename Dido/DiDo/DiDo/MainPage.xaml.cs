using Microsoft.Graphics.Canvas;
using Microsoft.Graphics.Canvas.Brushes;
using Microsoft.Graphics.Canvas.UI.Xaml;
using Microsoft.Graphics.Canvas.Effects;
using Microsoft.Graphics.Canvas.Text;
using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Windows.Foundation;
using Windows.UI;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Core;
using Windows.UI.Xaml.Input;
using DiDo.GameElements;
using DiDo.Levels;
using DiDo.Character;
using DiDo.Items;
using DiDo.MenuFolder;
using System.Diagnostics;
using Windows.System;
using Windows.Graphics.Imaging;
using Windows.UI.Xaml.Media;
using Windows.System.Threading;
using Windows.UI.Xaml.Shapes;
// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

// Resource list:
// * http://stackoverflow.com
// * 

namespace DiDo
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {           
        //CanvastBitmap: The images used by the game
        public static CanvasBitmap BG, StartScreen, Bullet, Enemy1, Enemy2, CurrentWeapon, sprite, UI_Pistol, UI_SMG, UI_AR, UI_Fists, CurrentArms, Arms_AR, Arms_Pistol, Arms_SMG, Arms_Fists, Player_sprite, Pistol, Assault_Rifle, SMG, Health_Full, Health_Half, Health_Empty, Char_UI;
        public static Transform2DEffect Bullets, PlayerA, PlayerS, PlayerD, PlayerW;
        public static Rect bounds = ApplicationView.GetForCurrentView().VisibleBounds;
        public static float pointX, pointY;
        public Point playerPoint;
        public Point mousePoint;
        public static int countdown = 60; // 60 frames per second
        private ClientController controller;
        public static bool RoundEnded = false;
        private Levels.Levels levels;
        public static string[,] ChosenLevel;

        //Lists Projectile
        public static List<Bullet> bullets = new List<Bullet>();
        public Weapon[] weapons;
        public static int GameState = 0; // startscreen
        public static DispatcherTimer RoundTimer = new DispatcherTimer();
        public static MyPlayer player;
        public List<Enemy> enemies = new List<Enemy>();
        public float temp_x, temp_y; // Temporary
        public double frames = 0;
        public Random random = new Random();

        //Ui elements
        public CanvasTextFormat font = new CanvasTextFormat();
        public Rect ui = new Rect(1150, 5, 300, 800); //UI element 
        public Rect playerRect = new Rect(1150, 5, 300, 200); // Rectangle for the player UI element
        public Rect weaponRect = new Rect(1150, 5, 300, 400); // Rectangle for the player ui element

        //public SoundEffects soundController;

        /// <summary>
        /// Creates the resources of the game
        /// </summary>
        private void GameCanvas_CreateResources(CanvasAnimatedControl sender, Microsoft.Graphics.Canvas.UI.CanvasCreateResourcesEventArgs args)
        {
            args.TrackAsyncAction(CreateResourcesAsync(sender).AsAsyncAction());
        }

        /// <summary>
        /// Goes through the weaponList and places the bitmap on the canvas
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        public async void setSprite(ICanvasAnimatedControl sender, CanvasAnimatedDrawEventArgs args)
        {
            foreach (Weapon weapon in weapons)
            {
                if (weapon != null)
                {
                    if (weapon.name == "Assault Rifle")
                    {
                        Assault_Rifle = await CanvasBitmap.LoadAsync(sender, new Uri("ms-appx:///Assets/Weapons/gun-1.png"));
                        args.DrawingSession.DrawImage(Assault_Rifle, weapon.x, weapon.y);
                    }
                    else if (weapon.name == "Sub Machine Gun")
                    {
                        SMG = await CanvasBitmap.LoadAsync(sender, new Uri("ms-appx:///Assets/Weapons/gun-2.png"));
                        args.DrawingSession.DrawImage(SMG, weapon.x, weapon.y);
                    }
                    else if (weapon.name == "Pistol")
                    {
                        Pistol = await CanvasBitmap.LoadAsync(sender, new Uri("ms-appx:///Assets/Weapons/gun-3.png"));
                        args.DrawingSession.DrawImage(Pistol, weapon.x, weapon.y);
                    }
                }
            }
        }
        #region
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


            //Draws the Level
            drawLevel(sender, args);

            //Character movement
            controller.movementCharacter(sender, args, player, levels);

            //Bullet handling
            bulletHandling(sender, args);

    
            updatePoint(player);

            //Draws the enemy
            foreach (Enemy enemy in enemies)
            {
                enemy.randomWalk();
                if (enemy.direction == 0)
                {
                    if(enemy.x == player.x && enemy.y < player.y)
                    {
                        args.DrawingSession.DrawImage(ImageManipulation.image(Enemy1, radians(playerPoint, new Point(player.x, player.y))), enemy.x, enemy.y);
                    }
                    //else
                    //{
                    //    args.DrawingSession.DrawImage(ImageManipulation.image(Enemy1, Math.PI), enemy.x, enemy.y);
                    //}
                }
                else if(enemy.direction == 1)
                {
                    if(enemy.x < player.x && enemy.y == player.y)
                    {
                        args.DrawingSession.DrawImage(ImageManipulation.image(Enemy1, radians(playerPoint, new Point(player.x, player.y))), enemy.x, enemy.y);
                    }
                    //else
                    //{
                    //    args.DrawingSession.DrawImage(ImageManipulation.image(Enemy1, Math.PI * 0.5), enemy.x, enemy.y);
                    //}
                }
                else if(enemy.direction == 2)
                {
                    if(enemy.x == player.x && enemy.y > player.y)
                    {
                        args.DrawingSession.DrawImage(ImageManipulation.image(Enemy1, radians(playerPoint, new Point(player.x, player.y))), enemy.x, enemy.y);
                    }
                    //else
                    //{
                    //    args.DrawingSession.DrawImage(ImageManipulation.image(Enemy1, 0), enemy.x, enemy.y);
                    //}
                }
                else if(enemy.direction == 3)
                {
                    if(enemy.x > player.x && enemy.y == player.y)
                    {
                        args.DrawingSession.DrawImage(ImageManipulation.image(Enemy1, radians(playerPoint, new Point(player.x, player.y))), enemy.x, enemy.y);
                    }
                    //else
                    //{
                    //    args.DrawingSession.DrawImage(ImageManipulation.image(Enemy1, Math.PI * 1.5), enemy.x, enemy.y);
                    //}
                }
                else
                {
                    if (enemy.direction == 0)
                    {
                        args.DrawingSession.DrawImage(ImageManipulation.image(Enemy1, Math.PI), enemy.x, enemy.y);
                    }
                    else if (enemy.direction == 1)
                    {
                        args.DrawingSession.DrawImage(ImageManipulation.image(Enemy1, Math.PI * 0.5), enemy.x, enemy.y);
                    }
                    else if (enemy.direction == 2)
                    {
                        args.DrawingSession.DrawImage(ImageManipulation.image(Enemy1, 0), enemy.x, enemy.y);
                    }
                    else
                    {
                        args.DrawingSession.DrawImage(ImageManipulation.image(Enemy1, Math.PI * 1.5), enemy.x, enemy.y);
                    }
                }


                //args.DrawingSession.DrawImage(ImageManipulation.img(Enemy1), enemy.x, enemy.y); //Enemy doesn't turn and faces the direction in which he spawned
                //args.DrawingSession.DrawImage(ImageManipulation.image(Enemy1, radians(playerPoint, new Point(player.x, player.y))), enemy.x, enemy.y);  //Enemy turns around player
                //args.DrawingSession.DrawImage(ImageManipulation.image(Enemy1, radians(mousePoint, playerPoint)), enemy.x, enemy.y);                     //Enemy turns with player around mouse
                //args.DrawingSession.DrawImage(ImageManipulation.image(Enemy1, radians(mousePoint, new Point(player.x, player.y))), enemy.x, enemy.y);   //Enemy turns around mouse
                args.DrawingSession.DrawText(enemy.debugName(), enemy.x - 16, enemy.y - 16, Colors.Black); // Toon de player location, Tijdelijk
            }

            setSprite(sender, args);


#region
            string fontUI = "ms-appx:/Assets/FFFFORWARD.TTF#FFF Forward";
            
            reloadArms(); //Method for showing the right gun in the UI

            args.DrawingSession.FillRectangle(ui, Colors.SlateGray); //Color of the UI element (1150, 5, 300, 200)
            args.DrawingSession.DrawRectangle(ui, Colors.Black, 10); //UI element (1150, 5, 300, 800)
            args.DrawingSession.DrawRectangle(playerRect, Colors.Black, 10);
            args.DrawingSession.DrawRectangle(weaponRect, Colors.Black, 10);


            args.DrawingSession.DrawImage(ImageManipulation.image(CurrentArms, radians(mousePoint, playerPoint)), player.x, player.y);
            args.DrawingSession.DrawImage(ImageManipulation.image(Player_sprite, radians(mousePoint, playerPoint)), player.x, player.y); // TODO: make it so that scaling and rotation is not processed each frame      
            args.DrawingSession.DrawImage(ImageManipulation.image(Player_sprite, radians(mousePoint, playerPoint)), player.x, player.y); // Later zorgen dat de scaling en rotation niet elke frame gebeurt

            args.DrawingSession.DrawText("X1: " + xPos + " | Y1: " + yPos + " | X1: " + xPos2 + " | Y1: " + yPos2 + " | Type: " + levels.getTileType(player.x, player.y, levels.gekozenLevel), 10, 600, Colors.Black); // Toon welke Tile de player is, Tijdelijk
            args.DrawingSession.DrawText("Player X: " + player.x + " | Player Y: " + player.y, 10, 650, Colors.Black); // Toon de player location, Tijdelijk
            args.DrawingSession.DrawText("Player Point: " + playerPoint, 10, 550, Colors.Black);
            args.DrawingSession.DrawText("Mouse Point: " + mousePoint, 10, 500, Colors.Black);
            args.DrawingSession.DrawText("Radians: " + radians(playerPoint, mousePoint), 10, 450, Colors.Black);

            args.DrawingSession.DrawText("PLAYER", 1245, 10, Colors.Black, new CanvasTextFormat() { FontSize = 24, FontFamily = fontUI }); // Adding text to the UI element
            args.DrawingSession.DrawText(player.name, 1255, 60, Colors.Black, new CanvasTextFormat() { FontSize = 10, FontFamily = fontUI }); //Adding playername to the UI element
            args.DrawingSession.DrawImage(Char_UI, 1155, 50); //Adding the character playing to the UI element
            args.DrawingSession.DrawText("WEAPON", 1240, 210, Colors.Black, new CanvasTextFormat() { FontSize = 24, FontFamily = fontUI }); // Adding text to the UI 

            if (player.currentWeapon != null)
            {
                //args.DrawingSession.DrawText(player.currentWeapon.name, 1225, 240, Colors.MediumBlue); // Adding the weaponname to the UI element
                args.DrawingSession.DrawImage(CurrentWeapon, 1255, 230); //Adding the current weapon to the UI element
            }

            if (player.currentWeapon != null)
            {
                args.DrawingSession.DrawText(player.currentWeapon.getAmmo() + "", 1275, 300, Colors.Black, new CanvasTextFormat() { FontSize = 14, FontFamily = fontUI }); //Adding the bullets to the UI element
                args.DrawingSession.DrawText(player.currentWeapon.getAdditionalAmmo() + "", 1325, 300, Colors.Black, new CanvasTextFormat() { FontSize = 14, FontFamily = fontUI }); //Adding the the total bullet amount to the UI element

                if (player.currentWeapon.getAmmo() < 10)
                {
                    args.DrawingSession.DrawText("0", 1265, 300, Colors.Black, new CanvasTextFormat() { FontSize = 14, FontFamily = fontUI });

                    if (player.currentWeapon.getAmmo() == 0)
                    {
                        args.DrawingSession.DrawText("0", 1265, 300, Colors.DarkRed, new CanvasTextFormat() { FontSize = 14, FontFamily = fontUI });
                        args.DrawingSession.DrawText(player.currentWeapon.getAmmo() + "", 1275, 300, Colors.DarkRed, new CanvasTextFormat() { FontSize = 14, FontFamily = fontUI });
                        args.DrawingSession.DrawText("RELOAD", 1275, 340, Colors.DarkRed, new CanvasTextFormat() { FontSize = 11, FontFamily = fontUI });
                    }
                    else if(player.currentWeapon.getAmmo() == 0 && player.currentWeapon.getAdditionalAmmo() == 0)
                    {
                        args.DrawingSession.DrawText("OUT OF AMMO", 1275, 340, Colors.DarkRed, new CanvasTextFormat() { FontSize = 11, FontFamily = fontUI });
                    }
                }

                if (player.currentWeapon.getAdditionalAmmo() < 10) 
                {
                    args.DrawingSession.DrawText("0", 1315, 300, Colors.Black, new CanvasTextFormat() { FontSize = 14, FontFamily = fontUI });

                    if (player.currentWeapon.getAdditionalAmmo() == 0)
                    {
                        args.DrawingSession.DrawText("0", 1315, 300, Colors.DarkRed, new CanvasTextFormat() { FontSize = 14, FontFamily = fontUI });
                        args.DrawingSession.DrawText(player.currentWeapon.getAdditionalAmmo() + "", 1325, 300, Colors.DarkRed, new CanvasTextFormat() { FontSize = 14, FontFamily = fontUI });
                    }
                }
            }
            //args.DrawingSession.DrawText("AMMO", 1255, 255, Colors.Firebrick, new CanvasTextFormat() { FontSize = 14, FontFamily = fontUI }); //Adding text to the UI element

            args.DrawingSession.DrawText("STATS", 1250, 410, Colors.Black, new CanvasTextFormat() { FontSize = 24, FontFamily = fontUI }); //Adding text to the UI element
            args.DrawingSession.DrawText("Health:", 1175, 460, Colors.DarkRed, new CanvasTextFormat() { FontSize = 14, FontFamily = fontUI }); //Adding text to the UI element
            args.DrawingSession.DrawText(player.getHealth() + " | " + player.getMaxHealth(), 1285, 460, Colors.DarkRed, new CanvasTextFormat() { FontSize = 14, FontFamily = fontUI }); //Adding the health amount to the UI element
            args.DrawingSession.DrawText("Stamina: ", 1175, 500, Colors.DeepSkyBlue, new CanvasTextFormat() { FontSize = 14, FontFamily = fontUI }); //Adding text to the UI element
            args.DrawingSession.DrawText(player.stamina + "", 1285, 500, Colors.DeepSkyBlue, new CanvasTextFormat() { FontSize = 14, FontFamily = fontUI }); //Adding the stamina amount to the UI element

            /// <summary>
            /// //Adding the healthbar to the UI element
            /// </summary>
            double maxHealth = player.getMaxHealth();
            double currentHealth = player.getHealth();
            double calc = (currentHealth / maxHealth) * 100 + 10;

            for (int i = 0; i < 5; i++)
            {
                int x = 1148 + (i * 50);
                calc -= 20;

                if (calc >= 9)
                {
                    args.DrawingSession.DrawImage(Health_Full, x, 525); //Show full lives
                }
                else if (calc >= -1)
                {
                    args.DrawingSession.DrawImage(Health_Half, x, 525); //Show half-full lives
                }
                else
                {
                    args.DrawingSession.DrawImage(Health_Empty, x, 525); //Show empty lives
                }
            }

            //Triggers the draw event 60 times per second
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
#endregion
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

        //public async void soundHandler()
        //{
        //    soundController = new SoundEffects();
        //    await soundController.Play(SoundEfxEnum.BACKGROUND);
        //}

       /// <summary>
       /// Initialisation of the mainpage for singleplayer
       /// </summary>
        public MainPage()
        {
            // Play background music
            //soundHandler();

            if (ChooseCharacter.PlayerCharacter.Equals("Jeroen"))
            {
                player = new MyPlayer("Jeroen", 100, 100, 20, 5, 32, 96);
            }
            else if (ChooseCharacter.PlayerCharacter.Equals("Jeffrey"))
            {
                player = new MyPlayer("Jeffrey", 100, 100, 30, 5, 32, 96);
            }
            else if (ChooseCharacter.PlayerCharacter.Equals("Daan"))
            {
                player = new MyPlayer("Daan", 100, 100, 20, 5, 32, 96);
            }
            else if (ChooseCharacter.PlayerCharacter.Equals("Jordy"))
            {
                player = new MyPlayer("Jordy", 150, 150, 10, 3, 32, 96);
            }
            else if (ChooseCharacter.PlayerCharacter.Equals("Matthew"))
            {
                player = new MyPlayer("Matthew", 100, 100, 40, 5, 32, 96);
            }
            else if (ChooseCharacter.PlayerCharacter.Equals("Hayri"))
            {
                player = new MyPlayer("Hayri", 80, 80, 60, 8, 32, 96);
            }
            else if (ChooseCharacter.PlayerCharacter.Equals("Max"))
            {
                player = new MyPlayer("Max", 100, 100, 30, 6, 32, 96);
            }

            else if (ChooseCharacter.PlayerCharacter.Equals("Samus"))
            {
                player = new MyPlayer("Samus", 200, 200, 0, 5, 32, 96);
            }
            controller = new ClientController(this, player.name, player.maxHealth, player.healthPoints, player.stamina , player.move_speed, player.x, player.y);
            weapons = new Weapon[100];
            levels = new Levels.Levels();
            
            mousePoint = new Point();
            
            this.InitializeComponent();
            Window.Current.SizeChanged += Current_SizeChanged;
            
            RoundTimer.Tick += RoundTimer_Tick;
            RoundTimer.Interval = new TimeSpan(0, 0, 1);
            Window.Current.CoreWindow.KeyDown += controller.CoreWindow_Keydown;
            Window.Current.CoreWindow.KeyUp += controller.CoreWindow_Keyup;

            this.enemies.Add(new Enemy("Freek", 100, 100, 0, 5, 256, 128)); // The AI Enemy 1
            this.enemies.Add(new Enemy("Albert", 100, 100, 0, 5, 256, 128)); // The AI Enemy 2
            this.enemies.Add(new Enemy("Karel", 100, 100, 0, 5, 256, 128)); // The AI Enemy 3
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
            Type weaponType = null;

            if(player.currentWeapon.GetType() == null)
            {
                CurrentArms = Arms_Fists;
            }
            else
            {
                weaponType = player.currentWeapon.GetType();
            }
            weaponType = typeof(PistolWeapon);

            if (weaponType == typeof(ARWeapon))
            {
                CurrentArms = Arms_AR;
                CurrentWeapon = UI_AR;
            }
            else if (weaponType == typeof(PistolWeapon))
            {
                CurrentArms = Arms_Pistol;
                CurrentWeapon = UI_Pistol;
            }
            else if (weaponType == typeof(SMGWeapon))
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
            Arms_Fists = await CanvasBitmap.LoadAsync(sender, new Uri("ms-appx:///Assets/Char/arms/Fists.png"));
            reloadArms();
            Bullet = await CanvasBitmap.LoadAsync(sender, new Uri("ms-appx:///Assets/Bullets/bullet.png"));
            UI_AR = await CanvasBitmap.LoadAsync(sender, new Uri("ms-appx:///Assets/UI/gun-1.png"));
            UI_SMG = await CanvasBitmap.LoadAsync(sender, new Uri("ms-appx:///Assets/UI/gun-2.png"));
            UI_Pistol = await CanvasBitmap.LoadAsync(sender, new Uri("ms-appx:///Assets/UI/gun-3.png"));
            Bullets = ImageManipulation.img(Bullet);
            Enemy1 = await CanvasBitmap.LoadAsync(sender, new Uri("ms-appx:///Assets/Char/spr_hayri.png"));

            if (ChooseCharacter.PlayerCharacter.Equals("Jeroen"))
            {
                Player_sprite = await CanvasBitmap.LoadAsync(sender, new Uri("ms-appx:///Assets/Char/spr_jeroen.png"));
                Char_UI = await CanvasBitmap.LoadAsync(sender, new Uri("ms-appx:///Assets/Char/Char_UI/Jeroen.png"));
            }
            else if (ChooseCharacter.PlayerCharacter.Equals("Jeffrey"))
            {
                Player_sprite = await CanvasBitmap.LoadAsync(sender, new Uri("ms-appx:///Assets/Char/spr_jeffrey.png"));
                Char_UI = await CanvasBitmap.LoadAsync(sender, new Uri("ms-appx:///Assets/Char/Char_UI/Jeffrey.png"));
            }
            else if (ChooseCharacter.PlayerCharacter.Equals("Daan"))
            {
                Player_sprite = await CanvasBitmap.LoadAsync(sender, new Uri("ms-appx:///Assets/Char/spr_daan.png"));
                Char_UI = await CanvasBitmap.LoadAsync(sender, new Uri("ms-appx:///Assets/Char/Char_UI/Daan.png"));
            }
            else if (ChooseCharacter.PlayerCharacter.Equals("Jordy"))
            {
                Player_sprite = await CanvasBitmap.LoadAsync(sender, new Uri("ms-appx:///Assets/Char/spr_jordy.png"));
                Char_UI = await CanvasBitmap.LoadAsync(sender, new Uri("ms-appx:///Assets/Char/Char_UI/Jordy.png"));
            }
            else if (ChooseCharacter.PlayerCharacter.Equals("Matthew"))
            {
                Player_sprite = await CanvasBitmap.LoadAsync(sender, new Uri("ms-appx:///Assets/Char/spr_matthew.png"));
                Char_UI = await CanvasBitmap.LoadAsync(sender, new Uri("ms-appx:///Assets/Char/Char_UI/Matthew.png"));
            }
            else if (ChooseCharacter.PlayerCharacter.Equals("Hayri"))
            {
                Player_sprite = await CanvasBitmap.LoadAsync(sender, new Uri("ms-appx:///Assets/Char/spr_hayri.png"));
                Char_UI = await CanvasBitmap.LoadAsync(sender, new Uri("ms-appx:///Assets/Char/Char_UI/Hayri.png"));
            }
            else if (ChooseCharacter.PlayerCharacter.Equals("Max"))
            {
                Player_sprite = await CanvasBitmap.LoadAsync(sender, new Uri("ms-appx:///Assets/Char/spr_max.png"));
                Char_UI = await CanvasBitmap.LoadAsync(sender, new Uri("ms-appx:///Assets/Char/Char_UI/Max.png"));
            }
            else if (ChooseCharacter.PlayerCharacter.Equals("Samus"))
            {
                Player_sprite = await CanvasBitmap.LoadAsync(sender, new Uri("ms-appx:///Assets/Char/spr_samus.png"));
                Char_UI = await CanvasBitmap.LoadAsync(sender, new Uri("ms-appx:///Assets/Char/Char_UI/samus.png"));
            }
            Health_Full = await CanvasBitmap.LoadAsync(sender, new Uri("ms-appx:///Assets/UI/Health/health-full.png"));
            Health_Half = await CanvasBitmap.LoadAsync(sender, new Uri("ms-appx:///Assets/UI/Health/health-half.png"));
            Health_Empty = await CanvasBitmap.LoadAsync(sender, new Uri("ms-appx:///Assets/UI/Health/health-empty.png"));

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

 

        private async void GameCanvas_Tapped(object sender, TappedRoutedEventArgs e)
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
                            //await soundController.Play(SoundEfxEnum.SHOOT);

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
#endregion