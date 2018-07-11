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
        public string DisplayOrderHistory()
        {
            var orders = new List<Order>();
            orders = GetOrders();
            string str = "OrderID  |  UserID |  StoreID  |  OrderTime  |  Price\n\n";
            foreach(Order order in orders)
            {
                str = $"{str}{order.OrderID}  |  {order.UserID}  |  {order.StoreID}  |  {order.OrderTime}  |  {order.Price}\n\n";
            }
            return str;
        }
        public int SetUserID()
        {
            var users = Mapper.Map(pizzaDB.Users);
            return users.Count + 1;
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
        public int SetPizzaId()
        {
            var pizzas = Mapper.Map(pizzaDB.Pizzas);

            return pizzas.Count + 1;
        }
        public void AddPizza(Pizza pizza)
        {
            pizzaDB.Add(Mapper.Map(pizza));
        }
        public int SetToppingId()
        {
            var toppings = Mapper.Map(pizzaDB.Toppings);
            return toppings.Count + 1;
        }
        public void AddPizzas(List<Pizza> pizzas)
        {
            foreach(var pizza in pizzas)
            {
                pizzaDB.Add(Mapper.Map(pizza));
            }
        }
        public void AddTopping(Topping topping)
        {
            
            
                pizzaDB.Add(Mapper.Map(topping));
            
        }
        public void Save()
        {
            pizzaDB.SaveChanges();
        }

        public List<Order> GetOrders()
        {
            var orderList = Mapper.Map(pizzaDB.Orders.Include(x => x.Store).Include(y => y.User));
            foreach (var order in orderList)
            {
                order.Pizzas = FindPizzasByOrderId(order.OrderID);
            }
            return orderList;

        }

        public int GetUserId(string first, string last)
        {
            var users = pizzaDB.Users;
            foreach(var user in users)
            {
                if (user.FirstName == first && user.LastName == last)
                    return user.UserId;
            }
            return 0;
        }

        public List<Pizza> FindPizzasByOrderId(int orderId)
        {
            List<Pizza> pizzas = new List<Pizza>();
            foreach(var pizza in pizzaDB.Pizzas)
            {
                if (orderId == pizza.OrderId)
                    pizzas.Add(Mapper.Map(pizza));
            }
            return pizzas;
        }

        public void DecreaseInventory(int location)
        {

        }

    }
}
