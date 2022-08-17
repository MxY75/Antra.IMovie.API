using Antra.IMovie.Core.Contracts.Service;
using Antra.IMovie.Core.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IMovieCRMAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PurchaseController : ControllerBase
    {
        IPurchaseService purchaseService;
        public PurchaseController(IPurchaseService purchase)
        {
            this.purchaseService = purchase;
        }

        [HttpPost("add")]
        public async Task<IActionResult> Post(PurchaseModel purchaseModel) {
            if (ModelState.IsValid)
            {
                if (await purchaseService.InsertPurchase(purchaseModel) > 0) {
                    return Ok(purchaseModel);
                }
            }

            return BadRequest();
        }
    }
}
