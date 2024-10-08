using PizzaLibrary.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaLibrary.Models
{
    internal class MenuItem : IMenuItem
    {
        public string Description { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string Name { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public int No => throw new NotImplementedException();

        public double Price { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public MenuType TheMenuType { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }
}
