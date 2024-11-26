using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class OrderRepository : IOrderRepository
{
    private List<Order> _orderList;

    public int Count { get { return _orderList.Count; } }

    public void AddOrder(Order order)
    {
        _orderList.Add(order);
    }

    public List<Order> GetAll()
    {
        return _orderList;
    }

    public Order GetOrderByID(int id)
    {
        foreach (Order order in _orderList)
        {
            if (order.Id == id) return order;
        }
        return null;
    }

    public void PrintAllOrder()
    {
        foreach (Order order in _orderList)
        {
            Console.WriteLine(order.ToString());
        }
    }

    public void RemoveOrder(int id)
    {
        foreach (Order order in _orderList)
        {
            if (order.Id == id) _orderList.Remove(order);
        }
    }

    public override string ToString()
    {
        string temp = "";
        foreach (Order order in _orderList)
        {
            temp += "\n" + order.ToString();
        }
        temp += "\nCount:" + Count;
        return temp;
    }
}
