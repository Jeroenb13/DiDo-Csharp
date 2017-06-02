using Microsoft.Graphics.Canvas;
using Microsoft.Graphics.Canvas.Effects;
using System.Numerics;

namespace DiDo.GameElements
{
    //Class to move the player around in a specific direction
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

        //Method to scale the window to every window size
        public static void SetScale()
        {
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

        //In the MainPage class, when the 'W' button is pressed
        public static Transform2DEffect imageW(CanvasBitmap source)
        {
            vector2();
            Transform2DEffect image;
            image = new Transform2DEffect() { Source = source };
            //image.TransformMatrix = Matrix3x2.CreateScale(MainPage.scaleWidth, MainPage.scaleHeight);
            image.TransformMatrix = Matrix3x2.CreateRotation(0);

            return image;
        }

        //In the MainPage class, when the 'A' button is pressed
        public static Transform2DEffect imageA(CanvasBitmap source)
        {
            vector2();
            Transform2DEffect image;
            image = new Transform2DEffect() { Source = source };
            //image.TransformMatrix = Matrix3x2.CreateScale(MainPage.scaleWidth, MainPage.scaleHeight);
            image.TransformMatrix = Matrix3x2.CreateRotation((float)4.71, vec);

            return image;
        }

        //In the MainPage class, when the 'S' button is pressed
        public static Transform2DEffect imageS(CanvasBitmap source)
        {
            vector2();
            Transform2DEffect image;
            image = new Transform2DEffect() { Source = source };
            //image.TransformMatrix = Matrix3x2.CreateScale(MainPage.scaleWidth, MainPage.scaleHeight);
            image.TransformMatrix = Matrix3x2.CreateRotation((float)3.14, vec);

            return image;
        }

        //In the MainPage class, when the 'D' button is pressed
        public static Transform2DEffect imageD(CanvasBitmap source)
        {
            vector2();
            Transform2DEffect image;
            image = new Transform2DEffect() { Source = source };
            //image.TransformMatrix = Matrix3x2.CreateScale(MainPage.scaleWidth, MainPage.scaleHeight);
            image.TransformMatrix = Matrix3x2.CreateRotation((float)1.57, vec);

            return image;
        }
    }
}
