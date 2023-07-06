using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDU_API_AFnc.DAL
{
    public static class CustomerOrder
    {
        public static SDU_API_Models_CustomerOrder.KundeOrdre GetCustomerOrders(string customerID)
        {
            SDU_API_Models_CustomerOrder.KundeOrdre custOrder = new SDU_API_Models_CustomerOrder.KundeOrdre();

            List<SDU_API_Models_CustomerOrder.Kunde> ListCustomers = DAL.CustomerRepository.GetCustomers(customerID);
            if (ListCustomers.Count == 1)
            {
                custOrder.Kunde = ListCustomers.ToArray()[0];

                List<SDU_API_Models_CustomerOrder.Ordre> x = DAL.OrderRepository.GetOrders(customerID);
                if (x.Count>0)
                {
                    custOrder.Ordre = x.ToArray();
                }
            }

            return custOrder;
        }
    }       
}
