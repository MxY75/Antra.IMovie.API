using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Antra.IMovie.Core.Contracts.Repository;
using Antra.IMovie.Core.Entity;
using Antra.IMovie.Core.Model;
using Antra.IMovie.Infrascruture.Data;
using Microsoft.EntityFrameworkCore;

namespace Antra.IMovie.Infrascruture.Repository
{
    public class MovieGenreRepositoryAsyn : BaseRepositoryAsync<MovieGenre>, IMovieGenreRepositoryAsync
    {
        IMovieCrmDBContext movieContext;
        public MovieGenreRepositoryAsyn(IMovieCrmDBContext _context) : base(_context)
        {
            movieContext = _context;
        }

        public async Task<IEnumerable<MovieGenre>> GetAllByGenreIdAsync(int genreId)
        {
            //select * from MovieCast join Movie on MovieGenre.genreid = 3
            return await movieContext.MovieGenre.Include("Movie").Where(x => x.GenreId == genreId).ToArrayAsync();
        }

        public async Task<IEnumerable<MovieGenre>> GetAllByMovieIdAsync(int movieId)
        {
            return await movieContext.MovieGenre.Include("Genre").Where(x => x.MovieId == movieId).ToArrayAsync();
        }

        public async Task<PagedResult<Movie>> MoviesByGenre(int id = 0, int pageSize = 30, int pageIndex = 1)
        {
            var movies = await movieContext.MovieGenre.Include("Movie").Where(x => x.GenreId == id).Select(m => new Movie
            {
                Id = m.Movie.Id,
                PosterUrl = m.Movie.PosterUrl,
                Title = m.Movie.Title
            }).Skip((pageIndex - 1) * pageSize).Take(pageSize).ToListAsync();
            var totalMoviesCount = await movieContext.MovieGenre.Include("Movie").Where(x => x.GenreId == id).CountAsync();
            var pagedMovies = new PagedResult<Movie>(movies, pageIndex, pageSize, totalMoviesCount);

            return pagedMovies;
        }
    }
}
