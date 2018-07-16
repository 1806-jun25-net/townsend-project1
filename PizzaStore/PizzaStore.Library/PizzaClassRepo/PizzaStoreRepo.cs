
using System;
using System.Collections.Generic;
using System.Text;
using PizzaStore.Data;
using PizzaStore.Library;
using Microsoft.EntityFrameworkCore;
namespace PizzaStore.Library.PizzaClassRepo
{
    public class PizzaStoreRepo
    {
        private readonly PizzaStoreDBContext pizzaDB;

        public PizzaStoreRepo(PizzaStoreDBContext db)
        {
            pizzaDB = db ?? throw new ArgumentNullException(nameof(db));
        }
        
        
        public void AddUser(EndUser user)
        {
            pizzaDB.Add(Mapper.Map(user));
        }

        public void AddOrder(Order order)
        {
            pizzaDB.Add(Mapper.Map(order));
        }

        public EndUser GetUserById(int id)
        {
            var users = pizzaDB.Users;
            var returnUser = new EndUser();
            foreach (var user in users)
            {
                if (user.UserId == id)
                    returnUser = Mapper.Map(user);
            }

            return returnUser;
        }
        
        
        public int GetUserID(string first, string last)
        {
            var userList = pizzaDB.Users;
            foreach(var user in userList)
            {
                if (first == user.FirstName && last == user.LastName)
                    return user.UserId;
            }
            return 0;
        }
        public void Save()
        {
            pizzaDB.SaveChanges();
        }
        public void AddPizza(Pizza pizza)
        {
            pizzaDB.Add(Mapper.Map(pizza));
        }
        public IEnumerable<EndUser> GetUsers(string search = null)
        {
            if (search == null)
            {
                // disable pointless tracking for performance
                return Mapper.Map(pizzaDB.Users);
            }
            else
            {
                return Mapper.Map(pizzaDB.Users);
            }

        }

        public int GetOrderID(int UserID)
        {
            var orderList = pizzaDB.Orders;
            int temp = 0;
            foreach(var item in orderList)
            {
                if (item.UserId == UserID)
                    temp = item.OrderId;
            }
            return temp;
        }
        public IEnumerable<Order> GetOrders(string search = null)
        {
            if (search == null)
            {
                // disable pointless tracking for performance
                return Mapper.Map(pizzaDB.Orders);
            }
            else
            {
                return Mapper.Map(pizzaDB.Orders);
            }
        }





    }
}
