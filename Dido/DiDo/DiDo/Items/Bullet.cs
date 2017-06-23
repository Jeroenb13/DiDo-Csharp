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

        /// <summary>
        /// Constructor for the bullet
        /// </summary>
        /// <param name="x">X location of the bullet</param>
        /// <param name="y">Y location of the bullet</param>
        /// <param name="velX">X Velocity of the bullet</param>
        /// <param name="velY">Y Velocity of the bullet</param>
        /// <param name="damage">Damage of the bullet</param>
        /// <param name="eigenaar">Who did shoot the bullet</param>
        public Bullet(float x, float y, float velX, float velY, int damage, String eigenaar) : base(x, y)
        {
            this.velX = velX;
            this.velY = velY;
            this.damage = damage;
            this.eigenaar = eigenaar;
            // Set the values for the current bullet
        }
    }
}
