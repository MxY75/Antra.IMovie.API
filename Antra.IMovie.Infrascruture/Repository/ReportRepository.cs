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
            var movies = await movieContext.Purchase.Include(p => p.Movie).GroupBy(p => new { p.MovieId, p.Movie.PosterUrl, p.Movie.Title })
               .OrderByDescending(m => m.Sum(p => p.TotalPrice)).Select(m => new Movie
               {
                   Id = m.Key.MovieId,
                   PosterUrl = m.Key.PosterUrl,
                   Title = m.Key.Title,
               }).Skip((pageIndex - 1) * pageSize).Take(pageSize).ToListAsync();
            var pageCount = movieContext.Purchase.Select(p => p.MovieId).Distinct().Count();
            var result = new PagedResult<Movie>(movies, pageSize, pageIndex, pageCount);

            return result;
        }

        public async Task<List<Movie>> GetTopPurchasedMoviesNoPage()
        {
            var topPurchasedMovies = await movieContext.Purchase.Include(p => p.Movie).GroupBy(p => new { p.MovieId, p.Movie.PosterUrl, p.Movie.Title })
                 .OrderByDescending(m => m.Sum(p => p.TotalPrice)).Select(m => new Movie
                 {
                     Id = m.Key.MovieId,
                     PosterUrl = m.Key.PosterUrl,
                     Title = m.Key.Title,
                 }).ToListAsync();

            return topPurchasedMovies;
        }

     

 
    }
}
