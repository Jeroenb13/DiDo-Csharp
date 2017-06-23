using Microsoft.Graphics.Canvas;
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
using Windows.System.Threading;
using DiDo.Multiplayer;
using Windows.UI.Xaml.Navigation;
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
        public static CanvasBitmap BG, StartScreen, Bullet, Enemy1, Enemy2, CurrentWeapon, sprite, UI_Pistol, UI_SMG, UI_AR, UI_Fists, CurrentArms, Arms_AR, Arms_Pistol, Arms_SMG, Arms_Fists, Player_sprite, Health_Full, Health_Half, Health_Empty, Char_UI;
        public static Transform2DEffect Bullets, PlayerA, PlayerS, PlayerD, PlayerW;
        public static Rect bounds = ApplicationView.GetForCurrentView().VisibleBounds;
        public static float pointX, pointY;
        public Point playerPoint;
        public Point mousePoint;

        private ClientController controller;
        public static bool RoundEnded = false;
        private Levels.Levels levels;
        public static string[,] ChosenLevel;
        bool holding = false;

        //Lists Projectile
        public static List<Bullet> bullets = new List<Bullet>();
        public List<Weapon> weapons;
        public static MyPlayer player;
        public List<Enemy> enemies = new List<Enemy>();
        public float temp_x, temp_y; // Temporary

        private ThreadPoolTimer shootTimer; // timer for shooting the bullets 

        private float xVelAR, yVelAR; // velocity of the Assault rifle weapon

        public double frames = 0;

        public Random random = new Random();

        //Ui elements
        public CanvasTextFormat font = new CanvasTextFormat();
        public Rect ui = new Rect(1150, 5, 300, 800); //UI element 
        public Rect playerRect = new Rect(1150, 5, 300, 200); // Rectangle for the player UI element
        public Rect weaponRect = new Rect(1150, 5, 300, 400); // Rectangle for the player ui element

        /// <summary>
        /// Initialisation of the mainpage for singleplayer
        /// </summary>
        public MainPage()
        {
            // Play background music
            //soundHandler();

            // Player selection
            if (ChooseCharacter.PlayerCharacter.Equals("Jeroen")) // Jeroen is choosen as the player
            {
                player = new MyPlayer("Jeroen", 100, 100, 20, 5, 32, 96); // Set the name and stats of the player
            }
            else if (ChooseCharacter.PlayerCharacter.Equals("Jeffrey")) // Jeffreyis choosen as the player
            {
                player = new MyPlayer("Jeffrey", 100, 100, 30, 5, 32, 96); // Set the name and stats of the player
            }
            else if (ChooseCharacter.PlayerCharacter.Equals("Daan")) // Daanis choosen as the player
            {
                player = new MyPlayer("Daan", 100, 100, 20, 5, 32, 96); // Set the name and stats of the player
            }
            else if (ChooseCharacter.PlayerCharacter.Equals("Jordy")) // Jordyis choosen as the player
            {
                player = new MyPlayer("Jordy", 150, 150, 10, 3, 32, 96); // Set the name and stats of the player
            }
            else if (ChooseCharacter.PlayerCharacter.Equals("Matthew")) // Matthewis choosen as the player
            {
                player = new MyPlayer("Matthew", 100, 100, 40, 5, 32, 96); // Set the name and stats of the player
            }
            else if (ChooseCharacter.PlayerCharacter.Equals("Hayri")) // Hayriis choosen as the player
            {
                player = new MyPlayer("Hayri", 80, 80, 60, 8, 32, 96); // Set the name and stats of the player
            }
            else if (ChooseCharacter.PlayerCharacter.Equals("Max")) // Maxis choosen as the player
            {
                player = new MyPlayer("Max", 100, 100, 30, 6, 32, 96); // Set the name and stats of the player
            }

            else if (ChooseCharacter.PlayerCharacter.Equals("Samus")) // Samusis choosen as the player
            {
                player = new MyPlayer("Samus", 200, 200, 0, 5, 32, 96); // Set the name and stats of the player
            }

            controller = new ClientController(this, player.name, player.maxHealth, player.healthPoints, player.stamina, player.move_speed, player.x, player.y);
            // Add the player to the ClientController
            weapons = new List<Weapon>();
            // Create a list of weapons
            levels = new Levels.Levels();
            // Get the current level

            // Update the mousePointer, Needed to make the player sprite follow the mouse
            mousePoint = new Point();

            this.InitializeComponent();
            Window.Current.SizeChanged += Current_SizeChanged;

            // Set the key events
            Window.Current.CoreWindow.KeyDown += controller.CoreWindow_Keydown;
            Window.Current.CoreWindow.KeyUp += controller.CoreWindow_Keyup;

            // Add the enemies
            this.enemies.Add(new Enemy("Freek", 100, 10, 0, 5, 256, 128)); // The AI Enemy 1
            this.enemies.Add(new Enemy("Albert", 100, 10, 0, 5, 256, 128)); // The AI Enemy 2
            this.enemies.Add(new Enemy("Karel", 100, 10, 0, 5, 256, 128)); // The AI Enemy 3
        }


        /// <summary>
        /// Method for pointer released
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="e">Pointer locations</param>
        private void GameCanvas_PointerReleased(object sender, PointerRoutedEventArgs e)
        {
            if (holding) // Check is mousebutton is pressed
            {
                if(shootTimer != null)
                {
                    shootTimer.Cancel();
                    // Cancel de timer
                }
                holding = false;
                // DThe mouse isnt pressed
            }
        }

        //public SoundEffects soundController;

        private NetHandlerClient netHandler;
        private bool isMultiplayerClient = false;

        protected override async void OnNavigatedTo(NavigationEventArgs e)
        {
            if(e.Parameter != null && e.Parameter is NetHandlerClient)
            {
                this.netHandler = e.Parameter as NetHandlerClient;
                this.isMultiplayerClient = true;
            }
        }
        
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
            foreach (Weapon weapon in weapons)// Walk through all posible weapons
            {
                if (weapon != null) // Show sprite is weapon if there is a weapon
                {
                    args.DrawingSession.DrawImage(weapon.Image, weapon.x, weapon.y);
                    // Draw the weapon
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
            // Increate the frames, needed for the animation

            // scales the player
            if (player.x == 0 && player.y == 0) // If player is spawned
            {
                player.x = 32;
                player.y = 32;
                // Offset the player 1 tile down and right, so is doesnt stand in the wall
            }


            //Draws the Level
            drawLevel(sender, args);

            //Character movement
            controller.movementCharacter(sender, args, player, levels);

            //Bullet handling
            bulletHandling(sender, args);

    
            updatePoint(player);
            // Update the mousePointer where the player looks

            //Draws the enemy
            foreach (Enemy enemy in enemies) // Walk through all enemies
            {
                enemy.randomWalk();
                // Let the enemy walk
                if (enemy.direction == 0)//if enemy is walking and looking up 
                {
                    if ((enemy.x - player.x) < 0 || (enemy.x - player.x) > 0 && enemy.y < player.y)//check if player is in peripheral vision
                    {
                        args.DrawingSession.DrawImage(ImageManipulation.image(Enemy1, radians(playerPoint, new Point(enemy.x, enemy.y))), enemy.x, enemy.y);
                        // Draw the enemy looking to the player
                    }
                    else
                    {
                        args.DrawingSession.DrawImage(ImageManipulation.image(Enemy1, Math.PI), enemy.x, enemy.y);
                        // Draw the enemy looking to the chosen direction
                    }
                }
                else if (enemy.direction == 1)//if enemy is walking and looking right
                {
                    if (enemy.x < player.x && (enemy.y - player.y) < 0 || (enemy.y - player.y) > 0)//check if player is in peripheral vision
                    {
                        args.DrawingSession.DrawImage(ImageManipulation.image(Enemy1, radians(playerPoint, new Point(enemy.x, enemy.y))), enemy.x, enemy.y);
                        // Draw the enemy looking to the player
                    }
                    else
                    {
                        args.DrawingSession.DrawImage(ImageManipulation.image(Enemy1, Math.PI * 0.5), enemy.x, enemy.y);
                        // Draw the enemy looking to the chosen direction
                    }
                }
                else if (enemy.direction == 2)//if enemy is walking and looking down
                {
                    if ((enemy.x - player.x) < 0 || (enemy.x - player.x) > 0 && enemy.y > player.y)//check if player is in peripheral vision
                    {
                        args.DrawingSession.DrawImage(ImageManipulation.image(Enemy1, radians(playerPoint, new Point(enemy.x, enemy.y))), enemy.x, enemy.y);
                        // Draw the enemy looking to the player
                    }
                    else
                    {
                        args.DrawingSession.DrawImage(ImageManipulation.image(Enemy1, 0), enemy.x, enemy.y);
                        // Draw the enemy looking to the chosen direction
                    }
                }
                else if (enemy.direction == 3)//if enemy is walking and looking left
                {
                    if (enemy.x > player.x && (enemy.y - player.y) < 0 || (enemy.y - player.y) > 0)//check if player is in peripheral vision
                    {
                        args.DrawingSession.DrawImage(ImageManipulation.image(Enemy1, radians(playerPoint, new Point(enemy.x, enemy.y))), enemy.x, enemy.y);
                        // Draw the enemy looking to the player
                    }
                    else
                    {
                        args.DrawingSession.DrawImage(ImageManipulation.image(Enemy1, Math.PI * 1.5), enemy.x, enemy.y);
                        // Draw the enemy looking to the chosen direction
                    }
                }

                args.DrawingSession.DrawText(enemy.debugName(), enemy.x - 16, enemy.y - 16, Colors.Black); // Show the enemy name and health
            }

            setSprite(sender, args);
            // Set the sprites


#region
            string fontUI = "ms-appx:/Assets/FFFFORWARD.TTF#FFF Forward";
            
            reloadArms(); //Method for showing the right gun in the UI

            args.DrawingSession.FillRectangle(ui, Colors.SlateGray); //Color of the UI element (1150, 5, 300, 200)
            args.DrawingSession.DrawRectangle(ui, Colors.Black, 10); //UI element (1150, 5, 300, 800)
            args.DrawingSession.DrawRectangle(playerRect, Colors.Black, 10);
            args.DrawingSession.DrawRectangle(weaponRect, Colors.Black, 10);


            args.DrawingSession.DrawImage(ImageManipulation.image(CurrentArms, radians(mousePoint, playerPoint)), player.x, player.y); // Show the correct arms
            args.DrawingSession.DrawImage(ImageManipulation.image(Player_sprite, radians(mousePoint, playerPoint)), player.x, player.y); // make it so that scaling and rotation is not processed each frame      


            /*
                    !! Na debug verwijderen !! 
            */
            args.DrawingSession.DrawText("PLAYER", 1245, 10, Colors.Black, new CanvasTextFormat() { FontSize = 24, FontFamily = fontUI }); // Adding text to the UI element
            args.DrawingSession.DrawText(player.name, 1255, 60, Colors.Black, new CanvasTextFormat() { FontSize = 10, FontFamily = fontUI }); //Adding playername to the UI element
            args.DrawingSession.DrawImage(Char_UI, 1155, 50); //Adding the character playing to the UI element
            args.DrawingSession.DrawText("WEAPON", 1240, 210, Colors.Black, new CanvasTextFormat() { FontSize = 24, FontFamily = fontUI }); // Adding text to the UI 

            if (player.currentWeapon != null) // When there is a weapon choosen
            {
                //args.DrawingSession.DrawText(player.currentWeapon.name, 1225, 240, Colors.MediumBlue); // Adding the weaponname to the UI element
                args.DrawingSession.DrawImage(CurrentWeapon, 1255, 230); //Adding the current weapon to the UI element
            }

            if (player.currentWeapon != null) // When there is a weapon choosen
            {
                args.DrawingSession.DrawText(player.currentWeapon.getAmmo() + "", 1275, 300, Colors.Black, new CanvasTextFormat() { FontSize = 14, FontFamily = fontUI }); //Adding the bullets to the UI element
                args.DrawingSession.DrawText(player.currentWeapon.getAdditionalAmmo() + "", 1325, 300, Colors.Black, new CanvasTextFormat() { FontSize = 14, FontFamily = fontUI }); //Adding the the total bullet amount to the UI element

                if (player.currentWeapon.getAmmo() < 10)// When there are less then 10 bullets
                {
                    args.DrawingSession.DrawText("0", 1265, 300, Colors.Black, new CanvasTextFormat() { FontSize = 14, FontFamily = fontUI });
                    // Show 0 in the UI

                    if (player.currentWeapon.getAmmo() == 0) // When there are no bullets left
                    {
                        args.DrawingSession.DrawText("0", 1265, 300, Colors.DarkRed, new CanvasTextFormat() { FontSize = 14, FontFamily = fontUI });
                        // Show a 0 in the UI
                        args.DrawingSession.DrawText(player.currentWeapon.getAmmo() + "", 1275, 300, Colors.DarkRed, new CanvasTextFormat() { FontSize = 14, FontFamily = fontUI });
                        // Show the ammo in the UI
                        args.DrawingSession.DrawText("RELOAD", 1275, 340, Colors.DarkRed, new CanvasTextFormat() { FontSize = 11, FontFamily = fontUI });
                        // Show RELOAD in the UI
                    }
                    else if(player.currentWeapon.getAmmo() == 0 && player.currentWeapon.getAdditionalAmmo() == 0) // When there are no bullets left
                    {
                        args.DrawingSession.DrawText("OUT OF AMMO", 1275, 340, Colors.DarkRed, new CanvasTextFormat() { FontSize = 11, FontFamily = fontUI });
                        // Show OUT OF AMMO
                    }
                }

                if (player.currentWeapon.getAdditionalAmmo() < 10)  // When there are less then 10 bullets in the aditional magazine
                {
                    args.DrawingSession.DrawText("0", 1315, 300, Colors.Black, new CanvasTextFormat() { FontSize = 14, FontFamily = fontUI });
                    // Show a 0 in the UI

                    if (player.currentWeapon.getAdditionalAmmo() == 0) // When there are no bullets in the aditional magazine
                    {
                        args.DrawingSession.DrawText("0", 1315, 300, Colors.DarkRed, new CanvasTextFormat() { FontSize = 14, FontFamily = fontUI });
                        // Show a 0 in the UI
                        args.DrawingSession.DrawText(player.currentWeapon.getAdditionalAmmo() + "", 1325, 300, Colors.DarkRed, new CanvasTextFormat() { FontSize = 14, FontFamily = fontUI });
                        // Show the bullets of the aditional ammo in the UI
                    }
                }
            }
            
            // Show the stats in the UI
            args.DrawingSession.DrawText("STATS", 1250, 410, Colors.Black, new CanvasTextFormat() { FontSize = 24, FontFamily = fontUI }); //Adding text to the UI element
            args.DrawingSession.DrawText("Health:", 1175, 460, Colors.DarkRed, new CanvasTextFormat() { FontSize = 14, FontFamily = fontUI }); //Adding text to the UI element
            args.DrawingSession.DrawText(player.getHealth() + " | " + player.getMaxHealth(), 1285, 460, Colors.DarkRed, new CanvasTextFormat() { FontSize = 14, FontFamily = fontUI }); //Adding the health amount to the UI element
            args.DrawingSession.DrawText("Stamina: ", 1175, 500, Colors.DeepSkyBlue, new CanvasTextFormat() { FontSize = 14, FontFamily = fontUI }); //Adding text to the UI element
            args.DrawingSession.DrawText(player.stamina + "", 1285, 500, Colors.DeepSkyBlue, new CanvasTextFormat() { FontSize = 14, FontFamily = fontUI }); //Adding the stamina amount to the UI element

            /// <summary>
            /// //Adding the healthbar to the UI element
            /// </summary>
            double maxHealth = player.getMaxHealth();
            // Max health of player
            double currentHealth = player.getHealth();
            // Current health of player
            double calc = (currentHealth / maxHealth) * 100 + 10;
            // Calculate the health

            for (int i = 0; i < 5; i++) // Walk through the maximim amount of hearts in the UI
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

            if (this.isMultiplayerClient)
            {
                this.netHandler.ReadAsync();
            }

            //Triggers the draw event 60 times per second
            GameCanvas.Invalidate();
        }

        public string inventory()
        {
            string inventory = "";
            foreach (Weapon weapon in weapons) // Loop through all weapons
            {
                if (weapon != null) // When there is a weapon
                {
                    inventory = inventory + " | " + weapon.name; // Add weapon to the inventory
                }
            }
            return inventory;
        }
#endregion
        public double xPos, yPos, xPos2, yPos2;
        private float xVel;

        /// <summary>
        /// Checks if the player ammo is null or not and returns the amount
        /// </summary>
        /// <returns></returns>
        public string getPlayerAmmo()
        {
            string ammo;
            if (player.currentWeapon == null) // There is no currentWeapon
            {
                ammo = ""; // There is no ammo
            }
            else
            {
                ammo = player.currentWeapon.getAmmo().ToString();
                // Show the currentWeapon Ammo
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
            if (player.name == null) // There is no player name
            {
                name = ""; // No player name
            }
            else
            {
                name = player.name; // Set the player name
            }
            return name;
            // Return de player name
        }

        /// <summary>
        /// Checks if the player weapon name is null or not and returns the name
        /// </summary>
        /// <returns></returns>
        public string getPlayerWeaponName()
        {
            string weaponName;
            if (player.currentWeapon == null) // No choosen currentWeapon
            {
                weaponName = ""; // No weapon, so no weapon name
            }
            else
            {
                weaponName = player.currentWeapon.name; // Set the name of the current weapon
            }
            return weaponName;
            // return the name of the current weapon
        }

        /// <summary>
        /// Checks if playerAdditional ammo is null or not and returns the amount
        /// </summary>
        /// <returns></returns>
        public string getPlayerWeaponAdditionalAmmo()
        {
            string additionalAmmo;
            if(player.currentWeapon == null) // There is no weapon choosen
            {
                additionalAmmo = ""; // There are no bullets in the aditional magazine
            }
            else
            {
                additionalAmmo = player.currentWeapon.getAdditionalAmmo().ToString();
                // Set the bullets of the aditional magazine
            }
            return additionalAmmo;
            // Return the aditional bullets
        }

        /// <summary>
        /// draws the sprites for the level
        /// </summary>
        public void  drawLevel(ICanvasAnimatedControl sender, CanvasAnimatedDrawEventArgs args)
        {
            var frames_sprite = (int)(this.frames / 15) + 1;
            // Frame sprite for the animations off water and torches

            // Loop through all the tiles in the level
            for (int x = 0; x < levels.gekozenLevel.GetLength(0); x += 1)
            {
                for (int y = 0; y < levels.gekozenLevel.GetLength(1); y += 1)
                {
                    string tileType = levels.gekozenLevel[x, y].ToString();
                    // Get the current tile type
                    string tmp = tileType + "_" + frames_sprite;
                    // Tile type for the choosen animation frame

                    // makes the sprite move
                    if (Levels.Levels.tiles.ContainsKey(tmp)) // if the animated frame exists
                    {
                        Tile tile = Levels.Levels.tiles[tileType + "_" + frames_sprite];
                        args.DrawingSession.DrawImage(
                            tile.Effect,
                            y * 32,
                            x * 32
                        );
                        // Draw the tile to generate the level

                    } else { // Show the default tile sprite
                        Tile tile = Levels.Levels.tiles[tileType];
                        args.DrawingSession.DrawImage(
                            tile.Effect,
                            y * 32,
                            x * 32
                        );
                        // Draw the tile to generate the level

                    }
                }
            }

            if (this.frames > 60)
            {
                this.frames = 0;
                // Set the amount off frames back to 0, needed for the animation
            }

        }

        //public async void soundHandler()
        //{
        //    soundController = new SoundEffects();
        //    await soundController.Play(SoundEfxEnum.BACKGROUND);
        //}

        public void updatePoint(Player player)
        {
            Point newPoint = new Point(player.x, player.y);
            // Create the pointer with the x and y of the player
            this.playerPoint = newPoint;
            // Set the playerpoint
        }

        public void updateMousePoint(object sender, PointerRoutedEventArgs e)
        {
            var pointerPoint = e.GetCurrentPoint(GameCanvas);
            int xPos = (int)pointerPoint.Position.X;
            int yPos = (int)pointerPoint.Position.Y;
            Point newPoint = new Point(xPos, yPos);
            this.mousePoint = newPoint;
            // Update the mousePointer, Needed to follow the mouse
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

        public void addItem(Characters character)
        {
            for (int i = 0; i <= weapons.Count; i++) // Loop through the weapons
            {
                if(character.dropItem() != null) // Drop the weapon is there is a weapon
                {
                    weapons.Add(character.weaponToDrop);
                    character.weaponToDrop = null;
                    // Drop the weapon
                }
            }
        }

        public void removeItem(Weapon item)
        {
            for (int i = 0; i < weapons.Count; i++) // Loop through the items
            {
                if (weapons[i] == item) // If the item is a weapon
                {
                    weapons[i] = null; // Delete the weapon
                }
            }
        }

        private void Current_SizeChanged(object sender, WindowSizeChangedEventArgs e)
        {
            bounds = ApplicationView.GetForCurrentView().VisibleBounds;
            // Get the screen bounds
        }

        public void reloadArms()
        {
            Type weaponType = null;

            weaponType = player.currentWeapon.GetType();
            // Get the current weapon

            if (weaponType == typeof(ARWeapon))
            {
                CurrentArms = Arms_AR;
                CurrentWeapon = UI_AR;
                // Set the correct weapons for the choosen weapon
            }
            else if (weaponType == typeof(PistolWeapon))
            {
                CurrentArms = Arms_Pistol;
                CurrentWeapon = UI_Pistol;
                // Set the correct weapons for the choosen weapon
            }
            else if (weaponType == typeof(SMGWeapon))
            {
                CurrentArms = Arms_SMG;
                CurrentWeapon = UI_SMG;
                // Set the correct weapons for the choosen weapon
            }
            else if (weaponType == typeof(Fist))
            {
                CurrentArms = Arms_Fists;
                CurrentWeapon = UI_Fists;
                // Set the the fists as the current weapon
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
            UI_Fists = await CanvasBitmap.LoadAsync(sender, new Uri("ms-appx:///Assets/UI/fists.png"));
            Bullets = ImageManipulation.img(Bullet);
            Enemy1 = await CanvasBitmap.LoadAsync(sender, new Uri("ms-appx:///Assets/Char/spr_hayri.png"));
            
            ARWeapon.SetImage(await CanvasBitmap.LoadAsync(sender, new Uri("ms-appx:///Assets/Weapons/gun-1.png")));
            SMGWeapon.SetImage(await CanvasBitmap.LoadAsync(sender, new Uri("ms-appx:///Assets/Weapons/gun-2.png")));
            PistolWeapon.SetImage(await CanvasBitmap.LoadAsync(sender, new Uri("ms-appx:///Assets/Weapons/gun-3.png")));

            if (ChooseCharacter.PlayerCharacter.Equals("Jeroen")) // If Jeroen is chooses as as the player
            {
                Player_sprite = await CanvasBitmap.LoadAsync(sender, new Uri("ms-appx:///Assets/Char/spr_jeroen.png"));
                Char_UI = await CanvasBitmap.LoadAsync(sender, new Uri("ms-appx:///Assets/Char/Char_UI/Jeroen.png"));
                    // Set the sprite, and set in in the UI
            }
            else if (ChooseCharacter.PlayerCharacter.Equals("Jeffrey")) // If Jeffrey is chooses as as the player
                {
                Player_sprite = await CanvasBitmap.LoadAsync(sender, new Uri("ms-appx:///Assets/Char/spr_jeffrey.png"));
                Char_UI = await CanvasBitmap.LoadAsync(sender, new Uri("ms-appx:///Assets/Char/Char_UI/Jeffrey.png"));
                    // Set the sprite, and set in in the UI
                }
                else if (ChooseCharacter.PlayerCharacter.Equals("Daan")) // If Daan is chooses as as the player
                {
                Player_sprite = await CanvasBitmap.LoadAsync(sender, new Uri("ms-appx:///Assets/Char/spr_daan.png"));
                Char_UI = await CanvasBitmap.LoadAsync(sender, new Uri("ms-appx:///Assets/Char/Char_UI/Daan.png"));
                    // Set the sprite, and set in in the UI
                }
                else if (ChooseCharacter.PlayerCharacter.Equals("Jordy")) // // If Jordy is chooses as as the player
                {
                Player_sprite = await CanvasBitmap.LoadAsync(sender, new Uri("ms-appx:///Assets/Char/spr_jordy.png"));
                Char_UI = await CanvasBitmap.LoadAsync(sender, new Uri("ms-appx:///Assets/Char/Char_UI/Jordy.png"));
                    // Set the sprite, and set in in the UI
                }
                else if (ChooseCharacter.PlayerCharacter.Equals("Matthew")) // If Matthew is chooses as as the player
                {
                Player_sprite = await CanvasBitmap.LoadAsync(sender, new Uri("ms-appx:///Assets/Char/spr_matthew.png"));
                Char_UI = await CanvasBitmap.LoadAsync(sender, new Uri("ms-appx:///Assets/Char/Char_UI/Matthew.png"));
                    // Set the sprite, and set in in the UI
                }
                else if (ChooseCharacter.PlayerCharacter.Equals("Hayri")) // If Hayri is chooses as as the player
                {
                Player_sprite = await CanvasBitmap.LoadAsync(sender, new Uri("ms-appx:///Assets/Char/spr_hayri.png"));
                Char_UI = await CanvasBitmap.LoadAsync(sender, new Uri("ms-appx:///Assets/Char/Char_UI/Hayri.png"));
                    // Set the sprite, and set in in the UI
                }
                else if (ChooseCharacter.PlayerCharacter.Equals("Max")) // If Max is chooses as as the player
                {
                Player_sprite = await CanvasBitmap.LoadAsync(sender, new Uri("ms-appx:///Assets/Char/spr_max.png"));
                Char_UI = await CanvasBitmap.LoadAsync(sender, new Uri("ms-appx:///Assets/Char/Char_UI/Max.png"));
                    // Set the sprite, and set in in the UI
                }
                else if (ChooseCharacter.PlayerCharacter.Equals("Samus")) // If Samus is chooses as as the player
                {
                Player_sprite = await CanvasBitmap.LoadAsync(sender, new Uri("ms-appx:///Assets/Char/spr_samus.png"));
                Char_UI = await CanvasBitmap.LoadAsync(sender, new Uri("ms-appx:///Assets/Char/Char_UI/samus.png"));
                    // Set the sprite, and set in in the UI
                }
            Health_Full = await CanvasBitmap.LoadAsync(sender, new Uri("ms-appx:///Assets/UI/Health/health-full.png"));
            Health_Half = await CanvasBitmap.LoadAsync(sender, new Uri("ms-appx:///Assets/UI/Health/health-half.png"));
            Health_Empty = await CanvasBitmap.LoadAsync(sender, new Uri("ms-appx:///Assets/UI/Health/health-empty.png"));
            // Images for the Health

            // So that this isn't done on each frame, but only once.

            foreach (Tile t in Levels.Levels.tiles.Values) // Loop through all tiles
            {
                await t.InitBitmap(sender).AsAsyncAction();
                // Load the tiles
            }
        }

        public void bulletHandling(ICanvasAnimatedControl sender, CanvasAnimatedDrawEventArgs args)
        {
            List<Bullet> bulletsToRemove = new List<Bullet>();
            // Create a list for bullets to delete
            List<int> enemiesToRemove = new List<int>();
            // Create a list for enemies to delete

            // Show bullets
            foreach (Bullet bullet in bullets)
            {
                bullet.x += bullet.velX;
                bullet.y += bullet.velY;
                // Move the bullets with choosen velocity
                args.DrawingSession.DrawImage(Bullets, bullet.x, bullet.y);

                
                if (levels.getPlayerTile(bullet.x, bullet.y, levels.gekozenLevel).TileType.Contains("wall")) // If the bullet hits the wall
                {
                    bulletsToRemove.Add(bullet);
                    // Add the bullet to the list of bullets to remove
                }

                if (bullet.y < 0f || bullet.y > 1080 || bullet.x > 1920f || bullet.x < 0f) // Als de kogel buiten beeld gaat
                {
                    bulletsToRemove.Add(bullet);
                    // Add the bullet to the list of bullets to remove
                }

                int enemiesCount = 0;
                foreach (Enemy enemy in enemies) // Loop though all the enemies
                {
                    if ((bullet.y > enemy.y - 16 && bullet.y < enemy.y + 16) && (bullet.x > enemy.x - 16 && bullet.x < enemy.x + 16) && (bullet.eigenaar != enemy.name)) // If the bullet isnt from yourself
                    {
                        enemy.hit(player.currentWeapon.getDamage());
                        // Give the enemy damage from the bullet
                        if (enemy.getHealth() <= 0)
                        {
                            addItem(enemy);
                            // Drop the weapon
                            enemiesToRemove.Add(enemiesCount);
                            // Add the enemy to the enemies to delete

                        }
                        bulletsToRemove.Add(bullet);
                        // Add the bullet to the list of bullets to remove
                    }
                    enemiesCount++;
                    // Increase the enemiesCount
                }

                if ((player.y > player.y - 16 && bullet.y < player.y + 16) && (bullet.x > player.x - 16 && bullet.x < player.x + 16) && (bullet.eigenaar != player.name)) // If the bullet hits the player
                {
                    player.hit(bullet.damage);
                    // Let the player take damage from the bullet
                    bulletsToRemove.Add(bullet);
                    // Add the bullet to the list of bullets to remove

                    if (!player.alive)
                    {
                        Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
                       {
                            Frame.Navigate(typeof(GameOver));
                                                   }).AsTask().Wait();
                       }
                }

            }
            

            // Remove Bullets
            foreach (Bullet bullet in bulletsToRemove)
            {
                bullets.Remove(bullet);
                // Remove bullet
            }

            // Remove enemies
            foreach (int removeEnemy in enemiesToRemove)
            {
                enemies.RemoveAt(removeEnemy);
                // Remove enemy

                // Check if there are enemies left. If not; game is finished
                if (enemies.Count == 0)
                {
                    // Run on UI thread
                    CoreApplication.MainView.CoreWindow.Dispatcher.RunAsync(CoreDispatcherPriority.Normal,
                    () =>
                    {
                        // Navigate to success page
                        Frame.Navigate(typeof(SuccessPage));
                    });
                }
            }
        }

        private void GameCanvas_Tapped(object sender, TappedRoutedEventArgs e)
        {

            float xPos = (float)e.GetPosition(GameCanvas).X;
            // X location of the click
            float yPos = (float)e.GetPosition(GameCanvas).Y;
            // Y location of the click

            float xVel = xPos - player.x;
            // Calculate the X velocity
            float yVel = yPos - player.y;
            // Calculate the Y velocity

            float distance = (float)Math.Sqrt(Math.Pow((double)xVel, 2) + Math.Pow((double)yVel, 2));
            // Pythagoras for calculation of the distance

            float scaling = distance / 25;
            // Scaling for the distance

            xVel = xVel / scaling;
            // X velocity
            yVel = yVel / scaling;

            // Y velocity
            if (player.currentWeapon != null) // If there is weapon choosen
            {
                if (player.currentWeapon.getAmmo() >= 1) // If there are bullets
                {
                    //await soundController.Play(SoundEfxEnum.SHOOT);

                    bullets.Add(new DiDo.Bullet(player.x, player.y, xVel, yVel, player.currentWeapon.getDamage(), player.name));
                    // Add the bullet
                    player.currentWeapon.reduceAmmo();
                    // Decrease the ammo of the player
                }
            }
        }

        private void GameCanvas_PointerMoved(object sender, Windows.UI.Xaml.Input.PointerRoutedEventArgs e)
        {
            updateMousePoint(sender, e);
            // Update the mousePointer for the clicked location
            Pointer ptr = e.Pointer;
            // Create a pointer for the clicked location

            if(ptr.PointerDeviceType == Windows.Devices.Input.PointerDeviceType.Mouse) // If the input device is a mouse
            {
                Windows.UI.Input.PointerPoint ptrPt = e.GetCurrentPoint(GameCanvas);
                if(ptrPt.Properties.IsLeftButtonPressed && !holding) //If the mouse is pressed
                {
                    if (player.currentWeapon.ShouldRepeat) // If its a automatic weapon
                    {
                        holding = true;
                        shootTimer = ThreadPoolTimer.CreatePeriodicTimer(ShootTimerHandler, new TimeSpan(0, 0, 0 ,0, player.currentWeapon.BulletsPerMilliSecond));
                        // Shoot multiple times when the mouse is hold down
                    }
                }
            }
            float xPos = (float)e.GetCurrentPoint(GameCanvas).RawPosition.X;
            // The X location where is clicked
            float yPos = (float)e.GetCurrentPoint(GameCanvas).RawPosition.Y;
            // The Y location  where is clicked

            xVelAR = xPos - player.x;
            // The X velocity
            yVelAR = yPos - player.y;
            // The Y velocity

            float distance = (float)Math.Sqrt(Math.Pow((double)xVelAR, 2) + Math.Pow((double)yVelAR, 2));
            // Pythagoras for calculating the distance
            float scaling = distance / 25;
            // Scale the distance

            xVelAR = xVelAR / scaling;
            yVelAR = yVelAR / scaling;
        }

        /// <summary>
        /// When the timer is elapsed it shoots a bullet
        /// </summary>
        /// <param name="timer"> threadpool timer</param>
        private void ShootTimerHandler(ThreadPoolTimer timer)
        {
            if (player.currentWeapon.getAmmo() >= 1) // Shoot when there is ammo
            {
                float xRand = (float)(random.NextDouble() - 0.5) * player.currentWeapon.RandomisationFactor;
                float yRand = (float)(random.NextDouble() - 0.5) * player.currentWeapon.RandomisationFactor;
                // Set random values to make the weapon less accurate

                bullets.Add(new DiDo.Bullet(player.x, player.y, xVelAR + xRand, yVelAR + yRand, player.currentWeapon.getDamage(), player.name));
                // Add the bullet to the bullets list
                player.currentWeapon.reduceAmmo();
                // Decrease the ammo
            }
        }
    }
}
#endregion