using Antra.IMovie.Core.Contracts.Repository;
using Antra.IMovie.Core.Contracts.Service;
using Antra.IMovie.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Antra.IMovie.Infrascruture.Service
{
    public class FavoriteService : IFavoriteService
    {
        private readonly IFavoriteRepository FavoriteRepository;

        public FavoriteService(IFavoriteRepository favoriteRepository)
        {
            FavoriteRepository = favoriteRepository;
        }

      
    }
}
