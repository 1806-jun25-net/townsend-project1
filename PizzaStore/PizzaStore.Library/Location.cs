using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaStore.Library
{
    public class Location
    {
        public int StoreID;

        public List<Order> History { get; set; } = new List<Order>();

        public int Pepperoni { get; set; } = 100;
        public int Sausage { get; set; } = 100;
        public int Chicken { get; set; } = 100;
        public int Bacon { get; set; } = 100;
        public int Beef { get; set; } = 100;
        public int Olives { get; set; } = 100;
        public int Onions { get; set; } = 100;
        public int Cheese { get; set; } = 100;
        public int Dough { get; set; } = 100;
        public int MarinaraSauce { get; set; } = 100;
        public int BuffaloSauce { get; set; } = 100;
        public int BBQSauce { get; set; } = 100;

        public void DecreaseInventory(List<Pizza> pizzas, int storeId)
        {
            foreach(var pizza in pizzas)
            {

            }   
        }
    }
}
