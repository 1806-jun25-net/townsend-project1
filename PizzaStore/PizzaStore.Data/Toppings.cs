using System;
using System.Collections.Generic;

namespace PizzaStore.Data
{
    public partial class Toppings
    {
        public int ToppingId { get; set; }
        public string Name { get; set; }
        public int PizzaId { get; set; }

        public Pizzas Pizza { get; set; }
    }
}
