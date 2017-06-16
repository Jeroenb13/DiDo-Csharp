using DiDo.Items;
using DiDo.Levels;
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

            int seed = char.ToUpper(name[0]) - 64;
            seed += char.ToUpper(name[2]) - 64;
            this.random = new Random(seed);

            this.direction = random.Next(0, 4);
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
            DiDo.Levels.Levels level = new DiDo.Levels.Levels();


            if (this.random.Next(0, 30) == 1)
            {
                this.direction = random.Next(0, 4);
            }
            if (this.direction == 0)
            {
                Tile nextTile = level.getPlayerTile(this.x, this.y + 1, level.gekozenLevel);
                if (nextTile.CanWalk == true)
                {
                    this.y += stepSize;
                }
            }
            else if (this.direction == 1)
            {
                Tile nextTile = level.getPlayerTile(this.x + 1, this.y, level.gekozenLevel);
                if (nextTile.CanWalk == true)
                {
                    this.x += stepSize;
                }
            }
            else if (this.direction == 2)
            {
                Tile nextTile = level.getPlayerTile(this.x, this.y - 1, level.gekozenLevel);
                if (nextTile.CanWalk == true)
                {
                    this.y -= stepSize;
                }
            }
            else
            {
                Tile nextTile = level.getPlayerTile(this.x - 1, this.y, level.gekozenLevel);
                if (nextTile.CanWalk == true)
                {
                    this.x -= stepSize;
                }
            }
        }

    }
}
