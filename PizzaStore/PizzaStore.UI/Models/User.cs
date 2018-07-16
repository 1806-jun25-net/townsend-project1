using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaStore.UI.Models
{
    public class User
    {
        public int UserID { get; set; }
        
        public string FirstName { get; set; }
        
        public string LastName { get; set; }
        public int StoreLocation { get; set; } = 1;
        public int OrderPref { get; set; }
    }
}
