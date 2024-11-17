using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PizzaLibrary.Interfaces;
using PizzaLibrary.Models;

namespace UMLRazor.Pages.MenuItems
{
    public class AddMenuItemModel : PageModel
    {
        private IMenuRepository _menuRepo;


        [BindProperty] //Two way binding
        public string _menuType {  get; set; }
        [BindProperty]
        public MenuItem Item { get; set; }

        public AddMenuItemModel(IMenuRepository menuRepo)
        {
            _menuRepo = menuRepo;
        }

        public void OnGet()
        {

        }

        public IActionResult OnPost()
        {
            switch (_menuType.ToUpper())
            {
                case "SANDWICHES":
                    Item.TheMenuType = MenuType.SANDWICHES;
                    break;
                case "BRUCHETTA_CROSTINO":
                    Item.TheMenuType = MenuType.BRUCHETTA_CROSTINO;
                    break;
                case "SALATER":
                    Item.TheMenuType = MenuType.SALATER;
                    break;
                case "PIZZECLASSSICHE":
                    Item.TheMenuType = MenuType.PIZZECLASSSICHE;
                    break;
                case "PIZZESPECIALI":
                    Item.TheMenuType = MenuType.PIZZESPECIALI;
                    break;
                case "PASTAALFORNO":
                    Item.TheMenuType = MenuType.PASTAALFORNO;
                    break;
                case "TILBEH�R":
                    Item.TheMenuType = MenuType.TILBEH�R;
                    break;
                default:
                    Item.TheMenuType = MenuType.TILBEH�R;
                    break;
            }
            _menuRepo.AddMenuItem(Item);
            return RedirectToPage("ShowMenuItems");
        }
    }
}
