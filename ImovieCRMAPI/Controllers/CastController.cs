using Antra.IMovie.Core.Contracts.Service;
using Antra.IMovie.Core.Model;
using Antra.IMovie.Infrascruture.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IMovieCRMAPI.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]

    public class CastController : ControllerBase
    {
        ICastService castService;
        IMovieCastServiceAsync movieCastServiceAsync;
        public CastController(ICastService castService,IMovieCastServiceAsync movieCastServiceAsync)
        {
            this.movieCastServiceAsync = movieCastServiceAsync;
            this.castService = castService;
        }


        [HttpGet]
        public async Task<IActionResult> Get() {

           var result = Ok(await castService.GetAllCasts());
            if (result != null) {
                return Ok(result);
            }
            return NoContent(); 

        }

        [HttpPost("createCast")]
        public async Task<IActionResult> Post(CastModel castModel){
            if (ModelState.IsValid)
            {
                if (await castService.InsertCast(castModel) > 0)
                {
                    return Ok(castModel);
                }
            }
            return BadRequest();    
        }


        [HttpGet("getMoviesbyCast")]
        public async Task<IActionResult> Detail(int id)
        {
            CastModel model = await castService.GetCastByIdAsync(id);
            model.MovieCasts = await movieCastServiceAsync.GetAllByCastId(id);
            return Ok(model);
        }


    }


}
