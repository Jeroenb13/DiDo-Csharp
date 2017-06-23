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

        /// <summary>
        /// Weapon constructor
        /// </summary>
        /// <param name="x">y location of the weapon</param>
        /// <param name="y">x location of the weapon</param>
        public Weapon(float x, float y) : base(x, y)
        {
            this.ShouldRepeat = false;
            // Set repeat to false
        }

        /// <summary>
        /// Get the magazine size
        /// </summary>
        /// <returns>Return the size of the magazine</returns>
        public int getMagazineSize()
        {
            return magazineSize;
            // Return amount of ammo
        }

        /// <summary>
        /// Set the size of the magazine
        /// </summary>
        /// <param name="newMagazineSize">value of amount of bullets in the magazine</param>
        public void setMagazineSize(int newMagazineSize)
        {
            this.magazineSize = newMagazineSize;
            // Set the magazine size
        }

        /// <summary>
        /// Get the ammo count
        /// </summary>
        /// <returns>Show amount of ammo</returns>
        public int getAmmo()
        {
            return magazine;
            // Show ammo
        }

        /// <summary>
        /// Set the ammo
        /// </summary>
        /// <param name="newAmmo">the value to set the ammo</param>
        public void setAmmo(int newAmmo)
        {
            this.magazine = newAmmo;
            // Set ammo
        }

        /// <summary>
        /// Get the additional ammo size
        /// </summary>
        /// <returns></returns>
        public int getAdditionalAmmo()
        {
            return additional;
            // How much bullets are in the second magazine left
        }

        /// <summary>
        /// Set the additional ammo size
        /// </summary>
        /// <param name="newAmmo">Set the ammo size</param>
        public void setAdditionalAmmo(int newAmmo)
        {
            this.additional = newAmmo;
            // Set how much ammo is in the additional magazine
        }

        public abstract void reduceAmmo();
        // Reduce the ammo

        public abstract int getDamage();
        // Get the damage

        public void reload()
        {
            if (getAmmo() < getMagazineSize())
            {
                // The current weapon has additional ammo
                if (getAdditionalAmmo() > 0)
                {
                    //await soundController.Play(SoundEfxEnum.RELOAD);
                    int difference = getMagazineSize() - getAmmo();
                    if (getAdditionalAmmo() <= difference)
                    {
                        setAmmo(getAmmo() + getAdditionalAmmo());
                        setAdditionalAmmo(0);
                    }
                    else
                    {
                        setAmmo(getMagazineSize());
                        setAdditionalAmmo(getAdditionalAmmo() - difference);
                    }
                }
            }
        }
    }
}
