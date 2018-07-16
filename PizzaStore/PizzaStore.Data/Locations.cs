using System;
using System.Collections.Generic;

namespace PizzaStore.Data
{
    public partial class Locations
    {
        public Locations()
        {
            Orders = new HashSet<Orders>();
            Users = new HashSet<Users>();
        }

        public int StoreId { get; set; }
        public int Pepperoni { get; set; }
        public int Sausage { get; set; }
        public int Chicken { get; set; }
        public int Bacon { get; set; }
        public int Beef { get; set; }
        public int Olives { get; set; }
        public int Onions { get; set; }
        public int Cheese { get; set; }
        public int Dough { get; set; }
        public int MarinaraSauce { get; set; }
        public int BuffaloSauce { get; set; }
        public int Bbqsauce { get; set; }

        public ICollection<Orders> Orders { get; set; }
        public ICollection<Users> Users { get; set; }
    }
}
