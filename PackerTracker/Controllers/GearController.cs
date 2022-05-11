using Microsoft.AspNetCore.Mvc;
using PackerTracker.Models;
using System.Collections.Generic;


namespace PackerTracker.Controllers
{
  public class GearController : Controller
  {
    [HttpGet("/gear")]
    public ActionResult Index()
    {
      List<Gear> allGear = Gear.GetAll();
      return View(allGear);
    }

    [HttpGet("/gear/new")]
    public ActionResult New()
    {
      return View();
    }

    [HttpPost("/gear")]
    public ActionResult Create(string name, string packed, string manufacturer, int weight, string purchased)
    {
      bool boolPacked = false;
      bool boolPurchased = false;
      if(packed == "true")
      {
        boolPacked = true;
      }
      if (purchased == "true")
      {
        boolPurchased = true;
      }

      Gear newGear = new Gear(name, boolPacked, manufacturer, weight, boolPurchased);
      return RedirectToAction("Index");
    }

    [HttpGet("/gear/{id}")]
    public ActionResult Show(int id)
    {
      Gear foundGear = Gear.Find(id);
      return View(foundGear);
    }
    [HttpPost("/gear/delete")]
    public ActionResult DeleteAll()
    {
      Gear.ClearAll();
      return View();
    }
    
    [HttpGet("/gear/purchase/{id}")]
    public ActionResult UpdatePurchase(int id)
    {
      Gear foundGear = Gear.Find(id);
      foundGear.GearPurchased();
      return RedirectToAction("Show", foundGear);
    }

    [HttpGet("/gear/pack/{id}")]
    public ActionResult UpdatePacked(int id)
    {
      Gear foundGear = Gear.Find(id);
      foundGear.GearPacked();
      return RedirectToAction("Show", foundGear);
    }

  }
}