using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaStore.Library
{
    public class Order
    {
        public Location Location { get; set; }
        public EndUser User { get; set; }
        public DateTime OrderTime { get; set; }

    }
}
