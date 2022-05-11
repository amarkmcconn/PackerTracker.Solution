using System.Collections.Generic;

namespace PackerTracker.Models
{
  public class Gear
  {
    public bool Packed { get; set; }
    public string Name { get; set; }
    public int Weight { get; set; }
    public string Manufacturer { get; set; }
    public bool Purchased { get; set; }
    public int Id { get; set; }
    private static List<Gear> _instances = new List<Gear> {};

    public Gear()
    {
    }

    public Gear(string name, bool packed, string manufacturer, int weight, bool purchased)
    {
      Name = name;
      Packed = packed;
      Manufacturer = manufacturer;
      Weight = weight;
      Purchased = purchased;
      _instances.Add(this);
      Id = _instances.Count;
    }

    public static List<Gear> GetAll()
    {
      return _instances;
    }

    public static void ClearAll()
    {
      _instances.Clear();
    }

    public void GearPacked()
    {
      if(Packed == false)
      {
        Packed = true;
      }
      else
      {
        Packed = false;
      }
    }

    public void GearPurchased()
    {
      if(Purchased == false)
      {
        Purchased = true;
      }
      else
      {
        Purchased = false;
      }
      
    }

    public static Gear Find(int searchId)
    {
      int tempIndex = searchId;
      for(int i = 0; i<_instances.Count; i++)
      {
        if( _instances[i].Id == searchId)
        {
          tempIndex = i;
        }
      }

      return _instances[tempIndex];
    }

    public static void DeleteGear(int searchId)
    {
      for(int i = 0; i<_instances.Count; i++)
      {
        if( _instances[i].Id == searchId)
        {
          _instances.RemoveAt(i);
        }
      }
      // _instances.RemoveAt(searchId-1);
    }
  }
}