using Antra.IMovie.Core.Contracts.Repository;
using Antra.IMovie.Core.Contracts.Service;
using Antra.IMovie.Core.Entity;
using Antra.IMovie.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Antra.IMovie.Infrascruture.Service
{
    public class PurchaseService : IPurchaseService
    {
        IPurchaseRepostiry purchaseRepostiry;
        public PurchaseService(IPurchaseRepostiry purchaseRepostiry)
        {
            this.purchaseRepostiry = purchaseRepostiry;
        }

        public async Task<IEnumerable<PurchaseModel>> GetAllByMovieIdAsync(int movieId)
        {
            List<PurchaseModel> purchaseModels = new List<PurchaseModel>();
            var Purchases = await purchaseRepostiry.GetAllByMovieIdAsync(movieId);
            if (Purchases != null) {
                foreach (var p in Purchases) {
                    PurchaseModel pmodel = new PurchaseModel();
                    pmodel.Id = p.Id;
                    pmodel.PurchaseNumber = p.PurchaseNumber;
                    pmodel.MovieId = p.MovieId;
                    pmodel.UserId = p.UserId;
                    pmodel.PurchaseDateTime = p.PurchaseDateTime;
                    pmodel.TotalPrice = p.TotalPrice;
                    purchaseModels.Add(pmodel);
                }

                return purchaseModels;
            }
            return null;
        }

        public Task<int> InsertPurchase(PurchaseModel model) {
            Purchase entity = new Purchase();
            var guid = Guid.NewGuid();
            entity.MovieId = model.MovieId;
            entity.UserId = model.UserId;
            entity.PurchaseNumber = guid;
            entity.TotalPrice = model.TotalPrice;
            entity.PurchaseDateTime = model.PurchaseDateTime;
            return purchaseRepostiry.InsertAsync(entity);
        }
    }
}
