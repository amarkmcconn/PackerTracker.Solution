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
    }
  }
}