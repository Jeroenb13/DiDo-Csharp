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
        public string name { get; set; }
        public int maxHealth;
        public int healthPoints { get; set; }
        public int stamina { get; set; }
        private Fist fists = new Fist(1, 1, 0, 0);
        public int maxStamina { get; set; }
        public int move_speed { get; set; }
        protected Weapon[] weapons;
        public Weapon currentWeapon;
        public Weapon weaponToDrop;
        protected int currentWeaponIndex;
        public Boolean alive = true;
        public Characters(string name, int maxHealth, int healthPoints, int stamina, int move_speed, float x, float y) : base(x, y)
        {
            this.name = name;
            this.stamina = stamina;
            this.maxStamina = stamina;
            this.move_speed = move_speed;
            currentWeaponIndex = 0;
            weapons = new Weapon[3];
            this.healthPoints = healthPoints;
            this.maxHealth = maxHealth;
        }

        public int getHealth()
        {
            return healthPoints;
        }

        public int getMaxHealth()
        {
            return maxHealth;
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

        public void returnStamina()
        {
            if(stamina < maxStamina)
            {
                stamina = stamina + 1;
            }
        }

        public int run()
        {
            int run_speed;
            if(this.stamina > 0)
            {
                run_speed = move_speed + 2;
                stamina = stamina - 1;
            }
            else
            {
                run_speed = move_speed;
            }
            return run_speed;
        }

        public Item getItem(int index)
        {
            return weapons[index];
        }

        public Item dropItem()
        {
            Item droppedWeapon = this.currentWeapon;
            if (droppedWeapon != null && droppedWeapon.name != "Fists")
            {
                weapons[currentWeaponIndex].x = x;
                weapons[currentWeaponIndex].y = y;
                weapons[currentWeaponIndex] = fists;
                this.currentWeapon = fists;
                weaponToDrop = (Weapon)droppedWeapon;
            }
            else
            {
                droppedWeapon = null;
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
            Weapon pickedUpWeapon = weapon;
            bool setWeapon = false;
            for(int i = 0; i < weapons.Length && !setWeapon; i ++)
            {
                Type weaponType = weapons[i].GetType();
                if (weaponType == typeof(Fist))
                {
                    setItem(i, pickedUpWeapon);
                    currentWeapon = weapons[currentWeaponIndex];
                    setWeapon = true;
                }
                             
            }
            if (setWeapon == false)
            {
                dropItem();
                setItem(currentWeaponIndex, pickedUpWeapon);
                currentWeapon = weapons[currentWeaponIndex];
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
