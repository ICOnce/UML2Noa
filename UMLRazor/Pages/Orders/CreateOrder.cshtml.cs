using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc;
using PizzaLibrary.Models;
using PizzaLibrary.Interfaces;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace UMLRazor.Pages.Orders
{
    public class CreateOrderModel : PageModel
    {
        private ICustomerRepository _cRepo;
        private IMenuRepository _mRepo;
        private IShoppingBasket _basket;
        [BindProperty]
        public string SearchCustomerMobile { get; set; }

        [BindProperty]
        public int ChosenMenuItem { get; set; }

        public Customer TheCustomer { get; set; }

        public List<SelectListItem> MenuItemSelectList { get; set; }

        [BindProperty]
        public int Amount { get; set; }

        [BindProperty]
        public string Comment { get; set; }

        public List<OrderLine> OrderLines { get; set; }

        public CreateOrderModel(ICustomerRepository cRepo, IMenuRepository mRepo, IShoppingBasket basket)
        {
            OrderLines = new List<OrderLine>();
            _cRepo = cRepo;
            _mRepo = mRepo;
            _basket = basket;
            TheCustomer = _basket.Customer;
            createMenuSelectList();
        }

        private void createMenuSelectList()
        {
            MenuItemSelectList = new List<SelectListItem>();
            MenuItemSelectList.Add(new SelectListItem("Select an item", "-1"));
            foreach (MenuItem item in _mRepo.GetAll())
            {
                MenuItemSelectList.Add(new SelectListItem(item.Name, item.No + ""));
            }
        }

        public void OnGet()
        {
        }

        public void OnPostCustomer()
        {
            TheCustomer = _cRepo.GetCustomerByMobile(SearchCustomerMobile);
            _basket.Customer = TheCustomer;
            if (TheCustomer == null)
            {
                //Return error
            }
        }

        public void OnPostAddToOrder()
        {
            TheCustomer = _basket.Customer;
            if (Amount > 0)
            {
                MenuItem menuItemToOrder = _mRepo.GetMenuItemByNo(ChosenMenuItem);
                if (menuItemToOrder != null)
                {
                    OrderLine ol = new OrderLine(menuItemToOrder, Amount, Comment);
                    _basket.AddOrderLine(ol);
                }
                OrderLines = _basket.GetAll();
            }
        }
    }
}