using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShantenCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            // Creates an initial hand, to be replaced with actual hand creation function
            Tile[] hand = Make9Gates();

            Console.WriteLine("Showing initial hand:");

            // Prints to console the initial hand
            for (int i = 0; i < 13; i++)
            {
                Console.Write(hand[i].Print());
            }

            Console.WriteLine("");

            Console.WriteLine("Press any key to draw...");

            Console.ReadKey();

            // Draws a tile
            hand[13] = DrawTile();

            Console.WriteLine("Showing new hand:");

            for (int i = 0; i < 14; i++)
            {
                Console.Write(hand[i].Print());
            }

            Console.WriteLine("");

            // Checks for Shanten, to be replaced
            CheckSame(hand[0], hand[13]);
            Console.WriteLine("Tsumo! 9 Gates, 48,000 all, 16,000 each");

        }

        // Makes a starting hand of 9-way wait of 9 gates and returns that hand, for testing purposes
        public static Tile[] Make9Gates()
        {
            Tile[] hand = new Tile[14];

            hand[0] = new Tile(1, TileType.MAN);

            hand[1] = new Tile(1, TileType.MAN);

            hand[2] = new Tile(1, TileType.MAN);

            hand[3] = new Tile(2, TileType.MAN);

            hand[4] = new Tile(3, TileType.MAN);

            hand[5] = new Tile(4, TileType.MAN);

            hand[6] = new Tile(5, TileType.MAN);

            hand[7] = new Tile(6, TileType.MAN);

            hand[8] = new Tile(7, TileType.MAN);

            hand[9] = new Tile(8, TileType.MAN);

            hand[10] = new Tile(9, TileType.MAN);

            hand[11] = new Tile(9, TileType.MAN);

            hand[12] = new Tile(9, TileType.MAN);

            return hand;
        }

        // Draws a tile from the wall, for now the tile is manually coded in and not random
        public static Tile DrawTile()
        {
            Tile tile = new Tile(9, TileType.MAN);
            return tile;
        }

        // Checks the entire hand, returning an array of tile pairs
        public static Tile[][] CheckPairs(Tile[] hand)
        {
            Tile[][] eyes = new Tile[7][];
            return eyes;
        }

        // Check if two tiles are the same
        public static Boolean CheckSame(Tile tile1, Tile tile2)
        {
            if (tile1.value.Equals(tile2.value) && (tile1.type.Equals(tile2.type)))
            {
                return true;
            }

            return false;
        }
    }
}
