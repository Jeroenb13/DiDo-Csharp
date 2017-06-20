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
        private Random random;
        public int direction;
        public int stepSize = 2;
        private PistolWeapon pistol = new PistolWeapon(15, 60 ,15, 0, 0);

        public Enemy(string name, int maxHealth, int healthPoints, int stamina, int move_speed, float x, float y) : base(name, maxHealth, healthPoints, stamina, move_speed, x, y)
        {
            this.name = name;
            this.healthPoints = healthPoints;
            this.stamina = stamina;
            this.move_speed = move_speed;
            weapons = new Weapon[1];
            setItem(0, pistol);
            currentWeapon = weapons[0];

            int seed = char.ToUpper(name[0]) - 64;
            seed += char.ToUpper(name[2]) - 64;
            this.random = new Random(seed);

            this.direction = random.Next(0, 4);
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
