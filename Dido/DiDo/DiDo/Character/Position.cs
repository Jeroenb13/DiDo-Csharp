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

        /// <summary>
        /// Constructor of the Position
        /// </summary>
        /// <param name="x">X coördinate of the Position</param>
        /// <param name="y">Y coördinate of the Position</param>
        public Position(float x, float y)
        {
            this.x = x;
            this.y = y;
        }
    }
}
