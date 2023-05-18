using System;
using System.Collections.Generic;
using System.Text;

namespace BunnySim
{
    class SkinGacha
    {
        public Random randomGenerator = new Random();
        List<Item> pool = new List<Item>();
        List<Item> draws = new List<Item>();

        public SkinGacha()
        {
            pool.Add(new Item("Custom Module", 0.01, 2));
            pool.Add(new Item("Skill Manual I", 0.0155, 90));
            pool.Add(new Item("Darling for a Day", 0.0175, 5));
            pool.Add(new Item("Central Government Supply Chest I", 0.16, 14));
            pool.Add(new Item("Burst Manual I", 0.16, 22));
            pool.Add(new Item("Growth Set: 1H", 0.3135, 4));
            pool.Add(new Item("Ultra Boost Module", 0.3135, 20));
        }

        public List<Item> PlayGacha()
        {
            // First pull
            Item pulledItem = PullGacha(pool);
            pool.Remove(pulledItem);
            draws.Add(pulledItem);

            // 2th prizes added
            pool.Add(new Item("Advanced Recruit Voucher", .004, 10));
            pool.Add(new Item("Manufacturer Arms", .0055, 200));

            // Three more pulls
            for (int i = 0; i < 3; i++)
            {
                Item pulledItem2 = PullGacha(pool);
                pool.Remove(pulledItem2);
                draws.Add(pulledItem2);
            }

            // Skin added
            pool.Add(new Item("Rabbit Deluxe", 0.0005, 1));

            //Remaining pulls
            while (pool.Count > 0)
            {
                Item pulledItem2 = PullGacha(pool);
                pool.Remove(pulledItem2);
                draws.Add(pulledItem2);
            }

            return draws;
        }

        private Item PullGacha(List<Item> pool)
        {
            double sumChance = 0;
            foreach (Item item in pool)
            {
                sumChance += item.chance;
            }

            double roll = randomGenerator.NextDouble() * sumChance;

            foreach (Item item in pool)
            {
                roll -= item.chance;

                if (roll < 0)
                {
                    return item;
                }
            }

            throw new Exception("Pull method broke.");
        }
    }
}
