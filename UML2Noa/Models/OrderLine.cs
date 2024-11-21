using Microsoft.VisualBasic.FileIO;
using PizzaLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class OrderLine : IOrderLine
{
    MenuItem _menuItem;
    List<Accessory> _accessories;
    private static int _count;
    public int Amount { get; set; }
    public string Comment { get; set; }
    public int Id { get; set; }
    public MenuItem Item { get { return _menuItem; } set { _menuItem = value; } }

    public OrderLine(MenuItem menuItem, int amount, string comment)
    {
        _accessories = new List<Accessory>();
        _menuItem = menuItem;
        Amount = amount;
        Comment = comment;
    }

    public void AddExtraAccessory(Accessory accessory)
    {
        _accessories.Add(accessory);
    }

    public double SubTotal()
    {
        double total = _menuItem.Price;
        foreach (Accessory accessory in _accessories)
        {
            total += accessory.Price;
        }
        return total;
    }

    public override string ToString()
    {
        string temp = $"Id: {Id}\nItem: {_menuItem}\nAccessories: ";
        foreach (Accessory accessory in _accessories) { temp += accessory.ToString() + ", "; }
        temp += "\n" + Comment;
        temp += "\n" + Amount;
        temp += "\n" + SubTotal();
        return temp;
    }
}
