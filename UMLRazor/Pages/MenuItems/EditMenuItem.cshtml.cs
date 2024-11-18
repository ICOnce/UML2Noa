using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PizzaLibrary.Interfaces;
using PizzaLibrary.Models;

namespace UMLRazor.Pages.MenuItems
{
    public class EditMenuItemModel : PageModel
    {

        private IMenuRepository _menuRepo;


        [BindProperty] //Two way binding
        public string _menuType { get; set; }
        [BindProperty]
        public MenuItem Item { get; set; }

        public EditMenuItemModel(IMenuRepository menuRepo)
        {
            _menuRepo = menuRepo;
        }

        public void OnGet(int editMenuItem)
        {
            MenuItem.counter--;
            Item = _menuRepo.GetMenuItemByNo(editMenuItem);
            _menuType = Item.TheMenuType.ToString();
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
            _menuRepo.EditMenuItem(Item.No, Item.Name, Item.Description, Item.TheMenuType, Item.Price);
            return RedirectToPage("ShowMenuItems");
        }
    }
}
