using Antra.IMovie.Core.Contracts.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IMovieCRMAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
 
    public class AdminController : ControllerBase
    {
        IUserService userService;
        IReportService reportService;
        IMovieServiceAsync movieService;
        public AdminController(IUserService userService,IMovieServiceAsync movieService, IReportService reportService)
        {
            this.userService = userService;
            this.movieService = movieService;
            this.reportService = reportService; 
        }
        [HttpGet("GetAllUsers")]
        public async Task<IActionResult> Get()
        {

            var result = await userService.GetAllUsers();
            if (result != null)
            {
                return Ok(result);
            }
            return BadRequest();
        }

        [HttpGet("topPurchase")]
        public async Task<IActionResult> GetTopPurchase()
        {
            var result = await reportService.GetTopPurchasedMoviesNoPage();
            if (result != null)
            {
                return Ok(result);
            }
            return NoContent();
        }
        [HttpGet("Top30RatedMovie")]
        public async Task<IActionResult> TopRatedMovie() {
            var result = await movieService.GetTop30GRatedMoviesAsync();
            if (result != null) {
                return Ok(result);
            }
            return NoContent();
        }
    }
}
