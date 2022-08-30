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
    public class ReviewRepositoryAsync : BaseRepositoryAsync<Review>, IReviewRepository
    {
        IMovieCrmDBContext movieContext;
        public ReviewRepositoryAsync(IMovieCrmDBContext _context) : base(_context)
        {
            movieContext = _context;
        }

        public async Task<IEnumerable<Review>> GetAllReviewsByMid(int mid)
        {
            return await movieContext.Review.Where(r => r.MovieId== mid).OrderByDescending(r=>r.Id).ToArrayAsync();
        }

        public async Task<IEnumerable<Review>> GetAllReviewsByUserId(int uid)
        {
            return await movieContext.Review.Where(r => r.UserId == uid).OrderByDescending(r => r.Id).ToArrayAsync();
        }

            public async Task<Review> GetReviewbyMidUid(int mid, int uid)
        {
            return await movieContext.Review.Where(r => r.MovieId == mid && r.UserId == uid).FirstOrDefaultAsync();
        }
    }
}
