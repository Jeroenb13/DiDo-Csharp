using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiDo
{
    public class Player : Entity
    {
        public float velX { get; set; } = 0;
        public float velY { get; set; } = 0;
        public Player(float x, float y)
        {
            this.x = x;
            this.y = y;
        }
    }
}
