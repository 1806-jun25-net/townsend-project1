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
            

            
            Lib.Order order = new Lib.Order();
            order.UserID = Repo.GetUserID(model.FirstName, model.LastName);
            order.StoreID = model.StoreLocation;
            order.OrderTime = DateTime.Now;

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

            

            return View("OrderPlaced", model);
        }
        public ActionResult Index([FromQuery]string search = "")
        {
            var libRests = Repo.GetOrders(search);
            var webRests = libRests.Select(x => new Order
            {
                OrderID = x.OrderID,
                UserID = x.User.UserID,
                StoreID = x.StoreID,
                OrderTime = x.OrderTime,
                Price = x.Price

            });
            return View(webRests);
        }

        // GET: Orders/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Orders/Create
        public ActionResult Create()
        {
            return View();
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