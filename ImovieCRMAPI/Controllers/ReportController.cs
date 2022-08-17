using Antra.IMovie.Core.Contracts.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IMovieCRMAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportController : ControllerBase
    {

        IReportService reportService;

        public ReportController(IReportService reportService)
        {
            this.reportService = reportService;
        }

        [HttpGet("topPurchase")]
        public async Task<IActionResult> GetTopPurchase()
        {
            var result = await reportService.GetTopPurchasedMovies();
            if (result != null)
            {
                return Ok(result);
            }
            return NoContent();
        }

        [HttpGet("topPurchasePaged")]
        public async Task<IActionResult> GetTopPurchasePage()
        {
            var result = await reportService.GetTopPurchasedMovies();
            if (result != null)
            {
                return Ok(result);
            }
            return NoContent();
        }

    }
}
