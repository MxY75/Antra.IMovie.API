using Antra.IMovie.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Antra.IMovie.Core.Contracts.Repository
{
    public interface IPurchaseRepostiry :IRepositoryAsync<Purchase>
    {

        Task<IEnumerable<Purchase>> GetAllByMovieIdAsync(int movieId);
        Task<Purchase> GetPurchasebyUserIdMovieId(int uid, int mid);
    }
}
