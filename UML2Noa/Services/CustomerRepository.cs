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

        public CustomerRepository(Dictionary<string, Customer> customers)
        {
            _customers = customers;
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

        public List<Customer> GetAllMembers()
        {
            List<Customer> result = new List<Customer>();
            foreach (Customer customer in _customers.Values)
            {
                if (customer.ClubMember) result.Add(customer);
            }
            return result;
        }

        public Customer GetCustomerByMobile(string mobile)
        {
            if (_customers.ContainsKey(mobile))
            {
                return _customers[mobile];
            }
            else return null;
        }

        public void PrintAllCustomers()
        {
            foreach(Customer customer in _customers.Values)
            {
                Console.WriteLine(customer.ToString());
                
            }
        }

        public void EditCustomer(string mobile, string? name, string? address, bool? member)
        {
            Customer c = _customers[mobile];
            if (name != null) c.Name = name;
            if (address != null) c.Address = address;
            if (member != null) c.ClubMember = (bool) member;
        }

        public void RemoveCustomer(string mobile)
        {
            _customers.Remove(mobile);
        }

        public override string ToString()
        {
            string result = $"{Count} customers in repository";
            foreach (Customer customer in _customers.Values)
            {
                result += "\n, " + customer.ToString();
            }
            return result;
        }
    }
}
