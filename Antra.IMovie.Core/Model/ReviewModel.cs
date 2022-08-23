using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Antra.IMovie.Core.Model
{
    public class ReviewModel
    {
        public int Id { get; set; }
        public int MovieId { get; set; }
        public int UserId { get; set; }
        public decimal Rating { get; set; }

        [MaxLength(2048)]
        [Column(TypeName = "Varchar")]
        public string? ReviewText { get; set; }
        public MovieModel Movie { get; set; }
        public UserModel User { get; set; }
    }
}