 using Antra.IMovie.Core.Contracts.Repository;
using Antra.IMovie.Core.Contracts.Service;
using Antra.IMovie.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Antra.IMovie.Infrascruture.Service
{
    public class MovieCastServiceAsync : IMovieCastServiceAsync
    {

        IMovieCastRepositoryAsync mctRepositoryAsync;
        public MovieCastServiceAsync(IMovieCastRepositoryAsync _mctRepositoryAsync)
        {
            this.mctRepositoryAsync = _mctRepositoryAsync;
        }

        public async Task<IEnumerable<MovieCastModel>> GetAllByCastId(int cid)
        {
            var result = await mctRepositoryAsync.GetAllByCastIdAsync(cid);
            List<MovieCastModel> mcList = new List<MovieCastModel>();

            foreach (var mc in result)
            {
                MovieCastModel model = new MovieCastModel();
                model.MovieId = mc.MovieId;
                model.CastId = mc.CastId;
                model.Character = mc.Character;
                model.Movie = new MovieResponseModel()
                {
                    Id = mc.MovieId,
                    Title = mc.Movie.Title,
                    Overview = mc.Movie.Overview,
                    Tagline = mc.Movie.Tagline,
                    PosterUrl = mc.Movie.PosterUrl,
                    ReleaseDate = mc.Movie.ReleaseDate
                };
                mcList.Add(model);
            }

            return mcList;
        }

        public async Task<IEnumerable<MovieCastModel>> GetAllByMovieId(int id)
        {
            var result = await mctRepositoryAsync.GetAllByMovieIdAsync(id);
            List<MovieCastModel> mcLst = new List<MovieCastModel>();

            foreach (var mc in result)
            {
                MovieCastModel model = new MovieCastModel();
                model.CastId = mc.CastId;
                model.MovieId = mc.MovieId;
                model.Character = mc.Character;
                model.Cast = new CastModel()
                {
                    Id = mc.Cast.Id,
                    Gender = mc.Cast.Gender,
                    Name = mc.Cast.Name,
                    ProfilePath = mc.Cast.ProfilePath,
                    TmdbUrl = mc.Cast.TmdbUrl
                };
                mcLst.Add(model);
            }
            return mcLst;

        }


    }
}
