using Antra.IMovie.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Antra.IMovie.Core.Contracts.Service
{
    public interface IMovieServiceAsync
    {
        Task<MovieModel> GetByIdAsync(int id);
        Task<MovieResponseModel> GetMovieResponseModel(int id);

        Task <IEnumerable<MovieResponseModel>> GetAllMovies();
        Task<List<MovieResponseModel>> GetTop30GRatedMoviesAsync();
        Task<PagedResult<MovieResponseModel>> GetMoviesByPaginationAsync(int pageSize, int page);

        Task<MovieModel> GetMovieDetailsAsync(int id);
        Task<List<MovieResponseModel>> MoviesSameGenreAsync(int id);


    }
}
