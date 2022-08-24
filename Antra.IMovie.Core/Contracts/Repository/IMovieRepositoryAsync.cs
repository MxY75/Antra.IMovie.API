using Antra.IMovie.Core.Entity;
using Antra.IMovie.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Antra.IMovie.Core.Contracts.Repository
{
    public interface IMovieRepositoryAsync : IRepositoryAsync<Movie>
    {

        Task<PagedResult<Movie>> GetMoviesByTitleAsync(int pageSize = 30, int page = 1);
        Task<List<Movie>> Get30HighestRatedMoviesAsync();


    }
}
