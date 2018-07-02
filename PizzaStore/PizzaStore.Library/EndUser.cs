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
        public EndUser(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
            StoreLocation = new Location();
            OrderPref = new Order();
        }
        public EndUser(string firstName, string lastName, Location location, Order orderPref)
        {
            FirstName = firstName;
            LastName = lastName;
            StoreLocation = location;
            OrderPref = orderPref;
        }
    }
}
