using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiDo.Levels
{
    public static class Levels
    {
        public static Dictionary<String, Tile> tiles = new Dictionary<String, Tile>()
        {
            { "a", new Tile("bridge0", new Uri("ms-appx:///Assets/Tiles/bridge/0.png"), true) },
            { "b", new Tile("bridge90", new Uri("ms-appx:///Assets/Tiles/bridge/90.png"), true) },
            { "c", new Tile("door0", new Uri("ms-appx:///Assets/Tiles/door//0.png") ) },
            { "d", new Tile("door90", new Uri("ms-appx:///Assets/Tiles/door/90.png") ) },
            { "e", new Tile("door180", new Uri("ms-appx:///Assets/Tiles/bridge/0.png") ) },
            { "f", new Tile("door270", new Uri("ms-appx:///Assets/Tiles/bridge/90.png") ) },
            { "g", new Tile("crack1", new Uri("ms-appx:///Assets/Tiles/floors/cracked/crack-1.png"), true) },
            { "h", new Tile("crack2", new Uri("ms-appx:///Assets/Tiles/floors/cracked/crack-2.png"), true) },
            { "i", new Tile("crack3", new Uri("ms-appx:///Assets/Tiles/floors/cracked/crack-3.png"), true) },
            { "j", new Tile("crack4", new Uri("ms-appx:///Assets/Tiles/floors/cracked/crack-4.png"), true) },
            { "k", new Tile("crack5", new Uri("ms-appx:///Assets/Tiles/floors/cracked/crack-5.png"), true) },
            { "l", new Tile("crack6", new Uri("ms-appx:///Assets/Tiles/floors/cracked/crack-6.png"), true) },
            { "m", new Tile("disco", new Uri("ms-appx:///Assets/Tiles/floors/disco/spr_disco.png"), true) },
            { "n", new Tile("flower1", new Uri("ms-appx:///Assets/Tiles/floors/flower/flower_1.png"), true) },
            { "o", new Tile("flower2", new Uri("ms-appx:///Assets/Tiles/floors/flower/flower_2.png"), true) },
            { "p", new Tile("flower3", new Uri("ms-appx:///Assets/Tiles/floors/flower/flower_3.png"), true) },
            { "q", new Tile("flower4", new Uri("ms-appx:///Assets/Tiles/floors/flower/flower_4.png"), true ) },
            { "r", new Tile("flower5", new Uri("ms-appx:///Assets/Tiles/floors/flower/flower_5.png"), true ) },
            { "s", new Tile("grass1", new Uri("ms-appx:///Assets/Tiles/floors/grass/grass_1.png"), true ) },
            { "t", new Tile("grass2", new Uri("ms-appx:///Assets/Tiles/floors/grass/grass_2.png"), true ) },
            { "u", new Tile("grass3", new Uri("ms-appx:///Assets/Tiles/floors/grass/grass_3.png"), true ) },
            { "v", new Tile("grass4", new Uri("ms-appx:///Assets/Tiles/floors/grass/grass_4.png"), true ) },
            { "w", new Tile("floor", new Uri("ms-appx:///Assets/Tiles/floors/floor.png"), true) },
            { "x", new Tile("cross", new Uri("ms-appx:///Assets/Tiles/paths/cross/0.png"), true ) },
            { "y", new Tile("straight0", new Uri("ms-appx:///Assets/Tiles/paths/straight/0.png"), true ) },
            { "z", new Tile("straight90", new Uri("ms-appx:///Assets/Tiles/paths/straight/90.png"), true ) },
            { "A", new Tile("t0", new Uri("ms-appx:///Assets/Tiles/paths/t/0.png"), true) },
            { "B", new Tile("t90", new Uri("ms-appx:///Assets/Tiles/paths/t/90.png"), true) },
            { "C", new Tile("t180", new Uri("ms-appx:///Assets/Tiles/paths/t/180.png"),true ) },
            { "D", new Tile("t270", new Uri("ms-appx:///Assets/Tiles/paths/t/270.png"), true ) },
            { "E", new Tile("turn0", new Uri("ms-appx:///Assets/Tiles/paths//turn/0.png"), true ) },
            { "F", new Tile("turn90", new Uri("ms-appx:///Assets/Tiles/paths/turn/90.png"), true ) },
            { "G", new Tile("turn180", new Uri("ms-appx:///Assets/Tiles/paths/turn/180.png"), true) },
            { "H", new Tile("turn270", new Uri("ms-appx:///Assets/Tiles/paths/turn/270.png"), true) },
            { "I", new Tile("wallS0", new Uri("ms-appx:///Assets/Tiles/walls/straight/0.png")) },
            { "J", new Tile("wallS90", new Uri("ms-appx:///Assets/Tiles/walls/straight/90.png")) },
            { "K", new Tile("wallS180", new Uri("ms-appx:///Assets/Tiles/walls/straight/180.png")) },
            { "L", new Tile("wallS270", new Uri("ms-appx:///Assets/Tiles/walls/straight/270.png")) },
            { "M", new Tile("torch0", new Uri("ms-appx:///Assets/Tiles/walls/torch/0.png")) },
            { "N", new Tile("torch90", new Uri("ms-appx:///Assets/Tiles/walls/torch/90.png")) },
            { "O", new Tile("torch180", new Uri("ms-appx:///Assets/Tiles/walls/torch/180.png")) },
            { "P", new Tile("torch270", new Uri("ms-appx:///Assets/Tiles/walls/torch/270.png")) },
            { "Q", new Tile("wallT0", new Uri("ms-appx:///Assets/Tiles/walls/turn/0.png")) },
            { "R", new Tile("wallT90", new Uri("ms-appx:///Assets/Tiles/walls/turn/90.png")) },
            { "S", new Tile("wallT180", new Uri("ms-appx:///Assets/Tiles/walls/turn/180.png")) },
            { "T", new Tile("wallT270", new Uri("ms-appx:///Assets/Tiles/walls/turn/270.png")) },
            { "U", new Tile("crate", new Uri("ms-appx:///Assets/Tiles/crate.png")) },
            { "V", new Tile("fence", new Uri("ms-appx:///Assets/Tiles/fence.png")) },
            { "W", new Tile("gas", new Uri("ms-appx:///Assets/Tiles/gas.png")) },
            { "X", new Tile("rubbishbin", new Uri("ms-appx:///Assets/Tiles/rubbishbin.png") ) },
            { "Y", new Tile("seat", new Uri("ms-appx:///Assets/Tiles/seat.png")) },
            { "Z", new Tile("table", new Uri("ms-appx:///Assets/Tiles/table.png") ) },
            { "1", new Tile("tree", new Uri("ms-appx:///Assets/Tiles/tree.png")) },
            { "2", new Tile("water", new Uri("ms-appx:///Assets/Tiles/water.png")) },
            { "3", new Tile("watersand", new Uri("ms-appx:///Assets/Tiles/water_sand.png"), true) }
        };

        public static Tile getTile(String key)
        {
            Tile tile = tiles[key];
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
