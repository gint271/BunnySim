using System;
using System.Collections.Generic;
using System.Text;

namespace BunnySim
{
    class Item
    {
        public string name;
        public double chance;
        public int quantity;

        public Item(string name, double chance, int quantity)
        {
            this.name = name;
            this.chance = chance;
            this.quantity = quantity;
        }
    }
}
