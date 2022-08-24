using Antra.IMovie.Core.Contracts.Repository;
using Antra.IMovie.Core.Contracts.Service;
using Antra.IMovie.Core.Entity;
using Antra.IMovie.Core.Model;
using Antra.IMovie.Infrascruture.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Antra.IMovie.Infrascruture.Service
{
    public class TrailerService : ITrailerService
    {
        ITrailerRepository trailerRepository;
        public TrailerService(ITrailerRepository trailerRepository)
        {
            this.trailerRepository = trailerRepository;
        }

        public async Task<IEnumerable<TrailerModel>> GetAllTrailersByMid(int mid) {
            List<TrailerModel> trailerModels = new List<TrailerModel>();
            var result = await trailerRepository.GetAllReviewsByMovieId(mid);
            if (result != null) {
                foreach (Trailer item in result) {
                    TrailerModel model = new TrailerModel();
                    model.TrailerUrl = item.TrailerUrl;
                    model.MovieId = item.MovieId;
                    model.Name = item.Name;
                    trailerModels.Add(model);
                }
                return trailerModels;
            }

            return null;
        }
    }
}
