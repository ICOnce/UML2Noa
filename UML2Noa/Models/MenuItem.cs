using PizzaLibrary.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaLibrary.Models
{
    public class MenuItem : IMenuItem
    {
        //According to the diagram this should be here, but this is already a thing
        private int _no;
        private static int counter;

        public string Description { get; set; }
        public string Name { get; set; }

        public int No { get { return _no; } }

        public double Price { get; set; }
        public MenuType TheMenuType { get; set; }

        public MenuItem(string name, double price, string description, MenuType menuType) 
        {
            Description = description;
            Name = name;
            Price = price;
            TheMenuType = menuType;

            _no = counter;
            counter++;
        }

        public override string ToString()
        {
            return $"{Name}\n" +
                $"Price: {Price}\n" +
                $"Menu type: {TheMenuType}\n" +
                $"Number: {No} \n" +
                $"Description:\n{Description}";
        }
    }
}