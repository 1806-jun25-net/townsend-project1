using System;
using System.Collections.Generic;
using System.Text;
using PizzaStore.Library.PizzaClassRepo;

namespace PizzaStore.Library
{
    public class Pizza
    {
        public int PizzaID { get; set; }
        public int OrderID { get; set; }
        public string Sauce { get; set; }
        public string Crust { get; set; }
        public string Size { get; set; }
        public decimal Price { get; set; }
       
        public List<Topping> Toppings { get; set; } = new List<Topping>();


        public void ChooseCrust()
        {
            
            string crust = "";
            do
            {
                Console.WriteLine("What type of crust would you like?");
                Console.WriteLine("Options are Thin, Stuffed and Pan");
                crust = Console.ReadLine();
            } while (crust != "Pan" && crust != "Thin" && crust != "Stuffed");
            switch (crust)
            {
                case "Pan":
                    Price += (decimal)1.0;
                    break;
                case "Thin":
                    Price += (decimal)0.50;
                    break;
                case "Stuffed":
                    Price += (decimal)1.30;
                    break;
            }
            Crust = crust;
        }
        public void ChooseSauce()
        {
            string sauce = "";
            do
            {
                Console.WriteLine("What type of sauce would you like?");
                Console.WriteLine("Options are Buffalo, Barbeque and Marinara");
                sauce = Console.ReadLine();
            } while (sauce != "Buffalo" && sauce != "Barbeque" && sauce != "Marinara");

            Sauce = sauce;
        }
        public void ChooseSize()
        {
            string size = "";
            do
            {
                Console.WriteLine("What size would you like?(L/M/S)");
                size = Console.ReadLine();
            } while (size != "L" && size != "M" && size != "S");

             switch(size)
             {
                case "L":
                    Price += (decimal)10.0;
                    size = "Large";
                    break;
                case "M":
                    Price += (decimal)8.0;
                    size = "Medium";
                    break;
                case "S":
                    Price += (decimal)6.0;
                    size = "Small";
                    break;
             }
            Size = size;
        }
        public Topping AddTopping(string topping, int id, int toppingId)
        {
            string[] meats = { "Bacon", "Pepperoni", "Sausage", "Chicken" };
            foreach (string s in meats)
            {

                if (topping == s)
                    Price += (decimal)1.20;
            }
            Topping temp = new Topping();
            temp.Name = topping;
            temp.PizzaID = id;
            temp.ToppingID = toppingId;
            Toppings.Add(temp);
            return temp;


        }
        public void ChooseToppings(int id, PizzaStoreRepo repo)
        {
            string[] toppings = { "Bacon", "Pepperoni", "Sausage", "Chicken", "Olives", "Onions" };
            foreach (string s in toppings)
            {
                Console.WriteLine($"Would you like {s} on your pizza?(y/n)");
                string ans = Console.ReadLine();
               /* if (ans == "y")
                {
                    repo.AddTopping(AddTopping(s, id, repo.SetToppingId()));
                    repo.Save();
                }*/
                    
            }
 
            
            
        }
        
        public override string ToString()
        {
            string str = $"{Size} pizza with ";
            foreach(Topping s in Toppings)
            {
                str = str + s.Name + ", ";
            }
            str = $"{str} {Sauce} sauce and {Crust} crust.  Price: ${Price}";
            return str;
        }
    }
}
