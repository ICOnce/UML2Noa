using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PizzaLibrary.Interfaces;
using PizzaLibrary.Models;

namespace PizzaLibrary.Services
{
    public class CustomerRepository : ICustomerRepository
    {
        public int Count => throw new NotImplementedException();

        public void AddCustomer(Customer customer)
        {
            throw new NotImplementedException();
        }

        public List<Customer> GetAll()
        {
            throw new NotImplementedException();
        }

        public Customer GetCustomerByMobile(string mobile)
        {
            throw new NotImplementedException();
        }

        public void PrintAllCustomers()
        {
            throw new NotImplementedException();
        }

        public void RemoveCustomer(string mobile)
        {
            throw new NotImplementedException();
        }
    }
}
