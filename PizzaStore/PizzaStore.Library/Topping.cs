using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaStore.Library
{
    public class Topping
    {
        public int ToppingID { get; set; }
        public string Name { get; set; }
        public int PizzaID { get; set; }
    }
}
