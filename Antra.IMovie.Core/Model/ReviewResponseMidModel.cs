using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Antra.IMovie.Core.Model
{
    public class ReviewResponseMidModel
    {
        public int MovieId { get; set; }

        public List<ReviewListMidModel> reviewList = new List<ReviewListMidModel>();

    }

    public class ReviewListMidModel
    {
        public int UserId { get; set; }
        public string ReviewText { get; set; }
        public decimal Rating { get; set; }
        public int Id { get; set; }
    }
}
