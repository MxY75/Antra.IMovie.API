using Antra.IMovie.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Antra.IMovie.Core.Contracts.Repository
{
    public interface ITrailerRepository : IRepositoryAsync<Trailer>
    {
        Task<IEnumerable<Trailer>> GetAllTrailersByMovieId(int mid);

    }
}
