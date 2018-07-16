
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using PizzaStore.Library.PizzaClassRepo;

namespace PizzaStore.Library
{
    public class Pizza
    {
        public int PizzaID { get; set; }
        public int OrderID { get; set; }
        [Required]
        public string Sauce { get; set; }
        [Required]
        public string Crust { get; set; }
        [Required]
        public string Size { get; set; }
        [Required]
        public decimal Price { get; set; }
        
        public bool Bacon { get; set; }
        
        public bool Pepperoni { get; set; }
        
        public bool Sausage { get; set; }
        
        public bool Chicken { get; set; }
        
        public bool Onions { get; set; }
        
        public bool Olives { get; set; }


        public decimal CalculatePrice(Pizza pizza)
        {
            decimal temp = 0;
            if (pizza.Bacon)
                temp += (decimal)1.00;
            if (pizza.Pepperoni)
                temp += (decimal)1.00;
            if (pizza.Sausage)
                temp += (decimal)1.00;
            if (pizza.Chicken)
                temp += (decimal)1.00;
            if (pizza.Size == "Large")
                temp += 10;
            else if (pizza.Size == "Medium")
                temp += 8;
            else if (pizza.Size == "Small")
                temp += 6;
            if (pizza.Crust == "Thin")
                temp += (decimal)0.60;
            else if (pizza.Crust == "Pan")
                temp += 1;
            else if (pizza.Crust == "Stuffed")
                temp += (decimal)1.20;


            return temp;
        }
        

        
        
        
        
        
    }
}
