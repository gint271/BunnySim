using System;
using System.Collections.Generic;

namespace BunnySim
{
    class Program
    {
        public static Random randomGenerator = new Random();

        static void Main(string[] args)
        {
            for (int i = 0; i < 10000; i++)
            {
                var game = new SkinGacha();
                List<Item> draws = game.PlayGacha();

                int skinDrawNumber = draws.FindIndex(item => item.name == "Rabbit Deluxe");
                Console.WriteLine(skinDrawNumber + 1);
            }
        }
    }
}
