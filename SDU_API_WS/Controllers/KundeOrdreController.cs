using Microsoft.AspNetCore.Mvc;
using SDU_API_WS.Model;

using SDU_API_Models_CustomerOrder;
using System.Reflection;

namespace SDU_API_Case.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class KundeOrdreController : ControllerBase
    {

        private readonly ILogger<KundeOrdreController> _logger;

        public KundeOrdreController(ILogger<KundeOrdreController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetKundeOrdre")]        
        public ActionResult Get(string itemNo)
        {
            try
            {
                SDU_API_Models_CustomerOrder.KundeOrdre x = null;

                if (string.IsNullOrWhiteSpace(itemNo))
                {
                    Response.StatusCode = 400;
                    return Content("Kunde ID mangler");
                }
                if (x == null)
                {                    
                    return new NotFoundResult();
                }
                else
                {
                    return new OkObjectResult(x);
                }
            }
            catch (Exception ex)
            {
                Response.StatusCode = 500;
                return Content(ex.Message);
            }
        }
}