using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiDo.GameElements
{
    class GameStateManager
    {
        public static void GSManager()
        {
            if (MainPage.RoundEnded == true)
            {
               
            }
            else
            {
                if (MainPage.GameState == 0)
                {
                    MainPage.BG = MainPage.StartScreen;
                }
                else if (MainPage.GameState == 1)
                {
                    MainPage.ChosenLevel = Levels.Levels.levelTwo;
                }

            }
        }
    }
}
