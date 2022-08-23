using Antra.IMovie.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Antra.IMovie.Core.Contracts.Repository
{
   

         public interface IReviewRepository : IRepositoryAsync<Review>
    {

        Task<Review> GetReviewbyMidUid(int mid, int uid);
        Task<IEnumerable<Review>> GetAllReviewsByUserId(int uid);
    }
}
