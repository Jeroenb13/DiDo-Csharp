﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DiDo.Character;
using Microsoft.Graphics.Canvas.UI.Xaml;
using Windows.System;
using DiDo.Levels;
using Windows.UI.Core;

namespace DiDo.Character
{
    public class ClientController : ClientPlayer
    {
        public Dictionary<VirtualKey, Boolean> keysPressed = new Dictionary<VirtualKey, bool>();

        public ClientController(string name, float x, float y) : base(name, x, y)
        {
        }

        private Boolean keyPressed(VirtualKey key)
        {
            if (keysPressed.ContainsKey(key))
            {
                return keysPressed[key];
            }
            return false;
        }

        public void movementCharacter(CanvasControl sender, CanvasDrawEventArgs args, Player player, Levels.Levels gekozenLevel, String[,] level)
        {
            player.x += player.velX;
            player.y += player.velY;

            if (keyPressed(VirtualKey.A))
            {
                Tile tile = gekozenLevel.getPlayerTile(player.x, player.y, level);
                if (tile.CanWalk == true) //positief
                {
                    player.x -= player.move_speed;
                }
                else
                {
                    player.x += player.move_speed;
                }
            }
            else if (keyPressed(VirtualKey.S))
            {
                //args.DrawingSession.DrawImage(PlayerS, player.x, player.y);
                Tile tile = gekozenLevel.getPlayerTile(player.x, player.y, level);
                if (tile.CanWalk == true)
                {
                    player.y += player.move_speed;
                }
                else
                {
                    player.y -= player.move_speed;
                }
            }
            else if (keyPressed(VirtualKey.D))
            {
                Tile tile = gekozenLevel.getPlayerTile(player.x, player.y, level);
                if (tile.CanWalk == true) //positief
                {
                    player.x += player.move_speed;
                }
                else
                {
                    player.x -= player.move_speed;
                }
            }
            else if (keyPressed(VirtualKey.W))
            {
                Tile tile = gekozenLevel.getPlayerTile(player.x, player.y, level);
                if (tile.CanWalk == true)
                {
                    player.y -= player.move_speed;
                }
                else
                {
                    player.y += player.move_speed;
                }
            }
        }

        //Character Movement 
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
