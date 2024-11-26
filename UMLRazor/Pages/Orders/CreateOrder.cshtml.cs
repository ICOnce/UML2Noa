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
        private IAccessoryRepository _aRepo;
        [BindProperty]
        public string SearchCustomerMobile { get; set; }

        [BindProperty]
        public int ChosenMenuItem { get; set; }

        [BindProperty]
        public int ChosenExtra {  get; set; }

        [BindProperty]
        public int OrderLineId {  get; set; }

        public Customer TheCustomer { get; set; }

        public List<SelectListItem> ExtraSelectList { get; set; }
        public List<SelectListItem> MenuItemSelectList { get; set; }

        [BindProperty]
        public int Amount { get; set; }

        [BindProperty]
        public string Comment { get; set; }

        public List<OrderLine> OrderLines { get; set; }

        public CreateOrderModel(ICustomerRepository cRepo, IMenuRepository mRepo, IShoppingBasket basket, IAccessoryRepository aRepo)
        {
            OrderLines = new List<OrderLine>();
            _cRepo = cRepo;
            _mRepo = mRepo;
            _basket = basket;
            _aRepo = aRepo;
            TheCustomer = _basket.Customer;
            createMenuSelectList();
            CreateExtraSelectList();
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

        void CreateExtraSelectList()
        {
            ExtraSelectList = new List<SelectListItem>();
            ExtraSelectList.Add(new SelectListItem("extras", "-1"));
            foreach (Accessory a in _aRepo.GetAll())
            {
                ExtraSelectList.Add(new SelectListItem(a.Name, a.Id + ""));
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
            OrderLines = _basket.GetAll();
        }

        public void OnPostAddToOrder()
        {
            if (Amount > 0)
            {
                MenuItem menuItemToOrder = _mRepo.GetMenuItemByNo(ChosenMenuItem);
                if (menuItemToOrder != null)
                {
                    OrderLine ol = new OrderLine(menuItemToOrder, Amount, Comment);
                    _basket.AddOrderLine(ol);
                }
            }
            OrderLines = _basket.GetAll();
            TheCustomer = _basket.Customer;
        }

        public void OnPostAddExtra()
        {
            _basket.GetOrderLine(OrderLineId).AddExtraAccessory(_aRepo.GetAccessory(ChosenExtra));
            OrderLines = _basket.GetAll();
            TheCustomer = _basket.Customer;
        }
        
        public void OnPostRemoveLine()
        {
            _basket.RemoveOrderLine(_basket.GetOrderLine(OrderLineId));
            OrderLines= _basket.GetAll();
            TheCustomer = _basket.Customer;
        }

        public double GetTotal()
        {
            double total = 0;
            foreach (OrderLine line in OrderLines)
            {
                total += line.SubTotal();
            }
            return total;
        }
    }
}