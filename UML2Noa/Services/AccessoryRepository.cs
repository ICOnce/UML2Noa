using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class AccessoryRepository : IAccessoryRepository
{
    private List<Accessory> _accessories;
    public int Count { get { return _accessories.Count(); } }

    public AccessoryRepository()
    {
        _accessories = new List<Accessory>();
        _accessories.Add(new Accessory("Cheese", 5));
        _accessories.Add(new Accessory("Bacon", 5));
        _accessories.Add(new Accessory("Pepperoni", 5));
        _accessories.Add(new Accessory("Banana", 5));
        _accessories.Add(new Accessory("Peanuts", 5));
        _accessories.Add(new Accessory("Skinke", 5));
    }
    public void AddAccessory(Accessory accessory)
    {
        _accessories.Add(accessory);
    }

    public Accessory GetAccessory(int id)
    {
        foreach (Accessory accessory in _accessories)
        {
            if (accessory.Id == id) return accessory;
        }
        return null;
    }

    public List<Accessory> GetAll()
    {
        return _accessories;
    }

    public void PrintAllAccessories()
    {
        foreach (Accessory accessory in _accessories)
        {
            Console.WriteLine(accessory.ToString());
        }
    }

    public void RemoveAccessory(int id)
    {
        foreach (Accessory accessory in _accessories) 
        { 
            if (accessory.Id == id) _accessories.Remove(accessory); 
        }
    }

    public override string ToString()
    {
        string temp = "";
        foreach (Accessory accessory in _accessories)
        {
            temp += "\n" + accessory.ToString();
        }
        temp += "\nCount:" + Count;
        return temp;
    }
}
