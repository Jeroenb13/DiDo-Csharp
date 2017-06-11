using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiDo.Items
{
    public class SRWeapon : Weapon
    {
        private int magazine { get; set; }  //Number of Rounds per Magazine
        private int damage = 45;            //Damage per Round

        public SRWeapon(int magazine, float x, float y) : base(x, y)
        {
            name = "Sniper Rifle";
            if (magazine >= 5)
            {
                this.magazine = 5;
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
    }
}
