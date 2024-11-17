using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PizzaLibrary.Interfaces;
using PizzaLibrary.Models;

namespace UMLRazor.Pages.Customers
{
    public class EditCustomerModel : PageModel
    {
        ICustomerRepository _customerRepository;

        [BindProperty]


        public Customer Customer { get; set; }

        public EditCustomerModel(ICustomerRepository cRepo)
        {
            _customerRepository = cRepo;
        }
        public void OnGet(string editCustomer)
        {
            Customer = _customerRepository.GetCustomerByMobile(editCustomer);
        }

        public IActionResult OnPost()
        {
            _customerRepository.EditCustomer(Customer.Mobile, Customer.Name, Customer.Address, Customer.ClubMember);
            return RedirectToPage("ShowCustomers");
        }
    }
}