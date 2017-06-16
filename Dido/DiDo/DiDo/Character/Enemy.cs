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
        private PistolWeapon pistol = new PistolWeapon(15, 0, 0);

        public Enemy(String name, float x, float y) : base(name, x, y)
        {
            healthPoints = 10;
            weapons = new Weapon[1];
            setItem(0, pistol);
            currentWeapon = weapons[0];
        }

        public String debugName()
        {
            return this.name + " (" + this.getHealth() + ")";
        }

    }
}
