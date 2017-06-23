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
        /// <summary>
        /// Constructor of the ClientPlayer
        /// </summary>
        /// <param name="name">Name of the character</param>
        /// <param name="maxHealth">Maximum health that the character can have</param>
        /// <param name="healthPoints">Current healthpoints of the character</param>
        /// <param name="stamina">Maximum stamina that the character can have</param>
        /// <param name="move_speed">Move speed of the character</param>
        /// <param name="x">X coördinates of the character</param>
        /// <param name="y">Y coördinates of the character</param>
        public ClientPlayer(string name, int maxHealth, int healthPoints, int stamina, int move_speed, float x, float y) : base(name, maxHealth, healthPoints, stamina, move_speed, x, y)
        {

        }
    }
}
