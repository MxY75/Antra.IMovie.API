using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Antra.IMovie.Core.Contracts.Repository;
using Antra.IMovie.Core.Entity;
using Antra.IMovie.Infrascruture.Data;
using Microsoft.EntityFrameworkCore;


namespace Antra.IMovie.Infrascruture.Repository
{
    public class GenreRepository : BaseRepositoryAsync<Genre>, IGenreRepository
    {
        public GenreRepository(IMovieCrmDBContext _context) : base(_context)
        {
        }
    }
}
