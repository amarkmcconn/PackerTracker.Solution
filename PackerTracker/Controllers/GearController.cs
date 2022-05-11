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
    public ActionResult EditPurchase(int id)
    {
      Gear foundGear = Gear.Find(id);
      foundGear.GearPurchased();
      return RedirectToAction("Show", new { id = id });
    }

    [HttpGet("/gear/pack/{id}")]
    public ActionResult EditPack(int id)
    {
      Gear foundGear = Gear.Find(id);
      foundGear.GearPacked();
      return RedirectToAction("Show", new { id = id });
    }

    [HttpGet("/gear/pack/gearlist/{id}")]
    public ActionResult EditPackGearList(int id)
    {
      Gear foundGear = Gear.Find(id);
      foundGear.GearPacked();
      return RedirectToAction("Index");
    }

      [HttpGet("/gear/purchase/gearlist/{id}")]
    public ActionResult EditPurchaseGearList(int id)
    {
      Gear foundGear = Gear.Find(id);
      foundGear.GearPurchased();
      return RedirectToAction("Index");
    }
    
    [HttpPost("/gear/delete/{id}")]
    public ActionResult Delete(int id)
    {
      Gear.DeleteGear(id);
      return RedirectToAction("Index");
    }
  }
}