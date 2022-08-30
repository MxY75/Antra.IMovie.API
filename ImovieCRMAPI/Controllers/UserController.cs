 
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
 //   [Authorize(Roles ="RUser")]
    public class UserController : ControllerBase
    {

        IUserService userService;
      

        public UserController(IUserService userService)
        {
            this.userService = userService;
        }

   
        [HttpGet("GetUserInfoByUid")]
        public async Task<IActionResult> GetUserInfoByUid(int uid)
        {
           var result = await userService.GetUserModelByIdAsync(uid);
            if (result != null)
            {
                return Ok(result);
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

        public async Task<IActionResult> PostAddPurchase(UidOtherIdModel idModel)
        {
            if (await userService.PurchaseMovie(idModel.Uid, idModel.Oid) > 0)
            {
                return Ok(1);
            }
            return BadRequest();

        }
        [HttpPost("CheckisPurchased")]
        public async Task<IActionResult> isPurchased(UidOtherIdModel idModel)
        {
            if (await userService.IsMoviePurchased(idModel.Uid, idModel.Oid))
            {
                return Ok(true);
            }
            return Ok(false);

        }

        [HttpPost("addFavorite")]
        public async Task<IActionResult> PostAddFavorite(FavoriteRequestModel model)
        {
            var result = await userService.AddFavorite(model);
            if (result > 0)
                return Ok(1);
            return BadRequest();
        }
        [HttpDelete("removieFavorite")]
        public async Task<IActionResult> DeleteFavorite(int uid,int mid)
        {
            var result = await userService.RemoveFavorite(uid,mid);
            if (result > 0)
            {
                var response = new { Message = "Favorite Deleted Successfully" };
                return Ok(response);
            }
            return BadRequest();
        }
        [HttpPost("CheckisFavorite")]
        public async Task<IActionResult> isFav(FavoriteRequestModel idModel)
        {
            if (await userService.IsMovieFavorited(idModel.UserId, idModel.MovieId))
            {
                return Ok(true);
            }
            return Ok(false);

        }

        [HttpGet("UserAllFavorites")]
        public async Task<IActionResult> GetAllFavoritesForUser(int id)
        {
            var result = await userService.GetAllFavoritesForUser(id);
            if (result == null)
                return NotFound($"This user doesn't have favorite movies ");
            return Ok(result);
        }
        [HttpGet("MovieAllReview")]
        public async Task<IActionResult> GetAllReviewsByMovie(int mid)
        {
            var result = await userService.GetAllReviewsByMid(mid);
            if (result == null)
                return NotFound($"This Movie doesn't write any review ");
            return Ok(result);

        }


        [HttpGet("UserAllReview")]
        public async Task<IActionResult> GetAllReviewsByUser(int uid)
        {
            var result = await userService.GetAllReviewsByUser(uid);
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
            var response = 1;
            if (await userService.DeleteMovieReview(uid, mid) > 0)
                return Ok(response);
            return NoContent();
        }

        [HttpPost("AddRview")]
        public async Task<IActionResult> AddReview(ReviewRequestModel model)
        {
            if (await userService.AddMovieReview(model) > 0)
            {
                return Ok(1);
            }
            return BadRequest();

        }
    }
}
