using Antra.IMovie.Core.Contracts.Repository;
using Antra.IMovie.Core.Contracts.Service;
using Antra.IMovie.Core.Entity;
using Antra.IMovie.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Antra.IMovie.Infrascruture.Service
{
    public class MovieServiceAsync : IMovieServiceAsync
    {
        private readonly IMovieRepositoryAsync movieRepositoryAsync;
        private readonly IMovieGenreRepositoryAsync movieGenreRepositoryAsyn;
        private readonly IMovieCastRepositoryAsync movieCastRepositoryAsync; 

        public MovieServiceAsync(IMovieRepositoryAsync _movieRepositoryAsync, IMovieGenreRepositoryAsync movieGenreRepositoryAsyn, IMovieCastRepositoryAsync movieCastRepositoryAsync)
        {
            movieRepositoryAsync = _movieRepositoryAsync;
            this.movieGenreRepositoryAsyn = movieGenreRepositoryAsyn;
            this.movieCastRepositoryAsync = movieCastRepositoryAsync;   
        }

        public async Task<IEnumerable<MovieResponseModel>> GetAllMovies()
        {

            var result = await movieRepositoryAsync.GelAllAsync();
            List<MovieResponseModel> models = new List<MovieResponseModel>();
            if (result != null)
            {
                foreach (Movie movie in result)
                {
                    MovieResponseModel model = new MovieResponseModel();
                    model.Id = movie.Id;
                    model.Overview = movie.Overview;
                    model.PosterUrl = movie.PosterUrl;
                    model.Title = movie.Title;
                    model.Tagline = movie.Tagline;
                    model.PosterUrl = movie.PosterUrl;
                    model.ReleaseDate = movie.ReleaseDate;
                    models.Add(model);
                }
                return models;
            }
            return null;
        }
        public async Task<MovieModel> GetByIdAsync(int id)
        {
            MovieModel model = new MovieModel();
            var movie = await movieRepositoryAsync.GetByIdAsync(id);
            if (movie != null)
            {
                model.Id = movie.Id;
                model.Overview = movie.Overview;
                model.PosterUrl = movie.PosterUrl;
                model.Title = movie.Title;
                model.Tagline = movie.Tagline;
                model.Budget = movie.Budget;
                model.Revenue = movie.Revenue;
                model.PosterUrl = movie.PosterUrl;
                model.BackdropUrl = movie.BackdropUrl;
                model.ImdbUrl = movie.ImdbUrl;
                model.TmdbUrl = movie.TmdbUrl;
                model.Runtime = movie.Runtime;
                model.ReleaseDate = movie.ReleaseDate;
            }
            return model;
        }

        public async Task<MovieModel> GetMovieDetailsAsync(int mid)
        {
            MovieModel model = new MovieModel();
            var movie = await movieRepositoryAsync.GetByIdAsync(mid);
            if (movie != null)
            {
                model.Id = movie.Id;
                model.Overview = movie.Overview;
                model.PosterUrl = movie.PosterUrl;
                model.Title = movie.Title;
                model.Tagline = movie.Tagline;
                model.Budget = movie.Budget;
                model.Revenue = movie.Revenue;
                model.PosterUrl = movie.PosterUrl;
                model.BackdropUrl = movie.BackdropUrl;
                model.ImdbUrl = movie.ImdbUrl;
                model.TmdbUrl = movie.TmdbUrl;
                model.Runtime = movie.Runtime;
                model.ReleaseDate = movie.ReleaseDate;
            }
            model.Casts = new List<CastModel>();
            var movieCast = await movieCastRepositoryAsync.GetAllByMovieIdAsync(mid);

            foreach (var mc in movieCast)
            {
              
               CastModel cast = new CastModel()
                {
                    Id = mc.Cast.Id,
                    Gender = mc.Cast.Gender,
                    Name = mc.Cast.Name,
                    ProfilePath = mc.Cast.ProfilePath,
                    TmdbUrl = mc.Cast.TmdbUrl
                };
                model.Casts.Add(cast);
            }
            model.Genres = new List<GenreModel>();
            var movieGenre = await movieGenreRepositoryAsyn.GetAllByMovieIdAsync(mid);
            foreach (var item in movieGenre)
            {

                GenreModel genreModel = new GenreModel
                {

                    Id = item.Genre.Id,
                    Name = item.Genre.Name
                };
                model.Genres.Add(genreModel);
            }
                return model;
        }

        public async Task<MovieResponseModel> GetMovieResponseModel(int id)
        {

            MovieResponseModel model = new MovieResponseModel();
            var movie = await movieRepositoryAsync.GetByIdAsync(id);
            if (movie != null)
            {
                model.Id = movie.Id;
                model.Overview = movie.Overview;
                model.Title = movie.Title;
                model.Tagline = movie.Tagline;
                model.PosterUrl = movie.PosterUrl;
                model.ReleaseDate = movie.ReleaseDate;
            }
            return model;

        }

        public async Task<PagedResult<MovieResponseModel>> GetMoviesByPaginationAsync(int pageSize, int page)
        {

            var pagedMovies = await movieRepositoryAsync.GetMoviesByTitleAsync(pageSize, page);

            var pagedMovie = new List<MovieResponseModel>();

            pagedMovie.AddRange(pagedMovies.Data.Select(m => new MovieResponseModel
            {
                Id = m.Id,
                Title = m.Title,
                PosterUrl = m.PosterUrl,
                Overview = m.Overview,
                Tagline = m.Tagline,
                ReleaseDate = m.ReleaseDate
            }));

            return new PagedResult<MovieResponseModel>(pagedMovie, page, pageSize, pagedMovies.Count);

        }

        public async Task<List<MovieResponseModel>> GetTop30GRatedMoviesAsync()
        {
            var topRatedMovies = await movieRepositoryAsync.Get30HighestRatedMoviesAsync();

            var movieCards = new List<MovieResponseModel>();
            foreach (var movie in topRatedMovies)
            {
                movieCards.Add(new MovieResponseModel
                {
                    Id = movie.Id,
                    Title = movie.Title,
                    PosterUrl = movie.PosterUrl
                });
            }

            return movieCards;

        }

        public Task<List<MovieResponseModel>> MoviesSameGenreAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}

