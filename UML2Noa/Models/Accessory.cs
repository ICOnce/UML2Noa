using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Accessory : IAccessory
{
    private int _id;
    private string _name;
    private static int _count = 0;

    public int Id { get { return _id; } set { _id = value; } }
    public string Name { get { return _name; } set { _name = value; } }
    public double Price { get; set; }

    public Accessory(string name, double price)
    {
        Price = price;
        Name = name;
        Id = _count;
        _count++;
    }

    public override string ToString()
    {
        return $"ID: {_id}, Name: {_name}, Price: {Price}";
    }
}
