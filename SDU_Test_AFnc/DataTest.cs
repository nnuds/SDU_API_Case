using SDU_Test_AFunc;
using SDU_API_Models_CustomerOrder;

namespace SDU_Test_AFunc
{
    [TestClass]
    public class DataTest
    {
        [TestMethod]
        public void LoadCustomer1()
        {
            var data = SDU_API_AFnc.DAL.CustomerRepository.GetCustomers("1");

            Assert.IsNotNull(data);
            Assert.AreEqual(1, data.Count);
        }

        [TestMethod]
        public void LoadCustomerMany()
        {
            var data = SDU_API_AFnc.DAL.CustomerRepository.GetCustomers("");
                        
            Assert.IsTrue(data.Count > 1, "Not all customers loaded");
        }

        [TestMethod]
        public void LoadCustomerNotExist()
        {
            var data = SDU_API_AFnc.DAL.CustomerRepository.GetCustomers("999999");
                        
            Assert.IsTrue(data.Count == 0, "Returned customers");
        }

        [TestMethod]
        public void LoadOrder5()
        {
            var data = SDU_API_AFnc.DAL.OrderRepository.GetOrders("4");

            Assert.IsNotNull(data);
            Assert.AreEqual(5, data.Count);
        }
                
        [TestMethod]
        public void LoadOrderNotExist()
        {
            var data = SDU_API_AFnc.DAL.OrderRepository.GetOrders("999999");

            Assert.IsTrue(data.Count == 0, "Returned orders");
        }
    }
}