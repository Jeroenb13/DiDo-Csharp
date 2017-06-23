using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiDo.Levels
{
    public class Levels
    {
        public String[,] gekozenLevel = levelTwo;
        // Set choosen level

        public static Dictionary<String, Tile> tiles = new Dictionary<String, Tile>()
        {
            { "a", new Tile("bridge0", new Uri("ms-appx:///Assets/Tiles/bridge/0.png"), true) },
            { "b", new Tile("bridge90", new Uri("ms-appx:///Assets/Tiles/bridge/90.png"), true) },
            { "c", new Tile("door0", new Uri("ms-appx:///Assets/Tiles/door/0.png") ) },
            { "d", new Tile("door90", new Uri("ms-appx:///Assets/Tiles/door/90.png") ) },
            { "e", new Tile("door180", new Uri("ms-appx:///Assets/Tiles/door/180.png") ) },
            { "f", new Tile("door270", new Uri("ms-appx:///Assets/Tiles/door/270.png") ) },
            { "g", new Tile("crack1", new Uri("ms-appx:///Assets/Tiles/floors/cracked/crack-1.png"), true) },
            { "h", new Tile("crack2", new Uri("ms-appx:///Assets/Tiles/floors/cracked/crack-2.png"), true) },
            { "i", new Tile("crack3", new Uri("ms-appx:///Assets/Tiles/floors/cracked/crack-3.png"), true) },
            { "j", new Tile("crack4", new Uri("ms-appx:///Assets/Tiles/floors/cracked/crack-4.png"), true) },
            { "k", new Tile("crack5", new Uri("ms-appx:///Assets/Tiles/floors/cracked/crack-5.png"), true) },
            { "l", new Tile("crack6", new Uri("ms-appx:///Assets/Tiles/floors/cracked/crack-6.png"), true) },
            { "m", new Tile("disco", new Uri("ms-appx:///Assets/Tiles/floors/disco/blue.png"), true) },
            { "m_1", new Tile("disco", new Uri("ms-appx:///Assets/Tiles/floors/disco/blue.png"), true) },
            { "m_2", new Tile("disco", new Uri("ms-appx:///Assets/Tiles/floors/disco/cyan.png"), true) },
            { "m_3", new Tile("disco", new Uri("ms-appx:///Assets/Tiles/floors/disco/green.png"), true) },
            { "m_4", new Tile("disco", new Uri("ms-appx:///Assets/Tiles/floors/disco/pink.png"), true) },
            { "m_5", new Tile("disco", new Uri("ms-appx:///Assets/Tiles/floors/disco/yellow.png"), true) },
            { "m2", new Tile("disco", new Uri("ms-appx:///Assets/Tiles/floors/disco/blue.png"), true) },
            { "m2_1", new Tile("disco", new Uri("ms-appx:///Assets/Tiles/floors/disco/yellow.png"), true) },
            { "m2_2", new Tile("disco", new Uri("ms-appx:///Assets/Tiles/floors/disco/pink.png"), true) },
            { "m2_3", new Tile("disco", new Uri("ms-appx:///Assets/Tiles/floors/disco/green.png"), true) },
            { "m2_4", new Tile("disco", new Uri("ms-appx:///Assets/Tiles/floors/disco/cyan.png"), true) },
            { "m2_5", new Tile("disco", new Uri("ms-appx:///Assets/Tiles/floors/disco/blue.png"), true) },
            { "m3", new Tile("disco", new Uri("ms-appx:///Assets/Tiles/floors/disco/blue.png"), true) },
            { "m3_1", new Tile("disco", new Uri("ms-appx:///Assets/Tiles/floors/disco/cyan.png"), true) },
            { "m3_2", new Tile("disco", new Uri("ms-appx:///Assets/Tiles/floors/disco/yellow.png"), true) },
            { "m3_3", new Tile("disco", new Uri("ms-appx:///Assets/Tiles/floors/disco/cyan.png"), true) },
            { "m3_4", new Tile("disco", new Uri("ms-appx:///Assets/Tiles/floors/disco/green.png"), true) },
            { "m3_5", new Tile("disco", new Uri("ms-appx:///Assets/Tiles/floors/disco/blue.png"), true) },
            { "m4", new Tile("disco", new Uri("ms-appx:///Assets/Tiles/floors/disco/blue.png"), true) },
            { "m4_1", new Tile("disco", new Uri("ms-appx:///Assets/Tiles/floors/disco/green.png"), true) },
            { "m4_2", new Tile("disco", new Uri("ms-appx:///Assets/Tiles/floors/disco/pink.png"), true) },
            { "m4_3", new Tile("disco", new Uri("ms-appx:///Assets/Tiles/floors/disco/blue.png"), true) },
            { "m4_4", new Tile("disco", new Uri("ms-appx:///Assets/Tiles/floors/disco/cyan.png"), true) },
            { "m4_5", new Tile("disco", new Uri("ms-appx:///Assets/Tiles/floors/disco/yellow.png"), true) },
            { "m5", new Tile("disco", new Uri("ms-appx:///Assets/Tiles/floors/disco/blue.png"), true) },
            { "m5_1", new Tile("disco", new Uri("ms-appx:///Assets/Tiles/floors/disco/pink.png"), true) },
            { "m5_2", new Tile("disco", new Uri("ms-appx:///Assets/Tiles/floors/disco/green.png"), true) },
            { "m5_3", new Tile("disco", new Uri("ms-appx:///Assets/Tiles/floors/disco/cyan.png"), true) },
            { "m5_4", new Tile("disco", new Uri("ms-appx:///Assets/Tiles/floors/disco/yellow.png"), true) },
            { "m5_5", new Tile("disco", new Uri("ms-appx:///Assets/Tiles/floors/disco/blue.png"), true) },
            { "n", new Tile("flower1", new Uri("ms-appx:///Assets/Tiles/floors/flowers/flower_1.png"), true) },
            { "o", new Tile("flower2", new Uri("ms-appx:///Assets/Tiles/floors/flowers/flower_2.png"), true) },
            { "p", new Tile("flower3", new Uri("ms-appx:///Assets/Tiles/floors/flowers/flower_3.png"), true) },
            { "q", new Tile("flower4", new Uri("ms-appx:///Assets/Tiles/floors/flowers/flower_4.png"), true ) },
            { "r", new Tile("flower5", new Uri("ms-appx:///Assets/Tiles/floors/flowers/flower_5.png"), true ) },
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
            { "E", new Tile("turn0", new Uri("ms-appx:///Assets/Tiles/paths/turn/0.png"), true ) },
            { "F", new Tile("turn90", new Uri("ms-appx:///Assets/Tiles/paths/turn/90.png"), true ) },
            { "G", new Tile("turn180", new Uri("ms-appx:///Assets/Tiles/paths/turn/180.png"), true) },
            { "H", new Tile("turn270", new Uri("ms-appx:///Assets/Tiles/paths/turn/270.png"), true) },
            { "I", new Tile("wallS0", new Uri("ms-appx:///Assets/Tiles/walls/straight/0.png")) },
            { "J", new Tile("wallS90", new Uri("ms-appx:///Assets/Tiles/walls/straight/90.png")) },
            { "K", new Tile("wallS180", new Uri("ms-appx:///Assets/Tiles/walls/straight/180.png")) },
            { "L", new Tile("wallS270", new Uri("ms-appx:///Assets/Tiles/walls/straight/270.png")) },
            { "M", new Tile("torch0", new Uri("ms-appx:///Assets/Tiles/walls/torch/0/1.png")) },
            { "M_1", new Tile("torch0", new Uri("ms-appx:///Assets/Tiles/walls/torch/0/1.png")) },
            { "M_2", new Tile("torch0", new Uri("ms-appx:///Assets/Tiles/walls/torch/0/2.png")) },
            { "M_3", new Tile("torch0", new Uri("ms-appx:///Assets/Tiles/walls/torch/0/3.png")) },
            { "M_4", new Tile("torch0", new Uri("ms-appx:///Assets/Tiles/walls/torch/0/4.png")) },
            { "N", new Tile("torch90", new Uri("ms-appx:///Assets/Tiles/walls/torch/90/1.png")) },
            { "N_1", new Tile("torch90", new Uri("ms-appx:///Assets/Tiles/walls/torch/90/1.png")) },
            { "N_2", new Tile("torch90", new Uri("ms-appx:///Assets/Tiles/walls/torch/90/2.png")) },
            { "N_3", new Tile("torch90", new Uri("ms-appx:///Assets/Tiles/walls/torch/90/3.png")) },
            { "N_4", new Tile("torch90", new Uri("ms-appx:///Assets/Tiles/walls/torch/90/4.png")) },
            { "O", new Tile("torch180", new Uri("ms-appx:///Assets/Tiles/walls/torch/180/1.png")) },
            { "O_1", new Tile("torch180", new Uri("ms-appx:///Assets/Tiles/walls/torch/180/1.png")) },
            { "O_2", new Tile("torch180", new Uri("ms-appx:///Assets/Tiles/walls/torch/180/2.png")) },
            { "O_3", new Tile("torch180", new Uri("ms-appx:///Assets/Tiles/walls/torch/180/3.png")) },
            { "O_4", new Tile("torch180", new Uri("ms-appx:///Assets/Tiles/walls/torch/180/4.png")) },
            { "P", new Tile("torch270", new Uri("ms-appx:///Assets/Tiles/walls/torch/270/1.png")) },
            { "P_1", new Tile("torch270", new Uri("ms-appx:///Assets/Tiles/walls/torch/270/1.png")) },
            { "P_2", new Tile("torch270", new Uri("ms-appx:///Assets/Tiles/walls/torch/270/2.png")) },
            { "P_3", new Tile("torch270", new Uri("ms-appx:///Assets/Tiles/walls/torch/270/3.png")) },
            { "P_4", new Tile("torch270", new Uri("ms-appx:///Assets/Tiles/walls/torch/270/4.png")) },
            { "Q", new Tile("wallT0", new Uri("ms-appx:///Assets/Tiles/walls/turn/0.png")) },
            { "R", new Tile("wallT90", new Uri("ms-appx:///Assets/Tiles/walls/turn/90.png")) },
            { "S", new Tile("wallT180", new Uri("ms-appx:///Assets/Tiles/walls/turn/180.png")) },
            { "T", new Tile("wallT270", new Uri("ms-appx:///Assets/Tiles/walls/turn/270.png")) },
            { "U", new Tile("crate", new Uri("ms-appx:///Assets/Tiles/crate.png")) },
            { "V", new Tile("fence", new Uri("ms-appx:///Assets/Tiles/fence.png")) },
            { "W", new Tile("gas", new Uri("ms-appx:///Assets/Tiles/gas.png")) },
            { "X", new Tile("rubbishbin", new Uri("ms-appx:///Assets/Tiles/rubbishbin.png") ) },
            { "Y", new Tile("rubbishbin", new Uri("ms-appx:///Assets/Tiles/rubbishbin.png") ) },
            { "Z", new Tile("table", new Uri("ms-appx:///Assets/Tiles/table.png") ) },
            { "1", new Tile("tree", new Uri("ms-appx:///Assets/Tiles/tree.png")) },
            { "2", new Tile("water", new Uri("ms-appx:///Assets/Tiles/water/1.png")) },
            { "2_1", new Tile("water", new Uri("ms-appx:///Assets/Tiles/water/1.png")) },
            { "2_2", new Tile("water", new Uri("ms-appx:///Assets/Tiles/water/2.png")) },
            { "2_3", new Tile("water", new Uri("ms-appx:///Assets/Tiles/water/3.png")) },
            { "2_4", new Tile("water", new Uri("ms-appx:///Assets/Tiles/water/4.png")) },
            { "3", new Tile("watersand", new Uri("ms-appx:///Assets/Tiles/water/water_sand.png"), true) },
            { "4", new Tile("barfloorblack", new Uri("ms-appx:///Assets/Tiles/floors/bar/black.png"), true) },
            { "5", new Tile("barfloorwhite", new Uri("ms-appx:///Assets/Tiles/floors/bar/white.png"), true) },
            { "6", new Tile("barstraight0", new Uri("ms-appx:///Assets/Tiles/bar/straight/0.png")) },
            { "7", new Tile("barstraight90", new Uri("ms-appx:///Assets/Tiles/bar/straight/90.png")) },
            { "8", new Tile("barstraight180", new Uri("ms-appx:///Assets/Tiles/bar/straight/180.png")) },
            { "9", new Tile("barturn0", new Uri("ms-appx:///Assets/Tiles/bar/turn/0.png")) },
            { "0", new Tile("barturn90", new Uri("ms-appx:///Assets/Tiles/bar/turn/90.png")) },
            { "!", new Tile("seatstraight0", new Uri("ms-appx:///Assets/Tiles/seat/straight/0.png")) },
            { "@", new Tile("seatstraight180", new Uri("ms-appx:///Assets/Tiles/seat/straight/180.png")) },
            { "#", new Tile("seatturn0", new Uri("ms-appx:///Assets/Tiles/seat/turn/0.png")) },
            { "$", new Tile("seatturn90", new Uri("ms-appx:///Assets/Tiles/seat/turn/90.png")) },
            { "%", new Tile("seatturn180", new Uri("ms-appx:///Assets/Tiles/seat/turn/180.png")) },
            { "^", new Tile("seatturn270", new Uri("ms-appx:///Assets/Tiles/seat/turn/270.png")) },
            { "&", new Tile("wallinset0", new Uri("ms-appx:///Assets/Tiles/walls/inset/0.png")) },
            { "*", new Tile("wallinset90", new Uri("ms-appx:///Assets/Tiles/walls/inset/90.png")) },
            { "(", new Tile("wallinset180", new Uri("ms-appx:///Assets/Tiles/walls/inset/180.png")) },
            { ")", new Tile("wallinset270", new Uri("ms-appx:///Assets/Tiles/walls/inset/270.png")) }
        };
        // Dictionary with all Tile generation

        public static Tile getTile(String key)
        {
            Tile tile = tiles[key];
            // Get the tile on the choosen index
            return tile;
            // Return the tile
        }


        public String getTileType(float x, float y, String [,] gekozenLevel)
        {
            Tile tile = getPlayerTile(x, y, gekozenLevel);
            // Get the tile on the choosen player location
            if(tile == null)
            {
                return null;
                // No tile, return null
            }
            return tile.TileType;
            // Return the tile type
        }

        /// <summary>
        /// Gets the desired tile according to the given coords
        /// </summary>
        /// <param name="x">The x coord of the tile</param>
        /// <param name="y">The y coord of the tile</param>
        /// <param name="gekozenLevel">The current level</param>
        /// <returns>The desired tile</returns>
        public Tile getPlayerTile(float x, float y, String[,] gekozenLevel)
        {
            double x_round = Math.Floor((x) / 32);
            double y_round = Math.Floor((y) / 32);
            // Rounded x and y, devided by the sprite size (32)

            double xPos = x_round * 32;
            double yPos = y_round * 32;
            double xPos2 = xPos + 32;
            double yPos2 = yPos + 32;
            // x and y locations

            if(y_round >= gekozenLevel.GetLength(0) || x_round >= gekozenLevel.GetLength(1)) // If its in the array
            {
                return null;
            }

            String tile_Type = gekozenLevel[(int)y_round, (int)x_round].ToString();
            // Get the tile type
            Tile tile = getTile(tile_Type);
            // Get the type information of the type

            return tile;
            // Return the tile
        }

        //dungeon
        public static String[,] levelOne = { // 14x14   
            {"Q","I","I","I","I","I","I","I","I","I","I","I","I","R"},
            {"L","w","w","w","w","w","w","w","w","w","w","w","w","J"},
            {"L","w","w","w","w","w","w","w","w","w","w","w","w","J"},
            {"L","w","w","w","w","w","w","w","w","w","w","w","w","J"},
            {"L","w","w","w","w","w","w","w","w","w","w","w","w","J"},
            {"L","w","w","w","w","w","w","w","w","w","w","w","w","J"},
            {"L","w","w","w","w","w","w","w","w","w","w","w","w","J"},
            {"L","w","w","w","w","w","w","w","w","w","w","w","w","J"},
            {"L","w","w","w","w","w","w","w","w","w","w","w","w","J"},
            {"L","w","w","w","w","w","w","w","w","w","w","w","w","J"},
            {"L","w","w","w","w","w","w","w","w","w","w","w","w","J"},
            {"L","w","w","w","w","w","w","w","w","w","w","w","w","J"},
            {"L","w","w","w","w","w","w","w","w","w","w","w","w","J"},
            {"T","K","K","K","K","K","K","K","K","K","K","K","K","S"},
        };
        // Tile information of the level
       
        //grassy planes
        public static String[,] levelTwo =  { // 35 x 24
            {"Q","I","I","I","I","I","I","I","I","I","I","I","I","I","I","I","I","I","I","I","I","I","I","I","I","I","I","I","I","I","I","I","I","I","R"},
            {"L","y","E","s","s","s","s","s","s","s","s","s","s","s","s","s","2","2","2","2","s","s","s","s","s","n","s","s","s","s","s","n","s","s","J"},
            {"L","s","z","s","s","s","s","s","s","s","s","s","n","s","s","s","2","2","2","2","2","s","s","s","s","s","s","s","s","s","s","s","s","s","J"},
            {"L","s","z","n","s","H","y","E","s","s","s","s","s","s","s","s","s","2","2","2","2","2","s","n","s","s","s","s","s","s","s","s","s","s","J"},
            {"L","s","D","y","y","F","s","G","y","E","s","s","s","s","s","s","s","2","2","2","2","2","s","s","s","s","s","s","s","s","s","s","s","s","J"},
            {"L","H","F","s","s","s","s","s","s","G","y","y","y","A","y","y","y","y","a","a","a","a","A","y","y","E","s","n","s","s","s","s","s","n","J"},
            {"L","z","s","s","s","s","s","s","1","1","s","s","s","z","s","s","s","s","2","2","2","2","z","s","1","G","y","y","E","s","s","s","s","s","J"},
            {"L","G","y","y","E","s","s","1","1","1","s","s","s","z","s","s","s","s","2","2","2","2","G","1","1","1","s","s","z","s","s","s","s","s","J"},
            {"L","s","s","s","z","s","s","s","1","s","s","s","s","G","E","s","s","s","2","2","2","2","2","z","1","1","s","s","z","s","s","H","y","y","J"},
            {"L","s","H","y","F","s","s","s","s","s","s","s","n","s","z","s","s","s","s","2","2","2","2","G","y","y","y","y","x","y","y","F","s","s","J"},
            {"L","s","z","s","s","s","s","s","s","s","s","s","s","s","G","y","y","E","s","2","2","2","2","2","s","s","s","s","z","s","s","s","s","s","J"},
            {"L","s","z","s","s","s","s","s","n","s","s","s","s","s","s","n","s","z","s","s","2","2","2","2","s","s","s","H","F","s","s","1","s","s","J"},
            {"L","s","G","E","s","s","2","2","2","2","s","s","s","H","y","y","E","z","s","2","2","2","2","2","s","n","H","F","s","s","1","1","1","s","J"},
            {"L","s","s","z","s","2","2","2","2","2","2","2","s","z","s","s","G","F","s","s","2","2","2","2","2","s","z","s","s","s","1","1","1","s","J"},
            {"L","s","s","z","s","2","2","2","2","2","2","2","s","z","s","s","s","s","n","s","2","2","2","2","2","H","F","s","s","s","s","1","s","s","J"},
            {"L","s","s","G","E","s","2","2","2","2","2","2","s","G","A","y","y","E","s","s","s","2","2","2","2","z","s","s","s","s","s","s","s","s","J"},
            {"L","s","s","s","z","s","2","2","2","2","2","2","s","s","z","s","s","G","y","y","y","a","a","a","a","F","s","s","s","s","s","s","s","s","J"},
            {"L","s","s","s","z","s","n","2","2","2","2","1","s","s","z","s","s","s","s","s","s","2","2","2","2","s","1","s","s","s","s","s","s","s","J"},
            {"L","s","s","s","z","s","s","2","2","2","1","1","1","s","G","y","y","E","s","s","s","2","2","2","2","1","1","1","s","s","s","s","s","s","J"},
            {"L","s","s","s","G","y","E","s","s","s","1","1","s","s","s","s","s","z","s","s","s","2","2","2","2","1","1","s","s","s","s","n","s","s","J"},
            {"L","s","s","s","s","s","G","y","y","y","E","s","s","s","s","s","s","z","s","s","s","2","2","2","2","2","s","s","s","s","s","s","s","s","J"},
            {"L","s","s","s","s","s","s","s","s","s","G","y","y","y","y","y","y","F","s","s","s","2","2","2","2","2","s","s","s","s","s","s","s","s","J"},
            {"L","s","s","s","s","s","s","s","s","s","s","s","s","s","s","s","s","s","s","s","s","s","2","2","2","2","s","s","s","s","s","s","s","s","J"},
            {"T","K","K","K","K","K","K","K","K","K","K","K","K","K","K","K","K","K","K","K","K","K","K","K","K","K","K","K","K","K","K","K","K","K","S"}
        };
        // Tile information of the level

        public static String[,] levelThree =  { //20x25
            {"H","H","H","H","H","H","H","Q","I","I","I","I","I","I","I","I","I","I","I","I","I","I","I","I","R"},
            {"H","H","H","H","H","H","H","L","w","w","w","w","w","w","w","w","w","w","U","w","U","w","w","w","J"},
            {"H","H","H","H","H","H","H","L","w","w","w","w","w","w","w","w","w","w","U","w","U","w","w","w","J"},
            {"H","H","H","H","H","H","H","L","w","w","w","w","w","w","w","w","w","w","w","w","w","w","w","w","J"},
            {"H","H","H","H","H","H","H","L","w","w","w","w","w","w","w","w","w","w","w","w","w","w","w","w","J"},
            {"H","H","H","H","H","H","H","L","w","w","w","w","w","w","w","w","w","w","w","w","w","w","w","w","J"},
            {"Q","I","I","I","I","I","I","S","w","w","w","w","w","w","w","w","w","w","w","w","w","w","w","w","J"},
            {"L","w","w","w","w","w","w","w","w","w","w","w","w","w","w","w","w","w","w","w","w","w","w","w","J"},
            {"L","w","w","w","w","w","w","w","w","w","w","w","w","w","w","w","w","w","w","w","w","w","w","w","J"},
            {"L","w","w","w","w","w","w","w","w","w","w","U","U","U","U","w","w","w","w","w","w","w","w","w","J"},
            {"L","w","w","w","w","w","w","w","w","w","w","U","w","w","w","w","w","w","w","w","w","w","w","w","J"},
            {"L","w","w","w","w","w","w","w","w","w","w","U","w","w","w","w","w","w","w","w","w","w","w","w","J"},
            {"L","w","w","w","w","w","w","w","w","w","w","U","w","w","w","w","w","w","w","w","w","w","w","w","J"},
            {"L","U","w","w","w","w","w","w","w","w","w","w","w","w","w","w","w","w","w","w","w","w","w","w","J"},
            {"L","w","w","w","w","w","w","w","w","w","w","w","w","w","w","w","w","w","w","w","w","w","w","U","J"},
            {"L","U","w","w","w","w","w","w","w","w","w","w","w","U","w","w","w","w","w","w","w","U","w","w","J"},
            {"L","w","w","w","w","w","w","w","w","w","w","w","w","w","w","w","w","w","w","w","w","U","w","w","J"},
            {"L","U","w","w","w","w","w","w","w","w","w","w","w","w","w","w","w","w","w","w","w","U","w","w","J"},
            {"T","K","K","K","K","K","K","K","K","K","K","K","K","K","K","K","K","K","K","K","K","K","K","K","S"},
        };
        // Tile information of the level

        public static String[,] levelFour = { // 26 x 26
            {"Q","I","I","I","I","I","I","I","I","I","I","I","I","I","I","I","I","I","I","I","I","I","R","H","H","H"},
            {"L","U","U","w","w","w","w","w","w","w","w","w","w","w","w","w","w","w","w","w","w","w","J","H","H","H"},
            {"L","U","w","w","w","w","w","w","w","w","w","w","w","w","w","w","w","w","w","w","w","w","J","H","H","H"},
            {"L","w","w","w","w","w","w","w","w","w","w","w","w","w","w","w","w","w","w","w","w","w","J","H","H","H"},
            {"L","w","w","w","w","w","w","w","w","w","w","w","w","w","w","w","w","w","w","w","w","w",")","I","I","R"},
            {"L","w","w","w","w","w","w","w","w","w","w","w","w","w","w","w","w","w","w","w","w","w","w","w","w","J"},
            {"T","K","K","K","*","w","w","w","w","w","&","K","*","U","U","w","U","w","w","w","w","w","w","w","w","J"},
            {"H","H","H","H","L","w","w","w","w","w","J","H","L","w","w","w","U","w","w","w","w","w","w","w","w","J"},
            {"Q","I","I","I","(","w","w","w","w","w",")","I","(","U","U","U","U","w","w","w","w","w","w","w","w","J"},
            {"L","w","U","w","w","w","w","w","w","w","w","w","w","w","w","w","w","w","w","w","w","w","w","w","w","J"},
            {"L","w","U","w","w","w","w","w","w","w","w","w","w","w","w","w","w","w","w","w","w","w","w","w","w","J"},
            {"L","w","U","w","w","w","w","w","U","w","w","w","w","w","w","U","w","w","w","w","w","w","w","w","w","J"},
            {"L","w","w","w","w","w","w","w","w","U","w","w","w","w","w","&","K","K","*","w","w","w","w","w","w","J"},
            {"L","w","U","w","w","w","w","w","w","w","w","w","w","w","w","J","H","H","L","w","w","w","w","w","w","J"},
            {"L","w","U","w","w","w","w","w","w","w","w","w","w","w","w","J","H","H","L","w","w","w","w","w","w","J"},
            {"L","U","U","w","w","w","w","w","w","w","w","w","w","w","w","J","H","H","L","w","w","w","w","w","w","J"},
            {"L","w","w","w","w","w","w","w","w","w","w","w","w","w","w","J","H","H","L","w","w","w","w","w","w","J"},
            {"L","w","w","w","w","w","w","w","w","w","w","w","w","w","w","J","H","H","L","w","w","w","&","K","K","S"},
            {"L","w","w","w","w","w","w","w","w","w","w","w","w","w","w",")","I","I","(","w","w","w",")","I","I","R"},
            {"L","w","w","w","w","w","w","w","w","w","w","w","w","w","w","w","w","w","w","w","w","w","w","w","w","J"},
            {"L","w","w","w","w","w","w","w","w","w","w","w","w","w","w","w","w","w","w","w","w","w","w","w","w","J"},
            {"L","w","w","w","w","w","w","w","w","w","w","w","w","w","w","w","w","w","w","w","w","w","w","w","w","J"},
            {"T","K","K","*","w","w","w","w","w","w","w","w","w","w","w","U","w","w","w","w","w","w","w","w","w","J"},
            {"H","H","H","L","w","w","w","w","w","w","&","K","K","K","K","*","w","w","w","w","w","w","w","w","w","J"},
            {"H","H","H","L","w","w","w","w","w","w","J","H","H","H","H","L","w","w","w","w","w","w","w","w","w","J"},
            {"H","H","H","T","K","K","K","K","K","K","S","H","H","H","H","T","K","K","K","K","K","K","K","K","K","S"}
        };
        // Tile information of the level

        //Disco YEAH
        public static String[,] levelFive = { // 39 x 21
            {"Q","I","I","I","I","I","I","I","I","I","I","I","I","M","I","I","I","I","I","I","I","I","I","I","I","I","M","I","I","I","I","I","I","I","I","M","I","I","I","I","R"},
            {"L","m","8","4","5","4","5","4","5","4","6","m","m","m","#","!","$","m","#","!","$","m","#","!","$","m","#","!","$","m","m","m","m","m","w","w","w","w","w","w","J"},
            {"L","m2","8","5","4","5","4","5","4","5","6","m","m","m3","m4","m2","m5","m3","m5","m","m","m","m4","m5","m2","m4","m4","m3","m","m3","m3","w","w","w","w","w","w","w","w","w","J"},
            {"L","m3","0","7","7","7","7","7","7","7","9","m3","m","m3","m5","m3","m2","m2","m5","m","m4","m5","m3","m4","m4","m3","m","m5","m4","m4","w","w","w","w","w","w","w","w","w","w","J"},
            {"L","m4","m5","m2","m4","m4","m3","m4","m5","m3","m4","m4","m3","m4","m5","m4","m4","m4","m3","m4","m5","m5","m4","m4","m3","m2","m5","m","m3","w","w","w","w","w","w","w","w","w","w","w","J"},
            {"L","m5","m3","m5","m2","m2","m2","m","m","m4","m5","m2","m4","m4","m3","m3","m2","m3","m5","m3","m5","m2","m4","m2","m4","m5","m","m4","w","w","w","w","w","w","w","w","w","w","w","w","J"},
            {"L","m","m4","m2","m4","m2","m4","m4","m5","m5","m4","m4","m3","m3","m4","m5","m3","m4","m4","m3","m4","m5","m4","m4","m4","m3","m4","w","w","w","w","w","w","w","w","w","w","w","w","w","J"},
            {"L","m2","m5","m4","m5","m2","m5","m2","m5","m2","m3","m2","m2","m5","m3","m2","m3","m4","m5","m4","m5","m2","m4","m4","m2","m5","m","w","w","w","w","w","w","w","w","w","w","w","w","w","J"},
            {"L","m3","m5","m2","m5","m3","m2","m","m5","m","m4","m5","m2","m4","m4","m3","m","m2","m5","m2","m3","m2","m","m5","m4","m3","w","w","w","w","w","w","w","w","w","w","w","w","w","w","J"},
            {"L","m4","m3","m3","m4","m4","m3","m4","m3","m3","m4","m5","m3","m4","m4","m3","m4","m5","m4","m4","m4","m3","m4","m5","m2","m","w","w","w","w","w","w","w","w","w","w","w","w","w","w","J"},
            {"L","m5","m2","m4","m5","m2","m2","m5","m4","m2","m","m3","m4","m","m2","m4","m3","m5","m","m3","m","m4","m5","m2","m","m5","w","w","w","w","w","w","w","w","w","w","w","w","w","w","J"},
            {"L","m","m2","m2","m2","m2","m2","m3","m2","m2","m5","m3","m2","m4","m","m5","m4","m5","m2","m4","m4","m2","m5","m2","m4","m","w","w","w","w","w","w","w","w","w","w","w","w","w","w","J"},
            {"L","m2","m3","m2","m2","m3","m4","m4","m2","m4","m5","m2","m3","m4","m2","m","m","m3","m","m","m2","m3","m4","m5","m4","m","w","w","w","w","w","w","w","w","w","w","w","w","w","w","J"},
            {"L","m3","m4","m2","m2","m5","m2","m3","m2","m2","m5","m3","m2","m3","m4","m5","m4","m5","m2","m4","m4","m3","m","m2","m2","m4","w","w","w","w","w","w","w","w","w","w","w","w","w","w","J"},
            {"L","m4","m2","m3","m5","m2","m4","m","m","m","m","m","m","m","m","m","m","m5","m","m","m","m","m","m","m","m","w","w","w","w","w","w","w","w","w","w","w","w","w","w","J"},
            {"L","m5","m4","m4","m3","m3","m5","m","m2","m3","m4","m5","m2","m","m4","m5","m2","m4","m3","m2","m4","m5","m4","m3","m2","m3","m","w","w","w","w","w","w","w","w","w","w","w","w","w","J"},
            {"L","m","m2","m2","m2","m5","m2","m3","m4","m","m5","m4","m3","m2","m","m2","m4","m3","m5","m4","m","m2","m3","m5","m4","m2","m3","w","w","w","w","w","w","w","w","w","w","w","w","w","J"},
            {"L","m2","m2","m2","m2","m2","m3","m2","m3","m4","m5","m","m5","m4","m3","m2","m","m2","m3","m4","m5","m","m2","m5","m3","m4","m3","m5","w","w","w","w","w","w","w","w","w","w","w","w","J"},
            {"L","m3","m2","m3","m2","m2","m2","m","m5","m4","m2","m2","m2","m4","m4","m2","m3","m","m4","m3","m5","m4","m2","m","m3","m2","m5","m4","m3","w","w","w","w","w","w","w","w","w","w","w","J"},
            {"L","m4","m3","m5","m3","m3","m2","m2","m4","m3","m5","m3","m3","m2","m","m5","m4","m3","m2","m","m2","m3","m4","m5","m3","m4","m2","m3","m2","m5","w","w","w","w","w","w","w","w","w","w","J"},
            {"L","m5","m4","m2","m2","m2","m4","m","m5","m4","m2","m2","m2","m4","m2","m5","m5","m3","m2","m3","m4","m2","m3","m4","m5","m4","m2","m5","m4","m2","m3","w","w","w","w","w","w","w","w","w","J"},
            {"L","m","^","@","%","m","^","@","%","m","^","@","%","m","^","@","%","m","^","@","%","m","^","@","%","m","^","@","%","m","m","m","m","m","w","w","w","w","w","w","J"},
            {"T","K","K","K","K","K","K","K","K","K","K","K","K","K","K","K","K","K","K","K","K","K","K","K","K","K","K","K","K","K","K","K","K","K","K","K","K","K","K","K","S"}
        };
        // Tile information of the level


        public static String[,] levelSix = { // 36x25
            {"Q","I","I","I","I","I","I","I","R","H","H","H","H","H","H","H","H","H","H","H","H","H","Q","I","I","I","I","I","I","I","I","I","I","I","I","R"},
            {"L","w","w","w","w","w","w","w","J","H","H","H","H","H","H","H","H","H","H","H","H","H","L","w","w","w","w","w","w","w","w","w","w","w","w","J"},
            {"L","w","w","w","w","w","w","w","J","H","H","H","H","H","H","H","H","H","H","H","H","H","L","w","w","w","w","w","w","w","w","w","w","w","w","J"},
            {"L","w","w","w","w","w","w","U","J","H","H","H","H","H","H","H","H","H","H","H","H","H","L","w","w","w","w","w","w","w","w","w","w","w","w","J"},
            {"L","w","w","w","w","U","U","U","J","H","H","H","H","H","H","H","H","H","H","H","H","H","L","w","w","w","w","w","w","w","U","U","w","w","w","J"},
            {"L","w","w","w","w","w","w","w","J","H","H","H","H","H","H","H","H","H","H","H","H","H","L","w","w","w","w","w","w","U","U","U","w","w","w","J"},
            {"L","w","w","w","w","w","w","w",")","I","I","I","I","I","I","I","I","I","I","I","I","I","(","w","w","w","w","w","w","w","U","w","w","w","w","J"},
            {"L","w","w","w","w","w","w","w","w","w","w","w","w","U","w","w","w","w","w","U","U","w","w","w","w","w","w","w","w","w","w","w","w","w","w","J"},
            {"L","w","w","w","w","w","w","w","w","w","w","w","w","w","w","w","w","w","w","w","w","w","w","w","w","w","w","w","w","w","w","w","w","w","w","J"},
            {"L","w","w","w","w","w","w","w","w","w","w","w","w","w","w","w","w","w","w","w","w","w","w","w","w","w","w","w","w","w","w","w","w","w","w","J"},
            {"L","w","w","w","w","w","w","w","w","w","w","w","U","w","w","w","w","w","w","w","w","w","w","w","w","w","w","w","w","w","w","w","w","w","w","J"},
            {"L","w","w","w","w","w","w","w","&","K","K","K","*","w","w","w","w","w","&","K","K","K","*","w","w","w","w","w","w","w","w","w","w","w","w","J"},
            {"L","w","w","w","w","w","w","U","J","H","H","H","T","K","K","K","K","K","S","H","H","H","L","w","w","w","w","w","U","U","w","w","w","w","w","J"},
            {"L","w","w","w","w","w","U","U","J","H","H","H","H","H","H","H","H","H","H","H","H","H","L","w","w","w","w","w","U","U","U","w","w","w","w","J"},
            {"L","w","w","w","w","w","w","U","J","H","H","H","H","H","H","H","H","H","H","H","H","H","L","w","w","w","w","w","U","U","U","U","w","w","w","J"},
            {"L","w","w","w","w","w","w","U","J","H","H","H","H","H","H","H","H","H","H","H","H","H","L","w","w","w","w","w","w","U","w","w","w","w","w","J"},
            {"L","w","w","w","w","w","w","w","J","H","H","H","H","H","H","H","H","H","H","H","H","H","L","w","w","w","w","w","w","w","w","w","w","w","w","J"},
            {"L","w","w","w","w","w","w","w","J","H","H","H","H","H","H","H","H","H","H","H","H","H","L","w","w","w","w","w","w","w","w","w","w","w","w","J"},
            {"L","w","w","w","w","w","w","w","J","H","H","H","H","H","H","H","H","H","H","H","H","H","L","w","w","w","U","w","w","w","w","w","w","w","w","J"},
            {"L","w","w","w","w","w","w","w",")","I","I","I","I","I","I","I","I","I","I","I","I","I","(","w","w","U","U","U","w","w","w","w","U","w","w","J"},
            {"L","w","w","w","w","w","w","w","w","U","U","w","w","w","w","w","w","w","w","w","w","w","w","w","w","U","U","U","w","w","w","U","U","w","w","J"},
            {"L","w","U","U","w","w","w","w","w","w","w","w","w","w","w","w","w","w","w","w","w","w","w","w","w","w","w","w","w","w","w","w","w","w","w","J"},
            {"L","w","U","U","U","w","w","w","w","w","w","w","w","w","w","w","w","w","w","w","w","w","w","w","w","w","w","w","w","w","w","w","w","w","w","J"},
            {"L","w","w","w","w","w","w","w","w","w","w","w","U","w","w","w","w","w","w","w","w","w","w","w","w","w","w","w","w","w","w","w","w","w","w","J"},
            {"T","K","K","K","K","K","K","K","K","K","K","K","K","K","K","K","K","K","K","K","K","K","K","K","K","K","K","K","K","K","K","K","K","K","K","S"}
        };
        // Tile information of the level

        public static String[,] testLevel = {
            {"Q","M","M","M","I","I","I","I","I","I","I","I","I","I","I","R"},
            {"L","m","m2","m3","m4","m5","n","o","p","q","r","2","w","w","w","N"},
            {"L","m5","m4","m3","m2","m","r","q","p","o","n","2","w","w","w","N"},
            {"L","m","m2","m3","m4","m5","n","o","p","q","r","2","w","w","w","N"},
            {"P","m5","m4","m3","m2","m","w","w","w","w","w","w","w","w","w","N"},
            {"P","s","t","u","v","w","w","w","w","w","w","w","w","w","w","J"},
            {"P","v","u","t","s","w","w","w","w","w","w","w","w","w","w","J"},
            {"L","s","t","u","v","w","w","w","w","w","w","w","w","w","w","J"},
            {"L","v","u","t","s","w","w","w","K","K","K","K","K","K","w","J"},
            {"L","2","2","2","2","w","w","w","w","w","w","w","w","w","w","J"},
            {"L","2","2","2","2","w","w","w","w","w","w","w","w","w","w","J"},
            {"L","2","2","2","2","w","w","w","w","w","w","w","w","w","w","J"},
            {"L","2","2","2","2","w","w","w","w","w","w","w","w","w","w","J"},
            {"T","K","K","O","O","O","K","K","K","K","K","K","K","K","K","S"}
        };
        // Tile information of the level

    }
}
