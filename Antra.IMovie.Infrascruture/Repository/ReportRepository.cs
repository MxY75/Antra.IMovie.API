using Antra.IMovie.Core.Contracts.Repository;
using Antra.IMovie.Core.Entity;
using Antra.IMovie.Core.Model;
using Antra.IMovie.Infrascruture.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Antra.IMovie.Infrascruture.Repository
{
    public class ReportRepository : BaseRepositoryAsync<Movie>, IReportRepository
    {

        IMovieCrmDBContext movieContext;
        public ReportRepository(IMovieCrmDBContext _context) : base(_context)
        {
            movieContext = _context;

        }

        public async Task<PagedResult<Movie>> GetTopPurchasedMovies(DateTime? fromDate = null, DateTime? toDate = null, int pageSize = 30, int pageIndex = 1)
        {
            var movies = await movieContext.Purchase.Include(p => p.Movie).Where(p =>p.PurchaseDateTime >= fromDate). Where(p=>p.PurchaseDateTime <= toDate).GroupBy(p => new { p.MovieId, p.Movie.PosterUrl, p.Movie.Title })
               .OrderByDescending(p=> p.Count()).Select(m => new Movie
               {
                   Id = m.Key.MovieId,
                   PosterUrl = m.Key.PosterUrl,
                   Title = m.Key.Title,
               }).Skip((pageIndex - 1) * pageSize).Take(pageSize).ToListAsync();
            var pageCount = movieContext.Purchase.Select(p => p.MovieId).Distinct().Count();
            var result = new PagedResult<Movie>(movies, pageSize, pageIndex, pageCount);

            return result;
        }

        public async Task<List<ReportTopPurchaseModel>> GetTopPurchasedMoviesNoPage(DateTime? fromDate = null, DateTime? toDate = null)
        {
            var topPurchasedMovies = await movieContext.Purchase.Include(p => p.Movie).Where(p => p.PurchaseDateTime >= fromDate).Where(p => p.PurchaseDateTime <= toDate).GroupBy(p => new { p.MovieId, p.Movie.PosterUrl, p.Movie.Title })
                 .OrderByDescending(m => m.Count()).Select(m => new
                 {

                     Title = m.Key.Title,
                     Count = m.Count()

                 }).Take(30).ToListAsync();
            List<ReportTopPurchaseModel> list = new List<ReportTopPurchaseModel>();
            foreach (var item in topPurchasedMovies)
            {
                ReportTopPurchaseModel model = new ReportTopPurchaseModel();
                model.Title = item.Title;
                model.Count = item.Count;
                list.Add(model);
            }
                return list;
            }
    }
}
