using Microsoft.Graphics.Canvas.UI.Xaml;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Windows.UI;
using Windows.UI.Xaml.Controls;
using Microsoft.Graphics.Canvas.UI.Xaml;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace Dido
{

    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        void CanvasControl_Draw(CanvasControl sender, CanvasDrawEventArgs args)
        {
            // Standaard drawing
            args.DrawingSession.DrawEllipse(155, 115, 80, 30, Colors.Black, 10);
            args.DrawingSession.DrawText("INF2J", 130, 100, Colors.Yellow);
        }

        private void Grid_OnKeyDown(object sender, KeyEventArgs e)
        {
            // Drawing na keypress
            var key = e.Key.ToString();
            // ToDo: Eerst de Canvas legen?
            args.DrawingSession.DrawEllipse(155, 115, 80, 30, Colors.Black, 10);
            args.DrawingSession.DrawText(str[0], 130, 100, Colors.Yellow);
  
        }


    }
}
