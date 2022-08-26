using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Antra.IMovie.Core.Contracts.Service;
using Antra.IMovie.Core.Model;
using Antra.IMovie.Infrascruture.Service;

namespace IMovieCRMAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenresController : ControllerBase
    {
        IGenreServiceAsync genreServiceAsync;
        IMovieGenreServiceAsync movieGenreServiceAsync;

        public GenresController(IGenreServiceAsync genreServiceAsync,IMovieGenreServiceAsync movieGenreServiceAsync) { 
            this.genreServiceAsync = genreServiceAsync;
            this.movieGenreServiceAsync = movieGenreServiceAsync;
        }

        [HttpGet("getAllGenre")]
        public async Task<IActionResult> Get() {
            var list =await genreServiceAsync.GetAllGenres();
            if (list != null) {
                return Ok(list);
            }

            return NoContent();

        }

        [HttpGet("MoviesByGenre")]
        public async Task<IActionResult> getMoviesByGenreid(int gid)
        {
            var result = await movieGenreServiceAsync.GetAllByGenreIdAsync(gid);
            if (result != null)
            {
                return Ok(result);
            }
            return NoContent();
        }
        //public async Task<IActionResult> getMoviesByGenreidPaged(int id, int pageSize = 30, int pageNumber = 1)
        //{
        //    var result = await movieGenreServiceAsync.MoviesByGenre(id, pageSize, pageNumber);
        //    if (result != null)
        //    {
        //        return Ok(result);
        //    }
        //    return NoContent();
        //}

    }
}
