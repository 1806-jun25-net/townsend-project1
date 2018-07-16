
using System;
using System.Collections.Generic;
using System.Text;
using PizzaStore.Library.PizzaClassRepo;
namespace PizzaStore.Library
{
    public class Order
    {
        
        public int OrderID { get; set; }
        public int StoreID { get; set; }
        public int UserID { get; set; }
        public EndUser User { get; set; } = new EndUser();
        public DateTime OrderTime { get; set; }
        public Pizza Pizza { get; set; }
        public decimal Price { get; set; }   

        
    }
}
