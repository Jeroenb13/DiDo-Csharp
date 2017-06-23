using Microsoft.Graphics.Canvas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiDo.Items
{
    class Fist : Weapon
    {
        private static CanvasBitmap image;

        public override CanvasBitmap Image
        {
            get
            {
                return image;
            }
        }

        private int damage = 50;            //Damage per Round

        public Fist(int magazine, int total, float x, float y) : base(x, y)
        {
            name = "Fists";
            if (magazine >= 1)
            {
                this.magazine = 1;
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

        public static void SetImage(CanvasBitmap img)
        {
            image = img;
        }
    }
}
