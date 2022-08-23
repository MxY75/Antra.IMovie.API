using Antra.IMovie.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Antra.IMovie.Core.Contracts.Service
{
    public interface IMovieGenreServiceAsync
    {
        Task<IEnumerable<MovieGenreModel>> GetAllByMovieIdAsync(int id);

        Task<IEnumerable<MovieGenreModel>> GetAllByGenreIdAsync(int genreId);
        Task<PagedResult<MovieReportModel>> MoviesByGenre(int id = 0,int pageSize = 30, int pageIndex = 1);

    }
}
