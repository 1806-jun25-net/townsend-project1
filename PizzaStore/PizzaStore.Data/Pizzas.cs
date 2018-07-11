using System;
using System.Collections.Generic;

namespace PizzaStore.Data
{
    public partial class Pizzas
    {
        public Pizzas()
        {
            Toppings = new HashSet<Toppings>();
        }

        public int PizzaId { get; set; }
        public int OrderId { get; set; }
        public string Crust { get; set; }
        public string Sauce { get; set; }
        public string Size { get; set; }
        public decimal Price { get; set; }

        public Orders Order { get; set; }
        public ICollection<Toppings> Toppings { get; set; }
    }
}
