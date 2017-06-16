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
            healthPoints = 100;
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


        public void pickUpWeapon(Weapon weapon)
        {
                if (weapons[0] != null && weapons[1] != null && weapons[2] != null)
                {
                    setItem(currentWeaponIndex, weapon);
                }
                else if (weapons[0] == null && weapons[1] != null && weapons[2] != null)
                {
                    setItem(0, weapon);
                }
                else if (weapons[0] != null && weapons[1] == null && weapons[2] != null)
                {
                    setItem(1, weapon);
                }
                else if (weapons[0] != null && weapons[1] != null && weapons[2] == null)
                {
                    setItem(2, weapon);
                }
                else if (weapons[0] == null && weapons[1] == null && weapons[2] == null)
                {
                    setItem(0, weapon);
                }
        }

        public void changeWeapon(int number)
        {
            if (number == 1)
            {
                currentWeaponIndex = 0;
                currentWeapon = weapons[0];
            }
            else if (number == 2)
            {
                currentWeaponIndex = 1;
                currentWeapon = weapons[1];
            }
            else if (number == 3)
            {
                currentWeaponIndex = 2;
                currentWeapon = weapons[2];
            }
        }
    }
}
