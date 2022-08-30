using Antra.IMovie.Core.Contracts.Service;
using Antra.IMovie.Infrascruture.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Antra.IMovie.Core.Model;

namespace IMovieCRMAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //  [Authorize]
    public class MovieController : ControllerBase
    {
        private readonly IMovieServiceAsync movieService;
        private readonly ITrailerService trailerService;
        public MovieController(IMovieServiceAsync movieService, ITrailerService trailerService)
        {
            this.movieService = movieService;
            this.trailerService = trailerService;
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
        public async Task<IActionResult> GetAllMovies()
        {
            //  var result = await movieService.GetMoviesByPaginationAsync(pageSize,page);
            var result = await movieService.GetAllMovies();
            if (result != null)
            {
                return Ok(result);
            }
            return NoContent();
        }

        [HttpGet("getAlltralierByid")]
        public async Task<IActionResult> getAlltralierByid(int id)
        {
            var result = await trailerService.GetAllTrailersByMid(id);
            if (result != null)
            {
                return Ok(result);
            }
            return NoContent();
        }

        [HttpPost("addMovie")]
        public async Task<IActionResult> addMovie(AddMovieModel model) {

          
            if (ModelState.IsValid)
            {
                if (await movieService.InsertMoviw(model) > 0)
                {
                    return Ok(new { Message = "add success" });
                }
            }

            return BadRequest();
        }
    }
}

