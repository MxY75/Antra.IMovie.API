using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Antra.IMovie.Core.Contracts.Repository;
using Antra.IMovie.Core.Entity;
using Antra.IMovie.Infrascruture.Data;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Antra.IMovie.Infrascruture.Repository
{
    public class MovieRepositoryAsync : BaseRepositoryAsync<Movie>, IMovieRepositoryAsync
    {
        public MovieRepositoryAsync(IMovieCrmDBContext _context) : base(_context)
        {
        }
    }
}
