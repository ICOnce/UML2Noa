using PizzaLibrary.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleMenu.Controllers.MenuItems
{
    public class ShowMenuItemController
    {
        private IMenuRepository _menuRepo;
        public ShowMenuItemController(IMenuRepository menuRepo) 
        {
            _menuRepo = menuRepo;
        }

        public void ShowAllMenuItems()
        {
            _menuRepo.PrintAllMenuItems();
        }
    }
}
