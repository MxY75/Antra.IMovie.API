using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Antra.IMovie.Core.Model
{
    public class MovieReportModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string PosterUrl { get; set; }
        public virtual IEnumerable<PurchaseModel> PurchaseMovie { get; set; }
    }
}
