using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiDo
{
    class Grid
    {
        public ObjectType[,] levelOne;
        public ObjectType[,] levelTwo;
        public ObjectType[,] levelThree;
        public ObjectType[,] levelFour;
        public ObjectType[,] levelFive;
        public Grid()
        {
            levelOne = new ObjectType[14, 14];
            levelTwo = new ObjectType[35, 24];
            levelThree = new ObjectType[20, 25];
            levelFour = new ObjectType[26, 26];
            levelFive = new ObjectType[39, 21];
        }
    }
}
