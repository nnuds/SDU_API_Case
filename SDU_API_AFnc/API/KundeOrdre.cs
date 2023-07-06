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
        public static async Task<IActionResult> RunAsync(
        [HttpTrigger(AuthorizationLevel.Function, "get", Route = "customer/{customerId}")] HttpRequest req,
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

            if (customer == null)
            {
                return new NotFoundResult();
            }

            return new OkObjectResult(customer);
        }

        private static async Task<SDU_API_Models_CustomerOrder.KundeOrdre> GetCustomerByIdAsync(string customerId)
        {
            // Logic to retrieve the customer information from a data source (e.g., database)
            // Replace this with your own implementation

            // Simulate an asynchronous operation
            await Task.Delay(TimeSpan.FromSeconds(1));

            // Sample code to create a Customer object
            SDU_API_Models_CustomerOrder.KundeOrdre customer = new SDU_API_Models_CustomerOrder.KundeOrdre();

            customer.Kunde.Id = 1;
            customer.Kunde.Firma = "test";

            customer.Ordre = new Ordre[2];
            customer.Ordre[0].Id = 1;
            customer.Ordre[1].Id = 2;

            return customer;
        }
    }
}
