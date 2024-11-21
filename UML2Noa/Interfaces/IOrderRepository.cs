using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public interface IOrderRepository
{
    public int Count {  get; set; }
    List<Order> GetAll();
    void AddOrder(Order order);
    Order GetOrderByID(int id);
    void RemoveOrder(int id);
    void PrintAllOrder();
    string ToString();
}
