using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShantenCalculator
{
    // Identifier for suit type of tile
    public enum TileType { MAN, SOU, PIN, HON }
    class Tile
    {
        // The value of the tile, from 1-9, or 1-7 for honor tiles, where 1-4 are East, South, West, North, and 5-7 are Haku, Hatsu, Chun
        public int value { get; }
        public TileType type { get; }
        // If a tile is a red Dora or not, either instantiated at the beginning of tile creation, or the tile became red by other means
        public Boolean red { get; set; }
        // If a tile is a component of Ryuuiisou
        public Boolean green { get; }


        public Tile(int value, TileType type)
        {
            this.value = value;

            this.type = type;
        }

        public String Print()
        {
            String t;

            switch (type)
            {
                case TileType.MAN:
                    t = "M";
                    break;
                case TileType.SOU:
                    t = "S";
                    break;
                case TileType.PIN:
                    t = "P";
                    break;
                default:
                    t = "H";
                    break;
            }

            return "[" + value + t + "] ";
        }
    }
}
