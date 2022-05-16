using System.Collections.Generic;
using MySql.Data.MySqlClient;
using System;

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
    // private static List<Gear> _instances = new List<Gear> {};

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
    //   _instances.Add(this);
      // Id = id;
    }

    public Gear(string name, bool packed, string manufacturer, int weight, bool purchased, int id)
    {
      Id = id;
      Name = name;
      Packed = packed;
      Manufacturer = manufacturer;
      Weight = weight;
      Purchased = purchased;
    }
    
    public static List<Gear> GetAll()
    {
      List<Gear> allGear = new List<Gear> { };
      MySqlConnection conn = DB.Connection();
      conn.Open();
      MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = "SELECT * FROM gear;";
      MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;
      while (rdr.Read())
      {
          int gearId = rdr.GetInt32(0);
          string gearName = rdr.GetString(1);
          string gearManufacturer = rdr.GetString(2);
          int gearWeight = rdr.GetInt32(3);
          bool gearPacked = Convert.ToBoolean(rdr.GetByte(4));
          bool gearPurchased = Convert.ToBoolean(rdr.GetByte(5));

          Gear newGear = new Gear(gearName, gearPacked, gearManufacturer, gearWeight, gearPurchased, gearId);
          allGear.Add(newGear);
      }
      conn.Close();
      if (conn != null)
      {
          conn.Dispose();
      }
      return allGear;
      
    }

    public static void ClearAll()
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();
      MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = "DELETE FROM gear;";
      cmd.ExecuteNonQuery();
      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
    }

    public void GearPacked()
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();
      MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
      // cmd.CommandText = "SELECT DISTINCT packed FROM gear;";
      cmd.CommandText = "UPDATE packed FROM gear;";
      if(Packed == false)
      {
        Packed = true;
      }
      else
      {
        Packed = false;
      }
      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
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

    public static Gear Find(int id)
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();
      MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = "SELECT * FROM gear WHERE id = @ThisId;";
      MySqlParameter param = new MySqlParameter();
      param.ParameterName = "@ThisId";
      param.Value = id;
      cmd.Parameters.Add(param);
      MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;
      int gearId = 0;
      string gearName = "";
      bool gearPacked = false;
      bool gearPurchased = false;
      string gearManufacturer = "";
      int gearWeight = 0;
      while (rdr.Read())
      {
        gearId = rdr.GetInt32(0);
        gearName = rdr.GetString(1);
        gearManufacturer = rdr.GetString(2);
        gearWeight = rdr.GetInt32(3);
        gearPacked = Convert.ToBoolean(rdr.GetByte(4));
        gearPurchased = Convert.ToBoolean(rdr.GetByte(5));
      }
      Gear foundItem = new Gear(gearName, gearPacked, gearManufacturer, gearWeight, gearPurchased, gearId);

      // We close the connection.
      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
      return foundItem;
    }

    public void Save()
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();
      MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;

      // Begin new code

      cmd.CommandText = "INSERT INTO gear (name, manufacter, weight, packed, purchased) VALUES (@gearName, @gearManufacturer, @gearWeight, @gearPacked, @gearPurchased);";
      MySqlParameter paramName = new MySqlParameter();
      paramName.ParameterName = "@gearName";
      paramName.Value = this.Name;
      cmd.Parameters.Add(paramName);
      cmd.Parameters.AddWithValue("@gearManufacturer", this.Manufacturer);
      cmd.Parameters.AddWithValue("@gearWeight", this.Weight);
      cmd.Parameters.AddWithValue("@gearPacked", this.Packed);
      cmd.Parameters.AddWithValue("@gearPurchased", this.Purchased);     
      cmd.ExecuteNonQuery();
      Id = (int) cmd.LastInsertedId;

      // End new code

      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
    }

    public override bool Equals(System.Object otherGear)
    {
      if(!(otherGear is Gear))
      {
        return false;
      }
      else
      {
        Gear newGear = (Gear) otherGear;
        bool idEquality = (this.Id == newGear.Id);
        bool nameEquality = (this.Name == newGear.Name);
        bool manufacturerEquality = (this.Manufacturer == newGear.Manufacturer);
        bool weightEquality = (this.Weight == newGear.Weight);
        bool packedEquality = (this.Packed == newGear.Packed);
        bool purchasedEquality = (this.Purchased == newGear.Purchased);
        return (idEquality && nameEquality && manufacturerEquality && weightEquality && packedEquality && purchasedEquality);
      }
    }

    public static void DeleteGear(int searchId)
    {
    //   for(int i = 0; i<_instances.Count; i++)
    //   {
    //     if( _instances[i].Id == searchId)
    //     {
    //       _instances.RemoveAt(i);
    //     }
    //   }
      // _instances.RemoveAt(searchId-1);
    }

    
  }
}