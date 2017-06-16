using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiDo.Character
{
    public class Enemy
    {
        public String name { get; }
        public int Health { get; set; }
        public float x { get; set; }
        public float y { get; set; }
        private Random random;
        public int direction;
        public int stepSize = 2;

        public Enemy(String name, float x, float y)
        {
            this.name = name;
            this.Health = 10;
            this.x = x;
            this.y = y;

            int seed = char.ToUpper(name[0]) - 64;
            seed += char.ToUpper(name[2]) - 64;
            this.random = new Random(seed);

            this.direction = random.Next(0, 4);
        }

        public void hit(int damage = 1)
        {
            this.Health = this.Health - damage;
        }

        public int health()
        {
            return this.Health;
        }

        public String debugName()
        {
            return this.name + " (" + this.health() + ")";
        }

        public void randomWalk()
        {
            if (this.random.Next(0, 20) == 1)
            {
                this.direction = random.Next(0, 4);
            }

            if (this.direction == 0)
            {
                this.y += stepSize;
            }
            else if (this.direction == 1)
            {
                this.x += stepSize;
            }
            else if (this.direction == 2)
            {
                this.y -= stepSize;
            }
            else
            {
                this.x -= stepSize;
            }
        }

    }
}
