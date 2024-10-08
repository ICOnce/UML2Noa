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
        private Dictionary<string, Customer> _customers;
        public int Count
        {
            get { return _customers.Count; }
        }

        public CustomerRepository()
        {
            _customers = MockData.CustomerData;
        }

        public void AddCustomer(Customer customer)
        {
            if (!_customers.ContainsKey(customer.Mobile))
            {
                _customers.Add(customer.Mobile, customer);
            }
        }

        public List<Customer> GetAll()
        {
            return _customers.Values.ToList();
        }

        public Customer GetCustomerByMobile(string mobile)
        {
            return _customers[mobile];
        }

        public void PrintAllCustomers()
        {
            foreach(Customer customer in _customers.Values)
            {
                Console.WriteLine();
                customer.ToString();
            }
        }

        public void RemoveCustomer(string mobile)
        {
            _customers.Remove(mobile);
        }
    }
}
