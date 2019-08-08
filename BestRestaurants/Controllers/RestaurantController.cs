using Microsoft.AspNetCore.Mvc;
using BestRestaurants.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BestRestaurants.Controllers
{
    public class RestaurantGroupController : Controller
    {
        private readonly BestRestaurantsContext _db;

        public RestaurantGroupController(BestRestaurantsContext db)
        {
            _db = db;
        }

        public ActionResult Index()
        {
            List<Restaurant> model = _db.RestaurantGroup.Include(restaurantGroup => restaurantGroup.Cousine).ToList();
            return View(model);
        }

        public ActionResult Create()
        {
            ViewBag.CousineId = new SelectList(_db.CousineGroup, "CousineId", "Name");
            return View();
        }

        [HttpPost]
        public ActionResult Create(Restaurant restaurant)
        {
            _db.RestaurantGroup.Add(restaurant);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Details(int id)
        {
            Restaurant thisRestaurant = _db.RestaurantGroup.FirstOrDefault(restaurantGroup => restaurantGroup.RestaurantId == id);
            return View(thisRestaurant);
        }

        public ActionResult Edit(int id)
        {
            var thisRestaurant = _db.RestaurantGroup.FirstOrDefault(restaurantGroup => restaurantGroup.RestaurantId == id);
            ViewBag.CousineId = new SelectList(_db.CousineGroup, "CousineId", "Name");
            return View(thisRestaurant);
        }

        [HttpPost]
        public ActionResult Edit(Restaurant restaurant)
        {
            _db.Entry(restaurant).State = EntityState.Modified;
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            var thisRestaurant = _db.RestaurantGroup.FirstOrDefault(restaurantGroup => restaurantGroup.RestaurantId == id);
            return View(thisRestaurant);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            var thisRestaurant = _db.RestaurantGroup.FirstOrDefault(restaurantGroup => restaurantGroup.RestaurantId == id);
            _db.RestaurantGroup.Remove(thisRestaurant);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DeleteAll()
        {
            var allRestaurantGroup = _db.RestaurantGroup.ToList();
            return View();
        }

        [HttpPost, ActionName("DeleteAll")]
            public ActionResult DeleteAllConfirmed()
        {
            var allRestaurantGroup = _db.RestaurantGroup.ToList();

        foreach (var restaurant in allRestaurantGroup)
        {
            _db.RestaurantGroup.Remove(restaurant);
        }
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
