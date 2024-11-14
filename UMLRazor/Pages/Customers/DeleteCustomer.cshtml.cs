using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PizzaLibrary.Interfaces;
using PizzaLibrary.Models;

namespace UMLRazor.Pages.Customers
{
    public class DeleteCustomerModel : PageModel
    {
        ICustomerRepository _customerRepository;

        [BindProperty]


        public Customer Customer { get; set; }

        public DeleteCustomerModel(ICustomerRepository cRepo)
        {
            _customerRepository = cRepo;
        }
        public void OnGet(string deleteMobile)
        {
            Customer = _customerRepository.GetCustomerByMobile(deleteMobile);
        }

        public IActionResult OnPost()
        {
            _customerRepository.RemoveCustomer(Customer.Mobile);
            return RedirectToPage("ShowCustomers");
        }
    }
}
