using Antra.IMovie.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Antra.IMovie.Core.Contracts.Service
{
   public interface IGenreServiceAsync
    {

        Task<int> InsertGenre(GenreModel genreModel);
        Task<IEnumerable<GenreModel>> GetAllGenres();
        Task<GenreModel> GetGenresByIdAsync(int id);

    }
}
