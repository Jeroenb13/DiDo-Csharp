using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiDo.Levels
{
    class Levels
    {
        private Dictionary<String, String> tiles = new Dictionary<String, String>()
        {
            { "a", "bridge" },
            { "b", "crate" },
            { "c", "disco" },
            { "d", "door" },
            { "e", "fence" },
            { "f", "floor" },
            { "g", "floor_cracked_1" },
            { "h", "floor_cracked_2" },
            { "i", "floor_cracked_3" },
            { "j", "floor_cracked_4" },
            { "k", "floor_cracked_5" },
            { "l", "floor_cracked_6" },
            { "m", "gas" },
            { "n", "grass" },
            { "o", "grass_flower_1" },
            { "p", "grass_flower_2" },
            { "q", "grass_flower_3" },
            { "r", "grass_flower_4" },
            { "s", "grass_flower_5" },
            { "t", "path_0_straight" },
            { "u", "path_0_turn" },
            { "v", "path_0_cross" },
            { "w", "path_0_t" },
            { "x", "path_90_straight" },
            { "y", "path_90_turn" },
            { "z", "path_90_cross" },
            { "A", "path_90_t" },
            { "B", "path_180_straight" },
            { "C", "path_180_turn" },
            { "D", "path_180_cross" },
            { "E", "path_180_t" },
            { "F", "path_270_straight" },
            { "G", "path_270_turn" },
            { "H", "path_270_cross" },
            { "I", "path_270_t" },
            { "J", "rubbish_bin" },
            { "K", "seat" },
            { "L", "table" },
            { "M", "torch_0" },
            { "N", "torch_90" },
            { "O", "torch_180" },
            { "P", "torch_270" },
            { "Q", "tree" },
            { "R", "wall_0_straight" },
            { "S", "wall_0_turn" },
            { "T", "wall_90_straight" },
            { "U", "wall_90_turn" },
            { "V", "wall_180_straight" },
            { "W", "wall_180_turn" },
            { "X", "wall_270_straight" },
            { "Y", "wall_270_turn" },
            { "Z", "water" },
            { "!", "new_row" }
        };

        String levelOne = "SRRMRRRRRMRRRU"
                    + "!" + "XffffffffffffT"
                    + "!" + "XffgfffffffffT"
                    + "!" + "XfffffffffffbT"
                    + "!" + "XffffbfhffffbN"
                    + "!" + "XffffbbffffffT"
                    + "!" + "XfifffffffffbT"
                    + "!" + "XffffffffffffT"
                    + "!" + "XffffffjfffffN"
                    + "!" + "XbbfffffffkffT"
                    + "!" + "XfbffffffffffT"
                    + "!" + "XfblffffbffffT"
                    + "!" + "YVVVVVVVVVVVVW";

        String[,] levelone = {
                {"S","R","R","M","R","R","R","R","R","M","R","R","R","U"},
                {"S","R","R","M","R","R","R","R","R","M","R","R","R","U"},
                {"S","R","R","M","R","R","R","R","R","M","R","R","R","U"},
                {"S","R","R","M","R","R","R","R","R","M","R","R","R","U"},
                {"S","R","R","M","R","R","R","R","R","M","R","R","R","U"},
                {"S","R","R","M","R","R","R","R","R","M","R","R","R","U"},
                {"S","R","R","M","R","R","R","R","R","M","R","R","R","U"},
                {"S","R","R","M","R","R","R","R","R","M","R","R","R","U"},
                {"S","R","R","M","R","R","R","R","R","M","R","R","R","U"},
                {"S","R","R","M","R","R","R","R","R","M","R","R","R","U"},
                {"S","R","R","M","R","R","R","R","R","M","R","R","R","U"},
                {"S","R","R","M","R","R","R","R","R","M","R","R","R","U"},
                {"S","R","R","M","R","R","R","R","R","M","R","R","R","U"},
                {"S","R","R","M","R","R","R","R","R","M","R","R","R","U"}
        };

    }
}
