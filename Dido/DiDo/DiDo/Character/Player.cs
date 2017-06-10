using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DiDo.Items;
using DiDo.Character;

namespace DiDo
{
    public class Player : Characters
    {
        private String name;
        public float velX { get; set; } = 0;
        public float velY { get; set; } = 0;
        private Item itemInHand;
        public int move_speed = 5;
        public Player(String name, float x, float y) : base(x, y)
        {
            this.name = name;
        }
    }
}
