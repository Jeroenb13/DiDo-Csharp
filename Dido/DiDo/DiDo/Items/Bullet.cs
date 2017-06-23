using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiDo
{
    public class Bullet : Entity
    {
        public float velX { get; set; } // X Velocity
        public float velY { get; set; } // Y Velocity

        public String eigenaar { get; set; } // Wie de kogel afschiet

        public int damage { get; set; } // Schade dat de kogel doet
        public Bullet(float x, float y, float velX, float velY, int damage, String eigenaar) : base(x, y)
        {
            this.velX = velX;
            this.velY = velY;
            this.damage = damage;
            this.eigenaar = eigenaar;
            // Zet de waardes van de huidige kogel
        }
    }
}
