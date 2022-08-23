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
    public class PurchaseRepository : BaseRepositoryAsync<Purchase>, IPurchaseRepostiry
    {
        IMovieCrmDBContext movieContext;
        public PurchaseRepository(IMovieCrmDBContext _context) : base(_context)
        {
            movieContext = _context;
        }

        public async Task<IEnumerable<Purchase>> GetAllByMovieIdAsync(int movieId)
        {
            return await movieContext.Purchase.Include("Movie").Where(x => x.MovieId == movieId).ToArrayAsync();
        }

        public async Task<Purchase> GetPurchasebyUserIdMovieId(int uid, int mid)
        {
            return await movieContext.Purchase.Include("Movie").Where(x => x.UserId == uid && x.MovieId == mid).FirstAsync();
        }
    }
}
