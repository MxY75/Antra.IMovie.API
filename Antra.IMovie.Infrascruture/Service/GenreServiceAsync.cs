using Antra.IMovie.Core.Contracts.Service;
using Antra.IMovie.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Antra.IMovie.Core.Contracts.Repository;
using Antra.IMovie.Core.Contracts.Service;
using Antra.IMovie.Core.Entity;
using Antra.IMovie.Core.Model;

namespace Antra.IMovie.Infrascruture.Service
{
    public class GenreServiceAsync : IGenreServiceAsync

    {
        private readonly IGenreRepository _genreRepository;
        private readonly IMovieGenreRepositoryAsync movieGenreRepositoryAsync;

        public GenreServiceAsync(IGenreRepository genreRepository, IMovieGenreRepositoryAsync movieGenreRepositoryAsync)
        {
            this._genreRepository = genreRepository;
            this.movieGenreRepositoryAsync = movieGenreRepositoryAsync;
        }

        public async Task<IEnumerable<GenreModel>> GetAllGenres()
        {
           var result = await _genreRepository.GelAllAsync();
            List<GenreModel> genreModels = new List<GenreModel>();
            if (result != null) {
                foreach (var item in result) {
                    GenreModel model = new GenreModel();
                    model.Id = item.Id;
                    model.Name = item.Name;
                    genreModels.Add(model);
                }
                return genreModels;
            }
            return null;
        }

        public async Task<GenreModel> GetGenresByIdAsync(int id)
        {
           var result =await _genreRepository.GetByIdAsync(id);

            if (result != null) {
                GenreModel genre = new GenreModel();
                genre.Id = result.Id;
                genre.Name = result.Name;
                return genre;
            }

            return null;

        }

        public async Task<int> InsertGenre(GenreModel genreModel)
        {
            Genre genre = new Genre();
            genre.Id = genreModel.Id;
            genre.Name = genreModel.Name;
            return await _genreRepository.InsertAsync (genre);
        } 


    }
}
