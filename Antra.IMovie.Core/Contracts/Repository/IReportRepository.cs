using Antra.IMovie.Core.Entity;
using Antra.IMovie.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Antra.IMovie.Core.Contracts.Repository
{
    public interface IReportRepository : IRepositoryAsync<Movie>
    {
        Task<PagedResult<Movie>> GetTopPurchasedMovies(DateTime? fromDate = null,
        DateTime? toDate = null, int pageSize = 30, int pageIndex = 1);
        Task<List<Movie>> GetTopPurchasedMoviesNoPage();
    }
}
