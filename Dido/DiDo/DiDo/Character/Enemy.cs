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
        public int direction; //Direction of the enemy
        public int stepSize = 2; //Amount of steps the enemy can take 
        private Weapon weapon; // Weapon of the enemy

        /// <summary>
        /// Constructor of the enemy
        /// </summary>
        /// <param name="name">Name of the enemey</param>
        /// <param name="maxHealth">Maximum amount of health of the enemy</param>
        /// <param name="healthPoints">Current health of the enemy</param>
        /// <param name="stamina">Maximum amount of stamina of the enemy</param>
        /// <param name="move_speed">Move speed of the enemy</param>
        /// <param name="x">X coördinate of the enemy</param>
        /// <param name="y">Y coördinate of the enemy</param>
        public Enemy(string name, int maxHealth, int healthPoints, int stamina, int move_speed, float x, float y) : base(name, maxHealth, healthPoints, stamina, move_speed, x, y)
        {
            this.name = name;
            this.healthPoints = healthPoints;
            this.stamina = stamina;
            this.move_speed = move_speed;

            int seed = char.ToUpper(name[0]) - 64;
            seed += char.ToUpper(name[2]) - 64;
            this.random = new Random(seed);
            // Seed de random

            this.direction = random.Next(0, 4);
            // Calculates a random location


            switch (random.Next(4))
            {
                case 0:
                    weapon = new PistolWeapon(15, 60, 15, 60, 0);
                    break;
                case 1:
                    weapon = new SMGWeapon(15, 60, 60, 0);
                    break;
                default:
                    weapon = new ARWeapon(15, 60, 60, 0);
                    break;
            }

            weapons = new Weapon[1];
            setItem(0, weapon);
            currentWeapon = weapons[0]; // Sets the weapon as the current Weapon
        }

        /// <summary>
        /// Returns the name and the health of the enemy
        /// </summary>
        /// <returns></returns>
        public String debugName()
        {
            return this.name + " (" + this.getHealth() + ")";
        }

        /// <summary>
        /// Makes it so that the enemy walks a random path
        /// </summary>
        public void randomWalk()
        {
            DiDo.Levels.Levels level = new DiDo.Levels.Levels();
            // Gets the tiles of the level and looks if they can be walked on

            if (this.random.Next(0, 30) == 1) // A chance of 1 to 29 that the enemy will walk
            {
                this.direction = random.Next(0, 4);
                // Calculates a random number and walks in the direction of that number
                
            } else
            {
                if (this.random.Next(0, 360) == 1) { // 1 on 120 chance that the enemy will shoot
                    // Shoot if the enemy stands still

                    this.currentWeapon.reload();
                    // Reload

                    if (this.currentWeapon.getAmmo() >= 1) // Looks if there are bullets in the magazine
                    {

                        float xPos = random.Next((int)(MainPage.player.x - 70), (int)(MainPage.player.x + 70));
                        float yPos = random.Next((int)(MainPage.player.y - 70), (int)(MainPage.player.y + 70));
                        // Makes the chance of shooting straigh very low

                        float xVel = (xPos - x) / 18;
                        float yVel = (yPos - y) / 18;
                        // Calculates the bullet velocity

                        if (xVel > 50) xVel = 50;
                        if (yVel > 50) yVel = 50;
                        // Makes it so that the bullets wont go to fast

                        MainPage.bullets.Add(new DiDo.Bullet(x, y, xVel, yVel, currentWeapon.getDamage(), name));
                        // Adds bullets to the list

                        this.currentWeapon.reduceAmmo();
                        // Reduces the ammo
                    }
                }
            }

            if (this.direction == 0)
            {
                Tile nextTile = level.getPlayerTile(this.x, this.y + 1, level.gekozenLevel); // Gets the information of the tile
                if (nextTile.CanWalk == true) // Checks if the next tile can be walked on.
                {
                    this.y += stepSize;
                    // Walk down
                }
            }
            else if (this.direction == 1)
            {
                Tile nextTile = level.getPlayerTile(this.x + 1, this.y, level.gekozenLevel); // Gets the information of the tile
                if (nextTile.CanWalk == true) // Checks if the next tile can be walked on.
                {
                    this.x += stepSize;
                    // Walk to the right
                }
            }
            else if (this.direction == 2)
            {
                Tile nextTile = level.getPlayerTile(this.x, this.y - 1, level.gekozenLevel); // Gets the information of the tile
                if (nextTile.CanWalk == true) // Checks if the next tile can be walked on.
                {
                    this.y -= stepSize;
                    // Walk up
                }
            }
            else
            {
                Tile nextTile = level.getPlayerTile(this.x - 1, this.y, level.gekozenLevel); // Gets the information of the tile
                if (nextTile.CanWalk == true) // Checks if the next tile can be walked on.
                {
                    this.x -= stepSize;
                    // Walk to the left
                }
            }
        }

    }
}
