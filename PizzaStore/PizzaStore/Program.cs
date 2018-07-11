using NLog;
using PizzaStore.Library;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using PizzaStore.Data;
using PizzaStore.Library.PizzaClassRepo;
namespace PizzaStore.Console
{
    class Program
    {
        private static readonly Logger logger =
            LogManager.GetCurrentClassLogger();

        static void Main(string[] args)
        {

            var configBuilder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
            var configuration = configBuilder.Build();
            var optionsBuilder = new DbContextOptionsBuilder<PizzaStore.Data.PizzaStoreDBContext>();
            optionsBuilder.UseSqlServer(configuration.GetConnectionString("PizzaStoreDB"));
            var options = optionsBuilder.Options;

            var dbContext = new PizzaStore.Data.PizzaStoreDBContext(options);
            var repo = new PizzaStoreRepo(dbContext);

            logger.Info("Application start");

           
                var orderHistory = new List<Order>();
                orderHistory = repo.GetOrders();
                Order fullOrder = new Order();
                EndUser user = new EndUser();
                fullOrder.OrderID = orderHistory.Count + 1;
                System.Console.WriteLine("Welcome to Kyle's Pizza Store");
                System.Console.WriteLine("Would you like to display order history?(y/n)");
                string tempString = System.Console.ReadLine();
                if (tempString == "y")
                    System.Console.WriteLine(repo.DisplayOrderHistory());
                
                System.Console.WriteLine("Enter First Name: ");
                user.FirstName = System.Console.ReadLine();
                System.Console.WriteLine("Enter Last Name: ");
                user.LastName = System.Console.ReadLine();
                bool userExists = false;
                
            if (repo.GetUserId(user.FirstName, user.LastName) != 0)
                {
                    user = repo.GetUserById(repo.GetUserId(user.FirstName, user.LastName));
                    userExists = true;

                }

                if (userExists == false)
                {
                    repo.AddUser(user);
                    repo.Save();
                }
                fullOrder.UserID = repo.GetUserId(user.FirstName, user.LastName);
                user.UserID = fullOrder.UserID;
                System.Console.WriteLine($"Current Store Location: {user.StoreLocation}\nWould you like to change store location?(y/n)");
                string temp = System.Console.ReadLine();
                if (temp == "y")
                {
                    do
                    {
                        System.Console.WriteLine("Choose store location(1-4)");
                        user.StoreLocation = Int32.Parse(System.Console.ReadLine());
                    } while (user.StoreLocation != 1 && user.StoreLocation != 2 && user.StoreLocation != 3 && user.StoreLocation != 4);
                }
                fullOrder.StartOrder(fullOrder.OrderID, repo, dbContext);
                fullOrder.StoreID = user.StoreLocation;
                fullOrder.User = user;
                fullOrder.OrderTime = DateTime.Now;
                fullOrder.CalculateOrderTotal();
                repo.AddOrder(fullOrder);
                repo.Save();
                
                
                


            
            

            logger.Info("Application shutting down");
            
                     


            

        }
    }
}
