﻿
using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaStore.Library
{
    public class Location
    {
        public int StoreID;

        public List<Order> History { get; set; } = new List<Order>();

        public int Pepperoni { get; set; }
        public int Sausage { get; set; }
        public int Chicken { get; set; }
        public int Bacon { get; set; }
        public int Olives { get; set; }
        public int Onions { get; set; }
        public int Cheese { get; set; }
        public int Dough { get; set; }
        public int MarinaraSauce { get; set; }
        public int BuffaloSauce { get; set; }
        public int BBQSauce { get; set; }

       
    }
}
