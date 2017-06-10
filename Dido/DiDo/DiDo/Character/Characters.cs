using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DiDo.Items;
using System.Threading.Tasks;

namespace DiDo.Character
{
    public class Characters : Entity
    {
        private int healthPoints { get; set; }
        private Item[] items;

        public Characters(float x, float y) : base(x, y)
        {

        }

        public int getHealth()
        {
            return healthPoints;
        }

        public Item getItem(int index)
        {
            return items[index];
        }

        public void setItem(int index, Item newItem)
        {
            items[index] = newItem;
        }
    }
}
