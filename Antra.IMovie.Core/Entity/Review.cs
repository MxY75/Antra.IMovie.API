using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Antra.IMovie.Core.Entity
{
    public class Review
    {
        public int Id { get; set; }
        public int MovieId { get; set; }
        public int UserId { get; set; }
        public decimal Rating { get; set; }

        [MaxLength(2048) ]
        [Column(TypeName = "Varchar")]
        public string? ReviewText { get; set; }
        public Movie Movie { get; set; }
        public User User { get; set; }
    }
}