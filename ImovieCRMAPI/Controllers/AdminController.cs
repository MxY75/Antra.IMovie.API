using Antra.IMovie.Core.Contracts.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IMovieCRMAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class AdminController : ControllerBase
    {
        IUserService userService;
        IMovieServiceAsync movieService;
        public AdminController(IUserService userService,IMovieServiceAsync movieService )
        {
            this.userService = userService;
            this.movieService = movieService;
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
