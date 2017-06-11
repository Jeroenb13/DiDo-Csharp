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

        public Entity(float x, float y) : base(x, y)
        {

        }

        public Position getPosition()
        {
            return position;
        }

        protected void setPosition(Position position)
        {
            this.position = position;
        }
    }
}
