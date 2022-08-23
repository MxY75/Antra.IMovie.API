
using Antra.IMovie.Core.Contracts.Repository;
using Antra.IMovie.Core.Contracts.Service;
using Antra.IMovie.Core.Entity;
using Antra.IMovie.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Antra.IMovie.Core.Model.FavoriteResponseModel;

namespace Antra.IMovie.Infrascruture.Service
{
    public class UserService : IUserService
    {

        IUserRepository userRepository;
        IPurchaseRepostiry purchaseRepostiry;
        IMovieRepositoryAsync movieRepository;
        IFavoriteRepository favoriteRepository;
        IMovieServiceAsync movieService;

        public UserService(IUserRepository _userRepository, IPurchaseRepostiry purchaseRepostiry,IMovieRepositoryAsync movieRepository, IFavoriteRepository favoriteRepository, IMovieServiceAsync movieService)
        {
            userRepository = _userRepository;
            this.purchaseRepostiry = purchaseRepostiry;
            this.movieRepository = movieRepository;
            this.favoriteRepository = favoriteRepository;
            this.movieService = movieService;
        }



        public async Task<UserGetModel> GetUserModelByIdAsync(int id) {
            var entity = await userRepository.GetByIdAsync(id);
            UserGetModel user = new UserGetModel();

            if (entity != null)
            {
                user.Id = entity.Id;
                user.FirstName = entity.FirstName;
                user.LastName = entity.LastName;
                user.Email = entity.Email;
                user.PhoneNumber = entity.PhoneNumber;
                return user;
            }
            return null;
        
        }
        public async Task<IEnumerable<UserGetModel>> GetAllUsers()
        {

            List<UserGetModel> usersList = new List<UserGetModel>();
          var list = await userRepository.GelAllAsync();
            foreach (var entity in list) {
                UserGetModel user = new UserGetModel();
                user.Id = entity.Id;
                user.FirstName = entity.FirstName;
                user.LastName = entity.LastName;
                user.Email = entity.Email;
                user.PhoneNumber = entity.PhoneNumber;
                usersList.Add(user);
            }

            return usersList;
        }

    

        public Task<int> InsertUser(UserPostModel user)
        {
            User entity = new User();
            entity.Id = user.Id;
            entity.FirstName = user.FirstName;
            entity.LastName = user.LastName;
            entity.Email = user.Email;
            entity.PhoneNumber = user.PhoneNumber;
            entity.DateOfBirth = user.DateOfBirth;

            return userRepository.InsertAsync(entity);
        }


        public async Task<bool> IsMoviePurchased(PurchaseRequestModel purchaseRequest, int userId)
        {
            var  purchases = await userRepository.GetPurchasesByUserid(userId);
            if (purchases != null)
            {
                foreach (var entity in purchases)
                {
                    if (entity.MovieId == purchaseRequest .MovieId) {
                        return true;
                    }
                }
            }
            return false;
        }


    
        public async Task<bool> PurchaseMovie(PurchaseRequestModel purchase, int userId)
        {
            Purchase entity = new Purchase();
            Movie movie = await movieRepository.GetByIdAsync(purchase.MovieId);
            entity.MovieId =purchase.MovieId;
            entity.UserId = userId;
            entity.PurchaseNumber = (Guid)purchase.PurchaseNumber;

            if (movie.Price == null)
                entity.TotalPrice = 8.9m;
          if (purchase.PurchaseDateTime != null) {
                entity.PurchaseDateTime = (DateTime)purchase.PurchaseDateTime;
            }
            entity.PurchaseDateTime = DateTime.Now;
           int insertSuccess =   await purchaseRepostiry.InsertAsync(entity);
            if (insertSuccess > 0) {
                return true;
            }
            return false;
        }
        public async Task<PurchaseDetailsResponseModel> GetPurchasesDetails(int userId, int movieId)
        {
            var result = await purchaseRepostiry.GetPurchasebyUserIdMovieId(userId, movieId);
            
            if (result != null) {
                PurchaseDetailsResponseModel model = new PurchaseDetailsResponseModel();
                model.Id = result.Id;
                model.PurchaseNumber = result.PurchaseNumber;
                model.UserId = result.UserId;
                model.MovieId = result.MovieId;
                model.PurchaseDateTime = result.PurchaseDateTime;
                model.Title = result.Movie.Title;
                model.PosterUrl = result.Movie.PosterUrl;
                model.ReleaseDate = result.Movie.ReleaseDate;
                return model;
            }
            return null;
           
        }

        public async Task<IEnumerable<PurchaseModel>> GetAllPurchasesForUser(int id)
        {
           var result = await userRepository.GetPurchasesByUserid(id);
            List<PurchaseModel> purchaseModels = new List<PurchaseModel>();
            if (result != null) {
                foreach (var entity in result) {
                    PurchaseModel model = new PurchaseModel();
                    model.Id = entity.Id;
                    model.UserId = entity.UserId;
                    model.PurchaseNumber = entity.PurchaseNumber;
                    model.MovieId = entity.MovieId;
                    model.TotalPrice = entity.TotalPrice;
                    model.PurchaseDateTime = model.PurchaseDateTime;
                    purchaseModels.Add(model);
                }
                return purchaseModels;
            }
            return null;
        }

        public async Task<int> AddFavorite(FavoriteRequestModel model)
        {
            if (!await FavoriteExists(model.MovieId,model.UserId))
            {
                Favorite favorite = new Favorite();
                if (model != null)
                {
                    favorite.UserId = model.UserId;
                    favorite.MovieId = model.MovieId;
                    return await favoriteRepository.InsertAsync(favorite);
                }
            }
            return - 1;
        }

        public async Task<int> RemoveFavorite(FavoriteRequestModel favoriteRequest)
        {
            if (favoriteRequest == null) { 
                return -1;
            }
            bool isExists = await FavoriteExists( favoriteRequest.MovieId, favoriteRequest.UserId);

            if (isExists) {
                Favorite entity = await favoriteRepository.GetFavoritebyMidUid(favoriteRequest.MovieId, favoriteRequest.UserId);
                return await favoriteRepository.Delete(entity.Id);

            }
            return -1;
        }

        public async Task<bool> FavoriteExists( int mid,int uid)
        {
            Favorite favorite = await favoriteRepository.GetFavoritebyMidUid(mid, uid);

           if(favorite == null) {
                return false;
            }
            return true;
        }

        public async Task<FavoriteResponseModel> GetAllFavoritesForUser(int id)
        {
            var result = await favoriteRepository.GetAllFavoritesByUserId(id);
            FavoriteResponseModel favoriteResponseModel = new FavoriteResponseModel();
            favoriteResponseModel.UserId = id;
          
            List<MovieResponseModel> lists = new List<MovieResponseModel>();
            if (result != null) {
                foreach (Favorite item in result) {
                    MovieResponseModel model = new MovieResponseModel();
                    model = await movieService.GetMovieResponseModel(item.MovieId);
                    lists.Add(model);
                }
            }

            favoriteResponseModel.FavoriteMovies = lists;
            return favoriteResponseModel;
        }
    }
}
