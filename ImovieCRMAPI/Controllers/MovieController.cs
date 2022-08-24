using Antra.IMovie.Core.Contracts.Service;
using Antra.IMovie.Infrascruture.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IMovieCRMAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private readonly IMovieServiceAsync movieService;
        public MovieController(IMovieServiceAsync movieService)
        {
            this.movieService = movieService;
        }
        [HttpGet("MovieDetail")]
        public async Task<IActionResult> GetMovieDetailByMovieId(int id)
        {
            var result = Ok(await movieService.GetMovieDetailsAsync(id));
            if (result != null)
            {
                return Ok(result);
            }
            return NoContent();
        }


        [HttpGet]
            public async Task<IActionResult> GetById(int id)
        {

            var result = Ok(await movieService.GetByIdAsync(id));
            if (result != null)
            {
                return Ok(result);
            }
            return NoContent();

        }

        [HttpGet("ShowAllMovies")]
        public async Task<IActionResult> GetAllMovies() {
            //  var result = await movieService.GetMoviesByPaginationAsync(pageSize,page);
            var result = await movieService.GetAllMovies();
            if (result != null)
            {
                return Ok(result);
            }
            return NoContent();
        }
    }
}

