using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaStore.Web.Models
{
    public class Order
    {
        public int OrderID { get; set; }
        public int StoreID { get; set; }
        public User User { get; set; } = new User();
        public DateTime OrderTime { get; set; }
        public Pizza Pizza { get; set; }
        public decimal Price { get; set; }

    }
}
