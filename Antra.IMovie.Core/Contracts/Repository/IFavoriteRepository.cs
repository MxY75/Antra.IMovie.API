using Antra.IMovie.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Antra.IMovie.Core.Contracts.Repository
{
    public interface IFavoriteRepository : IRepositoryAsync<Favorite>
    {
        Task<IEnumerable<Favorite>> GetAllFavoritesByUserId(int id);

        Task<Favorite> GetFavoritebyMidUid(int mid, int uid);
    }
}
