using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PizzaStore.UI.Models;
using PizzaStore.Library.PizzaClassRepo;
using Lib = PizzaStore.Library;
namespace PizzaStore.UI.Controllers
{
    public class OrdersController : Controller
    {
        PizzaStoreRepo Repo { get; }

        public OrdersController(PizzaStoreRepo repo)
        {
            Repo = repo;
        }
        public ActionResult PlaceOrder(OrderDisplay model)
        {
            var orderList = Repo.GetOrders();

            Lib.EndUser user = Repo.GetUserById(Repo.GetUserID(model.FirstName, model.LastName));
            Repo.UpdateUser(user);
            Repo.Save();
            Lib.Order order = new Lib.Order();
            order.UserID = Repo.GetUserID(model.FirstName, model.LastName);
            order.StoreID = model.StoreLocation;
            order.OrderTime = DateTime.Now;
            model.OrderTime = DateTime.Now;

            Lib.Pizza pizza = new Lib.Pizza();
            pizza.Size = model.Size;
            pizza.Crust = model.Crust;
            pizza.Sauce = model.Sauce;
            pizza.Bacon = model.Bacon;
            pizza.Pepperoni = model.Pepperoni;
            pizza.Sausage = model.Sausage;
            pizza.Chicken = model.Chicken;
            pizza.Onions = model.Onions;
            pizza.Olives = model.Olives;
            
            pizza.Price = pizza.CalculatePrice(pizza);
            order.Price = pizza.Price * model.PizzaCount;
            Repo.AddOrder(order);
            Repo.Save();
            pizza.OrderID = Repo.GetOrderID(order.UserID);
            Repo.AddPizza(pizza);
            Repo.Save();

            user.StoreLocation = model.StoreLocation;
            user.OrderPref = model.PizzaID;
            Repo.UpdateUser(user);
            Repo.Save();
            model.Price = order.Price;
            Lib.Location store = Repo.GetStoreByID(order.StoreID);
            for (int i = 0; i < model.PizzaCount; i++)
            {
                if (pizza.Pepperoni)
                    store.Pepperoni--;
                if (pizza.Chicken)
                    store.Chicken--;
                if (pizza.Sausage)
                    store.Sausage--;
                if (pizza.Bacon)
                    store.Bacon--;
                if (pizza.Olives)
                    store.Olives--;
                if (pizza.Onions)
                    store.Onions--;
                if (pizza.Sauce == "BBQ")
                    store.BBQSauce--;
                else if (pizza.Sauce == "Buffalo")
                    store.BuffaloSauce--;
                else if (pizza.Sauce == "Marinara")
                    store.MarinaraSauce--;
                store.Dough--;
                store.Cheese--;
            }
            Repo.UpdateLocation(store);
            Repo.Save();

            return View("OrderPlaced", model);
        }

        public ActionResult UserHistory(int id)
        {
            var orderList = Repo.GetOrdersByUserID(id);
            var webOrders = orderList.Select(x => new Order
            {
                OrderID = x.OrderID,
                StoreID = x.StoreID,
                UserID = x.UserID,
                OrderTime = x.OrderTime,
                Price = x.Price
            });
            return View("Index", webOrders);
        }
        public ActionResult StoreHistory(int id)
        {
            var orderList = Repo.GetOrdersByStoreID(id);
            var webOrders = orderList.Select(x => new Order
            {
                OrderID = x.OrderID,
                StoreID = x.StoreID,
                UserID = x.UserID,
                OrderTime = x.OrderTime,
                Price = x.Price
            });
            return View("Index", webOrders);
        }

        public ActionResult NewestPost()
        {
            var orderList = Repo.GetNewest();
            var webOrders = orderList.Select(x => new Order
            {
                OrderID = x.OrderID,
                UserID = x.UserID,
                StoreID = x.StoreID,
                OrderTime = x.OrderTime,
                Price = x.Price
            });
            return View("Index", webOrders);
        }
        public ActionResult OldestPost()
        {
            var orderList = Repo.GetOldest();
            var webOrders = orderList.Select(x => new Order
            {
                OrderID = x.OrderID,
                UserID = x.UserID,
                StoreID = x.StoreID,
                OrderTime = x.OrderTime,
                Price = x.Price
            });
            return View("Index", webOrders);
        }
        public ActionResult OrderPriceHigh()
        {
            var orderList = Repo.GetExpensive();
            var webOrders = orderList.Select(x => new Order
            {
                OrderID = x.OrderID,
                UserID = x.UserID,
                StoreID = x.StoreID,
                OrderTime = x.OrderTime,
                Price = x.Price
            });
            return View("Index", webOrders);
        }
        public ActionResult OrderPriceLow()
        {
            var orderList = Repo.GetCheap();
            var webOrders = orderList.Select(x => new Order
            {
                OrderID = x.OrderID,
                UserID = x.UserID,
                StoreID = x.StoreID,
                OrderTime = x.OrderTime,
                Price = x.Price
            });
            return View("Index", webOrders);
        }
        public ActionResult Index([FromQuery]string search = "")
        {
            var libRests = Repo.GetOrders(search);
            var webRests = libRests.Select(x => new Order
            {
                OrderID = x.OrderID,
                UserID = x.UserID,
                StoreID = x.StoreID,
                OrderTime = x.OrderTime,
                Price = x.Price

            });
            return View(webRests);
        }

        
        
        

        // POST: Orders/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Orders/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Orders/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Orders/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Orders/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}