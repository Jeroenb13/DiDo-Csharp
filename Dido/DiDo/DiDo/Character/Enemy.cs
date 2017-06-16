using DiDo.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiDo.Character
{
    public class Enemy : Characters
    {
        public String name { get; }
        private Random random;
        public int direction;
        public int stepSize = 2;
        private PistolWeapon pistol = new PistolWeapon(15, 60 ,15, 0, 0);

        public Enemy(String name, float x, float y) : base(name, x, y)
        {
            this.name = name;
            healthPoints = 100;
            weapons = new Weapon[1];
            setItem(0, pistol);
            currentWeapon = weapons[0];
        }

        public void hit(int damage = 1)
        {
            this.healthPoints = this.healthPoints - damage;
        }

        public String debugName()
        {
            return this.name + " (" + this.getHealth() + ")";
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
