using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Antra.IMovie.Core.Contracts.Repository;
using Antra.IMovie.Core.Entity;
using Antra.IMovie.Infrascruture.Data;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using Antra.IMovie.Core.Model;

namespace Antra.IMovie.Infrascruture.Repository
{
    public class MovieRepositoryAsync : BaseRepositoryAsync<Movie>, IMovieRepositoryAsync
    {
        IMovieCrmDBContext dBContext;
        public MovieRepositoryAsync(IMovieCrmDBContext _context) : base(_context)
        {
            this.dBContext = _context;
        }

        public async Task<List<Movie>> Get30HighestRatedMoviesAsync()
        {
            var topRatedMovies = await dBContext.Review.Include(r => r.Movie).GroupBy(r => new { r.MovieId, r.Movie.PosterUrl, r.Movie.Title })
                .OrderByDescending(m => m.Average(r => r.Rating)).Select(m => new Movie
                {
                    Id = m.Key.MovieId,
                    PosterUrl = m.Key.PosterUrl,
                    Title = m.Key.Title,
            
                }).Take(30).ToListAsync();

            return topRatedMovies;
        }

        public async Task<PagedResult<Movie>> GetMoviesByTitleAsync(int pageSize = 30, int page = 1)
        {
            var movies = await dBContext.Movie.Select(m => m).Skip((page - 1) * pageSize).Take(pageSize).ToListAsync();

            var totalMoviesCount = await dBContext.Movie.Select(m => m).CountAsync();

            var pagedMovies = new PagedResult<Movie>(movies, page, pageSize, totalMoviesCount);

            return pagedMovies;
        }
    }
}
