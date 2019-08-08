using Microsoft.AspNetCore.Mvc;
using BestRestaurants.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace BestRestaurants.Controllers
{
  public class CousineGroupController : Controller
  {
    private readonly BestRestaurantsContext _db;

    public CousineGroupController(BestRestaurantsContext db)
    {
      _db = db;
    }

    public ActionResult Index()
    {
      List<Cousine> model = _db.CousineGroup.ToList();
      return View(model);
    }

    public ActionResult Create()
    {
      return View();
    }

    [HttpPost]
    public ActionResult Create(Cousine cousine)
    {
      _db.CousineGroup.Add(cousine);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Details(int id)
    {
      Cousine thisCousine = _db.CousineGroup.FirstOrDefault(cousine => cousine.CousineId == id);
      return View(thisCousine);
    }

    public ActionResult Edit(int id)
    {
      var thisCousine = _db.CousineGroup.FirstOrDefault(cousine => cousine.CousineId == id);
      return View(thisCousine);
    }

    [HttpPost]
    public ActionResult Edit(Cousine cousine)
    {
      _db.Entry(cousine).State = EntityState.Modified;
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Delete(int id)
    {
      var thisCousine = _db.CousineGroup.FirstOrDefault(cousine => cousine.CousineId == id);
      return View(thisCousine);
    }
    [HttpPost, ActionName("Delete")]
    public ActionResult DeleteConfirmed(int id)
    {
      var thisCousine = _db.CousineGroup.FirstOrDefault(cousine => cousine.CousineId == id);
      _db.CousineGroup.Remove(thisCousine);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult DeleteAll()
    {
      var allCousineGroup = _db.CousineGroup.ToList();
      return View();
    }

    [HttpPost, ActionName("DeleteAll")]
    public ActionResult DeleteAllConfirmed()
    {
      var allCousineGroup = _db.CousineGroup.ToList();

      foreach (var cousine in allCousineGroup)
      {
      _db.CousineGroup.Remove(cousine);
      }
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
  }
}
