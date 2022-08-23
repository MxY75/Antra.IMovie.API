using Antra.IMovie.Core.Entity;
using Antra.IMovie.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Antra.IMovie.Core.Contracts.Repository
{
    public interface IMovieGenreRepositoryAsync :IRepositoryAsync<MovieGenre>
    {
        Task<IEnumerable<MovieGenre>> GetAllByGenreIdAsync(int genreId);
        Task<IEnumerable<MovieGenre>> GetAllByMovieIdAsync(int movieId);

        Task<PagedResult<Movie>> MoviesByGenre ( int id, int pageSize = 30, int pageIndex = 1);
    }
}
