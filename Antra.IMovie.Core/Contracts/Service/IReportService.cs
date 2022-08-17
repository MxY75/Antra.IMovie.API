using Antra.IMovie.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Antra.IMovie.Core.Contracts.Service
{
    public interface IReportService 
    {

        Task<PagedResult<MovieReportModel>> GetTopPurchasedMovies(DateTime? fromDate = null,
        DateTime? toDate = null, int pageSize = 30, int pageIndex = 1);
        Task<List<MovieReportModel>> GetTopPurchasedMoviesNoPage();
    }
}
