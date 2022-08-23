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
    public class FavoriteRepository : BaseRepositoryAsync<Favorite>, IFavoriteRepository
    {
        IMovieCrmDBContext movieContext;
        public FavoriteRepository(IMovieCrmDBContext _context) : base(_context)
        {
            this.movieContext = _context;
        }

        public async Task<Favorite> GetFavoritebyMidUid(int mid, int uid) {
            return await movieContext.Favorites.Where(f => f.MovieId == mid && f.UserId == uid).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Favorite>> GetAllFavoritesByUserId(int id)
        {
            return await movieContext.Favorites.Where(f => f.UserId == id).ToArrayAsync();
        }
    }
}
