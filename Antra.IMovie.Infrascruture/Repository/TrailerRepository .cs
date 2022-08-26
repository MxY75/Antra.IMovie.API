using Antra.IMovie.Core.Contracts.Repository;
using Antra.IMovie.Core.Entity;
using Antra.IMovie.Infrascruture.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Antra.IMovie.Infrascruture.Repository
{
    public class TrailerRepository : BaseRepositoryAsync<Trailer>, ITrailerRepository
    {
        IMovieCrmDBContext movieContext;
        public TrailerRepository(IMovieCrmDBContext _context) : base(_context)
        {
            movieContext = _context;
        }

        public async Task<IEnumerable<Trailer>> GetAllTrailersByMovieId(int mid)
        {
            return await movieContext.Trailer.Where(T=> T.MovieId == mid).ToArrayAsync();
        }
    }
}
