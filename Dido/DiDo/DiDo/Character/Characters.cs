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
        public string name { get; }
        protected int healthPoints { get; set; }
        protected Weapon[] weapons;
        public Weapon currentWeapon;
        protected int currentWeaponIndex;
        public Boolean alive = true;
        public Characters(string name, float x, float y) : base(x, y)
        {
            this.name = name;
            currentWeaponIndex = 0;
            weapons = new Weapon[3];
            healthPoints = 100;
        }

        public int getHealth()
        {
            return healthPoints;
        }

        public void hit(int damage)
        {
            if (this.alive)
            {
                this.healthPoints = this.healthPoints - damage;
                if (this.healthPoints <= 0)
                {
                    this.alive = false;
                }
            }
        }

        public Item getItem(int index)
        {
            return weapons[index];
        }

        public Item dropItem()
        {
            Item droppedWeapon = this.currentWeapon;
            if (droppedWeapon != null)
            {
                weapons[currentWeaponIndex].x = x;
                weapons[currentWeaponIndex].y = y;
                weapons[currentWeaponIndex] = null;
                this.currentWeapon = null;
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
            bool setWeapon = false;
            for(int i = 0; i < weapons.Length && !setWeapon; i ++)
            {
                if (weapons[i] == null)
                {
                    setItem(i, weapon);
                    setWeapon = true;
                }
                             
            }
            if (setWeapon == false)
            {
                dropItem();
                setItem(currentWeaponIndex, weapon);
                setWeapon = true;
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
