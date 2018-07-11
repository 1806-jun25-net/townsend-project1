using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaStore.Library
{
    public class EndUser
    {
        public int UserID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int StoreLocation { get; set; } = 1;
        public int OrderPref { get; set; }

        

        
    }
}
