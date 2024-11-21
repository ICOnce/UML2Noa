using PizzaLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class ShoppingBasket : IShoppingBasket
{
    private List<OrderLine> _orderLines;
    public Customer Customer { get; set; }


    public ShoppingBasket()
    {
        _orderLines = new List<OrderLine>();
    }
    public void AddOrderLine(OrderLine line)
    {
        _orderLines.Add(line);
    }

    public List<OrderLine> GetAll()
    {
        return _orderLines;
    }
}
