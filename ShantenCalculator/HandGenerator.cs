﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShantenCalculator
{
    // Class for creating test hands for the purpose of debugging
    class HandGenerator
    {
        Tile[] hand;

        public HandGenerator()
        {
            this.hand = new Tile[14];

        }

        public Tile[] make(String handType)
        {
            switch (handType.ToLower())
            {
                case "test":
                    Console.WriteLine("Which test number?");
                    MakeTest(Int32.Parse(Console.ReadLine()));
                    break;
                case "9gates":
                    Make9Gates();
                    break;
                case "tanyao":
                    MakeTanyao();
                    break;
                case "toitoi":
                    MakeToitoi();
                    break;
                case "7pairs":
                    Make7Pairs();
                    break;
                default:
                    MakeKokushi();
                    break;
            }

            return this.hand;
        }

        private void MakeTest(int shanten)
        {
            switch (shanten)
            {
                case 0:

                    Console.WriteLine("Testing tenpai");

                    this.hand[0] = new Tile(2, TileType.MAN);

                    this.hand[1] = new Tile(3, TileType.MAN);

                    this.hand[2] = new Tile(4, TileType.MAN);

                    this.hand[3] = new Tile(7, TileType.MAN);

                    this.hand[4] = new Tile(8, TileType.MAN);

                    this.hand[5] = new Tile(9, TileType.MAN);

                    this.hand[6] = new Tile(7, TileType.SOU);

                    this.hand[7] = new Tile(8, TileType.SOU);

                    this.hand[8] = new Tile(9, TileType.SOU);

                    this.hand[9] = new Tile(6, TileType.PIN);

                    this.hand[10] = new Tile(7, TileType.PIN);

                    this.hand[11] = new Tile(3, TileType.HON);

                    this.hand[12] = new Tile(3, TileType.HON);

                    break;

                case 1:

                    Console.WriteLine("Testing 1 shanten");

                    this.hand[0] = new Tile(3, TileType.MAN);

                    this.hand[1] = new Tile(6, TileType.MAN);

                    this.hand[2] = new Tile(7, TileType.MAN);

                    this.hand[3] = new Tile(8, TileType.MAN);

                    this.hand[4] = new Tile(9, TileType.MAN);

                    this.hand[5] = new Tile(9, TileType.MAN);

                    this.hand[6] = new Tile(1, TileType.SOU);

                    this.hand[7] = new Tile(5, TileType.SOU);

                    this.hand[8] = new Tile(5, TileType.SOU);

                    this.hand[9] = new Tile(1, TileType.PIN);

                    this.hand[10] = new Tile(2, TileType.PIN);

                    this.hand[11] = new Tile(3, TileType.PIN);

                    this.hand[12] = new Tile(1, TileType.HON);

                    break;

                default:

                    Console.WriteLine("Testing winning hand");

                    this.hand[0] = new Tile(2, TileType.MAN);

                    this.hand[1] = new Tile(3, TileType.MAN);

                    this.hand[2] = new Tile(4, TileType.MAN);

                    this.hand[3] = new Tile(7, TileType.MAN);

                    this.hand[4] = new Tile(8, TileType.MAN);

                    this.hand[5] = new Tile(9, TileType.MAN);

                    this.hand[6] = new Tile(8, TileType.SOU);

                    this.hand[7] = new Tile(8, TileType.SOU);

                    this.hand[8] = new Tile(8, TileType.SOU);

                    this.hand[9] = new Tile(6, TileType.PIN);

                    this.hand[10] = new Tile(6, TileType.PIN);

                    this.hand[11] = new Tile(6, TileType.PIN);

                    this.hand[12] = new Tile(4, TileType.HON);

                    break;
            }
        }

        private void Make9Gates()
        {
            this.hand[0] = new Tile(1, TileType.MAN);

            this.hand[1] = new Tile(1, TileType.MAN);

            this.hand[2] = new Tile(1, TileType.MAN);

            this.hand[3] = new Tile(2, TileType.MAN);

            this.hand[4] = new Tile(3, TileType.MAN);

            this.hand[5] = new Tile(4, TileType.MAN);

            this.hand[6] = new Tile(5, TileType.MAN);

            this.hand[7] = new Tile(6, TileType.MAN);

            this.hand[8] = new Tile(7, TileType.MAN);

            this.hand[9] = new Tile(8, TileType.MAN);

            this.hand[10] = new Tile(9, TileType.MAN);

            this.hand[11] = new Tile(9, TileType.MAN);

            this.hand[12] = new Tile(9, TileType.MAN);
        }

        private void MakeTanyao()
        {
            this.hand[0] = new Tile(2, TileType.MAN);

            this.hand[1] = new Tile(3, TileType.MAN);

            this.hand[2] = new Tile(4, TileType.MAN);

            this.hand[3] = new Tile(6, TileType.MAN);

            this.hand[4] = new Tile(7, TileType.MAN);

            this.hand[5] = new Tile(8, TileType.MAN);

            this.hand[6] = new Tile(2, TileType.PIN);

            this.hand[7] = new Tile(3, TileType.PIN);

            this.hand[8] = new Tile(4, TileType.PIN);

            this.hand[9] = new Tile(6, TileType.PIN);

            this.hand[10] = new Tile(7, TileType.PIN);

            this.hand[11] = new Tile(8, TileType.PIN);

            this.hand[12] = new Tile(5, TileType.SOU);
        }

        private void MakeToitoi()
        {
            this.hand[0] = new Tile(1, TileType.MAN);

            this.hand[1] = new Tile(1, TileType.MAN);

            this.hand[2] = new Tile(1, TileType.MAN);

            this.hand[3] = new Tile(2, TileType.MAN);

            this.hand[4] = new Tile(2, TileType.MAN);

            this.hand[5] = new Tile(2, TileType.MAN);

            this.hand[6] = new Tile(4, TileType.MAN);

            this.hand[7] = new Tile(4, TileType.MAN);

            this.hand[8] = new Tile(4, TileType.MAN);

            this.hand[9] = new Tile(5, TileType.MAN);

            this.hand[10] = new Tile(5, TileType.MAN);

            this.hand[11] = new Tile(5, TileType.MAN);

            this.hand[12] = new Tile(6, TileType.MAN);
        }

        private void Make7Pairs()
        {
            this.hand[0] = new Tile(1, TileType.MAN);

            this.hand[1] = new Tile(1, TileType.MAN);

            this.hand[2] = new Tile(2, TileType.MAN);

            this.hand[3] = new Tile(2, TileType.MAN);

            this.hand[4] = new Tile(4, TileType.MAN);

            this.hand[5] = new Tile(4, TileType.MAN);

            this.hand[6] = new Tile(5, TileType.MAN);

            this.hand[7] = new Tile(5, TileType.MAN);

            this.hand[8] = new Tile(7, TileType.MAN);

            this.hand[9] = new Tile(7, TileType.MAN);

            this.hand[10] = new Tile(8, TileType.MAN);

            this.hand[11] = new Tile(8, TileType.MAN);

            this.hand[12] = new Tile(1, TileType.SOU);
        }

        private void MakeKokushi()
        {
            this.hand[0] = new Tile(1, TileType.MAN);

            this.hand[1] = new Tile(9, TileType.MAN);

            this.hand[2] = new Tile(1, TileType.PIN);

            this.hand[3] = new Tile(9, TileType.PIN);

            this.hand[4] = new Tile(1, TileType.SOU);

            this.hand[5] = new Tile(9, TileType.SOU);

            this.hand[6] = new Tile(1, TileType.HON);

            this.hand[7] = new Tile(2, TileType.HON);

            this.hand[8] = new Tile(3, TileType.HON);

            this.hand[9] = new Tile(4, TileType.HON);

            this.hand[10] = new Tile(5, TileType.HON);

            this.hand[11] = new Tile(6, TileType.HON);

            this.hand[12] = new Tile(7, TileType.HON);
        }

    }
}
