using Microsoft.Graphics.Canvas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiDo.Items
{
    public class ARWeapon : Weapon
    {
        private static CanvasBitmap image;

        public override CanvasBitmap Image
        {
            get
            {
                return image;
            }
        }

        private int damage = 20;            //Damage per Round

        /// <summary>
        /// Constructor for the SRWeapon
        /// </summary>
        /// <param name="magazine">Magazine size</param>
        /// <param name="total">Amount of bullets</param>
        /// <param name="x">X location of the weapon</param>
        /// <param name="y">Y location of the weapon</param>
        public ARWeapon(int magazine, int total, float x, float y) : base(x, y)
        {
            name = "Assault Rifle";
            // Name of the weapon

            this.ShouldRepeat = true;
            if (magazine >= 30)
            {
                this.magazine = 30;
                // Set magazine to max when its set to more
            }
            else if (magazine <= 0)
            {
                this.magazine = 0;
                // If its below 0, set it to 0
            }
            else
            {
                this.magazine = magazine;
                // Set the magazine size to the given size
            }
            this.BulletsPerMilliSecond = 200;
            this.RandomisationFactor = 1.25F;
            // Random shooting
        }

        /// <summary>
        /// Reduce the ammo after shooting
        /// </summary>
        public override void reduceAmmo()
        {
            if (this.magazine - 1 < 0)
            {
                this.magazine = 0;
                // If after shooting the ammo is below 0, set it to zero
            }
            else
            {
                this.magazine = magazine - 1;
                // Decrease the ammo by 1
            }
        }

        /// <summary>
        /// Get the damage
        /// </summary>
        /// <returns>Return the damage</returns>
        public override int getDamage()
        {
            return this.damage;
            // Return what the damage is with the weapon
        }

        /// <summary>
        /// Set the image
        /// </summary>
        /// <param name="img"></param>
        public static void SetImage(CanvasBitmap img)
        {
            image = img;
            // Set the image to the choosen image
        }
    }
}
