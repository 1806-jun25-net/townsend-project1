
using System;
using System.Collections.Generic;
using System.Text;
using PizzaStore.Data;
using PizzaStore.Library;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace PizzaStore.Library.PizzaClassRepo
{
    public class PizzaStoreRepo
    {
        private readonly PizzaStoreDBContext pizzaDB;

        public PizzaStoreRepo(PizzaStoreDBContext db)
        {
            pizzaDB = db ?? throw new ArgumentNullException(nameof(db));
        }
        
        public IEnumerable<Order> GetOldest()
        {
            var orders = pizzaDB.Orders;
            return Mapper.Map(orders.OrderBy(x => x.OrderTime));
        }
        public IEnumerable<Order> GetNewest()
        {
            var orders = pizzaDB.Orders;
            return Mapper.Map(orders.OrderByDescending(x => x.OrderTime));
        }
        public IEnumerable<Order> GetCheap()
        {
            var orders = pizzaDB.Orders;
            return Mapper.Map(orders.OrderBy(x => x.Price));
        }
        public IEnumerable<Order> GetExpensive()
        {
            var orders = pizzaDB.Orders;
            return Mapper.Map(orders.OrderByDescending(x => x.Price));
        }
        
        public void AddUser(EndUser user)
        {
            pizzaDB.Add(Mapper.Map(user));
        }

        public void AddOrder(Order order)
        {
            pizzaDB.Add(Mapper.Map(order));
        }
        public void UpdateUser(EndUser user)
        {
            pizzaDB.Entry(pizzaDB.Users.Find(user.UserID)).CurrentValues.SetValues(Mapper.Map(user));
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
        public List<Library.EndUser> GetUsers(string search = null)
        {
            var users = pizzaDB.Users;
            List<EndUser> result = new List<EndUser>();
            if (search == null)
            {
                foreach (var item in users)
                {
                    result.Add(Mapper.Map(item));
                }
            }
            else
            {
                foreach (var item in users)
                {
                    if (item.FirstName.Contains(search) || item.LastName.Contains(search))
                    {
                        result.Add(Mapper.Map(item));
                    }
                }
            }
            return result;
        }

        public void UpdateLocation(Location store)
        {
            pizzaDB.Entry(pizzaDB.Locations.Find(store.StoreID)).CurrentValues.SetValues(Mapper.Map(store));
        }
        public Location GetStoreByID(int id)
        {
            var stores = pizzaDB.Locations;
            foreach(var store in stores)
            {
                if (store.StoreId == id)
                    return Mapper.Map(store);
            }
            return new Location();
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
        public List<Order> GetOrdersByUserID(int i)
        {
            var orders = pizzaDB.Orders;
            List<Order> result = new List<Order>();
            foreach (var item in orders)
            {
                if (item.UserId == i)
                {
                    result.Add(Mapper.Map(item));
                }
            }
            return result;
        }

        public List<Location> GetLocations()
        {
            var locations = pizzaDB.Locations;
            return Mapper.Map(locations);
        }
       
        public List<Order> GetOrdersByStoreID(int id)
        {
            var orders = pizzaDB.Orders;
            var result = new List<Order>();
            foreach(var item in orders)
            {
                if (item.StoreId == id)
                    result.Add(Mapper.Map(item));

            }
            return result;
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
