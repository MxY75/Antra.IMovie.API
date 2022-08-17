using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Antra.IMovie.Core.Contracts.Repository
{
    public interface IRepositoryAsync<T> where T :class
    {
        Task<int> Delete(int id);
  
        Task<T> GetByIdAsync(int id);
        Task<int> InsertAsync(T entity);
        Task<IEnumerable<T>> GetAllAsync(); 
    }
}
