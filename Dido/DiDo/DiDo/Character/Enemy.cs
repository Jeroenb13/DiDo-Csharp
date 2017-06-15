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

        public Enemy(String name, float x, float y)
        {
            this.name = name;
            this.Health = 5;
            this.x = x;
            this.y = y;
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

    }
}
