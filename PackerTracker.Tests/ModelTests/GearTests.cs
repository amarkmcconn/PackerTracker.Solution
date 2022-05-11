using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using PackerTracker.Models;

namespace PackerTracker.Tests
{
  [TestClass]
  public class GearTests
  {
    [TestMethod]
    public void GearConstructor_CreatesInstanceOfGear_Gear()
    {
      Gear newGear = new Gear();
      Assert.AreEqual(typeof(Gear), newGear.GetType());
    }

    [TestMethod]
    public void GearConstructor_ReturnsInstanceOfGearName_Gear()
    {
      string name = "chair";
      bool packed = true;
      int weight = 3;
      string manufacturer = "ozark";
      bool purchased = false;
      Gear newGear = new Gear(name, packed, manufacturer, weight, purchased);
      string result = newGear.Name;
      Assert.AreEqual(name, result);
    }
    [TestMethod]
    public void GearConstructor_ReturnsInstanceOfGearPacked_True()
    {
      string name = "chair";
      bool packed = true;
      int weight = 3;
      string manufacturer = "ozark";
      bool purchased = false;
      Gear newGear = new Gear(name, packed, manufacturer, weight, purchased);
      bool result = newGear.Packed;
      Assert.AreEqual(packed, result);
    }
    [TestMethod]
    public void GearConstructor_ReturnsInstanceOfWeight_Int()
    {
      string name = "chair";
      bool packed = true;
      int weight = 3;
      string manufacturer = "ozark";
      bool purchased = false;
      Gear newGear = new Gear(name, packed, manufacturer, weight, purchased);
      int result = newGear.Weight;
      Assert.AreEqual(weight, result);
    }
    [TestMethod]
    public void GearConstructor_ReturnsInstanceOfGearManufacturer_Manufacturer()
    {
      string name = "chair";
      bool packed = true;
      int weight = 3;
      string manufacturer = "ozark";
      bool purchased = false;
      Gear newGear = new Gear(name, packed, manufacturer, weight, purchased);
      string result = newGear.Manufacturer;
      Assert.AreEqual(manufacturer, result);
    }
    [TestMethod]
    public void GearConstructor_ReturnsInstanceOfGearPurchased_False()
    {
      string name = "chair";
      bool packed = true;
      int weight = 3;
      string manufacturer = "ozark";
      bool purchased = false;
      Gear newGear = new Gear(name, packed, manufacturer, weight, purchased);
      bool result = newGear.Purchased;
      Assert.AreEqual(purchased, result);
    }
  }
}