using PizzaLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Order : IOrder
{
    private List<OrderLine> _orderLines;
    private Customer _customer;
    private DateTime _created;
    private int _count;
    private int _id;

    public int Id { get { return _id; } set { _id = value; } }
    public bool ToBeDelivered { get; set; }

    public Order(bool toBeDelivered, Customer customer)
    {
        _orderLines = new List<OrderLine>();
        _created = DateTime.Now;
        _customer = customer;
        ToBeDelivered = toBeDelivered;
        Id = _count;
        _count++;
    }

    public void AddToOrder(OrderLine line)
    {
        line.Id = _orderLines.Count;
        _orderLines.Add(line);
    }

    public double CalculateTotal()
    {
        double total = 0;
        foreach (OrderLine line in _orderLines) 
        {
            total += line.SubTotal();
        }
        return total;
    }

    public void PrintReciept()
    {
        Console.WriteLine(ToString());
    }

    public override string ToString()
    {
        string temp = $"ID: {_id}, Customer: {_customer}\nDate: {_created}\nShould be delivered: {ToBeDelivered}";
        foreach (OrderLine line in _orderLines) { temp += line.ToString(); }
        temp += "\n" + CalculateTotal();
        return temp;
    }
}

