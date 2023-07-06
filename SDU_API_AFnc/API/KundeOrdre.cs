using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

using SDU_API_Models_CustomerOrder;
using System.Web.Http;

namespace SDU_API_AFnc.API
{
    public static class KundeOrdre
    {
        [FunctionName("KundeOrdre")]
        public static async Task<IActionResult> Run(
        [HttpTrigger(AuthorizationLevel.Function, "get", Route = "CustomerOrders/{customerId}")] HttpRequest req,
        string customerId,
        ILogger log)
        {
            log.LogInformation("KundeOrdre action");
            log.LogInformation($"Kunde ID: {0}", customerId);

            if (string.IsNullOrWhiteSpace(customerId) == true)
            {
                return new BadRequestObjectResult("Ingen Kunde ID parameter");
            }

            SDU_API_Models_CustomerOrder.KundeOrdre customer = await GetCustomerByIdAsync(customerId);
            dynamic data=JsonConvert.SerializeObject(customer);

            if (customer == null)
            {
                return new NotFoundResult();
            }

            return new OkObjectResult(data);
        }

        private static async Task<SDU_API_Models_CustomerOrder.KundeOrdre> GetCustomerByIdAsync(string customerId)
        {
            SDU_API_Models_CustomerOrder.KundeOrdre customer = null;

            await Task.Run(() => { customer = DAL.CustomerOrder.GetCustomerOrders(customerId); });
            
            return customer;
        }
    }
}
