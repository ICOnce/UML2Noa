using PizzaLibrary.Services;
using PizzaLibrary.Models;

namespace PizzaTest
{
    [TestClass]
    public class UnitTest1
    {            
        CustomerRepository cRepo = new CustomerRepository();
        MenuRepository menuRepo = new MenuRepository();

        public void TestSetup()
        {
            Customer.counter = 0;
            MockData.Reset();
            cRepo = new CustomerRepository();
            menuRepo = new MenuRepository();
        }

        [TestMethod]
        public void CRepoCount()
        {
            //Arrange
            TestSetup();

            //Act

            //Assert
            Assert.AreEqual(4, cRepo.Count);
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
                if (customer != MockData.CustomerData[customer.Mobile]) { areSame = false; break; }
            }

            //Assert
            Assert.IsTrue(areSame);
        }

        [TestMethod]
        public void GetCustByNum()
        {
            //Arrange
            TestSetup();

            //Act
            string mobile = "12121212";
            Customer c1 = cRepo.GetCustomerByMobile(mobile);
            Customer c2 = MockData.CustomerData[mobile];

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
    }
}