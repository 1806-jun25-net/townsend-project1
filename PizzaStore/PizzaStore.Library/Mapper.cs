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
            Beef = location.Beef,
            Olives = location.Olives,
            Onions = location.Onions,
            Dough = location.Dough,
            MarinaraSauce = location.MarinaraSauce,
            BuffaloSauce = location.BuffaloSauce,
            BBQSauce = location.Bbqsauce

        };
        public static Data.Locations Map(Location location) => new Data.Locations
        {
            //StoreId = location.StoreID,
            Pepperoni = location.Pepperoni,
            Sausage = location.Sausage,
            Chicken = location.Chicken,
            Bacon = location.Bacon,
            Beef = location.Beef,
            Olives = location.Olives,
            Onions = location.Onions,
            Dough = location.Dough,
            MarinaraSauce = location.MarinaraSauce,
            BuffaloSauce = location.BuffaloSauce,
            Bbqsauce = location.BBQSauce

        };

        public static Order Map(Data.Orders order) => new Order
        {
            OrderID = order.OrderId,
            OrderTime = order.OrderTime,
            Price = order.Price,
            UserID = order.UserId,
            StoreID = order.StoreId
        };

        public static Data.Orders Map(Order order) => new Data.Orders
        {
            OrderTime = order.OrderTime,
            Price = order.Price,
            UserId = order.UserID,
            StoreId = order.StoreID
        };
        public static Pizza Map(Data.Pizzas pizza) => new Pizza
        {
            PizzaID = pizza.PizzaId,
            Sauce = pizza.Sauce,
            Crust = pizza.Crust,
            Size = pizza.Size,
            Price = pizza.Price,
            OrderID = pizza.OrderId
        };

        public static Data.Pizzas Map(Pizza pizza) => new Data.Pizzas
        {
            Sauce = pizza.Sauce,
            Crust = pizza.Crust,
            Size = pizza.Size,
            Price = pizza.Price,
            OrderId = pizza.OrderID
        };

        public static Topping Map(Data.Toppings topping) => new Topping
        {
            Name = topping.Name,
            PizzaID = topping.PizzaId,
        };

        public static Data.Toppings Map(Topping topping) => new Data.Toppings
        {
            Name = topping.Name,
            PizzaId = topping.PizzaID
        };


        
        public static List<EndUser> Map(IEnumerable<Data.Users> users) => users.Select(Map).ToList();
        public static List<Data.Users> Map(IEnumerable<EndUser> users) => users.Select(Map).ToList();

        public static List<Location> Map(IEnumerable<Data.Locations> locations) => locations.Select(Map).ToList();
        public static List<Data.Locations> Map(IEnumerable<Location> locations) => locations.Select(Map).ToList();

        public static List<Order> Map(IEnumerable<Data.Orders> orders) => orders.Select(Map).ToList();
        public static List<Data.Orders> Map(IEnumerable<Order> orders) => orders.Select(Map).ToList();

        public static List<Pizza> Map(IEnumerable<Data.Pizzas> pizzas) => pizzas.Select(Map).ToList();
        public static List<Data.Pizzas> Map(IEnumerable<Pizza> pizzas) => pizzas.Select(Map).ToList();

        public static List<Topping> Map(IEnumerable<Data.Toppings> toppings) => toppings.Select(Map).ToList();
        public static List<Data.Toppings> Map(IEnumerable<Topping> toppings) => toppings.Select(Map).ToList();
    }
}
