using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DiDo.Character;
using Microsoft.Graphics.Canvas.UI.Xaml;
using Windows.System;
using DiDo.Levels;
using Windows.UI.Core;
using DiDo.Items;

namespace DiDo.Character
{
    public class ClientController : ClientPlayer
    {
        private MainPage mainPage;
        public Dictionary<VirtualKey, Boolean> keysPressed = new Dictionary<VirtualKey, bool>();

        public ClientController(MainPage mainPage, string name, float x, float y) : base(name, x, y)
        {
            this.mainPage = mainPage;   
        }

        private Boolean keyPressed(VirtualKey key)
        {
            if (keysPressed.ContainsKey(key))
            {
                return keysPressed[key];
            }
            return false;
        }

        /// <summary>
        /// Checks if the player can walk on the tile
        /// </summary>
        public void checkTile(Player player, Levels.Levels chosenLevel, String[,] level)
        {
     
        }

        /// <summary>
        /// Movement for the character
        /// </summary>
        /// <param name="sender"> Event handler</param>
        /// <param name="args">Event handler</param>
        /// <param name="player"> The player character</param>
        /// <param name="gekozenLevel">The chosen level</param>
        /// <param name="level">the tilemap for the level</param>
        public void movementCharacter(ICanvasAnimatedControl sender, CanvasAnimatedDrawEventArgs args, Player player, Levels.Levels level)
        {
            player.x += player.velX;
            player.y += player.velY;

            if (keyPressed(VirtualKey.A))
            {
                Tile tile = level.getPlayerTile(player.x -1, player.y, level.gekozenLevel);
                if (tile.CanWalk == true) //positief
                {
                    player.x -= player.move_speed;
                }
                
            }
            else if (keyPressed(VirtualKey.S))
            {
                //args.DrawingSession.DrawImage(PlayerS, player.x, player.y);
                Tile tile = level.getPlayerTile(player.x, player.y+31, level.gekozenLevel);
                if (tile.CanWalk == true)
                {
                    player.y += player.move_speed;
                }
               
            }
            else if (keyPressed(VirtualKey.D))
            {
                Tile tile = level.getPlayerTile(player.x+33, player.y, level.gekozenLevel);
                if (tile.CanWalk == true) //positief
                {
                    player.x += player.move_speed;
                }
                
            }
            else if (keyPressed(VirtualKey.W))
            {
                Tile tile = level.getPlayerTile(player.x, player.y-1, level.gekozenLevel);
                if (tile.CanWalk == true)
                {
                    player.y -= player.move_speed;
                }
            }
            else if(keyPressed(VirtualKey.G))
            {
                mainPage.addItem(player);
            }

            else if (keyPressed(VirtualKey.H))
            {
                for (int i = 0; i < mainPage.weapons.Length; i++)
                {
                    System.Diagnostics.Debug.WriteLine("Player: " + player.x + ", " + player.y);
                    System.Diagnostics.Debug.Write(weapons);
                    if (mainPage.weapons[i] != null)
                    {
                        if ((mainPage.weapons[i].x) - 32 < player.x && player.x < (mainPage.weapons[i].x + 32))
                        {
                            if ((mainPage.weapons[i].y) - 32 < player.y && player.y < (mainPage.weapons[i].y + 32))
                            {
                                player.pickUpWeapon(mainPage.weapons[i]);
                                mainPage.removeItem(mainPage.weapons[i]);
                            }
                        }
                    }
                }
            }
            else if(keyPressed(VirtualKey.Number1))
            {
                player.changeWeapon(1);
            }
            else if (keyPressed(VirtualKey.Number2))
            {
                player.changeWeapon(2);
            }
            else if (keyPressed(VirtualKey.Number3))
            {
                player.changeWeapon(3);
            }
        }

        //Keydown events for character movement
        public void CoreWindow_Keydown(CoreWindow sender, KeyEventArgs args)
        {
            //int move_speed = 5;

            keysPressed[args.VirtualKey] = true;

            //to do keylijst maken keylijst
            if (args.VirtualKey == VirtualKey.A)
            {
                velX = -move_speed;
            }
            else if (args.VirtualKey == VirtualKey.D)
            {
                velX = move_speed;
            }
            else if (args.VirtualKey == VirtualKey.W)
            {
                velY = -move_speed;
            }
            else if (args.VirtualKey == VirtualKey.S)
            {
                velY = move_speed;
            }
        }

        //Key up events to check if the key is stopped being pressed.
        public void CoreWindow_Keyup(CoreWindow sender, KeyEventArgs args)
        {

            keysPressed[args.VirtualKey] = false;

            //to do keylijst maken keylijst
            if (args.VirtualKey == VirtualKey.A)
            {
                velX = 0;
            }
            else if (args.VirtualKey == VirtualKey.D)
            {
                velX = 0;
            }
            else if (args.VirtualKey == VirtualKey.W)
            {
                velY = 0;
            }
            else if (args.VirtualKey == VirtualKey.S)
            {
                velY = 0;
            }

        }
    }
}
