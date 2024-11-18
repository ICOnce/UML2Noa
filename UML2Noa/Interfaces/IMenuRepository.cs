using PizzaLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaLibrary.Interfaces
{
    public interface IMenuRepository
    {
        int Count { get; }
        List<MenuItem> GetAll();
        void AddMenuItem(MenuItem menuItem);
        MenuItem GetMenuItemByNo(int no);
        MenuItem MostExpensivePizza();
        void RemoveMenuItem(int no);
        void EditMenuItem(int no, string name, string description, MenuType theMenuType, double price);
        void PrintAllMenuItems();

    }
}
