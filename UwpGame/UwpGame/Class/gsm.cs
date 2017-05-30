using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UwpGame.Class
{
    /// <summary>
    /// Gamestate manager
    /// </summary>
    class gsm
    {
        public static void GSM()
        {
            if (MainPage.RoundEnded == true)
            {
                MainPage.BG = MainPage.Level2;
            }else
            {

                if (MainPage.GameState == 0)
                {

                    MainPage.BG = MainPage.StartScreen;



                }
                else if (MainPage.GameState == 1)
                {
                    MainPage.BG = MainPage.Level1;
                }

            }

        }
    }
}
