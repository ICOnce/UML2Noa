using PizzaLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public interface IOrderLine
{
    int Amount { get; set; }
    string Comment { get; set; }
    int Id { get; set; }
    MenuItem Item { get; set; }

    void AddExtraAccessory(Accessory accessory);
    double SubTotal();
    string ToString();
}

