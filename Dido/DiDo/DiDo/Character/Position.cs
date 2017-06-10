using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiDo.Character
{
    public class Position
    {
        public float x { get; set; }
        public float y { get; set; }

        public Position(float x, float y)
        {
            this.x = x;
            this.y = y;
        }
    }
}
