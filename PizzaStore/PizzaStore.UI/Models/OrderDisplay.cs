using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaStore.UI.Models
{
    public class OrderDisplay
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

        public int UserID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int StoreLocation { get; set; } = 1;
        public int OrderPref { get; set; }
        public DateTime OrderTime;
        public int PizzaCount { get; set; }
    }
}
