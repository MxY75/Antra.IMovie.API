using Antra.IMovie.Core.Contracts.Repository;
using Antra.IMovie.Core.Entity;
using Antra.IMovie.Infrascruture.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Antra.IMovie.Infrascruture.Repository
{
    public class CastRepository : BaseRepositoryAsync<Cast>, ICastRepositorycs
    {
        public CastRepository(IMovieCrmDBContext _context) : base(_context)
        {
        }
    }
}
