using DiDo.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DiDo.Character
{
    public class MyPlayer : ClientPlayer
    {
        private PistolWeapon pistol = new PistolWeapon(15, 0, 0);
        public MyPlayer(string name, float x, float y) : base(name, x, y)
        {
            setItem(0, pistol);
            currentWeapon = weapons[0];
        }


        public void pickUpWeapon(Weapon weapon)
        {
            if (weapon.x >= x && weapon.x <= (x + 16) && weapon.y >= y && weapon.y <= (y - 16))
            {
                if (weapons[0] != null && weapons[1] != null && weapons[2] != null)
                {
                    setItem(currentWeaponIndex, weapon);
                }
                else if(weapons[0] == null && weapons[1] != null && weapons[2] != null)
                {
                    setItem(0, weapon);
                }
                else if (weapons[0] != null && weapons[1] == null && weapons[2] != null)
                {
                    setItem(1, weapon);
                }
                else
                {
                    setItem(2, weapon);
                }
            }
        }

        public void changeWeapon(int number)
        {
            if(number == 1)
            {
                currentWeaponIndex = 0;
                currentWeapon = weapons[0];
            }
            else if(number == 2)
            {
                currentWeaponIndex = 1;
                currentWeapon = weapons[1];
            }
            else if(number == 3)
            {
                currentWeaponIndex = 2;
                currentWeapon = weapons[2];
            }
        }
    }
}
