using System;
using System.Collections.Generic;

namespace PizzaStore.Data
{
    public partial class Users
    {
        public Users()
        {
            Orders = new HashSet<Orders>();
        }

        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int StorePref { get; set; }
        public int OrderPref { get; set; }

        public Locations StorePrefNavigation { get; set; }
        public ICollection<Orders> Orders { get; set; }
    }
}
