﻿using PizzaLibrary.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaLibrary.Models
{
    public class Customer : ICustomer
    {
        private int _id = 0;
        public static int counter = 0;

        #region Properties
        public string Address { get; set; }
        public bool ClubMember { get; set; }

        public int Id
        {
            get 
            {
                return _id;
            }
        }
        #endregion
        public string CustomerImage { get; set; }
        public string Mobile { get; set; }
        public string Name { get; set; }

        public Customer(string name, string mobile, string address)
        {
            CustomerImage = "default.jpeg";
            Name = name;
            Mobile = mobile;
            Address = address;
            ClubMember = false;
            _id = counter;
            counter++;
        }
        
        public Customer()
        {
            CustomerImage = "default.jpeg";
            _id = counter;
            counter++;
        }

        public override string ToString()
        {
            return $"ID: {Id} Name: {Name}\n" +
                $"   Mobile: {Mobile}\n" +
                $"   Address: {Address}\n" +
                $"   IsClubMember: {ClubMember}";
        }
    }
}
