using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DiDo.Items;
using DiDo.Character;

namespace DiDo
{
    public abstract class Player : Characters
    {
        public float velX { get; set; } = 0;
        public float velY { get; set; } = 0;

        /// <summary>
        /// Constructor of the MyPlayer
        /// </summary>
        /// <param name="name">Name the the Player</param>
        /// <param name="maxHealth">Maximum health of the Player</param>
        /// <param name="healthPoints">Current Health of the Player</param>
        /// <param name="stamina">Maximum amount of stamina the Player can have</param>
        /// <param name="move_speed">Move speed of the Player</param>
        /// <param name="x">X coördinate of the Player</param>
        /// <param name="y">Y coördinate of the Player</param>
        public Player(String name, int maxHealth, int healthPoints, int stamina, int move_speed, float x, float y) : base(name, maxHealth, healthPoints, stamina, move_speed, x, y)
        {

        }
    }
}
