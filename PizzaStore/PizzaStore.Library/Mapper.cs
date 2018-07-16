using PizzaStore.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace PizzaStore.Library
{
    public static class Mapper
    {
        public static EndUser Map(Data.Users user) => new EndUser
        {
            UserID = user.UserId,
            FirstName = user.FirstName,
            LastName = user.LastName,
            StoreLocation = user.StorePref,
            OrderPref = user.OrderPref

        };
        public static Data.Users Map(EndUser user) => new Data.Users
        {
            UserId = user.UserID,
            FirstName = user.FirstName,
            LastName = user.LastName,
            StorePref = user.StoreLocation,
            OrderPref = user.OrderPref
            
        };
        public static Location Map(Data.Locations location) => new Location
        {
            StoreID = location.StoreId,
            Pepperoni = location.Pepperoni,
            Sausage = location.Sausage,
            Chicken = location.Chicken,
            Bacon = location.Bacon,
            Olives = location.Olives,
            Onions = location.Onions,
            Dough = location.Dough,
            MarinaraSauce = location.MarinaraSauce,
            BuffaloSauce = location.BuffaloSauce,
            BBQSauce = location.Bbqsauce,
            Cheese = location.Cheese

        };
        public static Data.Locations Map(Location location) => new Data.Locations
        {
            StoreId = location.StoreID,
            Pepperoni = location.Pepperoni,
            Sausage = location.Sausage,
            Chicken = location.Chicken,
            Bacon = location.Bacon,
            Olives = location.Olives,
            Onions = location.Onions,
            Dough = location.Dough,
            MarinaraSauce = location.MarinaraSauce,
            BuffaloSauce = location.BuffaloSauce,
            Bbqsauce = location.BBQSauce,
            Cheese = location.Cheese

        };

        public static Order Map(Data.Orders order) => new Order
        {
            OrderID = order.OrderId,
            UserID = order.UserId,
            OrderTime = order.OrderTime,
            Price = order.Price,
            StoreID = order.StoreId
        };

        public static Data.Orders Map(Order order) => new Data.Orders
        {
            OrderId = order.OrderID,
            UserId = order.UserID,
            StoreId = order.StoreID,
            OrderTime = order.OrderTime,
            Price = order.Price
            
        };
        public static Pizza Map(Data.Pizzas pizza) => new Pizza
        {
            PizzaID = pizza.PizzaId,
            OrderID = pizza.OrderId,
            Sauce = pizza.Sauce,
            Crust = pizza.Crust,
            Size = pizza.Size,
            Price = pizza.Price,
            Pepperoni = pizza.Pepperoni,
            Bacon= pizza.Bacon,
            Chicken = pizza.Chicken,
            Sausage =pizza.Sausage,
            Onions = pizza.Onions,
            Olives = pizza.Olives
            
        };

        public static Data.Pizzas Map(Pizza pizza) => new Data.Pizzas
        {
            OrderId = pizza.OrderID,
            Sauce = pizza.Sauce,
            Crust = pizza.Crust,
            Size = pizza.Size,
            Price = pizza.Price,
            Pepperoni = pizza.Pepperoni,
            Bacon = pizza.Bacon,
            Chicken = pizza.Chicken,
            Sausage = pizza.Sausage,
            Onions = pizza.Onions,
            Olives = pizza.Olives


        };

   

        
        public static List<EndUser> Map(IEnumerable<Data.Users> users) => users.Select(Map).ToList();
        public static List<Data.Users> Map(IEnumerable<EndUser> users) => users.Select(Map).ToList();

        public static List<Location> Map(IEnumerable<Data.Locations> locations) => locations.Select(Map).ToList();
        public static List<Data.Locations> Map(IEnumerable<Location> locations) => locations.Select(Map).ToList();

        public static List<Order> Map(IEnumerable<Data.Orders> orders) => orders.Select(Map).ToList();
        public static List<Data.Orders> Map(IEnumerable<Order> orders) => orders.Select(Map).ToList();

        public static List<Pizza> Map(IEnumerable<Data.Pizzas> pizzas) => pizzas.Select(Map).ToList();
        public static List<Data.Pizzas> Map(IEnumerable<Pizza> pizzas) => pizzas.Select(Map).ToList();

       
    }
}
