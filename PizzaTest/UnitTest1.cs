using PizzaLibrary.Services;
using PizzaLibrary.Models;
using PizzaLibrary.Interfaces;

namespace PizzaTest
{
    [TestClass]
    public class UnitTest1
    {
        ICustomerRepository cRepo;
        IMenuRepository menuRepo;
        Dictionary<string, Customer> _customerData;
        List<MenuItem> _menuItemData;

        public void TestSetup()
        {
            Customer.counter = 0;
            MenuItem.counter = 0;
            _customerData = new Dictionary<string, Customer>()
            {
                { "12121212", new Customer("Mikkel", "12121212", "Street 123") },
                { "13131313", new Customer("Charlotte", "13131313", "Avenue 321") },
                { "14141414", new Customer("Carina", "14141414", "High Street 234") },
                { "15151515", new Customer("Muhammed", "15151515", "North Street 345") }
            };
            cRepo = new CustomerRepository(_customerData);

            _menuItemData = new List<MenuItem>()
            {
                new MenuItem("Margherita", 85, "Tomat, ost", MenuType.PIZZECLASSSICHE),
                new MenuItem("Vesuvio", 95, "Tomat, ost & skinke", MenuType.PIZZECLASSSICHE),
                new MenuItem("Capricciosa", 98, "Tomat, ost, skinke & champignon", MenuType.PIZZECLASSSICHE),
                new MenuItem("Calzone", 98, "Indbagt pizza med tomat, ost, skinke & champignon", MenuType.PIZZECLASSSICHE),
                new MenuItem("Quattro Stagioni", 99, "Tomat, ost, skinke, champignon, rejer & paprika", MenuType.PIZZECLASSSICHE),
                new MenuItem("Marinara", 97, "Tomat, ost, rejer, muslinger & hvidløg", MenuType.PIZZECLASSSICHE),
                new MenuItem("Vegetariana", 98, "Tomat, ost & grønsager", MenuType.PIZZECLASSSICHE),
                new MenuItem("Italiana", 97, "Tomat, ost, løg & kødsauce", MenuType.PIZZECLASSSICHE)
            };
            menuRepo = new MenuRepository(_menuItemData);
        }

        [TestMethod]
        public void CRepoCount()
        {
            //Arrange
            TestSetup();

            //Act

            //Assert
            Assert.AreEqual(_customerData.Count, cRepo.Count);
        }

        [TestMethod]
        public void AddCust()
        {
            //Arrange
            TestSetup();

            //Act
            int beforeCount = cRepo.Count;
            cRepo.AddCustomer(new Customer("Bob", "69696969", "street 69"));
            int afterCount = cRepo.Count;

            //Assert
            Assert.AreEqual(4, beforeCount);
            Assert.AreEqual(beforeCount + 1, afterCount);
        }

        [TestMethod]
        public void GetAllCust()
        {
            //Arrange
            TestSetup();

            //Act
            bool areSame = true;
            foreach (Customer customer in cRepo.GetAll())
            {
                if (customer != _customerData[customer.Mobile]) { areSame = false; break; }
            }

            //Assert
            Assert.AreEqual(_customerData.Count, cRepo.GetAll().Count);
            Assert.IsTrue(areSame);
        }

        [TestMethod]
        public void GetAllMembers()
        {
            TestSetup();

            cRepo.GetCustomerByMobile("12121212").ClubMember = true;
            List<Customer> members = cRepo.GetAllMembers();

            Assert.AreEqual(1, members.Count);
        }

        [TestMethod]
        public void GetCustByNum()
        {
            //Arrange
            TestSetup();

            //Act
            string mobile = "12121212";
            Customer c1 = cRepo.GetCustomerByMobile(mobile);
            Customer c2 = _customerData[mobile];

            //Assert
            Assert.AreEqual(c1, c2);
        }

        [TestMethod]
        public void RemoveCust()
        {
            //Arrange
            TestSetup();

            //Act
            int beforeCount = cRepo.Count;
            cRepo.RemoveCustomer("12121212");
            int afterCount = cRepo.Count;

            //Assert
            Assert.AreEqual(beforeCount, afterCount + 1);
        }

        [TestMethod] 
        public void MenuConstruction()
        {
            TestSetup();

            Assert.AreEqual(menuRepo.Count, _menuItemData.Count);
        }

        [TestMethod]
        public void GetMostExpPizza()
        {
            //Arrange
            TestSetup();

            //Act
            MenuItem temp = menuRepo.MostExpensivePizza();

            //Assert
            Assert.AreEqual(temp.Price, 99);
        }
    }
}