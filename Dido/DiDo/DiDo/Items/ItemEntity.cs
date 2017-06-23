using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiDo.Items
{
    public abstract class ItemEntity
    {
        public float x { get; set; }
        public float y { get; set; }

        /// <summary>
        /// Create the item with the location
        /// </summary>
        /// <param name="x">X location of the item</param>
        /// <param name="y">Y location of the item</param>
        public ItemEntity(float x, float y)
        {
            this.x = x;
            this.y = y;
            // Set the location of X and Y
        }

    }
}
