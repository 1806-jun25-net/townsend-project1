using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaStore.Library
{
    public class EndUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Location StoreLocation { get; set; }
        public Order OrderPref { get; set; }
    }
}
