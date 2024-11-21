using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc;

namespace UMLRazor.Pages.Orders
{
    public class CreateOrderModel : PageModel
    {
        [BindProperty]
        public string SearchCustomerMobile { get; set; }
        public void OnGet()
        {
        }
        public void OnPostCustomer()
        {
        }
    }
}