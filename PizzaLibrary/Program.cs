using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using PizzaLibrary;
using PizzaLibrary.Models;
using PizzaLibrary.Services;

internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
        Customer c1 = new Customer("Bob", "69696969", "Sex St. 69");
        Console.WriteLine(c1.ToString());
        CustomerRepository cRepo = new CustomerRepository();
        cRepo.AddCustomer(c1);
        //cRepo.RemoveCustomer("12121212");
        Console.WriteLine(cRepo.Count);
        bool areSame = true;
        foreach (Customer customer in cRepo.GetAll())
        {
            if (customer != MockData.CustomerData[customer.Mobile]) { areSame = false; break; }
        }
        Console.WriteLine(areSame);
        Console.WriteLine("Mobile test: " + (cRepo.GetCustomerByMobile("12121212") == MockData.CustomerData["12121212"]));
    }
}

