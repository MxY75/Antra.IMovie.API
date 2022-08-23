using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Antra.IMovie.Core.Model
{
    public class ReviewResponseModel
    {
        public int UserId { get; set; }

        public List<ReviewListModel> reviewList = new List<ReviewListModel>();

    }

    public class ReviewListModel
    {
        public int MovieId { get; set; }
        public string ReviewText { get; set; }
        public decimal Rating { get; set; }
    }
}
