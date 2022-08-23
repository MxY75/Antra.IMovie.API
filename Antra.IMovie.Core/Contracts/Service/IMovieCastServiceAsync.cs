using Antra.IMovie.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Antra.IMovie.Core.Contracts.Service
{
    public interface IMovieCastServiceAsync
    {

        Task<IEnumerable<MovieCastModel>> GetAllByMovieId(int id);
        Task<IEnumerable<MovieCastModel>> GetAllByCastId(int id);
    }
}
