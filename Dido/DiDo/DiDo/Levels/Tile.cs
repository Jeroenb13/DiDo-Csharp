using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiDo.Levels
{
    class Tile
    {
        public string TileType { get; }
        public Uri Image { get; }
        
        public Tile(string tileType, Uri image)
        {
            TileType = tileType;
            Image = image;
        }
        
    }
}
