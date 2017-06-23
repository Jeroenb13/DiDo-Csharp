using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiDo.Items
{
    public abstract class Item : ItemEntity
    {
        private Object item;
        public String name { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="x">X location of the item</param>
        /// <param name="y">Y location of the item</param>
        public Item(float x, float y) : base(x, y)
        {
        }
    }
}
