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
            // Creates an initial hand
            HandGenerator handGenerator = new HandGenerator();

            Console.WriteLine("Welcome to Monkey Mahjong! To begin, enter the type of hand");

            Tile[] hand = handGenerator.make(Console.ReadLine().ToLower());

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

            // Check for Shanten, work in progress
            // First create a list of all potentials pairs of eyes
            List<int[]> pairList = CheckPairs(hand);
            int numPairs = pairList.Count;
            Console.WriteLine(numPairs);

            // Finish with point calculation
            Console.WriteLine("Tsumo! 9 Gates, 48,000 all, 16,000 each");
            
        }

        // Draws a tile from the wall, for now the tile is manually coded in and not random
        public static Tile DrawTile()
        {
            Tile tile = new Tile(7, TileType.HON);
            return tile;
        }

        // Checks the entire hand, returning an array of pair indices
        public static List<int[]> CheckPairs(Tile[] hand)
        {
            List<int[]> pairList = new List<int[]>();
 
            for (int i = 0; i < hand.Length; i++)
            {
                for (int j = i+1; j < hand.Length; j++)
                {
                    if (CheckSame(hand[i], hand[j]))
                    {
                        pairList.Add(new int[] { i, j });
                    }
        
                }
            }

            return pairList;
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
