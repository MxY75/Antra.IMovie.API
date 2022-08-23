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
    public class UserRepository : BaseRepositoryAsync<User>, IUserRepository
    {
        IMovieCrmDBContext movieContext;
        public UserRepository(IMovieCrmDBContext _context) : base(_context)
        {
            movieContext = _context;
        }


      public async Task<IEnumerable<Purchase>> GetPurchasesByUserid(int id) {
            var result = await movieContext.Purchase.Where(p => p.UserId == id).ToListAsync();
            return result;
        }

        public async Task<IEnumerable<Purchase>> GetPurchasesByUseridMovieId(int uid, int mid) {
      
            return await movieContext.Purchase.Include("Movie").Where(x => x.MovieId == mid && x.UserId == uid).ToArrayAsync();
        }
    }
}
