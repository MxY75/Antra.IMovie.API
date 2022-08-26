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
        public async Task<IActionResult> Post(int uid,int mid) {
            if (ModelState.IsValid)
            {
                if (await purchaseService.InsertPurchase(uid,mid) > 0) {
                    return Ok(new { Message = "add success" });
                }
            }

            return BadRequest();
        }
    }
}
