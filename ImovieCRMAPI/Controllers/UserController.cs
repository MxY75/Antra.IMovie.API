 
using Antra.IMovie.Core.Contracts.Service;
using Antra.IMovie.Core.Entity;
using Antra.IMovie.Core.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace IMovieCRMAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "RUser")]
    public class UserController : ControllerBase
    {

        IUserService userService;
      
        public UserController(IUserService userService)
        {
            this.userService = userService;
        }

        [HttpPost("userRegister")]
        public async Task<IActionResult> Post(UserPostModel userModel)
        {
            if (ModelState.IsValid)
            {
                if (await userService.InsertUser(userModel) > 0)
                {
                    return Ok(userModel);
                }
            }
            return BadRequest();

        }
   

        [HttpGet("GetAllPurchaseByuserId")]
        public async Task<IActionResult> GetAllPurchaseByuserId(int id)
        {
            var result = await userService.GetAllPurchasesForUser(id);
            if (result != null)
            {
                return Ok(result);
            }
            return BadRequest();
        }

        [HttpGet("GetPurchasesDetails")]

        public async Task<IActionResult> GetPurchaseDeatils(int uid, int mid)
        {
            var result = await userService.GetPurchasesDetails(uid, mid);
            if (result != null)
            {
                return Ok(result);
            }
            return BadRequest();
        }
        [HttpPost("addPurchase")]
        public async Task<IActionResult> PostAddPurchase(PurchaseRequestModel model, int uid)
        {
            bool isPurchased = false;
            bool isInsert = false;
            isPurchased = await userService.IsMoviePurchased(model, uid);
            if (!isPurchased)
            {
                isInsert = await userService.PurchaseMovie(model, uid);
            }
            if (isInsert)
                return Ok();
            return BadRequest("Invalid data.");
        }
        [HttpPost("addFavorite")]
        public async Task<IActionResult> PostAddFavorite(FavoriteRequestModel model)
        {
            var result = await userService.AddFavorite(model);
            if (result > 0)
                return Ok(model);
            return BadRequest();
        }
        [HttpDelete("removieFavorite")]
        public async Task<IActionResult> DeleteFavorite(FavoriteRequestModel model)
        {
            var result = await userService.RemoveFavorite(model);
            if (result > 0)
            {
                var response = new { Message = "Favorite Deleted Successfully" };
                return Ok(response);
            }
            return BadRequest();
        }

        [HttpGet("UserAllFavorites")]
        public async Task<IActionResult> GetAllFavoritesForUser(int id)
        {
            var result = await userService.GetAllFavoritesForUser(id);
            if (result == null)
                return NotFound($"This user doesn't have favorite movies ");
            return Ok(result);
        }
        [HttpGet("UserAllReview")]
        public async Task<IActionResult> GetAllReviewsByUser(int uid)
        {
            var result = await userService.GetAllFavoritesForUser(uid);
            if (result == null)
                return NotFound($"This user doesn't write any review ");
            return Ok(result);

        }

        [HttpPut("EditReview")]
        public async Task<IActionResult> Put(ReviewRequestModel m)
        {
            var response = new { Message = "Review is updated" };
            if (await userService.UpdateMovieReview(m) > 0)
                return Ok(response);
            return NoContent();
        }

        [HttpDelete("DeleteReview")]
        public async Task<IActionResult> Delete(int uid, int mid)
        {
            var response = new { Message = "deleted" };
            if (await userService.DeleteMovieReview(uid, mid) > 0)
                return Ok(response);
            return NoContent();
        }

        [HttpPost("AddRview")]
        public async Task<IActionResult> AddReview(ReviewRequestModel model)
        {
            if (await userService.AddMovieReview(model) > 0)
            {
                return Ok(model);
            }
            return BadRequest();

        }
    }
}
