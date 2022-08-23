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
        Task<bool> PurchaseMovie(PurchaseRequestModel purchaseRequest, int userId);
        Task<bool> IsMoviePurchased(PurchaseRequestModel purchaseRequest, int userId);
        Task<IEnumerable<PurchaseModel>> GetAllPurchasesForUser(int id);
        Task<PurchaseDetailsResponseModel> GetPurchasesDetails(int userId, int movieId);

       Task<int> AddFavorite(FavoriteRequestModel favoriteRequest);
        Task<int> RemoveFavorite(FavoriteRequestModel favoriteRequest);
        Task<bool> FavoriteExists(int mid, int uid);
        Task<FavoriteResponseModel> GetAllFavoritesForUser(int id);

    }
}
