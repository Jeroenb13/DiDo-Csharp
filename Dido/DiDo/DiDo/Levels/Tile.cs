using Microsoft.Graphics.Canvas;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiDo.Levels
{
    public class Tile
    {
        public string TileType { get; }
        public Uri Image { get; }
        public bool CanWalk { get; }
        public int Rotation { get; }

        public CanvasBitmap Bitmap { get; private set; }

        public Tile(string tileType, Uri image, bool canWalk = false, int rotation = 0)
        {
            TileType = tileType;
            Image = image;
            CanWalk = canWalk;
            Rotation = rotation;
        }

        public async Task InitBitmap(ICanvasResourceCreator creator)
        {
            this.Bitmap = await CanvasBitmap.LoadAsync(creator, this.Image);
        }
    }
}
