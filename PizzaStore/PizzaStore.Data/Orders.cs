using System;
using System.Collections.Generic;

namespace PizzaStore.Data
{
    public partial class Orders
    {
        public Orders()
        {
            Pizzas = new HashSet<Pizzas>();
        }

        public int OrderId { get; set; }
        public int UserId { get; set; }
        public int StoreId { get; set; }
        public DateTime OrderTime { get; set; }
        public decimal Price { get; set; }

        public Locations Store { get; set; }
        public Users User { get; set; }
        public ICollection<Pizzas> Pizzas { get; set; }
    }
}
