using Microsoft.Graphics.Canvas;
using Microsoft.Graphics.Canvas.Effects;
using System.Numerics;
using Windows.Foundation;

namespace DiDo.GameElements
{
    ///Class to move the player around in a specific direction
    class ImageManipulation
    {
        public static Vector2 vec = new Vector2();
        
        public static Vector2 vector2 ()
        {
            //Together the center point of the player
            vec.X = 16; 
            vec.Y = 16;
            
            return vec;
        }

        /// <summary>
        /// Returns the image Transform
        /// </summary>
        /// <param name="source">Source of the image</param>
        /// <returns></returns>
        public static Transform2DEffect img(CanvasBitmap source)
        {
            Transform2DEffect image;
            image = new Transform2DEffect() { Source = source };
            
            return image;
        }

        /// <summary>
        /// In the MainPage class, when the 'W' button is pressed
        /// </summary>
        /// <param name="source">The source of an image</param>
        /// <param name="radians">The radians of the image</param>
        /// <returns>an image</returns>
        public static Transform2DEffect image(CanvasBitmap source, double radians)
        {
            vector2();
            Transform2DEffect image;
            image = new Transform2DEffect() { Source = source };
            //image.TransformMatrix = Matrix3x2.CreateScale(MainPage.scaleWidth, MainPage.scaleHeight);
            image.TransformMatrix = Matrix3x2.CreateRotation((float)radians);
            image.TransformMatrix = Matrix3x2.CreateRotation((float)radians, vec);

            return image;
        }
    }
}
