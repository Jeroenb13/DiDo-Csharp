using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DiDo.Items;
using System.Threading.Tasks;

namespace DiDo.Character
{
    public abstract class Characters : Entity
    {
        private int healthPoints { get; set; }
        protected Weapon[] weapons;
        public Weapon currentWeapon;
        protected int currentWeaponIndex;
        public Characters(float x, float y) : base(x, y)
        {
            currentWeaponIndex = 0;
            weapons = new Weapon[3];
        }

        public int getHealth()
        {
            return healthPoints;
        }

        public Item getItem(int index)
        {
            return weapons[index];
        }

        public Item dropItem()
        {
            Item droppedWeapon = currentWeapon;
            if (currentWeapon != null)
            {
                weapons[currentWeaponIndex].x = x;
                weapons[currentWeaponIndex].y = y;
                weapons[currentWeaponIndex] = null;
                currentWeapon = null;
            }
            return droppedWeapon;
        }

        public string inventory()
        {
            string inventory = "";
            foreach (Weapon weapon in weapons)
            {
                if(weapon != null)
                {
                    inventory = inventory + " | " + weapon.name;
                }
            }
            return inventory;
        }

        public void setItem(int index, Weapon newWeapon)
        {
            weapons[index] = newWeapon;
        }
    }
}
