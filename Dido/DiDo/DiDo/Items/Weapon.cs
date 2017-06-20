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

        public Weapon(float x, float y) : base(x, y)
        {
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
