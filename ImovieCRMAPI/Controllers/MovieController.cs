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
        private readonly IMovieServiceAsync MovieService;
        public MovieController(IMovieServiceAsync movieService)
        {
            this.MovieService = movieService;
        }
        [HttpGet]
        public async Task<IActionResult> GetById(int id)
        {

            var result = Ok(await MovieService.GetByIdAsync(id));
            if (result != null)
            {
                return Ok(result);
            }
            return NoContent();

        }
    }
}

