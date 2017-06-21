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
        private PistolWeapon pistol = new PistolWeapon(15, 200, 15, 0, 0);
        private ARWeapon ar = new ARWeapon(30, 300, 0, 0);
        private SMGWeapon smg = new SMGWeapon(15, 60, 0, 0);
        public MyPlayer(string name, int maxHealth, int healthPoints, int stamina, int move_speed, float x, float y) : base(name, maxHealth, healthPoints, stamina, move_speed, x, y)
        {
            this.maxHealth = maxHealth;
            this.healthPoints = healthPoints;
            this.stamina = stamina;
            this.move_speed = move_speed;
            weapons = new Weapon[3];
            setItem(0, pistol);
            setItem(1, ar);
            setItem(2, smg);
            currentWeapon = weapons[0];
            //weapons[0].x = 1337;
        }
    }
}
