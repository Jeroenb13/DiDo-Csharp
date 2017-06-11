using DiDo.Character;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiDo.Items
{
    public abstract class Weapon : Item
    {
        public int magazine;       //Number of rounds per magazine

        public Weapon(float x, float y) : base(x, y)
        {
        }

        public int getAmmo()
        {
            return magazine;
        }

        public abstract void reduceAmmo();
    }
}
