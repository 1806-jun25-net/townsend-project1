using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PizzaStore.Library.PizzaClassRepo;
using Lib = PizzaStore.Library;
using PizzaStore.UI.Models;
namespace PizzaStore.UI.Controllers
{
    public class LocationsController : Controller
    {
        // GET: Location
        public PizzaStoreRepo Repo { get; }
        public LocationsController(PizzaStoreRepo repo)
        {
            Repo = repo;
        }
        public ActionResult Index()
        {
            var libRests = Repo.GetLocations();
            var webRests = libRests.Select(x => new Location
            {
                StoreID = x.StoreID,
                Pepperoni = x.Pepperoni,
                Bacon = x.Bacon,
                Chicken = x.Chicken,
                Sausage = x.Sausage,
                Olives = x.Olives,
                Onions = x.Onions,
                Dough = x.Dough,
                Cheese = x.Cheese,
                BBQSauce = x.BBQSauce,
                BuffaloSauce = x.BuffaloSauce,
                MarinaraSauce = x.MarinaraSauce


            });
            return View(webRests);
        }

        // GET: Location/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Location/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Location/Create
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

        // GET: Location/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Location/Edit/5
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

        // GET: Location/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Location/Delete/5
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