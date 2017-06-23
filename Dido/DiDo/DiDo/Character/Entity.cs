using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DiDo.Character;

namespace DiDo
{
    public abstract class Entity : Position
    {
        private Position position;

        /// <summary>
        /// Constructor of the entity
        /// </summary>
        /// <param name="x">X coördinate of the entity</param>
        /// <param name="y">Y coördinate of the entity</param>
        public Entity(float x, float y) : base(x, y)
        {

        }

        /// <summary>
        /// Returns the position
        /// </summary>
        /// <returns></returns>
        public Position getPosition()
        {
            return position;
        }

        /// <summary>
        /// Sets the position
        /// </summary>
        /// <param name="position">Sets the X and Y position</param>
        protected void setPosition(Position position)
        {
            this.position = position;
        }
    }
}
