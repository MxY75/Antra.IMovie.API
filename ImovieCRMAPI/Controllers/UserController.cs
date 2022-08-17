
using Antra.IMovie.Core.Contracts.Service;
using Antra.IMovie.Core.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IMovieCRMAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {

        IUserService userService;
        public UserController(IUserService userService)
        {
            this.userService = userService;
        }   

        [HttpPost("userRegister")]
        public async Task<IActionResult> Post(UserPostModel userModel) {
            if (ModelState.IsValid) {
                if (await userService.InsertUser(userModel) > 0)
                {
                    return Ok(userModel);
                }
            }
            return BadRequest();
        
        }
    }
}
