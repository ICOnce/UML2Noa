using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PizzaLibrary.Interfaces;
using PizzaLibrary.Models;

namespace UMLRazor.Pages.MenuItems
{
    public class ShowMenuItemsModel : PageModel
    {
        private IMenuRepository _mr;

        public List<MenuItem> Mr { get; private set; }

        public ShowMenuItemsModel(IMenuRepository mr)
        {
            _mr = mr;
        }
        public void OnGet()
        {
            Mr = _mr.GetAll();
        }
    }
}
