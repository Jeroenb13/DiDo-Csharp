using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiDo
{
    class Collide
    {
        public List<String> itemList;

        public Collide()
        {
            itemList = new List<String>();
            fillList();
        }
        public void fillList()
        {
            itemList.Add("b");
            itemList.Add("Q");
            itemList.Add("R");
            itemList.Add("S");
            itemList.Add("T");
            itemList.Add("U");
            itemList.Add("V");
            itemList.Add("W");
            itemList.Add("X");
            itemList.Add("Y");
            itemList.Add("Z");
        }
        public bool collide(string item)
        {
            bool collision = false;

            if (itemList.Contains(item))
            {
                collision = true;
            }

            else
            {
                collision = false;
            }

            return collision;
        }

        public void collisionDetection(Player player, float tileX, float tileY)
        {
            if(player.x == tileX || player.y == tileY)
            {
                Debug.WriteLine("Het is raak!");
            }
            else
            {
                Debug.WriteLine("Het is niet raak!");
            }
        }
    }
}
