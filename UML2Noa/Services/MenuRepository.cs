using PizzaLibrary.Interfaces;
using PizzaLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaLibrary.Services
{
    public class MenuRepository : IMenuRepository
    {
        List<MenuItem> _menuItemList = new List<MenuItem>();
        public int Count { get { return _menuItemList.Count(); } }

        public MenuRepository() 
        {
            _menuItemList = MockData.MenuItemData;
        }
        public void AddMenuItem(MenuItem menuItem)
        {
            _menuItemList.Add(menuItem);
        }

        public List<MenuItem> GetAll()
        {
            return _menuItemList;
        }

        public MenuItem GetMenuItemByNo(int no)
        {
            foreach (MenuItem item in _menuItemList)
            {
                if (item.No == no) return item;
            }
            return null;
        }

        public void PrintAllMenuItems()
        {
            foreach (MenuItem menuItem in _menuItemList)
            {
                menuItem.ToString();
            }
        }

        public void RemoveMenuItem(int no)
        {
            foreach(MenuItem item in _menuItemList)
            {
                if (item.No == no) 
                { 
                    _menuItemList.Remove(item);
                    return;
                }
            }
        }

        public override string ToString()
        {
            string result = $"{Count} elements in MenuRepository\n";
            foreach (MenuItem menuItem in _menuItemList)
            {
                result += "\n, " + menuItem.ToString();
            }
            return result;
        }
    }
}
