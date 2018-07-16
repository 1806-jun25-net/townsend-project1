using System;
using System.Collections.Generic;

namespace PizzaStore.Data
{
    public partial class Pizzas
    {
        public int PizzaId { get; set; }
        public int OrderId { get; set; }
        public string Crust { get; set; }
        public string Sauce { get; set; }
        public string Size { get; set; }
        public bool Bacon { get; set; }
        public bool Pepperoni { get; set; }
        public bool Sausage { get; set; }
        public bool Chicken { get; set; }
        public bool Olives { get; set; }
        public bool Onions { get; set; }
        public decimal Price { get; set; }

        public Orders Order { get; set; }
    }
}
