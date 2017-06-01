using Microsoft.Graphics.Canvas;
using Microsoft.Graphics.Canvas.Effects;
using System.Numerics;

namespace DiDo.GameElements
{
    class ImageManipulation
    {
        public static Vector2 vec = new Vector2();
        
        public static Vector2 vector2 ()
        {
            vec.X = 16;
            vec.Y = 16;
            
            return vec;
        }

        public static void SetScale()
        {
            // Display Information

            MainPage.scaleWidth = (float)MainPage.bounds.Width / MainPage.DesignWidth;
            MainPage.scaleHeight = (float)MainPage.bounds.Height / MainPage.DesignHeight;
        }

        public static Transform2DEffect img(CanvasBitmap source)
        {
            Transform2DEffect image;
            image = new Transform2DEffect() { Source = source };
            image.TransformMatrix = Matrix3x2.CreateScale(MainPage.scaleWidth, MainPage.scaleHeight);
            
            return image;
        }
        public static Transform2DEffect imageW(CanvasBitmap source)
        {
            vector2();
            Transform2DEffect image;
            image = new Transform2DEffect() { Source = source };
            //image.TransformMatrix = Matrix3x2.CreateScale(MainPage.scaleWidth, MainPage.scaleHeight);
            image.TransformMatrix = Matrix3x2.CreateRotation(0);

            return image;
        }

        public static Transform2DEffect imageA(CanvasBitmap source)
        {
            vector2();
            Transform2DEffect image;
            image = new Transform2DEffect() { Source = source };
            //image.TransformMatrix = Matrix3x2.CreateScale(MainPage.scaleWidth, MainPage.scaleHeight);
            image.TransformMatrix = Matrix3x2.CreateRotation(270, vec);

            return image;
        }

        public static Transform2DEffect imageS(CanvasBitmap source)
        {
            vector2();
            Transform2DEffect image;
            image = new Transform2DEffect() { Source = source };
            //image.TransformMatrix = Matrix3x2.CreateScale(MainPage.scaleWidth, MainPage.scaleHeight);
            image.TransformMatrix = Matrix3x2.CreateRotation(180, vec);

            return image;
        }

        public static Transform2DEffect imageD(CanvasBitmap source)
        {
            vector2();
            Transform2DEffect image;
            image = new Transform2DEffect() { Source = source };
            //image.TransformMatrix = Matrix3x2.CreateScale(MainPage.scaleWidth, MainPage.scaleHeight);
            image.TransformMatrix = Matrix3x2.CreateRotation(80, vec);

            return image;
        }
    }
}
