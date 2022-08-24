using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Antra.IMovie.Core.Entity
{
    public class Trailer
    {
        public int Id { get; set; }

        [MaxLength(100)]
        [Column(TypeName = "Varchar")]
        public string? Name { get; set; }

        [MaxLength(1024)]
        [Column(TypeName = "Varchar")]
        public string? TrailerUrl { get; set; }
        public int MovieId { get; set; }


        public Movie Movie { get; set; }
    }
}
