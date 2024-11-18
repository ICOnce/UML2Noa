using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PizzaLibrary.Interfaces;
using PizzaLibrary.Models;

namespace UMLRazor.Pages.MenuItems
{
    public class DeleteMenuItemModel : PageModel
    {
        IMenuRepository _mRepo;

        [BindProperty]


        public MenuItem Item { get; set; }

        public DeleteMenuItemModel(IMenuRepository mRepo)
        {
            _mRepo = mRepo;
        }
        public void OnGet(int number)
        {
            MenuItem.counter--;
            Item = _mRepo.GetMenuItemByNo(number);
        }

        public IActionResult OnPost()
        {
            if (_mRepo.GetAll().Contains(_mRepo.GetMenuItemByNo(Item.No)))
            {
                _mRepo.RemoveMenuItem(Item.No);
            }
            return RedirectToPage("ShowMenuItems");
        }
    }
}
