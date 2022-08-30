using Antra.IMovie.Core.Entity;
using Antra.IMovie.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Antra.IMovie.Core.Contracts.Service
{
    public interface IUserService
    {
        Task<int> InsertUser(UserPostModel user);
        Task<IEnumerable<UserGetModel>> GetAllUsers();
        Task<int> PurchaseMovie(int uid, int mid);
        Task<bool> IsMoviePurchased(int uid, int mid);
        Task<IEnumerable<PurchaeMovieModel>> GetAllPurchasesForUser(int id);
        Task<PurchaseDetailsResponseModel> GetPurchasesDetails(int userId, int movieId);

       Task<int> AddFavorite(FavoriteRequestModel favoriteRequest);
        Task<int> RemoveFavorite(int uid, int mid);
        Task<bool> FavoriteExists(int mid, int uid);
        Task<FavoriteResponseModel> GetAllFavoritesForUser(int id);
        Task<bool> IsMovieFavorited(int uid, int mid);

        Task<int>AddMovieReview(ReviewRequestModel reviewRequest);
        Task<int> UpdateMovieReview(ReviewRequestModel reviewRequest);
        Task<int> DeleteMovieReview(int userId, int movieId);
        Task<IEnumerable<ReviewModel>> GetAllReviewsByUser(int id);
        Task<IEnumerable<ReviewModel>> GetAllReviewsByMid(int mid);
        Task<UserGetModel> GetUserModelByIdAsync(int id);
    }
}
