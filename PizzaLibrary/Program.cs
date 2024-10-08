using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using PizzaLibrary.Models;

internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
        Customer c1 = new Customer("Bob", "69696969", "Sex St. 69");
        Console.WriteLine(c1.ToString());
    }
}

