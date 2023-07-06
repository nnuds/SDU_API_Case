using SDU_Test_AFunc;
using SDU_API_Models_CustomerOrder;

namespace SDU_Test_AFunc
{
    [TestClass]
    public class DataViewTest
    {
        [TestMethod]
        public void LoadCustomer1()
        {
            var data = SDU_API_AFnc.DAL.CustomerOrder.GetCustomerOrders("1");

            Assert.IsNotNull(data);
            Assert.IsNotNull(data.Kunde);
            Assert.IsNotNull(data.Ordre);
            Assert.AreEqual(1, data.Kunde.Id);
        }

        [TestMethod]
        public void LoadCustomer4()
        {
            var data = SDU_API_AFnc.DAL.CustomerOrder.GetCustomerOrders("4");

            Assert.IsNotNull(data);
            Assert.IsNotNull(data.Kunde);
            Assert.IsNotNull(data.Ordre);
            Assert.AreEqual(4, data.Kunde.Id);
            Assert.AreEqual(5, data.Ordre.Length);
        }

        [TestMethod]
        public void LoadCustomerNotExist()
        {
            var data = SDU_API_AFnc.DAL.CustomerOrder.GetCustomerOrders("999999");
                        
            Assert.IsNull(data.Kunde);
            Assert.IsNull(data.Ordre);
        }
    }
}