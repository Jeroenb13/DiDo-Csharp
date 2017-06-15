﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiDo.Items
{
    class PistolWeapon : Weapon
    {
        private int damage = 10;            //Damage per round

        public PistolWeapon(int magazine, float x, float y) : base(x, y)
        {
            name = "Pistol";
            if (magazine >= 16)
            {
                this.magazine = 15;
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
