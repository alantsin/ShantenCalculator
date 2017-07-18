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
            int shantenCount;

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

            // With the pairs list, check for all Pon and Chi
            List<Tile> tempHand = CheckMelds(pairList, hand);

            // Finish with point calculation
            Console.WriteLine("Tsumo! 9 Gates, 48,000 all, 16,000 each");
            
        }

        public static List<Tile> CheckMelds(List<int[]> pairList, Tile[] hand)
        {
            // This list holds all melds
            List<Tile> tempHand = new List<Tile>();

            // Check for Pon
            pairList.ForEach(delegate (int[] eyes) {

                int eye1 = eyes[0];
                int eye2 = eyes[1];

                for (int i = 0; i < hand.Length; i++)
                {
                    if (i != eye1 || i != eye2)
                    {
                        for (int j = i + 1; j < hand.Length; j++)
                        {
                            if (hand[i].value.Equals(hand[j].value) && hand[i].type.Equals(hand[j].type))
                            {
                                for (int k = j + 1; k < hand.Length; k++)
                                {
                                    if (hand[j].value.Equals(hand[k].value) && hand[j].type.Equals(hand[k].type))
                                    {
                                        tempHand.Add(hand[i]);
                                        tempHand.Add(hand[j]);
                                        tempHand.Add(hand[k]);
                                    }
                                }
                            }
                        }
                    }
                }

            });

            // Check for Chi

            return tempHand;
        }

        // Draws a tile from the wall, for now the tile is manually coded in and not random
        public static Tile DrawTile()
        {
            Tile tile = new Tile(9, TileType.MAN);
            return tile;
        }

        // Checks the entire hand, returning an array of pair indices
        public static List<int[]> CheckPairs(Tile[] hand)
        {
            List<int[]> pairList = new List<int[]>();

            // Generate list of eye combinations
 
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

            // Remove duplicates
            List<int> tempIndex = new List<int>() ;
            for (int i = 0; i < pairList.Count; i++)
            {
                for (int j = i+1; j < pairList.Count; j++)
                {
                    if (hand[pairList.ElementAt(i)[0]].value.Equals(hand[pairList.ElementAt(j)[0]].value) &&
                        hand[pairList.ElementAt(i)[0]].type.Equals(hand[pairList.ElementAt(j)[0]].type))
                    {
                        if (!tempIndex.Contains(i))
                        {
                            tempIndex.Add(i);
                        }
                        
                    }
                }
            }

            for (int i = tempIndex.Count; i > 0; i--)
            {
                pairList.RemoveAt(i);
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
