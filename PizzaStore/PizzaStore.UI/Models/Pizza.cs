using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaStore.UI.Models
{
    public class Pizza
    {
        public int PizzaID { get; set; }
        public int OrderID { get; set; }
        public string Sauce { get; set; }
        public string Crust { get; set; }
        public string Size { get; set; }
        public decimal Price { get; set; }
        public bool Bacon { get; set; }
        public bool Pepperoni { get; set; }
        public bool Sausage { get; set; }
        public bool Chicken { get; set; }
        public bool Onions { get; set; }
        public bool Olives { get; set; }
    }
}
