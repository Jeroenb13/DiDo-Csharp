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
        private PistolWeapon pistol = new PistolWeapon(15, 60, 15, 0, 0);
        public MyPlayer(string name, float x, float y) : base(name, x, y)
        {
            healthPoints = 100;
            weapons = new Weapon[3];
            setItem(0, pistol);
            currentWeapon = weapons[0];
            //weapons[0].x = 1337;
        }
    }
}
