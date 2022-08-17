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
    [Authorize]

    public class CastController : ControllerBase
    {
        ICastService castService;
        public CastController(ICastService castService)
        {
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

        [HttpPost]
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

        
  }


}
