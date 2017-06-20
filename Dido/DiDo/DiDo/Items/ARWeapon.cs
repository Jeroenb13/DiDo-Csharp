using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiDo.Items
{
    public class ARWeapon : Weapon
    {
        private int magazine { get; set; }  //Number of Rounds per Magazine
        private int damage = 20;            //Damage per Round

        public ARWeapon(int magazine, int total, float x, float y) : base(x, y)
        {
            name = "Assault Rifle";
            if (magazine >= 30)
            {
                this.magazine = 30;
            }
            else if (magazine <= 0)
            {
                this.magazine = 0;
            }
            else
            {
                this.magazine = magazine;
            }
        }

        public override void reduceAmmo()
        {
            if (this.magazine - 1 < 0)
            {
                this.magazine = 0;
            }
            else
            {
                this.magazine = magazine - 1;
            }
        }

        public override int getDamage()
        {
            return this.damage;
        }
    }
}
