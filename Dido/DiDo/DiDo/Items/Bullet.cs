using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiDo
{
    public class Bullet : Entity
    {
        public float velX { get; set; }
        public float velY { get; set; }
        public Bullet(float x, float y, float velX, float velY) : base(x, y)
        {
            this.velX = velX;
            this.velY = velY;
        }
    }
}
