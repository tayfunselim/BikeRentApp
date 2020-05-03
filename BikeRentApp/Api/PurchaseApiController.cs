using BikeRentApp.Data;
using Microsoft.AspNetCore.Mvc;

namespace BikeRentApp.Api
{
    [Route("api/Purchases")]
    [ApiController]
    public class PurchaseApiController : ControllerBase
    {
        private readonly IPurchaseData purchaseData;

        public PurchaseApiController(IPurchaseData purchaseData)
        {
            this.purchaseData = purchaseData;
        }

        [HttpGet]
        public IActionResult GetPurchasesAll()
        {
            var data = purchaseData.GetPurchases();
            return Ok(data);
        }

        [HttpGet("{id}")]
        public IActionResult GetPurchasesById(int id)
        {
            var data = purchaseData.GetPurchaseById(id);
            if (data == null)
            {
                return NotFound();
            }
            return Ok(data);
        }
    }
}