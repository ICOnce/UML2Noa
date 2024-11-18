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

        public MenuRepository(List<MenuItem> menuList) 
        {
            _menuItemList = menuList;
        }
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

        public List<MenuItem> GetAllOverPrice(double max)
        {
            List<MenuItem> result = new List<MenuItem>();
            foreach (MenuItem item in _menuItemList)
            {
                if (item.Price > max) result.Add(item);
            }
            return result;
        }

        public MenuItem GetMenuItemByNo(int no)
        {
            foreach (MenuItem item in _menuItemList)
            {
                if (item.No == no) return item;
            }
            return null;
        }

        public MenuItem MostExpensivePizza()
        {
            MenuItem temp;
            temp = new MenuItem("Filler", 0, "Filler", MenuType.PIZZECLASSSICHE);
            foreach (MenuItem item in _menuItemList)
            {
                if (item.TheMenuType == MenuType.PIZZECLASSSICHE || item.TheMenuType == MenuType.PIZZESPECIALI)
                {
                    if (item.Price > temp.Price)
                    {
                        temp = item;
                    }
                }
            }
            return temp;
        }

        public void PrintAllMenuItems()
        {
            foreach (MenuItem menuItem in _menuItemList)
            {
                Console.WriteLine();
                Console.WriteLine(menuItem.ToString());
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

        public void EditMenuItem(int no, string name, string description, MenuType theMenuType, double price)
        {
            _menuItemList[no].Name = name;
            _menuItemList[no].Description = description;
            _menuItemList[no].Price = price;
            _menuItemList[no].TheMenuType = theMenuType;
            _menuItemList[no].Price = price;
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
