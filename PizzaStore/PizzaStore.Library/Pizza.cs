using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaStore.Library
{
    public class Pizza
    {
        public string Cheese { get; set; }
        public string Crust { get; set; }
        public string Sauce { get; set; }
        public List<string> Toppings { get; set; }
    }
}
