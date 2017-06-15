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

        public ItemEntity(float x, float y)
        {
            this.x = x;
            this.y = y;
        }

    }
}
