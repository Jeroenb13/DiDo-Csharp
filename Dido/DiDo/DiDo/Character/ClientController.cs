using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DiDo.Character;
using Microsoft.Graphics.Canvas.UI.Xaml;
using Windows.System;
using DiDo.Levels;

namespace DiDo.Character
{
    class ClientController
    {
        public Dictionary<VirtualKey, Boolean> keysPressed = new Dictionary<VirtualKey, bool>();

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
                if (tile.CanWalk == false) //positief
                {
                    player.x += player.move_speed;
                }
            }
            else if (keyPressed(VirtualKey.S))
            {
                //args.DrawingSession.DrawImage(PlayerS, player.x, player.y);
                Tile tile = gekozenLevel.getPlayerTile(player.x, player.y, level);
                if (tile.CanWalk == false)
                {
                    player.y -= player.move_speed;
                }
            }
            else if (keyPressed(VirtualKey.D))
            {
                Tile tile = gekozenLevel.getPlayerTile(player.x, player.y, level);
                if (tile.CanWalk == false) //positief
                {
                    player.x -= player.move_speed;
                }
            }
            else
            {
                Tile tile = gekozenLevel.getPlayerTile(player.x, player.y, level);
                if (tile.CanWalk == false)
                {
                    player.y += player.move_speed;
                }
            }
        }
    }
}
