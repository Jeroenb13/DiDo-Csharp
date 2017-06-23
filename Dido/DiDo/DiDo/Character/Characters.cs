using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DiDo.Items;
using System.Threading.Tasks;
using DiDo.MenuFolder;
using Windows.UI.Xaml.Controls;

namespace DiDo.Character
{
    public abstract class Characters : Entity
    {
        public string name { get; set; } //Name of the character
        public int maxHealth; //Maximum amount of health that the character can have
        public int healthPoints { get; set; } //Current amount of health of the character
        public int stamina { get; set; } //Current amount of stamina of the character
        private Fist fists = new Fist(1, 1, 0, 0);//Standard weapon
        public int maxStamina { get; set; } //Maximum amount of stamina the character can have
        public int move_speed { get; set; } //Move speed of the character
        protected Weapon[] weapons; //The inventory of weapons of the character
        public Weapon currentWeapon; //Current weapon in character his hands
        public Weapon weaponToDrop; //Weapon that needs to be dropped.
        protected int currentWeaponIndex; //Current weapon index in the array
        public Boolean alive = true; //Current status of the player

        /// <summary>
        /// Constructor of the character
        /// </summary>
        /// <param name="name">Name of the character</param>
        /// <param name="maxHealth">Maximum health of the character</param>
        /// <param name="healthPoints">Current healthpoints of the character</param>
        /// <param name="stamina">Maximum statmina of the character</param>
        /// <param name="move_speed">Move speed of the character</param>
        /// <param name="x">Starting X coördinate of the character</param>
        /// <param name="y">Starting Y coördinate of the character</param>
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

        /// <summary>
        /// Returns the current healthpoints of the character
        /// </summary>
        /// <returns></returns>
        public int getHealth()
        {
            return healthPoints;
        }

        /// <summary>
        /// Returns the the maximum amount of healthpoints of the charachter
        /// </summary>
        /// <returns></returns>
        public int getMaxHealth()
        {
            return maxHealth;
        }

        /// <summary>
        /// Removes the amount of damage from the healthpoints
        /// </summary>
        /// <param name="damage">Amount of damage that is taken</param>
        public void hit(int damage)
        {
            if (alive)//if player is alive
            {
                healthPoints = healthPoints - damage; //Calculates the healthpoints - damage
                if (healthPoints <= 0) //if healthpoints below 0
                {
                    alive = false; // alive is false
                    this.OnDeath();
                }
            }
        }

        public virtual void OnDeath() { }

        /// <summary>
        /// Recalculates the stamina if it is below the maximum amount of stamina
        /// </summary>
        public void returnStamina()
        {
            if(stamina < maxStamina)
            {
                stamina = stamina + 1;
            }
        }

        /// <summary>
        /// Makes the move speed higher if the stamina is higher than 0
        /// </summary>
        /// <returns></returns>
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

        /// <summary>
        /// Gets an item at the specified index
        /// </summary>
        /// <param name="index">Index of the array</param>
        /// <returns></returns>
        public Item getItem(int index)
        {
            return weapons[index];
        }

        /// <summary>
        /// Drops the currentWeapon
        /// </summary>
        /// <returns></returns>
        public Item dropItem()
        {
            Item droppedWeapon = this.currentWeapon; //Sets droppedweapon as currentweapon
            if (droppedWeapon != null && droppedWeapon.name != "Fists") //If droppedweapon is not null or of the weapon type Fists
            {
                weapons[currentWeaponIndex].x = x; // Sets the weapon X coördinate
                weapons[currentWeaponIndex].y = y; // Sets the weapon Y coördinate
                weapons[currentWeaponIndex] = fists; // Sets the weapon to fists
                this.currentWeapon = fists; // Sets the currentweapon as fists
                weaponToDrop = (Weapon)droppedWeapon; 
            }
            else
            {
                droppedWeapon = null;
            }
            return droppedWeapon;
        }

        /// <summary>
        /// Sets the item in the weapon array
        /// </summary>
        /// <param name="index">Index where the weapons needs to be added</param>
        /// <param name="newWeapon">Weapon that is added to the array</param>
        public void setItem(int index, Weapon newWeapon)
        {
            weapons[index] = newWeapon;
        }

        /// <summary>
        /// Pickup a weapon
        /// </summary>
        /// <param name="weapon">Weapon that needs to be picked up</param>
        public void pickUpWeapon(Weapon weapon)
        {
            Weapon pickedUpWeapon = weapon;
            bool setWeapon = false;
            for(int i = 0; i < weapons.Length && !setWeapon; i ++) 
            {
                Type weaponType = weapons[i].GetType();
                if (weaponType == typeof(Fist)) //Checks for an empty spot in the array
                {
                    setItem(i, pickedUpWeapon); //Sets weapon on the current index of the loop
                    currentWeapon = weapons[currentWeaponIndex];
                    setWeapon = true;
                }
                             
            }
            if (setWeapon == false) //If weapon array is full 
            {
                dropItem();
                setItem(currentWeaponIndex, pickedUpWeapon); //sets weapon as current weapon
                currentWeapon = weapons[currentWeaponIndex]; 
                setWeapon = true;
            }
        }
        
        /// <summary>
        /// Changes weapon according to the number
        /// </summary>
        /// <param name="number">Sets the weapon to this number</param>
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
