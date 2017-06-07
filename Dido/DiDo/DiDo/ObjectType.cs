using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiDo
{
    class ObjectType
    {
        string type;
        float x1, x2;
        float y1, y2;

        public ObjectType(string type, float x1, float x2, float y1, float y2)
        {
            this.type = type;
            this.x1 = x1;
            this.x2 = x1 + 31;
            this.y1 = y1;
            this.y2 = y1 + 31;
        }
    }
}
