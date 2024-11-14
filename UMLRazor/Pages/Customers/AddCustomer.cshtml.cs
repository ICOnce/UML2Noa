using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PizzaLibrary.Interfaces;
using PizzaLibrary.Models;

namespace UMLRazor.Pages.Customers
{
    public class AddCustomerModel : PageModel
    {
        private ICustomerRepository _customerRepository;

        [BindProperty] //Two way binding

        public Customer Customer { get; set; }

        public AddCustomerModel(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public void OnGet()
        {

        }

        public IActionResult OnPost()
        {
            _customerRepository.AddCustomer(Customer);
            return RedirectToPage("ShowCustomers");
        }
    }
}
