using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Antra.IMovie.Core.Model
{
    public class FavoriteResponseModel
    {

        public int UserId { get; set; }
        public List<MovieResponseModel> FavoriteMovies { get; set; }
       // public class FavoriteMovieResponseModel : MovieResponseModel
       // { }
    }
}
