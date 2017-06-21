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

        private SoundEffects soundController;

        public ClientController(MainPage mainPage, string name, int maxHealth, int healthPoints, int stamina, int move_speed, float x, float y) : base(name, maxHealth, healthPoints, stamina, move_speed, x, y)
        {
            this.mainPage = mainPage;
            this.soundController = new SoundEffects();
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
        public async void movementCharacter(ICanvasAnimatedControl sender, CanvasAnimatedDrawEventArgs args, Player player, Levels.Levels level)
        {
            player.x += player.velX;
            player.y += player.velY;

            if (keyPressed(VirtualKey.A) && !keyPressed(VirtualKey.Shift))
            {
                Tile tile = level.getPlayerTile(player.x -1, player.y, level.gekozenLevel);
                if (tile.CanWalk == true) //positive
                {
                    player.x -= player.move_speed;
                    player.returnStamina();
                }
                
            }
             if (keyPressed(VirtualKey.S) && !keyPressed(VirtualKey.Shift))
            {
                //args.DrawingSession.DrawImage(PlayerS, player.x, player.y);
                Tile tile = level.getPlayerTile(player.x, player.y+33, level.gekozenLevel);
                if (tile.CanWalk == true)
                {
                    player.y += player.move_speed;
                    player.returnStamina();
                }
               
            }
             if (keyPressed(VirtualKey.D) && !keyPressed(VirtualKey.Shift))
            {
                Tile tile = level.getPlayerTile(player.x+33, player.y, level.gekozenLevel);
                if (tile.CanWalk == true) //positive
                {
                    player.x += player.move_speed;
                    player.returnStamina();
                }
                
            }
             if (keyPressed(VirtualKey.W) && !keyPressed(VirtualKey.Shift))
            {
                Tile tile = level.getPlayerTile(player.x, player.y-1, level.gekozenLevel);
                if (tile.CanWalk == true)
                {
                    player.y -= player.move_speed;
                    player.returnStamina();
                }
            }
             if (keyPressed(VirtualKey.A) && keyPressed(VirtualKey.Shift))
            {
                Tile tile = level.getPlayerTile(player.x - 1, player.y, level.gekozenLevel);
                if (tile.CanWalk == true) //positive
                {
                    player.x -= player.run();
                }

            }
             if (keyPressed(VirtualKey.S) && keyPressed(VirtualKey.Shift))
            {
                //args.DrawingSession.DrawImage(PlayerS, player.x, player.y);
                Tile tile = level.getPlayerTile(player.x, player.y + 33, level.gekozenLevel);
                if (tile.CanWalk == true)
                {
                    player.y += player.run();
                }

            }
             if (keyPressed(VirtualKey.D) && keyPressed(VirtualKey.Shift))
            {
                Tile tile = level.getPlayerTile(player.x + 33, player.y, level.gekozenLevel);
                if (tile.CanWalk == true) //positive
                {
                    player.x += player.run();
                }

            }
             if (keyPressed(VirtualKey.W) && keyPressed(VirtualKey.Shift))
            {
                Tile tile = level.getPlayerTile(player.x, player.y - 1, level.gekozenLevel);
                if (tile.CanWalk == true)
                {
                    player.y -= player.run();
                }
            }//Drop item in hand
             if(keyPressed(VirtualKey.G))
            {
                mainPage.addItem(player);
            }
             //Pickup Item 
             if (keyPressed(VirtualKey.H))
            {
                for (int i = 0; i < mainPage.weapons.Count; i++)
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
             if (keyPressed(VirtualKey.R))
            {
                // The current weapon holds less bullets than it can
                if (player.currentWeapon.getAmmo() < player.currentWeapon.getMagazineSize())
                {
                    // The current weapon has additional ammo
                    if (player.currentWeapon.getAdditionalAmmo() > 0)
                    {
                        await soundController.Play(SoundEfxEnum.RELOAD);
                        int difference = player.currentWeapon.getMagazineSize() - player.currentWeapon.getAmmo();
                        if (player.currentWeapon.getAdditionalAmmo() <= difference)
                        {
                            player.currentWeapon.setAmmo(player.currentWeapon.getAmmo() + player.currentWeapon.getAdditionalAmmo());
                            player.currentWeapon.setAdditionalAmmo(0);
                        } else
                        {
                            player.currentWeapon.setAmmo(player.currentWeapon.getMagazineSize());
                            player.currentWeapon.setAdditionalAmmo(player.currentWeapon.getAdditionalAmmo() - difference);
                        }
                    }
                }
            }
             if(keyPressed(VirtualKey.Number1))
            {
                player.changeWeapon(1);
                mainPage.reloadArms();
            }
             if (keyPressed(VirtualKey.Number2))
            {
                player.changeWeapon(2);
                mainPage.reloadArms();
            }
             if (keyPressed(VirtualKey.Number3))
            {
                player.changeWeapon(3);
                mainPage.reloadArms();
            }
             if (keyPressed(VirtualKey.Space))
            {
                player.hit(1);
            }
             if (!keyPressed(VirtualKey.Shift))
            {
                player.returnStamina();
            }
        }

        //Keydown events for character movement
        public void CoreWindow_Keydown(CoreWindow sender, KeyEventArgs args)
        {
            //int move_speed = 5;

            keysPressed[args.VirtualKey] = true;

            // TODO: make keylist
            if (args.VirtualKey == VirtualKey.A && args.VirtualKey != VirtualKey.Shift)
            {
                velX = -move_speed;
            }
             if (args.VirtualKey == VirtualKey.D && args.VirtualKey != VirtualKey.Shift)
            {
                velX = move_speed;
            }
             if (args.VirtualKey == VirtualKey.W && args.VirtualKey != VirtualKey.Shift)
            {
                velY = -move_speed;
            }
             if (args.VirtualKey == VirtualKey.S && args.VirtualKey != VirtualKey.Shift)
            {
                velY = move_speed;
            }
             if (args.VirtualKey == VirtualKey.A && args.VirtualKey == VirtualKey.Shift)
            {
                velX = - run();
            }
             if (args.VirtualKey == VirtualKey.D && args.VirtualKey == VirtualKey.Shift)
            {
                velX = run();
            }
             if (args.VirtualKey == VirtualKey.W && args.VirtualKey == VirtualKey.Shift)
            {
                velY = - run();
            }
             if (args.VirtualKey == VirtualKey.S && args.VirtualKey == VirtualKey.Shift)
            {
                velY = run();
            }
        }

        //Key up events to check if the key is stopped being pressed.
        public void CoreWindow_Keyup(CoreWindow sender, KeyEventArgs args)
        {

            keysPressed[args.VirtualKey] = false;

            // TODO: make keylist
            if (args.VirtualKey == VirtualKey.A)
            {
                velX = 0;
            }
             if (args.VirtualKey == VirtualKey.D)
            {
                velX = 0;
            }
             if (args.VirtualKey == VirtualKey.W)
            {
                velY = 0;
            }
             if (args.VirtualKey == VirtualKey.S)
            {
                velY = 0;
            }

        }
    }
}
