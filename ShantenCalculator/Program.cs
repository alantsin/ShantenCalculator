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

            Console.WriteLine("Draw what type of tile?");

            TileType type = (TileType) Enum.Parse(typeof(TileType), Console.ReadLine().ToUpper());

            Console.WriteLine("What value of " + type + "?");

            int value = Int32.Parse(Console.ReadLine());

            // Draws a tile
            DrawTile(hand, value, type);

            PrintTiles("Showing new hand:", hand);

            Console.WriteLine("");

            // Check for Shanten, work in progress
            // First remove all groups, pon and chi

            // This list holds all melds
            List<Tile> tempHand = new List<Tile>();

            // Indices of the meld
            List<int[]> tempIndexGroup = new List<int[]>();
            int pons = 0;
            int chis = 0;

            // Index of the particular tile
            List<int> tempIndex = new List<int>();

            // Check for Pon
            Boolean loopBreak = false;
            for (int i = 0; i < hand.Length; i++)
            {
                if (tempIndex.Contains(i))
                {
                    continue;
                }

                for (int j = i + 1; j < hand.Length; j++)
                {
                    if (loopBreak)
                    {
                        loopBreak = false;
                        break;
                    }

                    if (hand[i].value.Equals(hand[j].value) && hand[i].type.Equals(hand[j].type))
                    {
                        for (int k = j + 1; k < hand.Length; k++)
                        {
                            if (!tempIndex.Contains(k))
                            {
                                if (hand[j].value.Equals(hand[k].value) && hand[j].type.Equals(hand[k].type))
                                {
                                    tempIndexGroup.Add(new int[] { i, j, k });
                                    pons++;
                                    tempIndex.Add(i);
                                    tempIndex.Add(j);
                                    tempIndex.Add(k);
                                    loopBreak = true;
                                    break;
                                }
                            }
                        }
                    }
                }

            }

            Tile[] handAfterPon = new Tile[14 - (pons * 3)];

            // Temp index
            int x = 0;

            for (int i = 0; i < hand.Length; i++)
            {
                if (!tempIndex.Contains(i))
                {
                    handAfterPon[x] = hand[i];
                    x++;
                }
            }

            PrintTiles("Showing hand after removing pons:", handAfterPon);

            Console.WriteLine(pons + " pons");

            // Check for Chi

            loopBreak = false;
            for (int i = 0; i < handAfterPon.Length; i++)
            {
                if (tempIndex.Contains(i) || handAfterPon[i].type.Equals(TileType.HON))
                {
                    continue;
                }

                for (int j = i + 1; j < hand.Length; j++)
                {
                    if (loopBreak)
                    {
                        loopBreak = false;
                        break;
                    }

                    if (hand[i].value.Equals(hand[j].value - 1) && hand[i].type.Equals(hand[j].type))
                    {
                        for (int k = j + 1; k < hand.Length; k++)
                        {
                            if (!tempIndex.Contains(k))
                            {
                                if (hand[j].value.Equals(hand[k].value - 1) && hand[j].type.Equals(hand[k].type))
                                {
                                    tempIndexGroup.Add(new int[] { i, j, k });
                                    chis++;
                                    tempIndex.Add(i);
                                    tempIndex.Add(j);
                                    tempIndex.Add(k);
                                    loopBreak = true;
                                    break;
                                }
                            }
                        }
                    }
                }

            }

            Tile[] handAfterChi = new Tile[handAfterPon.Length - (chis * 3)];

            // Temp index
            x = 0;

            for (int i = 0; i < hand.Length; i++)
            {
                if (!tempIndex.Contains(i))
                {
                    handAfterChi[x] = hand[i];
                    x++;
                }
            }

            PrintTiles("Showing hand after removing chis:", handAfterChi);

            Console.WriteLine(chis + " chis");

            int numGroups = tempIndexGroup.Count;
            Console.WriteLine(numGroups + " groups total");

            // Next remove the pairs
            List<int[]> pairList = new List<int[]>();
            List<int> pairIndex = new List<int>();

            // Generate list of eye combinations

            for (int i = 0; i < handAfterChi.Length; i++)
            {
                for (int j = i + 1; j < handAfterChi.Length; j++)
                {
                    if (CheckSame(handAfterChi[i], handAfterChi[j]))
                    {
                        pairList.Add(new int[] { i, j });

                        if (!pairIndex.Contains(i))
                        {
                            pairIndex.Add(i);
                        }

                        if (!pairIndex.Contains(j))
                        {
                            pairIndex.Add(j);
                        }
                        i++;
                        j++;
                        break;
                    }

                }
            }

            // Make new hand after removing pairs

            Tile[] handAfterPairs = new Tile[handAfterChi.Length - (pairList.Count * 2)];

            x = 0;

            for (int i = 0; i < handAfterChi.Length; i++)
            {
                if (!pairIndex.Contains(i))
                {
                    handAfterPairs[x] = handAfterChi[i];
                    x++;
                }
            }

            int numPairs = pairList.Count;
            Console.WriteLine(numPairs + " pairs total");

            PrintTiles("Showing hand after removing pairs:", handAfterPairs);

            // Finally remove taatsu

            List<int[]> taatsuList = new List<int[]>();
            List<int> taatsuIndex = new List<int>();

            // Generate list of eye combinations

            for (int i = 0; i < handAfterPairs.Length; i++)
            {
                for (int j = i + 1; j < handAfterPairs.Length; j++)
                {
                    if (CheckRelated(handAfterPairs[i], handAfterPairs[j]))
                    {
                        taatsuList.Add(new int[] { i, j });

                        if (!taatsuIndex.Contains(i))
                        {
                            taatsuIndex.Add(i);
                        }

                        if (!taatsuIndex.Contains(j))
                        {
                            taatsuIndex.Add(j);
                        }
                        i++;
                        j++;
                        break;
                    }

                }
            }

            // Make new hand after removing pairs

            Tile[] handAfterTaatsu = new Tile[handAfterPairs.Length - (taatsuList.Count * 2)];

            x = 0;

            for (int i = 0; i < handAfterPairs.Length; i++)
            {
                if (!taatsuIndex.Contains(i))
                {
                    handAfterTaatsu[x] = handAfterPairs[i];
                    x++;
                }
            }

            int numTaatsu = taatsuList.Count;
            Console.WriteLine(numTaatsu + " taatsu total");

            PrintTiles("Showing hand after removing taatsu:", handAfterTaatsu);

            if (handAfterTaatsu.Length > 0)
            {
                shantenCount = ShantenCount(numGroups, numPairs, numTaatsu, handAfterTaatsu.Length);
            }

            else
            {
                shantenCount = -1;
            }

            Console.WriteLine("Shanten count: " + shantenCount);


            // Finish with point calculation
         //   Console.WriteLine("Tsumo! 9 Gates, 48,000 all, 16,000 each");
            
        }

        // Draws a tile from the wall, for now the tile is manually coded in and not random
        public static void DrawTile(Tile[] hand, int value, TileType type)
        {
            Tile tile = new Tile(value, type);
            hand[13] = tile;
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

        // Check if two tiles are related
        public static Boolean CheckRelated(Tile tile1, Tile tile2)
        {
            if (tile1.type.Equals(TileType.HON))
            {
                return false;
            }

            if (tile1.type.Equals(tile2.type))
            {
                if ((tile1.value.Equals(tile2.value - 1) || tile1.value.Equals(tile2.value - 2)) &&
                tile1.type.Equals(tile2.type))
                {
                    return true;
                }

            }

            return false;
        }

        // Function to print tiles on screen
        public static void PrintTiles(String text, Tile[] hand)
        {
            Console.WriteLine(text);

            // Prints to console the initial hand
            for (int i = 0; i < hand.Length; i++)
            {
                Console.Write(hand[i].Print());
            }

            Console.WriteLine("");
        }

        // Calculate Shanten
        public static int ShantenCount(int groups, int pairs, int taatsu, int handSize)
        {

            int part1 = 8 - (2 * groups);
            int part2 = Math.Max((pairs + taatsu), (int)Math.Ceiling((double)(handSize / 3)));
            int part3 = Math.Min(1, Math.Max(0, ((pairs + taatsu) - (4 - groups))));

            return Math.Min((part1 - part2), 6);
        }

    }
}
