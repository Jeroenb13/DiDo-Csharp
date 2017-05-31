﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiDo.Levels
{
    class Levels
    {
        private Dictionary<String, Tile> tiles = new Dictionary<String, Tile>()
        {
            { "a", new Tile("bridge", new Uri("ms-appx:///Assets/Tiles/bridge.png")) },
            { "b", new Tile("crate", new Uri("ms-appx:///Assets/Tiles/crate.png")) },
            { "c", new Tile("disco", new Uri("ms-appx:///Assets/Tiles/spr_disco.png")) },
            { "d", new Tile("door", new Uri("ms-appx:///Assets/Tiles/door.png")) },
            { "e", new Tile("fence", new Uri("ms-appx:///Assets/Tiles/fence.png")) },
            { "f", new Tile("floor", new Uri("ms-appx:///Assets/Tiles/floor.png")) },
            { "g", new Tile("floor_cracked_1", new Uri("ms-appx:///Assets/Tiles/crack-1.png")) },
            { "h", new Tile("floor_cracked_2", new Uri("ms-appx:///Assets/Tiles/crack-2.png")) },
            { "i", new Tile("floor_cracked_3", new Uri("ms-appx:///Assets/Tiles/crack-3.png")) },
            { "j", new Tile("floor_cracked_4", new Uri("ms-appx:///Assets/Tiles/crack-4.png")) },
            { "k", new Tile("floor_cracked_5", new Uri("ms-appx:///Assets/Tiles/crack-5.png")) },
            { "l", new Tile("floor_cracked_6", new Uri("ms-appx:///Assets/Tiles/crack-6.png")) },
            { "m", new Tile("gas", new Uri("ms-appx:///Assets/Tiles/gas.png")) },
            { "n", new Tile("grass" , new Uri("ms-appx:///Assets/Tiles/grass.png"))},
            { "o", new Tile("grass_flower_1" , new Uri("ms-appx:///Assets/Tiles/flower-1.png"))},
            { "p", new Tile("grass_flower_2", new Uri("ms-appx:///Assets/Tiles/flower-2.png")) },
            { "q", new Tile("grass_flower_3", new Uri("ms-appx:///Assets/Tiles/flower-3.png")) },
            { "r", new Tile("grass_flower_4", new Uri("ms-appx:///Assets/Tiles/flower-4.png")) },
            { "s", new Tile("grass_flower_5", new Uri("ms-appx:///Assets/Tiles/flower-5.png")) },
            { "t", new Tile("path_0_straight", new Uri("ms-appx:///Assets/Tiles/path_1.png")) },
            { "u", new Tile("path_0_turn", new Uri("ms-appx:///Assets/Tiles/path_2.png")) },
            { "v", new Tile("path_0_cross" , new Uri("ms-appx:///Assets/Tiles/path_3.png"))},
            { "w", new Tile("path_0_t", new Uri("ms-appx:///Assets/Tiles/path_4.png")) },
            { "x", new Tile("path_90_straight" , new Uri("ms-appx:///Assets/Tiles/path_1.png"))},
            { "y", new Tile( "path_90_turn", new Uri("ms-appx:///Assets/Tiles/path_2.png")) },
            { "z", new Tile("path_90_cross" , new Uri("ms-appx:///Assets/Tiles/path_3.png"))},
            { "A", new Tile("path_90_t", new Uri("ms-appx:///Assets/Tiles/path_4.png")) },
            { "B", new Tile("path_180_straight" , new Uri("ms-appx:///Assets/Tiles/path_1.png"))},
            { "C", new Tile("path_180_turn" , new Uri("ms-appx:///Assets/Tiles/path_2.png"))},
            { "D", new Tile("path_180_cross", new Uri("ms-appx:///Assets/Tiles/path_3.png")) },
            { "E", new Tile("path_180_t", new Uri("ms-appx:///Assets/Tiles/path_4.png")) },
            { "F", new Tile("path_270_straight" , new Uri("ms-appx:///Assets/Tiles/path_1.png"))},
            { "G", new Tile("path_270_turn" , new Uri("ms-appx:///Assets/Tiles/path_2.png"))},
            { "H", new Tile("path_270_cross", new Uri("ms-appx:///Assets/Tiles/path_3.png")) },
            { "I", new Tile("path_270_t", new Uri("ms-appx:///Assets/Tiles/path_4.png")) },
            { "J", new Tile("rubbish_bin", new Uri("ms-appx:///Assets/Tiles/rubbishbin.png")) },
            { "K", new Tile("seat", new Uri("ms-appx:///Assets/Tiles/seat.png")) },
            { "L", new Tile("table" , new Uri("ms-appx:///Assets/Tiles/table.png")) },
            { "M", new Tile("torch_0", new Uri("ms-appx:///Assets/Tiles/torch.png")) },
            { "N", new Tile("torch_90", new Uri("ms-appx:///Assets/Tiles/torch.png")) },
            { "O", new Tile("torch_180", new Uri("ms-appx:///Assets/Tiles/torch.png")) },
            { "P", new Tile("torch_270", new Uri("ms-appx:///Assets/Tiles/torch.png")) },
            { "Q", new Tile("tree", new Uri("ms-appx:///Assets/Tiles/tree.png")) },
            { "R", new Tile("wall_0_straight", new Uri("ms-appx:///Assets/Tiles/wall-2.png")) },
            { "S", new Tile("wall_0_turn", new Uri("ms-appx:///Assets/Tiles/wall-1.png")) },
            { "T", new Tile("wall_90_straight", new Uri("ms-appx:///Assets/Tiles/wall-2.png")) },
            { "U", new Tile("wall_90_turn", new Uri("ms-appx:///Assets/Tiles/wall-1.png")) },
            { "V", new Tile("wall_180_straight", new Uri("ms-appx:///Assets/Tiles/wall-2.png")) },
            { "W", new Tile("wall_180_turn", new Uri("ms-appx:///Assets/Tiles/wall-1.png")) },
            { "X", new Tile("wall_270_straight", new Uri("ms-appx:///Assets/Tiles/wall-2.png")) },
            { "Y", new Tile("wall_270_turn", new Uri("ms-appx:///Assets/Tiles/wall-1.png")) },
            { "Z", new Tile("water", new Uri("ms-appx:///Assets/Tiles/water.png"))}
        };

        String[,] levelOne = { // 14x14
                {"S","R","R","M","R","R","R","R","R","M","R","R","R","U"},
                {"P","f","f","f","f","f","f","f","f","f","f","f","f","T"},
                {"X","f","f","g","f","f","f","f","f","f","f","f","f","T"},
                {"X","f","f","f","f","f","f","f","f","f","f","f","b","T"},
                {"X","f","f","f","f","b","f","h","f","f","f","f","b","N"},
                {"X","f","f","f","f","b","b","f","f","f","f","f","f","T"},
                {"X","f","i","f","f","f","f","f","f","f","f","f","b","T"},
                {"X","f","f","f","f","f","f","f","f","f","f","f","f","T"},
                {"X","f","f","f","f","f","f","j","f","f","f","f","f","N"},
                {"X","b","b","f","f","f","f","f","f","f","k","f","f","T"},
                {"X","f","b","f","f","f","f","f","f","f","f","f","f","T"},
                {"P","f","b","l","f","f","f","f","b","f","f","f","f","T"},
                {"P","f","f","f","f","f","f","f","f","f","f","f","b","T"},
                {"Y","V","V","V","V","V","V","V","V","V","V","V","V","W"},
        };
        String[,] levelTwo = { // 34x24
                {"n","n","n","n","n","n","o","n","n","n","n","n","n","n","n","Z","Z","Z","Z","Z","n","n","n","n","n","n","n","n","n","n","n","n","n","n","n"},
                {"t","t","u","n","n","n","n","n","n","n","n","n","n","n","n","n","Z","Z","Z","Z","n","n","n","n","n","p","n","n","n","n","n","q","n","n","n"},
                {"n","n","x","n","n","n","n","n","n","n","n","n","r","n"/**/,"n","n","n","n","n","n","n","n","n","n","n","n","n","n","n","n","n","n","n","n","n"},
                {"n","n","n","n","n","n","n","n","n","n","n","n","n","n","n","n","n","n","n","n","n","n","n","n","n","n","n","n","n","n","n","n","n","n","n"},
                {"n","n","n","n","n","n","n","n","n","n","n","n","n","n","n","n","n","n","n","n","n","n","n","n","n","n","n","n","n","n","n","n","n","n","n"},
                {"n","n","n","n","n","n","n","n","n","n","n","n","n","n","n","n","n","n","n","n","n","n","n","n","n","n","n","n","n","n","n","n","n","n","n"},
                {"n","n","n","n","n","n","n","n","n","n","n","n","n","n","n","n","n","n","n","n","n","n","n","n","n","n","n","n","n","n","n","n","n","n","n"},
                {"n","n","n","n","n","n","n","n","n","n","n","n","n","n","n","n","n","n","n","n","n","n","n","n","n","n","n","n","n","n","n","n","n","n","n"},
                {"n","n","n","n","n","n","n","n","n","n","n","n","n","n","n","n","n","n","n","n","n","n","n","n","n","n","n","n","n","n","n","n","n","n","n"},
                {"n","n","n","n","n","n","n","n","n","n","n","n","n","n","n","n","n","n","n","n","n","n","n","n","n","n","n","n","n","n","n","n","n","n","n"},
                {"n","n","n","n","n","n","n","n","n","n","n","n","n","n","n","n","n","n","n","n","n","n","n","n","n","n","n","n","n","n","n","n","n","n","n"},
                {"n","n","n","n","n","n","n","n","n","n","n","n","n","n","n","n","n","n","n","n","n","n","n","n","n","n","n","n","n","n","n","n","n","n","n"},
                {"n","n","n","n","n","n","n","n","n","n","n","n","n","n","n","n","n","n","n","n","n","n","n","n","n","n","n","n","n","n","n","n","n","n","n"},
                {"n","n","n","n","n","n","n","n","n","n","n","n","n","n","n","n","n","n","n","n","n","n","n","n","n","n","n","n","n","n","n","n","n","n","n"},
                {"n","n","n","n","n","n","n","n","n","n","n","n","n","n","n","n","n","n","n","n","n","n","n","n","n","n","n","n","n","n","n","n","n","n","n"},
                {"n","n","n","n","n","n","n","n","n","n","n","n","n","n","n","n","n","n","n","n","n","n","n","n","n","n","n","n","n","n","n","n","n","n","n"},
                {"n","n","n","n","n","n","n","n","n","n","n","n","n","n","n","n","n","n","n","n","n","n","n","n","n","n","n","n","n","n","n","n","n","n","n"},
                {"n","n","n","n","n","n","n","n","n","n","n","n","n","n","n","n","n","n","n","n","n","n","n","n","n","n","n","n","n","n","n","n","n","n","n"},
                {"n","n","n","n","n","n","n","n","n","n","n","n","n","n","n","n","n","n","n","n","n","n","n","n","n","n","n","n","n","n","n","n","n","n","n"},
                {"n","n","n","n","n","n","n","n","n","n","n","n","n","n","n","n","n","n","n","n","n","n","n","n","n","n","n","n","n","n","n","n","n","n","n"},
                {"n","n","n","n","n","n","n","n","n","n","n","n","n","n","n","n","n","n","n","n","n","n","n","n","n","n","n","n","n","n","n","n","n","n","n"},
                {"n","n","n","n","n","n","n","n","n","n","n","n","n","n","n","n","n","n","n","n","n","n","n","n","n","n","n","n","n","n","n","n","n","n","n"},
                {"n","n","n","n","n","n","n","n","n","n","n","n","n","n","n","n","n","n","n","n","n","n","n","n","n","n","n","n","n","n","n","n","n","n","n"},
                {"n","n","n","n","n","n","n","n","n","n","n","n","n","n","n","n","n","n","n","n","n","n","n","n","n","n","n","n","n","n","n","n","n","n","n"}
        };

    }
}
