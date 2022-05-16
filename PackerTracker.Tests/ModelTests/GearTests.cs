using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using PackerTracker.Models;
using MySql.Data.MySqlClient;

namespace PackerTracker.Tests
{
  [TestClass]
  public class GearTests : IDisposable
  {
    public void Dispose()
    {
      Gear.ClearAll();
    }
    public GearTests()
    {
     DBConfiguration.ConnectionString = "server=localhost;user id=root;password=epicodus;port=3306;database=packer_tracker_test;"; 
    }
    
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
    
    [TestMethod]
    public void GetAll_ReturnsEmptyListFromDatabase_GearList()
    {
      // Arrange
      List<Gear> newList = new List<Gear> { };

      // Act
      List<Gear> result = Gear.GetAll();

      // Assert
      CollectionAssert.AreEqual(newList, result);
    }

    [TestMethod]
    public void GetAll_ReturnsItems_GearList()
    {
      string name1 = "chair";
      bool packed1 = true;
      int weight1 = 3;
      string manufacturer1 = "ozark";
      bool purchased1 = false;
      Gear newGear1 = new Gear(name1, packed1, manufacturer1, weight1, purchased1);
      newGear1.Save();
      string name2 = "tent";
      bool packed2 = true;
      int weight2 = 4;
      string manufacturer2 = "canvas";
      bool purchased2 = true;
      Gear newGear2 = new Gear(name2, packed2, manufacturer2, weight2, purchased2);
      newGear2.Save();
      List<Gear> newList = new List<Gear> { newGear1, newGear2 };
      
      // Act
      List<Gear> result = Gear.GetAll();

      // Assert
      CollectionAssert.AreEqual(newList, result);
    }
    [TestMethod]
    public void Save_SavesToDatabase_GearList()
    {
      //Arrange
      string name1 = "chair";
      bool packed1 = true;
      int weight1 = 3;
      string manufacturer1 = "ozark";
      bool purchased1 = false;
      Gear testGear = new Gear(name1, packed1, manufacturer1, weight1, purchased1);

      //Act
      testGear.Save();
      List<Gear> result = Gear.GetAll();
      List<Gear> testList = new List<Gear>{testGear};

      //Assert
      CollectionAssert.AreEqual(testList, result);
    }

    [TestMethod]
    public void Find_ReturnsCorrectGearFromDatabase_Gear()
    {
      string name1 = "chair";
      bool packed1 = true;
      int weight1 = 3;
      string manufacturer1 = "ozark";
      bool purchased1 = false;
      Gear newGear1 = new Gear(name1, packed1, manufacturer1, weight1, purchased1);
      newGear1.Save();
      string name2 = "tent";
      bool packed2 = true;
      int weight2 = 4;
      string manufacturer2 = "canvas";
      bool purchased2 = true;
      Gear newGear2 = new Gear(name2, packed2, manufacturer2, weight2, purchased2);
      newGear2.Save();

      Gear foundGear = Gear.Find(newGear1.Id);
      Assert.AreEqual(newGear1, foundGear);
    }

    // [TestMethod]
    // public void GearPacked_UpdatesPackedStatus_True()
    // {
    //   string name1 = "chair";
    //   bool packed1 = false;
    //   int weight1 = 3;
    //   string manufacturer1 = "ozark";
    //   bool purchased1 = false;
    //   Gear newGear1 = new Gear(name1, packed1, manufacturer1, weight1, purchased1);

    //   newGear1.GearPacked();
    //   Assert.AreEqual(true, newGear1.Packed);
    // }

    // [TestMethod]
    // public void GearPurchased_UpdatesPurchasedStatus_True()
    // {
    //   string name1 = "chair";
    //   bool packed1 = false;
    //   int weight1 = 3;
    //   string manufacturer1 = "ozark";
    //   bool purchased1 = false;
    //   Gear newGear1 = new Gear(name1, packed1, manufacturer1, weight1, purchased1);

    //   newGear1.GearPurchased();
    //   Assert.AreEqual(true, newGear1.Purchased);
    // }

    // [TestMethod]
    // public void DeleteGear_DeletesSpecificGearFromList_GearList()
    // {
    //   string name1 = "chair";
    //   bool packed1 = false;
    //   int weight1 = 3;
    //   string manufacturer1 = "ozark";
    //   bool purchased1 = false;
    //   Gear newGear1 = new Gear(name1, packed1, manufacturer1, weight1, purchased1);
    //   string name2 = "tent";
    //   bool packed2 = true;
    //   int weight2 = 4;
    //   string manufacturer2 = "canvas";
    //   bool purchased2 = true;
    //   Gear newGear2 = new Gear(name2, packed2, manufacturer2, weight2, purchased2);
    //   List<Gear> newList = new List<Gear> { newGear2 };
      
    //   Gear.DeleteGear(newGear1.Id);
    //   List<Gear> result = Gear.GetAll();
    //   CollectionAssert.AreEqual(newList, result);
    // }
  }
}