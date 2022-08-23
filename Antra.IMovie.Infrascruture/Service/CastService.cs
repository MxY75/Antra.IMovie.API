
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
    public class CastService : ICastService
    {

        private readonly ICastRepositorycs castRepository;

        public CastService(ICastRepositorycs _castRepository)
        {
            this.castRepository = _castRepository;
        }


        public async Task<IEnumerable<CastModel>> GetAllCasts()
        {
            var result = await castRepository.GelAllAsync();

            List<CastModel> casts = new List<CastModel>();
            if (result != null)
            {
                foreach (var item in result)
                {
                    CastModel c = new CastModel();
                    c.Id = item.Id;
                    c.Name = item.Name;
                    c.Gender = item.Gender;
                    c.TmdbUrl = item.TmdbUrl;
                    c.ProfilePath = item.ProfilePath;
                    casts.Add(c);
                }
            }
            return casts;
        }

        public async Task<CastModel> GetCastByIdAsync(int id)
        {
            Cast entity = await castRepository.GetByIdAsync(id);
            if (entity != null)
            {
                CastModel cast = new CastModel()
                {
                    Id = entity.Id,
                    Gender = entity.Gender,
                    Name = entity.Name,
                    TmdbUrl = entity.TmdbUrl,
                    ProfilePath = entity.ProfilePath
                };
                return cast;
            }
            return null;

        }

        public Task<int> InsertCast(CastModel castModel)
        {
            Cast castEntity = new Cast();

            castEntity.Name = castModel.Name;
            castEntity.TmdbUrl = castModel.TmdbUrl;
            castEntity.Gender = castModel.Gender;
            castEntity.ProfilePath = castModel.ProfilePath;
            return castRepository.InsertAsync(castEntity);
        }

    }
}
