﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiDo.Levels
{
    public class Levels
    {
        public static Dictionary<String, Tile> tiles = new Dictionary<String, Tile>()
        {
            { "a", new Tile("bridge", new Uri("ms-appx:///Assets/Tiles/bridge.png"), true) },
            { "b", new Tile("crate", new Uri("ms-appx:///Assets/Tiles/crate.png")) },
            { "c", new Tile("disco", new Uri("ms-appx:///Assets/Tiles/spr_disco.png"), true) },
            { "d", new Tile("door", new Uri("ms-appx:///Assets/Tiles/door.png")) },
            { "e", new Tile("fence", new Uri("ms-appx:///Assets/Tiles/fence.png")) },
            { "f", new Tile("floor", new Uri("ms-appx:///Assets/Tiles/floor.png"), true) },
            { "g", new Tile("floor_cracked_1", new Uri("ms-appx:///Assets/Tiles/crack-1.png"), true) },
            { "h", new Tile("floor_cracked_2", new Uri("ms-appx:///Assets/Tiles/crack-2.png"), true) },
            { "i", new Tile("floor_cracked_3", new Uri("ms-appx:///Assets/Tiles/crack-3.png"), true) },
            { "j", new Tile("floor_cracked_4", new Uri("ms-appx:///Assets/Tiles/crack-4.png"), true) },
            { "k", new Tile("floor_cracked_5", new Uri("ms-appx:///Assets/Tiles/crack-5.png"), true) },
            { "l", new Tile("floor_cracked_6", new Uri("ms-appx:///Assets/Tiles/crack-6.png"), true) },
            { "m", new Tile("gas", new Uri("ms-appx:///Assets/Tiles/gas.png")) },
            { "n", new Tile("grass" , new Uri("ms-appx:///Assets/Tiles/grass_1.png"), true)},
            { "o", new Tile("grass_flower_1" , new Uri("ms-appx:///Assets/Tiles/flower_1.png"), true)},
            { "p", new Tile("grass_flower_2", new Uri("ms-appx:///Assets/Tiles/flower_2.png"), true) },
            { "q", new Tile("grass_flower_3", new Uri("ms-appx:///Assets/Tiles/flower_3.png"), true) },
            { "r", new Tile("grass_flower_4", new Uri("ms-appx:///Assets/Tiles/flower_4.png"), true) },
            { "s", new Tile("grass_flower_5", new Uri("ms-appx:///Assets/Tiles/flower_5.png"), true) },
            { "t", new Tile("path_0_straight", new Uri("ms-appx:///Assets/Tiles/path_1.png"), true) },
            { "u", new Tile("path_0_turn", new Uri("ms-appx:///Assets/Tiles/path_2.png"), true) },
            { "v", new Tile("path_0_cross" , new Uri("ms-appx:///Assets/Tiles/path_3.png"), true)},
            { "w", new Tile("path_0_t", new Uri("ms-appx:///Assets/Tiles/path_4.png"), true) },
            { "x", new Tile("path_90_straight" , new Uri("ms-appx:///Assets/Tiles/path_1.png"), true, 90)},
            { "y", new Tile( "path_90_turn", new Uri("ms-appx:///Assets/Tiles/path_2.png"), true, 90) },
            { "z", new Tile("path_90_cross" , new Uri("ms-appx:///Assets/Tiles/path_3.png"), true, 90)},
            { "A", new Tile("path_90_t", new Uri("ms-appx:///Assets/Tiles/path_4.png"), true, 90) },
            { "B", new Tile("path_180_straight" , new Uri("ms-appx:///Assets/Tiles/path_1.png"), true, 180)},
            { "C", new Tile("path_180_turn" , new Uri("ms-appx:///Assets/Tiles/path_2.png"), true, 180)},
            { "D", new Tile("path_180_cross", new Uri("ms-appx:///Assets/Tiles/path_3.png"), true, 180) },
            { "E", new Tile("path_180_t", new Uri("ms-appx:///Assets/Tiles/path_4.png"), true, 180) },
            { "F", new Tile("path_270_straight" , new Uri("ms-appx:///Assets/Tiles/path_1.png"), true, 270)},
            { "G", new Tile("path_270_turn" , new Uri("ms-appx:///Assets/Tiles/path_2.png"), true, 270)},
            { "H", new Tile("path_270_cross", new Uri("ms-appx:///Assets/Tiles/path_3.png"), true, 270) },
            { "I", new Tile("path_270_t", new Uri("ms-appx:///Assets/Tiles/path_4.png"), true, 270) },
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
            { "T", new Tile("wall_90_straight", new Uri("ms-appx:///Assets/Tiles/wall-2.png"), false, 90) },
            { "U", new Tile("wall_90_turn", new Uri("ms-appx:///Assets/Tiles/wall-1.png"), false, 90) },
            { "V", new Tile("wall_180_straight", new Uri("ms-appx:///Assets/Tiles/wall-2.png"), false, 180) },
            { "W", new Tile("wall_180_turn", new Uri("ms-appx:///Assets/Tiles/wall-1.png"), false, 180) },
            { "X", new Tile("wall_270_straight", new Uri("ms-appx:///Assets/Tiles/wall-2.png"), false, 270) },
            { "Y", new Tile("wall_270_turn", new Uri("ms-appx:///Assets/Tiles/wall-1.png"), false, 270) },
            { "Z", new Tile("water", new Uri("ms-appx:///Assets/Tiles/water.png"))}
        };

        public static Tile getTile(String key)
        {
            Tile tile = tiles[key];
            return tile;
        }


        public String getTileType(float x, float y, String [,] gekozenLevel)
        {
            return getPlayerTile(x, y, gekozenLevel).TileType;
        }

        public Tile getPlayerTile(float x, float y, String[,] gekozenLevel)
        {
            double x_round = Math.Floor((x) / 32);
            double y_round = Math.Floor((y) / 32);
            double xPos = x_round * 32;
            double yPos = y_round * 32;
            double xPos2 = xPos + 32;
            double yPos2 = yPos + 32;
            String tile_Type = gekozenLevel[(int)y_round, (int)x_round].ToString();
            Tile tile = getTile(tile_Type);

            return tile;
        }

        public static String[,] levelOne = { // 14x14   
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
        public static String[,] levelTwo =  { // 35 x 24
            {"n","n","n","n","n","n","o","n","n","n","n","n","n","n","n","Z","Z","Z","Z","Z","n","n","n","n","n","n","n","n","n","n","n","n","n","n","n"},
            {"t","t","u","n","n","n","n","n","n","n","n","n","n","n","n","n","Z","Z","Z","Z","n","n","n","n","n","o","n","n","n","n","n","o","n","n","n"},
            {"n","n","x","n","n","n","n","n","n","n","n","n","o","n","n","n","Z","Z","Z","Z","Z","n","n","n","n","n","n","n","n","n","n","n","n","n","n"},
            {"n","n","x","o","n","G","t","u","n","n","n","n","n","n","n","n","n","Z","Z","Z","Z","Z","n","o","n","n","n","n","n","n","n","n","n","n","n"},
            {"n","n","I","t","t","y","n","C","t","u","n","n","n","n","n","n","n","Z","Z","Z","Z","Z","n","n","n","n","n","n","n","n","n","n","n","n","n"},
            {"n","G","y","n","n","n","n","n","n","C","t","t","t","w","t","t","t","t","a","a","a","a","w","t","t","u","n","o","n","n","n","n","n","o","n"},
            {"n","x","n","n","n","n","n","n","Q","Q","n","n","n","x","n","n","n","n","Z","Z","Z","Z","x","n","Q","C","t","t","u","n","n","n","n","n","n"},
            {"n","C","t","t","u","n","n","Q","Q","Q","n","n","n","x","n","n","n","n","Z","Z","Z","Z","C","Q","Q","Q","n","n","x","n","n","n","n","n","n"},
            {"n","n","n","n","x","n","n","n","Q","n","n","n","n","C","u","n","n","n","Z","Z","Z","Z","Z","x","Q","Q","n","n","x","n","n","G","t","t","t"},
            {"n","n","G","t","y","n","n","n","n","n","n","n","o","n","x","n","n","n","n","Z","Z","Z","Z","C","t","t","t","t","v","t","t","y","n","n","n"},
            {"n","n","x","n","n","n","n","n","n","n","n","n","n","n","C","t","t","u","n","Z","Z","Z","Z","Z","n","n","n","n","x","n","n","n","n","n","n"},
            {"n","n","x","n","n","n","n","n","o","n","n","n","n","n","n","o","n","x","n","n","Z","Z","Z","Z","n","n","n","G","y","n","n","Q","n","n","n"},
            {"o","n","C","u","n","n","Z","Z","Z","Z","n","n","n","G","t","t","u","x","n","Z","Z","Z","Z","Z","n","o","G","y","n","n","Q","Q","Q","n","n"},
            {"n","n","n","x","n","Z","Z","Z","Z","Z","Z","Z","n","x","n","n","C","y","n","n","Z","Z","Z","Z","Z","n","x","n","n","n","Q","Q","Q","n","n"},
            {"n","n","n","x","n","Z","Z","Z","Z","Z","Z","Z","n","x","n","n","n","n","o","n","Z","Z","Z","Z","Z","G","y","n","n","n","n","Q","n","n","n"},
            {"n","n","n","C","u","n","Z","Z","Z","Z","Z","Z","n","C","w","t","t","u","n","n","n","Z","Z","Z","Z","x","n","n","n","n","n","n","n","n","n"},
            {"n","n","n","n","x","n","Z","Z","Z","Z","Z","Z","n","n","x","n","n","C","t","t","t","a","a","a","a","y","n","n","n","n","n","n","n","n","n"},
            {"n","n","n","n","x","n","o","Z","Z","Z","Z","Q","n","n","x","n","n","n","n","n","n","Z","Z","Z","Z","n","Q","n","n","n","n","n","n","n","n"},
            {"n","n","n","n","x","n","n","Z","Z","Z","Q","Q","Q","n","C","t","t","u","n","n","n","Z","Z","Z","Z","Q","Q","Q","n","n","n","n","n","n","n"},
            {"n","n","n","n","C","t","u","n","n","n","Q","Q","n","n","n","n","n","x","n","n","n","Z","Z","Z","Z","Q","Q","n","n","n","n","o","n","n","n"},
            {"n","n","n","n","n","n","C","t","t","t","u","n","n","n","n","n","n","x","n","n","n","Z","Z","Z","Z","Z","n","n","n","n","n","n","n","n","n"},
            {"n","n","n","n","n","n","n","n","n","n","C","t","t","t","t","t","t","y","n","n","n","Z","Z","Z","Z","Z","n","n","n","n","n","n","n","n","n"},
            {"n","n","n","n","n","n","n","n","n","n","n","n","n","n","n","n","n","n","n","n","n","n","Z","Z","Z","Z","n","n","n","n","n","n","n","n","n"},
            {"n","n","n","n","n","n","n","n","n","n","n","n","n","n","n","n","n","n","o","n","n","n","Z","Z","Z","Z","n","n","n","n","n","n","n","n","n"}
        };

        public static String[,] levelThree =  { //20x25
            {" ", " ", " ", " ", " ", " ", " ", "S", "R", "R", "R", "R", "R", "R", "R", "R", "R", "R", "R", "R", "R", "R", "R", "R", "U"},
            {" ", " ", " ", " ", " ", " ", " ", "X", "f", "f", "f", "f", "f", "f", "f", "f", "f", "f", "b", "f", "b", "f", "f", "f", "T"},
            {" ", " ", " ", " ", " ", " ", " ", "X", "f", "f", "f", "f", "f", "f", "f", "f", "f", "f", "b", "f", "b", "f", "f", "f", "T"},
            {" ", " ", " ", " ", " ", " ", " ", "X", "f", "f", "f", "f", "f", "f", "f", "f", "f", "f", "f", "f", "f", "f", "f", "f", "T"},
            {" ", " ", " ", " ", " ", " ", " ", "X", "f", "f", "f", "f", "f", "f", "f", "f", "f", "f", "f", "f", "f", "f", "f", "f", "T"},
            {" ", " ", " ", " ", " ", " ", " ", "X", "f", "f", "f", "f", "f", "f", "f", "f", "f", "f", "f", "f", "f", "f", "f", "f", "T"},
            {"S", "R", "R", "R", "R", "R", "R", "W", "f", "f", "f", "f", "f", "f", "f", "f", "f", "f", "f", "f", "f", "f", "f", "f", "T"},
            {"X", "f", "f", "f", "f", "f", "f", "f", "f", "f", "f", "f", "f", "f", "f", "f", "f", "f", "f", "f", "f", "f", "f", "f", "T"},
            {"X", "f", "f", "f", "f", "f", "f", "f", "f", "f", "f", "f", "f", "f", "f", "f", "f", "f", "f", "f", "f", "f", "f", "f", "T"},
            {"X", "f", "f", "f", "f", "f", "f", "f", "f", "f", "b", "b", "b", "b", "f", "f", "f", "f", "f", "f", "f", "f", "f", "f", "T"},
            {"X", "f", "f", "f", "f", "f", "f", "f", "f", "f", "b", "f", "f", "f", "f", "f", "f", "f", "f", "f", "f", "f", "f", "f", "T"},
            {"X", "f", "f", "f", "f", "f", "f", "f", "f", "f", "b", "f", "f", "f", "f", "f", "f", "f", "f", "f", "f", "f", "f", "f", "T"},
            {"X", "f", "f", "f", "f", "f", "f", "f", "f", "f", "b", "f", "f", "f", "f", "f", "f", "f", "f", "f", "f", "f", "f", "f", "T"},
            {"X", "b", "f", "f", "f", "f", "f", "f", "f", "f", "f", "f", "f", "f", "f", "f", "f", "f", "f", "f", "f", "f", "f", "f", "T"},
            {"X", "f", "f", "f", "f", "f", "f", "f", "f", "f", "f", "f", "f", "f", "f", "f", "f", "f", "f", "f", "f", "f", "f", "b", "T"},
            {"X", "f", "f", "f", "f", "f", "f", "f", "f", "f", "f", "f", "b", "f", "f", "f", "f", "f", "f", "f", "f", "f", "f", "f", "T"},
            {"X", "b", "f", "f", "f", "f", "f", "f", "f", "f", "b", "f", "f", "f", "f", "f", "f", "f", "f", "f", "f", "b", "f", "f", "T"},
            {"X", "f", "f", "f", "f", "f", "f", "f", "f", "f", "f", "f", "f", "f", "f", "f", "f", "f", "f", "f", "f", "b", "f", "f", "T"},
            {"X", "b", "f", "f", "f", "f", "f", "f", "f", "f", "f", "f", "f", "f", "f", "f", "f", "f", "f", "f", "f", "b", "f", "f", "T"},
            {"Y", "V", "V", "V", "V", "V", "V", "V", "V", "V", "V", "V", "V", "V", "V", "V", "V", "V", "V", "V", "V", "V", "V", "V", "W"},
        };

        public static String[,] levelFour = { // 26 x 26
            {"S","R","R","R","R","R","R","R","R","R","R","R","R","R","R","R","R","R","R","R","R","R","U","H","H","H"},
            {"X","b","b","f","f","f","f","f","f","f","f","f","f","f","f","f","f","f","f","f","f","f","T","H","H","H"},
            {"X","b","f","f","f","f","f","f","f","f","f","f","f","f","f","f","f","f","f","f","f","f","T","H","H","H"},
            {"X","f","f","f","f","f","f","f","f","f","f","f","f","f","f","f","f","f","f","f","f","f","T","H","H","H"},
            {"X","f","f","f","f","f","f","f","f","f","f","f","f","f","f","f","f","f","f","f","f","f","9","R","R","U"},
            {"X","f","f","f","f","f","f","f","f","f","f","f","f","f","f","f","f","f","f","f","f","f","f","f","f","T"},
            {"Y","V","V","V","@","f","f","f","f","f","!","V","@","b","b","f","b","f","f","f","f","f","f","f","f","T"},
            {"H","H","H","H","X","f","f","f","f","f","T","H","X","f","f","f","b","f","f","f","f","f","f","f","f","T"},
            {"S","R","R","R","8","f","f","f","f","f","9","R","8","b","b","b","b","f","f","f","f","f","f","f","f","T"},
            {"X","f","b","f","f","f","f","f","f","f","f","f","f","f","f","f","f","f","f","f","f","f","f","f","f","T"},
            {"X","f","b","f","f","f","f","f","f","f","f","f","f","f","f","f","f","f","f","f","f","f","f","f","f","T"},
            {"X","f","b","f","f","f","f","f","b","f","f","f","f","f","f","b","f","f","f","f","f","f","f","f","f","T"},
            {"X","f","f","f","f","f","f","f","f","b","f","f","f","f","f","!","V","V","@","f","f","f","f","f","f","T"},
            {"X","f","b","f","f","f","f","f","f","f","f","f","f","f","f","T","H","H","X","f","f","f","f","f","f","T"},
            {"X","f","b","f","f","f","f","f","f","f","f","f","f","f","f","T","H","H","X","f","f","f","f","f","f","T"},
            {"X","b","b","f","f","f","f","f","f","f","f","f","f","f","f","T","H","H","X","f","f","f","f","f","f","T"},
            {"X","f","f","f","f","f","f","f","f","f","f","f","f","f","f","T","H","H","X","f","f","f","f","f","f","T"},
            {"X","f","f","f","f","f","f","f","f","f","f","f","f","f","f","T","H","H","X","f","f","f","!","V","V","W"},
            {"X","f","f","f","f","f","f","f","f","f","f","f","f","f","f","9","R","R","8","f","f","f","9","R","R","U"},
            {"X","f","f","f","f","f","f","f","f","f","f","f","f","f","f","f","f","f","f","f","f","f","f","f","f","T"},
            {"X","f","f","f","f","f","f","f","f","f","f","f","f","f","f","f","f","f","f","f","f","f","f","f","f","T"},
            {"X","f","f","f","f","f","f","f","f","f","f","f","f","f","f","f","f","f","f","f","f","f","f","f","f","T"},
            {"Y","V","V","@","f","f","f","f","f","f","f","f","f","f","f","b","f","f","f","f","f","f","f","f","f","T"},
            {"H","H","H","X","f","f","f","f","f","f","!","V","V","V","V","@","f","f","f","f","f","f","f","f","f","T"},
            {"H","H","H","X","f","f","f","f","f","f","T","H","H","H","H","X","f","f","f","f","f","f","f","f","f","T"},
            {"H","H","H","Y","V","V","V","V","V","V","W","H","H","H","H","Y","V","V","V","V","V","V","V","V","V","W"}
        };

        public static String[,] levelFive = { // 39 x 21
            {"c","D","q","p","q","p","q","p","q","r","c","c","c","1","0","3","c","1","0","3","c","1","0","3","c","1","0","3","c","c","c","c","c","f","f","f","f","f","f"},
            {"c","D","p","q","p","q","p","q","p","r","c","c","c","c","c","c","c","c","c","c","c","c","c","c","c","c","c","c","c","c","f","f","f","f","f","f","f","f","f"},
            {"c","B","z","z","z","z","z","z","z","s","c","c","c","c","c","c","c","c","c","c","c","c","c","c","c","c","c","c","c","f","f","f","f","f","f","f","f","f","f"},
            {"c","c","c","c","c","c","c","c","c","c","c","c","c","c","c","c","c","c","c","c","c","c","c","c","c","c","c","c","f","f","f","f","f","f","f","f","f","f","f"},
            {"c","c","c","c","c","c","c","c","c","c","c","c","c","c","c","c","c","c","c","c","c","c","c","c","c","c","c","f","f","f","f","f","f","f","f","f","f","f","f"},
            {"c","c","c","c","c","c","c","c","c","c","c","c","c","c","c","c","c","c","c","c","c","c","c","c","c","c","f","f","f","f","f","f","f","f","f","f","f","f","f"},
            {"c","c","c","c","c","c","c","c","c","c","c","c","c","c","c","c","c","c","c","c","c","c","c","c","c","c","f","f","f","f","f","f","f","f","f","f","f","f","f"},
            {"c","c","c","c","c","c","c","c","c","c","c","c","c","c","c","c","c","c","c","c","c","c","c","c","c","f","f","f","f","f","f","f","f","f","f","f","f","f","f"},
            {"c","c","c","c","c","c","c","c","c","c","c","c","c","c","c","c","c","c","c","c","c","c","c","c","c","f","f","f","f","f","f","f","f","f","f","f","f","f","f"},
            {"c","c","c","c","c","c","c","c","c","c","c","c","c","c","c","c","c","c","c","c","c","c","c","c","c","f","f","f","f","f","f","f","f","f","f","f","f","f","f"},
            {"c","c","c","c","c","c","c","c","c","c","c","c","c","c","c","c","c","c","c","c","c","c","c","c","c","f","f","f","f","f","f","f","f","f","f","f","f","f","f"},
            {"c","c","c","c","c","c","c","c","c","c","c","c","c","c","c","c","c","c","c","c","c","c","c","c","c","f","f","f","f","f","f","f","f","f","f","f","f","f","f"},
            {"c","c","c","c","c","c","c","c","c","c","c","c","c","c","c","c","c","c","c","c","c","c","c","c","c","f","f","f","f","f","f","f","f","f","f","f","f","f","f"},
            {"c","c","c","c","c","c","c","c","c","c","c","c","c","c","c","c","c","c","c","c","c","c","c","c","c","f","f","f","f","f","f","f","f","f","f","f","f","f","f"},
            {"c","c","c","c","c","c","c","c","c","c","c","c","c","c","c","c","c","c","c","c","c","c","c","c","c","c","f","f","f","f","f","f","f","f","f","f","f","f","f"},
            {"c","c","c","c","c","c","c","c","c","c","c","c","c","c","c","c","c","c","c","c","c","c","c","c","c","c","f","f","f","f","f","f","f","f","f","f","f","f","f"},
            {"c","c","c","c","c","c","c","c","c","c","c","c","c","c","c","c","c","c","c","c","c","c","c","c","c","c","c","f","f","f","f","f","f","f","f","f","f","f","f"},
            {"c","c","c","c","c","c","c","c","c","c","c","c","c","c","c","c","c","c","c","c","c","c","c","c","c","c","c","c","f","f","f","f","f","f","f","f","f","f","f"},
            {"c","c","c","c","c","c","c","c","c","c","c","c","c","c","c","c","c","c","c","c","c","c","c","c","c","c","c","c","c","f","f","f","f","f","f","f","f","f","f"},
            {"c","c","c","c","c","c","c","c","c","c","c","c","c","c","c","c","c","c","c","c","c","c","c","c","c","c","c","c","c","c","f","f","f","f","f","f","f","f","f"},
            {"c","7","4","5","c","7","4","5","c","7","4","5","c","7","4","5","c","7","4","5","c","7","4","5","c","7","4","5","c","c","c","c","c","f","f","f","f","f","f"}};

        public static String[,] levelSix =
        { // 36x25
            {"S","R","R","R","R","R","R","R","U","H","H","H","H","H","H","H","H","H","H","H","H","H","S","R","R","R","R","R","R","R","R","R","R","R","R","U"},
            {"X","f","f","f","f","f","f","f","T","H","H","H","H","H","H","H","H","H","H","H","H","H","X","f","f","f","f","f","f","f","f","f","f","f","f","T"},
            {"X","f","f","f","f","f","f","f","T","H","H","H","H","H","H","H","H","H","H","H","H","H","X","f","f","f","f","f","f","f","f","f","f","f","f","T"},
            {"X","f","f","f","f","f","f","b","T","H","H","H","H","H","H","H","H","H","H","H","H","H","X","f","f","f","f","f","f","f","f","f","f","f","f","T"},
            {"X","f","f","f","f","b","b","b","T","H","H","H","H","H","H","H","H","H","H","H","H","H","X","f","f","f","f","f","f","f","b","b","f","f","f","T"},
            {"X","f","f","f","f","f","f","f","T","H","H","H","H","H","H","H","H","H","H","H","H","H","X","f","f","f","f","f","f","b","b","b","f","f","f","T"},
            {"X","f","f","f","f","f","f","f","9","R","R","R","R","R","R","R","R","R","R","R","R","R","8","f","f","f","f","f","f","f","b","f","f","f","f","T"},
            {"X","f","f","f","f","f","f","f","f","f","f","f","f","b","f","f","f","f","f","b","b","f","f","f","f","f","f","f","f","f","f","f","f","f","f","T"},
            {"X","f","f","f","f","f","f","f","f","f","f","f","f","f","f","f","f","f","f","f","f","f","f","f","f","f","f","f","f","f","f","f","f","f","f","T"},
            {"X","f","f","f","f","f","f","f","f","f","f","f","f","f","f","f","f","f","f","f","f","f","f","f","f","f","f","f","f","f","f","f","f","f","f","T"},
            {"X","f","f","f","f","f","f","f","f","f","f","f","b","f","f","f","f","f","f","f","f","f","f","f","f","f","f","f","f","f","f","f","f","f","f","T"},
            {"X","f","f","f","f","f","f","f","!","V","V","V","@","f","f","f","f","f","!","V","V","V","@","f","f","f","f","f","f","f","f","f","f","f","f","T"},
            {"X","f","f","f","f","f","f","b","T","H","H","H","Y","V","V","V","V","V","W","H","H","H","X","f","f","f","f","f","b","b","f","f","f","f","f","T"},
            {"X","f","f","f","f","f","b","b","T","H","H","H","H","H","H","H","H","H","H","H","H","H","X","f","f","f","f","f","b","b","b","f","f","f","f","T"},
            {"X","f","f","f","f","f","f","b","T","H","H","H","H","H","H","H","H","H","H","H","H","H","X","f","f","f","f","f","b","b","b","b","f","f","f","T"},
            {"X","f","f","f","f","f","f","b","T","H","H","H","H","H","H","H","H","H","H","H","H","H","X","f","f","f","f","f","f","b","f","f","f","f","f","T"},
            {"X","f","f","f","f","f","f","f","T","H","H","H","H","H","H","H","H","H","H","H","H","H","X","f","f","f","f","f","f","f","f","f","f","f","f","T"},
            {"X","f","f","f","f","f","f","f","T","H","H","H","H","H","H","H","H","H","H","H","H","H","X","f","f","f","f","f","f","f","f","f","f","f","f","T"},
            {"X","f","f","f","f","f","f","f","T","H","H","H","H","H","H","H","H","H","H","H","H","H","X","f","f","f","b","f","f","f","f","f","f","f","f","T"},
            {"X","f","f","f","f","f","f","f","9","R","R","R","R","R","R","R","R","R","R","R","R","R","8","f","f","b","b","b","f","f","f","f","b","f","f","T"},
            {"X","f","f","f","f","f","f","f","f","b","b","f","f","f","f","f","f","f","f","f","f","f","f","f","f","b","b","b","f","f","f","b","b","f","f","T"},
            {"X","f","b","b","f","f","f","f","f","f","f","f","f","f","f","f","f","f","f","f","f","f","f","f","f","f","f","f","f","f","f","f","f","f","f","T"},
            {"X","f","b","b","b","f","f","f","f","f","f","f","f","f","f","f","f","f","f","f","f","f","f","f","f","f","f","f","f","f","f","f","f","f","f","T"},
            {"X","f","f","f","f","f","f","f","f","f","f","f","b","f","f","f","f","f","f","f","f","f","f","f","f","f","f","f","f","f","f","f","f","f","f","T"},
            {"Y","V","V","V","V","V","V","V","V","V","V","V","V","V","V","V","V","V","V","V","V","V","V","V","V","V","V","V","V","V","V","V","V","V","V","W"}
    };

}
}
