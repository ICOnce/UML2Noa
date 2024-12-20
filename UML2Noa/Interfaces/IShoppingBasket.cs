﻿using PizzaLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public interface IShoppingBasket
{
    void AddOrderLine(OrderLine line);
    void RemoveOrderLine(OrderLine line);
    OrderLine GetOrderLine(int id);
    Customer Customer { get; set; }
    List<OrderLine> GetAll();
}

