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
        public int stepSize = 2; // 
        private PistolWeapon pistol = new PistolWeapon(15, 60 ,15, 60, 0); // Het wapen van de enemy

        public Enemy(string name, int maxHealth, int healthPoints, int stamina, int move_speed, float x, float y) : base(name, maxHealth, healthPoints, stamina, move_speed, x, y)
        {
            this.name = name;
            this.healthPoints = healthPoints;
            this.stamina = stamina;
            this.move_speed = move_speed;
            weapons = new Weapon[1];
            setItem(0, pistol);
            currentWeapon = weapons[0]; // Zet het wapen als actief wapen

            int seed = char.ToUpper(name[0]) - 64;
            seed += char.ToUpper(name[2]) - 64;
            this.random = new Random(seed);
            // Seed de random

            this.direction = random.Next(0, 4);
            // Bereken een random direction
        }

        public String debugName()
        {
            return this.name + " (" + this.getHealth() + ")";
            // Toon de naam van de enemy, en de levens
        }

        public void randomWalk()
        {
            DiDo.Levels.Levels level = new DiDo.Levels.Levels();
            // Haal de tiles van de level op, om te kijken of je op de tile kan lopen

            if (this.random.Next(0, 30) == 1) // 1 op de 29 dat de enemy een stap gaat zetten
            {
                this.direction = random.Next(0, 4);
                // Bereken een random getal om te kiezen welke richting er op gelopen moet worden
                
            } else
            {
                if (this.random.Next(0, 120) == 1) { // Niet altijd schieten
                    // Schieten als de enemy stilstaat
                    if (this.currentWeapon.getAmmo() >= 1) // Als er kogels in het magazijn zitten kan er worden geschoten
                    {

                        float xPos = random.Next((int)(MainPage.player.x - 70), (int)(MainPage.player.x + 70));
                        float yPos = random.Next((int)(MainPage.player.y - 70), (int)(MainPage.player.y + 70));
                        // X en Y locatie met een random offset om te zorgen dat het geen scherpschutters zijn.

                        float xVel = (xPos - x) / 18;
                        float yVel = (yPos - y) / 18;
                        // Bereken de velocity van de kogel

                        if (xVel > 50) xVel = 50;
                        if (yVel > 50) yVel = 50;
                        // Zorg dat de velocity niet te hoog kan worden, zodat de kogels niet te snel zijn

                        MainPage.bullets.Add(new DiDo.Bullet(x, y, xVel, yVel, currentWeapon.getDamage(), name));
                        // Voeg de kogels toe aan de lijst met kogels.

                        this.currentWeapon.reduceAmmo();
                        // Verlaag het aantal kogels na het schot
                    }
                }
            }

            if (this.direction == 0)
            {
                Tile nextTile = level.getPlayerTile(this.x, this.y + 1, level.gekozenLevel); // Haal de informatie van de Tile op
                if (nextTile.CanWalk == true) // Kijk of er naar de tile beneden je gelopen kan worden
                {
                    this.y += stepSize;
                    // Loop naar beneden
                }
            }
            else if (this.direction == 1)
            {
                Tile nextTile = level.getPlayerTile(this.x + 1, this.y, level.gekozenLevel); // Haal de informatie van de Tile op
                if (nextTile.CanWalk == true) // Kijk of er naar de tile rechts van je gelopen kan worden
                {
                    this.x += stepSize;
                    // Loop naar rechts
                }
            }
            else if (this.direction == 2)
            {
                Tile nextTile = level.getPlayerTile(this.x, this.y - 1, level.gekozenLevel); // Haal de informatie van de Tile op
                if (nextTile.CanWalk == true) // Kijk of er naar de tile boven je gelopen kan worden
                {
                    this.y -= stepSize;
                    // Loop naar boven
                }
            }
            else
            {
                Tile nextTile = level.getPlayerTile(this.x - 1, this.y, level.gekozenLevel); // Haal de informatie van de Tile op
                if (nextTile.CanWalk == true) // Kijk of er naar de tile links van je gelopen kan worden
                {
                    this.x -= stepSize;
                    // Loop naar links
                }
            }
        }

    }
}
