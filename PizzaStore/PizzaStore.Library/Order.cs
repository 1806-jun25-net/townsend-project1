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
        public List<Pizza> Pizzas { get; set; } = new List<Pizza>();
        public decimal Price { get; set; }   


        public void StartOrder(int id,PizzaStoreRepo repo, PizzaStore.Data.PizzaStoreDBContext dbContext)
        {
            
           
            AddPizza(repo, id);
            
            
        }
        
        public void AddPizza(PizzaStoreRepo repo, int id)
        {
            string temp = "";
            do
            {

                Pizza order = new Pizza();
                order.OrderID = id;
                order.PizzaID = repo.SetPizzaId();
                order.ChooseSize();
                order.ChooseCrust();
                order.ChooseSauce();
                repo.AddPizza(order);
                repo.Save();
                order.ChooseToppings(order.PizzaID, repo);
                
                
                Pizzas.Add(order);
                CalculateOrderTotal();

                if (Pizzas.Count == 12)
                    Console.WriteLine("This is your last pizza.");
                else
                {
                    Console.WriteLine("Would you like to add another pizza to your order?(y/n)");
                    temp = Console.ReadLine();
                }

            } while (temp == "y" || temp == "Y" && Pizzas.Count <= 12);
            
            DisplayOrder();
            Console.ReadLine();
        }

        public void CalculateOrderTotal()
        {
            decimal tax = (decimal) 1.05;
            Price = 0;
            foreach (Pizza p in Pizzas)
            {
                Price = Price + p.Price;
            }
            Price = Price * tax;
            Console.WriteLine($"The price for your order so far is: {Price}");
        }
        public void DisplayOrder()
        {

            Console.WriteLine("Thank you for your order, see order details below.");
            foreach (Pizza p in Pizzas)
            {
                Console.WriteLine(p.ToString());
            }


            Console.WriteLine($"\nThe final price for your order is: ${Price}");

            

        }


        
    }
}
