using DiDo.Character;
using Microsoft.Graphics.Canvas;
using Microsoft.Graphics.Canvas.UI.Xaml;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiDo.Items
{
    public abstract class Weapon : Item
    {
        protected int magazine;       //Number of rounds per magazine
        protected int additional;       //Number of rounds in total 
        protected int magazineSize;       //Number of rounds in total 
        public bool ShouldRepeat { get; protected set; } // Is the weapon a repeating product
        public int BulletsPerMilliSecond { get; protected set; } // bullet per millisecond
        public float RandomisationFactor { get; protected set; } // randomises the bullet for automatic weapons
        /// <summary>
        /// The image for this weapon
        /// </summary>
        public abstract CanvasBitmap Image { get; }

        public Weapon(float x, float y) : base(x, y)
        {
            this.ShouldRepeat = false;
        }

        public int getMagazineSize()
        {
            return magazineSize;
        }

        public void setMagazineSize(int newMagazineSize)
        {
            this.magazineSize = newMagazineSize;
        }

        public int getAmmo()
        {
            return magazine;
        }

        public void setAmmo(int newAmmo)
        {
            this.magazine = newAmmo;
        }

        public int getAdditionalAmmo()
        {
            return additional;
        }

        public void setAdditionalAmmo(int newAmmo)
        {
            this.additional = newAmmo;
        }

        public abstract void reduceAmmo();

        public abstract int getDamage();
    }
}
