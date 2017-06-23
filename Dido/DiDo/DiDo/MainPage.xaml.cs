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
        public static CanvasBitmap BG, StartScreen, Bullet, Enemy1, Enemy2, CurrentWeapon, sprite, UI_Pistol, UI_SMG, UI_AR, UI_Fists, CurrentArms, Arms_AR, Arms_Pistol, Arms_SMG, Arms_Fists, Player_sprite, Health_Full, Health_Half, Health_Empty, Char_UI;
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
        bool holding = false;

        //Lists Projectile
        public static List<Bullet> bullets = new List<Bullet>();
        public List<Weapon> weapons;
        public static int GameState = 0; // startscreen
        public static DispatcherTimer RoundTimer = new DispatcherTimer();
        public static MyPlayer player;
        public List<Enemy> enemies = new List<Enemy>();
        public float temp_x, temp_y; // Temporary

        private ThreadPoolTimer shootTimer; // timer for shooting the bullets 

        private float xVelAR, yVelAR; // velocity of the Assault rifle weapon

        public double frames = 0;



        private void GameCanvas_PointerReleased(object sender, PointerRoutedEventArgs e)
        {
            if (holding) // Kijk of de muis ingedrukt is
            {
                if(shootTimer != null)
                {
                    shootTimer.Cancel();
                    // Cancel de timer
                }
                holding = false;
                // De muis is niet meer ingedrukt
            }
        }

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
            foreach (Weapon weapon in weapons)// Loop door de mogelijke wapens heen
            {
                if (weapon != null) // Als er wel een wapen is gekozen, toon dat de sprites
                {
                    args.DrawingSession.DrawImage(weapon.Image, weapon.x, weapon.y);
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
            // Verhoog het aantal frames dat is uitgevoerd, nodig voor de animaties

            GameStateManager.GSManager();
            // Laad de gameStateManager

            // scales the player
            if (player.x == 0 && player.y == 0) // Als de player is gespawned
            {
                player.x = 32;
                player.y = 32;
                // Offset de player dan 1 tile naar beneden en naar rechts
            }


            //Draws the Level
            drawLevel(sender, args);

            //Character movement
            controller.movementCharacter(sender, args, player, levels);

            //Bullet handling
            bulletHandling(sender, args);

    
            updatePoint(player);
            // Update de mousePointer waar de speler naar kijkt

            //Draws the enemy
            foreach (Enemy enemy in enemies) // Doorloop alle gevonden enemies
            {
                enemy.randomWalk();
                // Laat de enemy random lopen
                if (enemy.direction == 0)
                {
                    if((enemy.x - player.x) < 0 || (enemy.x - player.x) > 0 && enemy.y < player.y)
                    {
                        args.DrawingSession.DrawImage(ImageManipulation.image(Enemy1, radians(playerPoint, new Point(player.x, player.y))), enemy.x, enemy.y);
                        // Teken de enemy die naar de player kijkt
                    }
                    else
                    {
                        args.DrawingSession.DrawImage(ImageManipulation.image(Enemy1, Math.PI), enemy.x, enemy.y);
                        // Teken de enemy die naar de gekozen direction kijkt
                    }
                }
                else if(enemy.direction == 1)
                {
                    if(enemy.x < player.x && (enemy.y - player.y) < 0 || (enemy.y - player.y) > 0)
                    {
                        args.DrawingSession.DrawImage(ImageManipulation.image(Enemy1, radians(playerPoint, new Point(player.x, player.y))), enemy.x, enemy.y);
                        // Teken de enemy die naar de player kijkt
                    }
                    else
                    {
                        args.DrawingSession.DrawImage(ImageManipulation.image(Enemy1, Math.PI * 0.5), enemy.x, enemy.y);
                        // Teken de enemy die naar de gekozen direction kijkt
                    }
                }
                else if(enemy.direction == 2)
                {
                    if((enemy.x - player.x) < 0 || (enemy.x - player.x) > 0 && enemy.y > player.y)
                    {
                        args.DrawingSession.DrawImage(ImageManipulation.image(Enemy1, radians(playerPoint, new Point(player.x, player.y))), enemy.x, enemy.y);
                        // Teken de enemy die naar de player kijkt
                    }
                    else
                    {
                        args.DrawingSession.DrawImage(ImageManipulation.image(Enemy1, 0), enemy.x, enemy.y);
                        // Teken de enemy die naar de gekozen direction kijkt
                    }
                }
                else if(enemy.direction == 3)
                {
                    if(enemy.x > player.x && (enemy.y - player.y) < 0 || (enemy.y - player.y) > 0)
                    {
                        args.DrawingSession.DrawImage(ImageManipulation.image(Enemy1, radians(playerPoint, new Point(player.x, player.y))), enemy.x, enemy.y);
                        // Teken de enemy die naar de player kijkt
                    }
                    else
                    {
                        args.DrawingSession.DrawImage(ImageManipulation.image(Enemy1, Math.PI * 1.5), enemy.x, enemy.y);
                        // Teken de enemy die naar de gekozen direction kijkt
                    }
                }
                else
                {
                    if (enemy.direction == 0)
                    {
                        args.DrawingSession.DrawImage(ImageManipulation.image(Enemy1, Math.PI), enemy.x, enemy.y);
                        // Teken de enemy die naar de gekozen direction kijkt
                    }
                    else if (enemy.direction == 1)
                    {
                        args.DrawingSession.DrawImage(ImageManipulation.image(Enemy1, Math.PI * 0.5), enemy.x, enemy.y);
                        // Teken de enemy die naar de gekozen direction kijkt
                    }
                    else if (enemy.direction == 2)
                    {
                        args.DrawingSession.DrawImage(ImageManipulation.image(Enemy1, 0), enemy.x, enemy.y);
                        // Teken de enemy die naar de gekozen direction kijkt
                    }
                    else
                    {
                        args.DrawingSession.DrawImage(ImageManipulation.image(Enemy1, Math.PI * 1.5), enemy.x, enemy.y);
                        // Teken de enemy die naar de gekozen direction kijkt
                    }
                }

                args.DrawingSession.DrawText(enemy.debugName(), enemy.x - 16, enemy.y - 16, Colors.Black); // Toon de enemy naam en levens
            }

            setSprite(sender, args);
            // Zet de sprites


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
        private float xVel;

        //public String type_tile;

        /// <summary>
        /// Checks if the player ammo is null or not and returns the amount
        /// </summary>
        /// <returns></returns>
        public string getPlayerAmmo()
        {
            string ammo;
            if (player.currentWeapon == null) // Er is geen wapen gekozen
            {
                ammo = ""; // Er is dus geen Ammo
            }
            else
            {
                ammo = player.currentWeapon.getAmmo().ToString();
                // Toon de Ammo van het gekozen wapen
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
            if (player.name == null) // Er is geen player name
            {
                name = ""; // Geen naam bekend
            }
            else
            {
                name = player.name; // Zet de player name
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
            if (player.currentWeapon == null) // Er is geen wapen gekozen
            {
                weaponName = ""; // Geen wapen naam
            }
            else
            {
                weaponName = player.currentWeapon.name; // Zet de naam van het wapen
            }
            return weaponName;
            // return de naam van het wapen
        }

        /// <summary>
        /// Checks if playerAdditional ammo is null or not and returns the amount
        /// </summary>
        /// <returns></returns>
        public string getPlayerWeaponAdditionalAmmo()
        {
            string additionalAmmo;
            if(player.currentWeapon == null) // Er is geen wapen gekozen
            {
                additionalAmmo = ""; // Er zijn dus ook geen extra kogels in een overig magazijn
            }
            else
            {
                additionalAmmo = player.currentWeapon.getAdditionalAmmo().ToString();
                // Zet de kogels van het extra magazijn
            }
            return additionalAmmo;
            // Return de extra kogels
        }

        /// <summary>
        /// draws the sprites for the level
        /// </summary>
        public void  drawLevel(ICanvasAnimatedControl sender, CanvasAnimatedDrawEventArgs args)
        {
            var frames_sprite = (int)(this.frames / 15) + 1;
            // Frame sprite voor de animaties van water en torches

            // Doorloop de tiles van het level
            for (int x = 0; x < levels.gekozenLevel.GetLength(0); x += 1)
            {
                for (int y = 0; y < levels.gekozenLevel.GetLength(1); y += 1)
                {
                    string tileType = levels.gekozenLevel[x, y].ToString();
                    // haal de tile type op
                    string tmp = tileType + "_" + frames_sprite;
                    // Tile type met de gekozen animatie frame

                    // makes the sprite move
                    if (Levels.Levels.tiles.ContainsKey(tmp)) // Als de animated frame sprite bestaat, deze toevoegen
                    {
                        Tile tile = Levels.Levels.tiles[tileType + "_" + frames_sprite];
                        args.DrawingSession.DrawImage(
                            tile.Effect,
                            y * 32,
                            x * 32
                        );
                        // Render de tile om de level te genereren

                    } else { // Toon de standaard sprite, er is geen animatie mogelijk
                        Tile tile = Levels.Levels.tiles[tileType];
                        args.DrawingSession.DrawImage(
                            tile.Effect,
                            y * 32,
                            x * 32
                        );
                        // Render de tile om de level te genereren

                    }
                }
            }

            if (this.frames > 60)
            {
                this.frames = 0;
                // Zet het aantal frames weer terug naar 0, dit is nodig voor de animaties
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

            // Player selection
            if (ChooseCharacter.PlayerCharacter.Equals("Jeroen")) // Jeroen is gekozen als player
            {
                player = new MyPlayer("Jeroen", 100, 100, 20, 5, 32, 96); // Laat de speler met de naam en stats van de speler
            }
            else if (ChooseCharacter.PlayerCharacter.Equals("Jeffrey")) // Jeffrey is gekozen als player
            {
                player = new MyPlayer("Jeffrey", 100, 100, 30, 5, 32, 96); // Laat de speler met de naam en stats van de speler
            }
            else if (ChooseCharacter.PlayerCharacter.Equals("Daan")) // Daan is gekozen als player
            {
                player = new MyPlayer("Daan", 100, 100, 20, 5, 32, 96); // Laat de speler met de naam en stats van de speler
            }
            else if (ChooseCharacter.PlayerCharacter.Equals("Jordy")) // Jordy is gekozen als player
            {
                player = new MyPlayer("Jordy", 150, 150, 10, 3, 32, 96); // Laat de speler met de naam en stats van de speler
            }
            else if (ChooseCharacter.PlayerCharacter.Equals("Matthew")) // Matthew is gekozen als player
            {
                player = new MyPlayer("Matthew", 100, 100, 40, 5, 32, 96); // Laat de speler met de naam en stats van de speler
            }
            else if (ChooseCharacter.PlayerCharacter.Equals("Hayri")) // Hayri is gekozen als player
            {
                player = new MyPlayer("Hayri", 80, 80, 60, 8, 32, 96); // Laat de speler met de naam en stats van de speler
            }
            else if (ChooseCharacter.PlayerCharacter.Equals("Max")) // Max is gekozen als player
            {
                player = new MyPlayer("Max", 100, 100, 30, 6, 32, 96); // Laat de speler met de naam en stats van de speler
            }

            else if (ChooseCharacter.PlayerCharacter.Equals("Samus")) // Samus is gekozen als player
            {
                player = new MyPlayer("Samus", 200, 200, 0, 5, 32, 96); // Laat de speler met de naam en stats van de speler
            }

            controller = new ClientController(this, player.name, player.maxHealth, player.healthPoints, player.stamina , player.move_speed, player.x, player.y);
            // Voeg de player toe aan de ClientController
            weapons = new List<Weapon>();
            // Maak een lijst van wapens
            levels = new Levels.Levels();
            // Haal de level op
            
            // Update de mousePointer, nodig voor het volgen van de muis
            mousePoint = new Point();
            
            this.InitializeComponent();
            Window.Current.SizeChanged += Current_SizeChanged;
           
            // Timer voor de ronde tijd
            RoundTimer.Tick += RoundTimer_Tick;
            RoundTimer.Interval = new TimeSpan(0, 0, 1);

            // Stel de key events in
            Window.Current.CoreWindow.KeyDown += controller.CoreWindow_Keydown;
            Window.Current.CoreWindow.KeyUp += controller.CoreWindow_Keyup;

            // Voeg de enemies toe
            this.enemies.Add(new Enemy("Freek", 100, 100, 0, 5, 256, 128)); // The AI Enemy 1
            this.enemies.Add(new Enemy("Albert", 100, 100, 0, 5, 256, 128)); // The AI Enemy 2
            this.enemies.Add(new Enemy("Karel", 100, 100, 0, 5, 256, 128)); // The AI Enemy 3
        }

        //private void GameCanvas_Holding(object sender, HoldingRoutedEventArgs e)
        //{
        //    float xPos = (float)e.GetPosition(GameCanvas).X;
        //    float yPos = (float)e.GetPosition(GameCanvas).Y;

        //    float xVel = xPos - player.x;
        //    float yVel = yPos - player.y;

        //    // pythagorasmagic
        //    float distance = (float)Math.Sqrt(Math.Pow((double)xVel, 2) + Math.Pow((double)yVel, 2));
        //    float scaling = distance / 25;

        //    xVel = xVel / scaling;
        //    yVel = yVel / scaling;
        //    if (player.currentWeapon != null)
        //    {
        //        if (player.currentWeapon.getAmmo() >= 1)
        //        {
        //            //await soundController.Play(SoundEfxEnum.SHOOT);

        //            //Debug.WriteLine(player.currentWeapon.getDamage());
        //            bullets.Add(new DiDo.Bullet(player.x, player.y, xVel, yVel, player.currentWeapon.getDamage()));
        //            player.currentWeapon.reduceAmmo();
        //        }
        //    }
        //}

        public void updatePoint(Player player)
        {
            Point newPoint = new Point(player.x, player.y);
            // Maak een pointer van de x en y van de player
            this.playerPoint = newPoint;
            // Zet de playerPoint
        }



        public void updateMousePoint(object sender, PointerRoutedEventArgs e)
        {
            var pointerPoint = e.GetCurrentPoint(GameCanvas);
            int xPos = (int)pointerPoint.Position.X;
            int yPos = (int)pointerPoint.Position.Y;
            Point newPoint = new Point(xPos, yPos);
            this.mousePoint = newPoint;
            // Update de mousePointer, nodig voor volgen van de muis
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


        private void RoundTimer_Tick(object sender, object e)
        {
            // Ronde tijd verlagen
            countdown -= 1;
            if (countdown < 1) // Als de tijd over is
            {
                RoundTimer.Stop();
                RoundEnded = true;
                // Geef aan dat de ronde over is
            }
        }

        public void addItem(Characters character)
        {
            for (int i = 0; i <= weapons.Count; i++) // Doorloop de wapens
            {
                if(character.dropItem() != null) // Drop het wapen als er een wapen is
                {
                    weapons.Add(character.weaponToDrop);
                    character.weaponToDrop = null;
                    // Drop het wapen
                }
            }
        }

        public void removeItem(Weapon item)
        {
            for (int i = 0; i < weapons.Count; i++) // Doorloop de items
            {
                if (weapons[i] == item) // Als het wapen een item is
                {
                    weapons[i] = null; // Verwijder het wapen
                }
            }
        }

        private void Current_SizeChanged(object sender, WindowSizeChangedEventArgs e)
        {
            bounds = ApplicationView.GetForCurrentView().VisibleBounds;
            // Haal de bounds van het scherm op
        }

        public void reloadArms()
        {
            Type weaponType = null;

            weaponType = player.currentWeapon.GetType();
            // Haal het type wapen op

            if (weaponType == typeof(ARWeapon))
            {
                CurrentArms = Arms_AR;
                CurrentWeapon = UI_AR;
                // Stel in welke armen er nodig zijn voor dit wapen
            }
            else if (weaponType == typeof(PistolWeapon))
            {
                CurrentArms = Arms_Pistol;
                CurrentWeapon = UI_Pistol;
                // Stel in welke armen er nodig zijn voor dit wapen
            }
            else if (weaponType == typeof(SMGWeapon))
            {
                CurrentArms = Arms_SMG;
                CurrentWeapon = UI_SMG;
                // Stel in welke armen er nodig zijn voor dit wapen
            }
            else if (weaponType == typeof(Fist))
            {
                CurrentArms = Arms_Fists;
                CurrentWeapon = UI_Fists;
                // Stel in dat de armen getoond worden
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

            if (ChooseCharacter.PlayerCharacter.Equals("Jeroen"))
            // Bewaar de images, zodat deze niet elke keer worden opgehaald

            if (ChooseCharacter.PlayerCharacter.Equals("Jeroen")) // Als Jeroen is gekozen als player
            {
                Player_sprite = await CanvasBitmap.LoadAsync(sender, new Uri("ms-appx:///Assets/Char/spr_jeroen.png"));
                Char_UI = await CanvasBitmap.LoadAsync(sender, new Uri("ms-appx:///Assets/Char/Char_UI/Jeroen.png"));
                // Stel de sprite, en de sprite in de UI in
            }
            else if (ChooseCharacter.PlayerCharacter.Equals("Jeffrey")) // Als Jeffrey is gekozen als player
            {
                Player_sprite = await CanvasBitmap.LoadAsync(sender, new Uri("ms-appx:///Assets/Char/spr_jeffrey.png"));
                Char_UI = await CanvasBitmap.LoadAsync(sender, new Uri("ms-appx:///Assets/Char/Char_UI/Jeffrey.png"));
                // Stel de sprite, en de sprite in de UI in
            }
            else if (ChooseCharacter.PlayerCharacter.Equals("Daan")) // Als Daan is gekozen als player
            {
                Player_sprite = await CanvasBitmap.LoadAsync(sender, new Uri("ms-appx:///Assets/Char/spr_daan.png"));
                Char_UI = await CanvasBitmap.LoadAsync(sender, new Uri("ms-appx:///Assets/Char/Char_UI/Daan.png"));
                // Stel de sprite, en de sprite in de UI in
            }
            else if (ChooseCharacter.PlayerCharacter.Equals("Jordy")) // Als Jordy is gekozen als player
            {
                Player_sprite = await CanvasBitmap.LoadAsync(sender, new Uri("ms-appx:///Assets/Char/spr_jordy.png"));
                Char_UI = await CanvasBitmap.LoadAsync(sender, new Uri("ms-appx:///Assets/Char/Char_UI/Jordy.png"));
                // Stel de sprite, en de sprite in de UI in
            }
            else if (ChooseCharacter.PlayerCharacter.Equals("Matthew")) // Als Matthew is gekozen als player
            {
                Player_sprite = await CanvasBitmap.LoadAsync(sender, new Uri("ms-appx:///Assets/Char/spr_matthew.png"));
                Char_UI = await CanvasBitmap.LoadAsync(sender, new Uri("ms-appx:///Assets/Char/Char_UI/Matthew.png"));
                // Stel de sprite, en de sprite in de UI in
            }
            else if (ChooseCharacter.PlayerCharacter.Equals("Hayri")) // Als Hayri is gekozen als player
            {
                Player_sprite = await CanvasBitmap.LoadAsync(sender, new Uri("ms-appx:///Assets/Char/spr_hayri.png"));
                Char_UI = await CanvasBitmap.LoadAsync(sender, new Uri("ms-appx:///Assets/Char/Char_UI/Hayri.png"));
                // Stel de sprite, en de sprite in de UI in
            }
            else if (ChooseCharacter.PlayerCharacter.Equals("Max")) // Als Max is gekozen als player
            {
                Player_sprite = await CanvasBitmap.LoadAsync(sender, new Uri("ms-appx:///Assets/Char/spr_max.png"));
                Char_UI = await CanvasBitmap.LoadAsync(sender, new Uri("ms-appx:///Assets/Char/Char_UI/Max.png"));
                // Stel de sprite, en de sprite in de UI in
            }
            else if (ChooseCharacter.PlayerCharacter.Equals("Samus")) // Als Samus is gekozen als player
            {
                Player_sprite = await CanvasBitmap.LoadAsync(sender, new Uri("ms-appx:///Assets/Char/spr_samus.png"));
                Char_UI = await CanvasBitmap.LoadAsync(sender, new Uri("ms-appx:///Assets/Char/Char_UI/samus.png"));
                // Stel de sprite, en de sprite in de UI in
            }
            Health_Full = await CanvasBitmap.LoadAsync(sender, new Uri("ms-appx:///Assets/UI/Health/health-full.png"));
            Health_Half = await CanvasBitmap.LoadAsync(sender, new Uri("ms-appx:///Assets/UI/Health/health-half.png"));
            Health_Empty = await CanvasBitmap.LoadAsync(sender, new Uri("ms-appx:///Assets/UI/Health/health-empty.png"));
            // Afbeeldingen voor de Health

            // So that this isn't done on each frame, but only once.

            foreach (Tile t in Levels.Levels.tiles.Values) // Doorloop alle types health
            {
                await t.InitBitmap(sender).AsAsyncAction();
                // Laad de tiles
            }
        }

        public void bulletHandling(ICanvasAnimatedControl sender, CanvasAnimatedDrawEventArgs args)
        {
            List<Bullet> bulletsToRemove = new List<Bullet>();
            // Maak een lijst voor de te verwijderen kogels, dit gebeurt na de iterate
            List<int> enemiesToRemove = new List<int>();
            // Maak een lijst voor de te verwijderen enemies, dit gebeurt na de iterate

            // Show bullets
            foreach (Bullet bullet in bullets)
            {
                bullet.x += bullet.velX;
                bullet.y += bullet.velY;
                // Verplaats de kogel met de gekozen velocity
                args.DrawingSession.DrawImage(Bullets, bullet.x, bullet.y);

                
                if (levels.getPlayerTile(bullet.x, bullet.y, levels.gekozenLevel).TileType.Contains("wall")) // Als de kogel een muur raakt
                {
                    bulletsToRemove.Add(bullet);
                    // Voeg de kogels aan de te verwijderen kogels toe
                }

                if (bullet.y < 0f || bullet.y > 1080 || bullet.x > 1920f || bullet.x < 0f) // Als de kogel buiten beeld gaat
                {
                    bulletsToRemove.Add(bullet);
                    // Voeg de kogels aan de te verwijderen kogels toe
                }

                int enemiesCount = 0;
                foreach (Enemy enemy in enemies) // Doorloop de enemies
                {
                    if ((bullet.y > enemy.y - 16 && bullet.y < enemy.y + 16) && (bullet.x > enemy.x - 16 && bullet.x < enemy.x + 16) && (bullet.eigenaar != enemy.name)) // Als de kogel niet van jezelf is, en in de buurt van de enemy komt
                    {
                        enemy.hit(player.currentWeapon.getDamage());
                        // Geef de enemy schade door de kogel
                        if (enemy.getHealth() <= 0)
                        {
                            addItem(enemy);
                            // Drop het wapen
                            enemiesToRemove.Add(enemiesCount);
                            // Voeg de enemy aan de te verwijderen enemies toe
                        }
                        bulletsToRemove.Add(bullet);
                        // Voeg de kogels aan de te verwijderen kogels toe
                    }
                    enemiesCount++;
                    // Verhoog het aantal enemies
                }

                if ((player.y > player.y - 16 && bullet.y < player.y + 16) && (bullet.x > player.x - 16 && bullet.x < player.x + 16) && (bullet.eigenaar != player.name))// als de kogels de player raakt
                {
                    player.hit(bullet.damage);
                    // Zorg dat de player schade krijgt
                    bulletsToRemove.Add(bullet);
                    // Voeg de kogels aan de te verwijderen kogels toe
                }

            }
            

            // Remove Bullets
            foreach (Bullet bullet in bulletsToRemove)
            {
                bullets.Remove(bullet);
                // Verwijder de kogels
            }

            // Remove enemies
            foreach (int removeEnemy in enemiesToRemove)
            {
                enemies.RemoveAt(removeEnemy);
                // Verwijder de enemies
            }
        }

        private void GameCanvas_Tapped(object sender, TappedRoutedEventArgs e)
        {

            if (RoundEnded == true)
            {
                GameState = 0;
                RoundEnded = false;
                countdown = 60;
                // De ronde is afgelopen
            }
            else
            {
                if (GameState == 0)
                {
                    GameState += 1;
                    // Verhoog de gameState
                    RoundTimer.Start();
                    // Start de ronde
                }
                else if (GameState > 0)
                {
                    RoundTimer.Start();
                    // Start de ronde

                    float xPos = (float)e.GetPosition(GameCanvas).X;
                    // X locatie waar word geklikt
                    float yPos = (float)e.GetPosition(GameCanvas).Y;
                    // Y locatie waar word geklikt

                    float xVel = xPos - player.x;
                    // Bereken de X velocity
                    float yVel = yPos - player.y;
                    // Bereken de Y velocity

                    float distance = (float)Math.Sqrt(Math.Pow((double)xVel, 2) + Math.Pow((double)yVel, 2));
                    // Pythagoras voor het berekenen van de afstand

                    float scaling = distance / 25;
                    // Scaling bij de afstand

                    xVel = xVel / scaling;
                    // X velocity
                    yVel = yVel / scaling;
                    // Y velocity
                    if (player.currentWeapon != null) // Als er een wapen is gekozen
                    {
                        if (player.currentWeapon.getAmmo() >= 1) // Als er kogels zijn
                        {
                            //await soundController.Play(SoundEfxEnum.SHOOT);

                            bullets.Add(new DiDo.Bullet(player.x, player.y, xVel, yVel, player.currentWeapon.getDamage(), player.name));
                            // Voeg de kogels toe
                            player.currentWeapon.reduceAmmo();
                            // Verlaag de ammo van de player
                        }
                    }
                }
            }
        }

        private void GameCanvas_PointerMoved(object sender, Windows.UI.Xaml.Input.PointerRoutedEventArgs e)
        {
            updateMousePoint(sender, e);
            // Update de mousePointer voor waar er geklikt is
            Pointer ptr = e.Pointer;
            // Maak een mounter aan met de geklikte locatie

            if(ptr.PointerDeviceType == Windows.Devices.Input.PointerDeviceType.Mouse) // Als de invoer een muis is
            {
                Windows.UI.Input.PointerPoint ptrPt = e.GetCurrentPoint(GameCanvas);
                if(ptrPt.Properties.IsLeftButtonPressed && !holding) //Als de muisknop ingedrukt is
                {
                    if (player.currentWeapon.ShouldRepeat) // Als het een automatisch wapen is
                    {
                        holding = true;
                        shootTimer = ThreadPoolTimer.CreatePeriodicTimer(ShootTimerHandler, new TimeSpan(0, 0, 0 ,0, player.currentWeapon.BulletsPerMilliSecond));
                        // Schiet een paar keer door het ingedrukt houden
                    }
                }
            }
            float xPos = (float)e.GetCurrentPoint(GameCanvas).RawPosition.X;
            // De X locatie waar word geklikt
            float yPos = (float)e.GetCurrentPoint(GameCanvas).RawPosition.Y;
            // De Y locatie waar word geklikt

            xVelAR = xPos - player.x;
            // De X velocity
            yVelAR = yPos - player.y;
            // De Y velocity

            float distance = (float)Math.Sqrt(Math.Pow((double)xVelAR, 2) + Math.Pow((double)yVelAR, 2));
            // Pythagoras voor het berekenen van de afstand
            float scaling = distance / 25;
            // Scale de distance

            xVelAR = xVelAR / scaling;
            yVelAR = yVelAR / scaling;


            //Debug.WriteLine(e.GetCurrentPoint(GameCanvas).RawPosition.ToString());
        }

        /// <summary>
        /// When the timer is elapsed it shoots a bullet
        /// </summary>
        /// <param name="timer"> threadpool timer</param>
        private void ShootTimerHandler(ThreadPoolTimer timer)
        {
            if (player.currentWeapon.getAmmo() >= 1) // Schieten als er ammo is
            {
                float xRand = (float)(random.NextDouble() - 0.5) * player.currentWeapon.RandomisationFactor;
                float yRand = (float)(random.NextDouble() - 0.5) * player.currentWeapon.RandomisationFactor;
                // Bereken random waardes voor het schieten, zodat het wapen minder nauwkeurig is

                bullets.Add(new DiDo.Bullet(player.x, player.y, xVelAR + xRand, yVelAR + yRand, player.currentWeapon.getDamage(), player.name));
                // Voeg de kogel toe aan de lijst van kogels
                player.currentWeapon.reduceAmmo();
                // Verlaag na het schieten het aantal kogels
            }
        }
    }
}
#endregion