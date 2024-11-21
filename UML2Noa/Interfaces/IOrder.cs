using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

public interface IOrder
{
    int Id { get; set; }
    bool ToBeDelivered { get; set; }

    void AddToOrder(OrderLine line);
    double CalculateTotal();
    void PrintReciept();
    string ToString();
}

