using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Lib = PizzaStore.Library;
using PizzaStore.UI.Models;
using PizzaStore.Library.PizzaClassRepo;

namespace PizzaStore.UI.Controllers
{
    public class UsersController : Controller
    {
        // GET: Users
        PizzaStoreRepo Repo { get; }

        public UsersController(PizzaStoreRepo repo)
        {
            Repo = repo;
        }
        [HttpPost]
        public ActionResult Login(OrderDisplay model)
        {
            var userList = Repo.GetUsers();
            
            OrderDisplay order = new OrderDisplay();
            order.FirstName = model.FirstName;
            order.LastName = model.LastName;
            bool exists = false;
            foreach (var user in userList)
            {
                if (user.FirstName == model.FirstName && user.LastName == model.LastName)
                {
                    order.UserID = user.UserID;
                    order.StoreLocation = user.StoreLocation;
                    order.OrderPref = user.OrderPref;
                    exists = true;
                    break;
                }
            }
            if (exists == false)
            {
                Lib.EndUser user = new Lib.EndUser()
                {
                    FirstName = order.FirstName,
                    LastName = order.LastName
                };
                Repo.AddUser(user);
                Repo.Save();
            }

            return View("PlaceOrder", order);
        }
        public ActionResult Index([FromQuery]string search = "")
        {
            var libRests = Repo.GetUsers(search);
            var webRests = libRests.Select(x => new User
            {
                UserID = x.UserID,
                FirstName = x.FirstName,
                LastName = x.LastName,
                OrderPref = x.OrderPref,
                StoreLocation = x.StoreLocation

            });
            return View(webRests);
        }
        // GET: Users/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Users/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Users/Create
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

        // GET: Users/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Users/Edit/5
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

        // GET: Users/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Users/Delete/5
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