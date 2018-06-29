using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaStore.Library
{
    public class Location
    { 
        public Inventory Inventory { get; set; }
        public IEnumerable<Order> History { get; set; }
    }
}
