using Microsoft.Graphics.Canvas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiDo.Items
{
    public class SMGWeapon : Weapon
    {
        private static CanvasBitmap image;

        public override CanvasBitmap Image
        {
            get
            {
                return image;
            }
        }

        private int damage = 10;            //Damage per Round

        public SMGWeapon(int magazine, int total, float x, float y) : base(x, y)
        {
            name = "Sub Machine Gun";

            if (magazine >= 25)
            {
                this.magazine = 25;
            }
            else if(magazine <= 0)
            {
                this.magazine = 0;
            }
            else
            {
                this.magazine = magazine;
            }
            this.ShouldRepeat = true;
            this.BulletsPerMilliSecond = 100;
            this.RandomisationFactor = 4.5F;
        }

        public override void reduceAmmo()
        {
            if(this.magazine -1 < 0)
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

        public static void SetImage(CanvasBitmap img)
        {
            image = img;
        }
    }
}
