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

        public int damage { get; set; }
        public Bullet(float x, float y, float velX, float velY, int damage) : base(x, y)
        {
            this.velX = velX;
            this.velY = velY;
            this.damage = damage;
        }
    }
}
