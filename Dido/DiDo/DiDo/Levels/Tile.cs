using DiDo.GameElements;
using Microsoft.Graphics.Canvas;
using Microsoft.Graphics.Canvas.Effects;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Graphics.Imaging;

namespace DiDo.Levels
{
    public class Tile
    {
        public string TileType { get; }
        public Uri Image { get; }
        public bool CanWalk { get; }
        public int Rotation { get; }

        public float xPos { get; }
        public float yPos { get; }

        public CanvasBitmap Bitmap { get; private set; }
        public Transform2DEffect Effect { get; private set; }

        /// <summary>
        /// Constructor for the tiles
        /// </summary>
        /// <param name="tileType">Tile type</param>
        /// <param name="image">Uri to the image</param>
        /// <param name="canWalk">Can we walk on it</param>
        /// <param name="rotation">rotation for the tile</param>
        public Tile(string tileType, Uri image, bool canWalk = false, int rotation = 0)
        {
            TileType = tileType;
            Image = image;
            CanWalk = canWalk;
            Rotation = rotation;
            // set the values given in the constructor
        }

        /// <summary>
        /// InitBitmap
        /// </summary>
        /// <param name="creator">ICanvasResourceCreator</param>
        /// <returns></returns>
        public async Task InitBitmap(ICanvasResourceCreator creator)
        {
            this.Bitmap = await CanvasBitmap.LoadAsync(creator, this.Image); // Set the scaled bitmap
            this.Effect = ImageManipulation.img(this.Bitmap); // manipulate the image
        }

        /// <summary>
        /// resizeBitmap
        /// </summary>
        /// <param name="creator">ICanvasResourceCreator</param>
        public void resizeBitmap(ICanvasResourceCreator creator) // Resize the bitMap
        {
            var scaledSoftwareBitmap = CanvasBitmap.CreateFromSoftwareBitmap(creator, new SoftwareBitmap(BitmapPixelFormat.Bgra8, (int) 128, (int)128));
            this.Bitmap = scaledSoftwareBitmap; // Set the scaled bitmap
            this.Effect = ImageManipulation.img(this.Bitmap); // manipulate the image
        }
    }
}
