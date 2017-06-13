using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.System;
using Windows.UI.Core;
using Windows.UI.Xaml;

namespace DiDo.Character
{
    public abstract class ClientPlayer : Player
    {
        public ClientPlayer(string name, float x, float y) : base(name, x, y)
        {

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
