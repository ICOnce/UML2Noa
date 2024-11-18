using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PizzaLibrary.Interfaces;
using PizzaLibrary.Models;

namespace UMLRazor.Pages.Customers
{
    public class AddCustomerModel : PageModel
    {
        private ICustomerRepository _customerRepository;

        private IWebHostEnvironment _webHostEnvironment;

        [BindProperty]
        public IFormFile Photo { get; set; }

        [BindProperty] //Two way binding
        public Customer Customer { get; set; }

        public AddCustomerModel(ICustomerRepository customerRepository, IWebHostEnvironment webHostEnvironment)
        {
            _customerRepository = customerRepository;
            _webHostEnvironment = webHostEnvironment;
        }

        public void OnGet()
        {
            //Customer.counter--;
        }

        public IActionResult OnPost()
        {
            if (Photo != null)
            {
                if(Customer.CustomerImage != null && Customer.CustomerImage != "default.jpeg")
                {
                    string filePath = Path.Combine(_webHostEnvironment.WebRootPath, "/images/customerImages", Customer.CustomerImage);
                    System.IO.File.Delete(filePath);
                }

                Customer.CustomerImage = ProcessUploadedFile();
            }


            if (_customerRepository.GetCustomerByMobile(Customer.Mobile) == null)
            {
                _customerRepository.AddCustomer(Customer);
            }
            else
            {
                Customer.counter--;
            }

            return RedirectToPage("ShowCustomers");
        }
        private string ProcessUploadedFile()
        {
            string uniqueFileName = null;
            if (Photo != null)
            {
                string uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, "images/customerImages");
                uniqueFileName = Guid.NewGuid().ToString() + "_" + Photo.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    Photo.CopyTo(fileStream);
                }
            }
            return uniqueFileName;
        }
    }
}


